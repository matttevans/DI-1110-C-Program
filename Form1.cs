using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DI_2108_Example_CSharp_Program
{
  public partial class Form1 : Form
  {
    private Dataq.Devices.DI1110.Device TargetDevice;
    private System.Threading.CancellationTokenSource cancelRead = null;
    private double sampleRate = 100;
    private int channelIndex = 0;
    private int channelCount = 0;



    public Form1()
    {
      InitializeComponent();
    }

    private async void Form1_Load(object sender, EventArgs e)
    {
      try
      {
        //Get a list of devices with model DI-1110
        IReadOnlyList<Dataq.Devices.IDevice> AllDevices = await Dataq.Misc.Discovery.ByModelAsync(typeof(Dataq.Devices.DI1110.Device));
        if (AllDevices.Count > 0)
        {
          tbOutput.AppendText("Found a DI-1110." + Environment.NewLine);
          // Cast first device from generic device to specific DI-1110 type
          TargetDevice = (AllDevices[0] as Dataq.Devices.DI1110.Device);
          //Connect to device
          await TargetDevice.ConnectAsync();
          //' Ensure it's stopped
          await TargetDevice.AcquisitionStopAsync();
          //Query device for some info
          await TargetDevice.QueryDeviceAsync();
          // Print queried info to GUI
          tbOutput.AppendText("Manufacturer: " + TargetDevice.Manufacturer + Environment.NewLine);
          tbOutput.AppendText("Model: " + TargetDevice.Model + Environment.NewLine);
          tbOutput.AppendText("Serial number: " + TargetDevice.Serial + Environment.NewLine);
          tbOutput.AppendText("Firmware revision: " + TargetDevice.FirmwareRevision.ToString() + Environment.NewLine);
          // Enable the Start button
          btnStart.Enabled = true;
        }
        else
        {
          tbOutput.AppendText("No DI-1110 found." + Environment.NewLine);
          // Disable the Start button
          btnStart.Enabled = false;
        }
      }
      catch (Exception myError)
      {
        string myErrorString = myError.Message;
      }
    }

    private async void btnStart_Click(object sender, EventArgs e)
    {
      try
      {
        if (cancelRead == null)
        //get here if we're starting a new acquisition process
        {
          btnStart.Enabled = false;
          channelIndex = 0;
          var progressHandler = new Progress<string>(value =>
          {
            tbOutput.AppendText(value);
          });
          var progress = progressHandler as IProgress<string>;

          TargetDevice.Channels.Clear(); //initialize the device
          ConfigureAnalogChannels();
          ConfigureDigitalChannels();
          if (SampleRateBad(sampleRate))
          {
            //get here if requested sample rate is out of range
            //It's a bust, so...
            btnStart.Enabled = true;
            return;
          }
          else
          {
            TargetDevice.SetSampleRateOnChannels(sampleRate);
          }
          //otherwise, the selected sample rate is good, so use it
          try
          {
            await TargetDevice.InitializeAsync(); //configure the device as defined. Errors if no channels are enabled
          }
          catch 
          {
            //Detect if no channels are enabled, and bail if so. 
            MessageBox.Show("Please enable at least one analog channel or digital port.", "No Enabled Channels", MessageBoxButtons.OK, MessageBoxIcon.Error);
            btnStart.Enabled = true;
            return;
          }
          //now determine what sample rate per channel the device is using from the 
          //first enabled input channel, and display it
          Dataq.Devices.DI1110.ChannelIn FirstInChannel;
          bool NoInputChannels = true;
          channelCount = 0;
          for (int index = 0; index < TargetDevice.Channels.Count; index++)
          {
            if (TargetDevice.Channels[index] is Dataq.Devices.IChannelIn)
            {
              FirstInChannel = (Dataq.Devices.DI1110.ChannelIn)TargetDevice.Channels[index];
              NoInputChannels = false;
              break;
            }
          }

          if (NoInputChannels)
          {
            MessageBox.Show("Please configure at least one analog channel or digital port as an input", "No Inputs Enabled", MessageBoxButtons.OK, MessageBoxIcon.Error);
            btnStart.Enabled = true;
            return;
          }

          for (int index = 0; index < TargetDevice.Channels.Count; index++)
          {
            if (TargetDevice.Channels[index] is Dataq.Devices.IChannelIn)
            {
              channelCount++;
            }
          }

          //Everything is good, so...
          btnStart.Text = "Stop"; //change button text to "Stop" from "Start";
          btnStart.Enabled = true;
          cancelRead = new System.Threading.CancellationTokenSource();
          await TargetDevice.AcquisitionStartAsync(); //start acquiring

          // NOTE: assumes at least one input channel enabled
          // Start a task in the background to read data
          await Task.Run(async () =>
          {
          //capture the first channel programmed as an input (MasterChannel)
          //and use it to track data availability for all input channels
           Dataq.Devices.IChannelIn MasterChannel = null;
            for (int index = 0;index < TargetDevice.Channels.Count;index++)
            {
              if (TargetDevice.Channels[index] is Dataq.Devices.IChannelIn)
              {
                MasterChannel = (Dataq.Devices.IChannelIn)TargetDevice.Channels[index];
                break;
              }
            }

            //Keep reading while acquiring data
            while (TargetDevice.IsAcquiring)
            {
              //Read data and catch if cancelled (to exit loop and continue)
              try
              {
                //throws an error if acquisition has been cancelled
                //otherwise refreshes the buffer DataIn with new data
                await TargetDevice.ReadDataAsync(cancelRead.Token);
              }
              catch
              {
                //get here if acquisition cancelled
                break;
              }

              //get here if acquisition is still active
              if (MasterChannel.DataIn.Count == 0)
              {
                //get here if no data in the channel buffer
                continue;
              }

              //We have data.Convert it to strings
              string temp = "";
              string temp1 = "";
              //NOTE: assuming all input channels contain exact same amount of data
              //Think of data for each input channel organized in columns, 
              //one column per channel (DataIn (index)). Rows represent scans.
              //Data is extracted by the following routine 
              for (int index = 0; index < MasterChannel.DataIn.Count; index++)  //this is the row (scan) counter
              {
                foreach (Dataq.Devices.IChannelIn ch in TargetDevice.Channels )  //this is the column (channel) counter
                {
                  //get a channel value and convert it to a string
                  //format the output string depending upon the type of input
                  if ((ch is Dataq.Devices.IAnalogVoltage) || (ch is Dataq.Devices.IFrequency))
                  {
                    temp1 = (ch as Dataq.Devices.IChannelIn).DataIn[index].ToString("0.0000");
                  }
                  else if (ch is Dataq.Devices.IChannelIn)
                  {
                    //must be either dig in or count so we need just a single integer
                    //temp1 = (ch as Dataq.Devices.IChannelIn).DataIn[index].ToString("0");
                    temp1 = ch.DataIn[index].ToString("0");
                  }

                  channelIndex = (channelIndex + 1) % channelCount;
                  //if data is from last channel insert carriage return line feed
                  if (channelIndex == 0)
                  {
                    temp1 = temp1 + "\r\n";
                  }
                  // if data if not from last channel insert a comma
                  else
                  {
                    temp1 = temp1 + ",";
                  }
                  temp = temp + temp1;  //append the channel value to the output

                }
              }

              //purge displayed data from the buffer
              foreach (Dataq.Devices.IChannelIn ch in TargetDevice.Channels)
              {
                if (ch is Dataq.Devices.IChannelIn)
                {
                  ch.DataIn.Clear();
                }
              }

              //Report the data to be printed to the GUI
              progress.Report(temp);
            }

          },cancelRead.Token);

        }
        else
        //get here if an acquisition process is in progress and we've been commanded to stop
        {
          btnStart.Enabled = false;
          cancelRead.Cancel();  //cancel the read process
          cancelRead = null;
          //          await taskRead(); //wait for the read process to complete
          await TargetDevice.AcquisitionStopAsync(); //stop the device from acquiring 
          // Change button text/state
          btnStart.Enabled = true;
          btnStart.Text = "Start";

        }

      }
      catch (Exception myError)
      {
        string myErrorString = myError.Message;
      }
    }

    private void ConfigureAnalogChannels()
    {
        Dataq.Devices.DI1110.AnalogVoltageIn AnalogChan;

        if(cbCH1.Checked) {
            //configure analog channel 1
            AnalogChan = (Dataq.Devices.DI1110.AnalogVoltageIn)TargetDevice.ChannelFactory(typeof(Dataq.Devices.DI1110.AnalogVoltageIn), 1);
        }
        if(cbCH2.Checked) {
            //configure analog channel 2
            AnalogChan = (Dataq.Devices.DI1110.AnalogVoltageIn)TargetDevice.ChannelFactory(typeof(Dataq.Devices.DI1110.AnalogVoltageIn), 2);
        }
        if(cbCH3.Checked) {
            //configure analog channel 3
            AnalogChan = (Dataq.Devices.DI1110.AnalogVoltageIn)TargetDevice.ChannelFactory(typeof(Dataq.Devices.DI1110.AnalogVoltageIn), 3);
        }
        if(cbCH4.Checked) {
            //configure analog channel 4
            AnalogChan = (Dataq.Devices.DI1110.AnalogVoltageIn)TargetDevice.ChannelFactory(typeof(Dataq.Devices.DI1110.AnalogVoltageIn), 4);
        }
        if(cbCH5.Checked) {
            //configure analog channel 5
            AnalogChan = (Dataq.Devices.DI1110.AnalogVoltageIn)TargetDevice.ChannelFactory(typeof(Dataq.Devices.DI1110.AnalogVoltageIn), 5);
        }
        if(cbCH6.Checked) {
            //configure analog channel 6
            AnalogChan = (Dataq.Devices.DI1110.AnalogVoltageIn)TargetDevice.ChannelFactory(typeof(Dataq.Devices.DI1110.AnalogVoltageIn), 6);
        }
        if(cbCH7.Checked) {
            //configure analog channel 7
            AnalogChan = (Dataq.Devices.DI1110.AnalogVoltageIn)TargetDevice.ChannelFactory(typeof(Dataq.Devices.DI1110.AnalogVoltageIn), 7);
        }
        if(cbCH8.Checked) {
            //configure analog channel 8
            AnalogChan = (Dataq.Devices.DI1110.AnalogVoltageIn)TargetDevice.ChannelFactory(typeof(Dataq.Devices.DI1110.AnalogVoltageIn), 8);
        }
    }

    private void ConfigureDigitalChannels()
    {

      Dataq.Devices.DI1110.DigitalIn DigitalInChan;
      Dataq.Devices.DI1110.DigitalOut DigitalOutChan;
      Dataq.Devices.DI1110.FrequencyIn RateInChan;
      Dataq.Devices.DI1110.CounterIn CountInChan;

      string Port0State = "disabled";
      string Port1State = "disabled";
      string Port2State = "disabled";
      string Port3State = "disabled";
      string Port4State = "disabled";
      string Port5State = "disabled";
      string Port6State = "disabled";
      string Port7State = "disabled";


      //configure digtial port 0
      switch (Port0State)
      {
        case "DigitalIn":
          //configure digtial port 0 as a digital input
          DigitalInChan = (Dataq.Devices.DI1110.DigitalIn)TargetDevice.ChannelFactory(typeof(Dataq.Devices.DI1110.DigitalIn), 0);
          break;
        case "DigitalOut":
          //configure digtial port 0 as a digital output
          DigitalOutChan = (Dataq.Devices.DI1110.DigitalOut)TargetDevice.ChannelFactory(typeof(Dataq.Devices.DI1110.DigitalOut), 0);
          break;
        default:
          break;
      }

      //configure digtial port 1
      switch (Port1State)
      {
        case "DigitalIn":
          //configure digtial port 1 as a digital input
          DigitalInChan = (Dataq.Devices.DI1110.DigitalIn)TargetDevice.ChannelFactory(typeof(Dataq.Devices.DI1110.DigitalIn), 1);
          break;
        case "DigitalOut":
          //configure digtial port 1 as a digital output
          DigitalOutChan = (Dataq.Devices.DI1110.DigitalOut)TargetDevice.ChannelFactory(typeof(Dataq.Devices.DI1110.DigitalOut), 1);
          break;
        default:
          break;
      }

      //configure digtial port 2
      switch (Port2State)
      {
        case "DigitalIn":
          //configure digtial port 2 as a digital input
          DigitalInChan = (Dataq.Devices.DI1110.DigitalIn)TargetDevice.ChannelFactory(typeof(Dataq.Devices.DI1110.DigitalIn), 2);
          break;
        case "DigitalOut":
          //configure digtial port 2 as a digital output
          DigitalOutChan = (Dataq.Devices.DI1110.DigitalOut)TargetDevice.ChannelFactory(typeof(Dataq.Devices.DI1110.DigitalOut), 2);
          break;
        case "Rate":
          //configure digtial port 2 as a frequency input
          RateInChan = (Dataq.Devices.DI1110.FrequencyIn)TargetDevice.ChannelFactory(typeof(Dataq.Devices.DI1110.FrequencyIn), 2);
          RateInChan.AveragingFactor = 1; //Set averaging factor = 1
          RateInChan.FrequencyRange.Maximum = 50000;  //Set frequency range to 50,000
          break;
        default:
          break;
      }

      //configure digtial port 3
      switch (Port3State)
      {
        case "DigitalIn":
          //configure digtial port 3 as a digital input
          DigitalInChan = (Dataq.Devices.DI1110.DigitalIn)TargetDevice.ChannelFactory(typeof(Dataq.Devices.DI1110.DigitalIn), 3);
          break;
        case "DigitalOut":
          //configure digtial port 3 as a digital output
          DigitalOutChan = (Dataq.Devices.DI1110.DigitalOut)TargetDevice.ChannelFactory(typeof(Dataq.Devices.DI1110.DigitalOut), 3);
          break;
        case "Count":
          //configure digtial port 3 as a counter input
          CountInChan = (Dataq.Devices.DI1110.CounterIn)TargetDevice.ChannelFactory(typeof(Dataq.Devices.DI1110.CounterIn), 3);
          break;
        default:
          break;
      }

      //configure digtial port 4
      switch (Port4State)
      {
        case "DigitalIn":
          //configure digtial port 4 as a digital input
          DigitalInChan = (Dataq.Devices.DI1110.DigitalIn)TargetDevice.ChannelFactory(typeof(Dataq.Devices.DI1110.DigitalIn), 4);
          break;
        case "DigitalOut":
          //configure digtial port 4 as a digital output
          DigitalOutChan = (Dataq.Devices.DI1110.DigitalOut)TargetDevice.ChannelFactory(typeof(Dataq.Devices.DI1110.DigitalOut), 4);
          break;
        default:
          break;
      }

      //configure digtial port 5
      switch (Port5State)
      {
        case "DigitalIn":
          //configure digtial port 5 as a digital input
          DigitalInChan = (Dataq.Devices.DI1110.DigitalIn)TargetDevice.ChannelFactory(typeof(Dataq.Devices.DI1110.DigitalIn), 5);
          break;
        case "DigitalOut":
          //configure digtial port 5 as a digital output
          DigitalOutChan = (Dataq.Devices.DI1110.DigitalOut)TargetDevice.ChannelFactory(typeof(Dataq.Devices.DI1110.DigitalOut), 5);
          break;
        default:
          break;
      }

      //configure digtial port 6
      switch (Port6State)
      {
        case "DigitalIn":
          //configure digtial port 6 as a digital input
          DigitalInChan = (Dataq.Devices.DI1110.DigitalIn)TargetDevice.ChannelFactory(typeof(Dataq.Devices.DI1110.DigitalIn), 6);
          break;
        case "DigitalOut":
          //configure digtial port 6 as a digital output
          DigitalOutChan = (Dataq.Devices.DI1110.DigitalOut)TargetDevice.ChannelFactory(typeof(Dataq.Devices.DI1110.DigitalOut), 6);
          break;
        default:
          break;
      }

      //configure digtial port 7
      switch (Port7State)
      {
        case "DigitalIn":
          //configure digtial port 7 as a digital input
          DigitalInChan = (Dataq.Devices.DI1110.DigitalIn)TargetDevice.ChannelFactory(typeof(Dataq.Devices.DI1110.DigitalIn), 7);
          break;
        case "DigitalOut":
          //configure digtial port 7 as a digital output
          DigitalOutChan = (Dataq.Devices.DI1110.DigitalOut)TargetDevice.ChannelFactory(typeof(Dataq.Devices.DI1110.DigitalOut), 7);
          break;
        default:
          break;
      }


    }

    private bool SampleRateBad(double sampleRate)
    {
      try
      {
        Dataq.Collections.IReadOnlyRange<double> SampleRateRange = (TargetDevice.Channels[0] as Dataq.Devices.Dynamic.IReadOnlyChannelSampleRate).GetSupportedSampleRateRange(TargetDevice);
        if (!SampleRateRange.ContainsValue(sampleRate))
        {
          MessageBox.Show("Selected sample rate is outside the range of " + SampleRateRange.Minimum.ToString() + " to " + SampleRateRange.Maximum.ToString() + " Hz inclusive for your current channel settings.",
                          "Sample Rate Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
          return true;
        }
        else
        {
          return false;
        }
      }
      catch
      {
        return false;
      }
    }

    private async void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
      if (TargetDevice != null)
      {
        if (TargetDevice.IsAcquiring)
        {
          await TargetDevice.AcquisitionStopAsync(); //stop the device from acquiring 
        }
        if (TargetDevice.IsConnected)
        {
          await TargetDevice.DisconnectAsync();
        }
        TargetDevice.Dispose();
      }
    }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {

            switch (cmbLED.SelectedItem.ToString()) {

                case "Black":
                    TargetDevice.Protocol.SetLedColorAsync(Dataq.Protocols.Enums.LedColor1.Black);
                    break;
                case "Blue":
                    TargetDevice.Protocol.SetLedColorAsync(Dataq.Protocols.Enums.LedColor1.Blue);
                    break;
                case "Green":
                    TargetDevice.Protocol.SetLedColorAsync(Dataq.Protocols.Enums.LedColor1.Green);
                    break;
                case "Cyan":
                    TargetDevice.Protocol.SetLedColorAsync(Dataq.Protocols.Enums.LedColor1.Cyan);
                    break;
                case "Red":
                    TargetDevice.Protocol.SetLedColorAsync(Dataq.Protocols.Enums.LedColor1.Red);
                    break;
                case "Magenta":
                    TargetDevice.Protocol.SetLedColorAsync(Dataq.Protocols.Enums.LedColor1.Magenta);
                    break;
                case "Yellow":
                    TargetDevice.Protocol.SetLedColorAsync(Dataq.Protocols.Enums.LedColor1.Yellow);
                    break;
                case "White":
                    TargetDevice.Protocol.SetLedColorAsync(Dataq.Protocols.Enums.LedColor1.White);
                    break;
                default:
                    TargetDevice.Protocol.SetLedColorAsync(Dataq.Protocols.Enums.LedColor1.Green);
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e) {

            /*
             * For Each chan In TargetDevice.Channels
                If TypeOf chan Is Dataq.Devices.DI1110.DigitalOut Then
                    Dim temp As Dataq.Devices.DI1110.DigitalOut =
                        CType(chan, Dataq.Devices.DI1110.DigitalOut)
                    ' Clear any previous data
                    temp.DataOut.Clear()
                    ' Add desired output value to channel
                    temp.DataOut.Add(DigOut(temp.Number))
                    OutputExists = True
                End If
            Next
             * 
             */

            // Define a flag to indicate if at least one output port is defined
            bool outputExists = false;

            // Store desired output states in array for easy access
            double [] digOut = new double[7];

            digOut[0] = Convert.ToDouble(cmbDigOut0.SelectedItem);
            digOut[1] = Convert.ToDouble(cmbDigOut1.SelectedItem);
            digOut[2] = Convert.ToDouble(cmbDigOut2.SelectedItem);
            digOut[3] = Convert.ToDouble(cmbDigOut3.SelectedItem);
            digOut[4] = Convert.ToDouble(cmbDigOut4.SelectedItem);
            digOut[5] = Convert.ToDouble(cmbDigOut5.SelectedItem);
            digOut[6] = Convert.ToDouble(cmbDigOut6.SelectedItem);

            foreach(Dataq.Devices.IChannel chan in TargetDevice.Channels) {

                if(chan.GetType().Equals(typeof(Dataq.Devices.DI1110.DigitalOut))) {

                    Dataq.Devices.DI1110.DigitalOut temp = 
                        (Dataq.Devices.DI1110.DigitalOut)TargetDevice.ChannelFactory(chan, Dataq.Devices.DI1110.DigitalOut);

                    temp.DataOut.Clear();

                    temp.DataOut.Add(digOut[temp.Number]);

                    outputExists = true;
                }
            }

        }
    }
}
