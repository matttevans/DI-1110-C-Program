namespace DI_2108_Example_CSharp_Program
{
  partial class Form1
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
			this.btnStart = new System.Windows.Forms.Button();
			this.tbOutput = new System.Windows.Forms.TextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.cmbLED = new System.Windows.Forms.ComboBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.cbCH8 = new System.Windows.Forms.CheckBox();
			this.cbCH7 = new System.Windows.Forms.CheckBox();
			this.cbCH6 = new System.Windows.Forms.CheckBox();
			this.cbCH5 = new System.Windows.Forms.CheckBox();
			this.cbCH4 = new System.Windows.Forms.CheckBox();
			this.cbCH3 = new System.Windows.Forms.CheckBox();
			this.cbCH2 = new System.Windows.Forms.CheckBox();
			this.cbCH1 = new System.Windows.Forms.CheckBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.cmbD0Mode = new System.Windows.Forms.ComboBox();
			this.cbD2 = new System.Windows.Forms.CheckBox();
			this.cbD6 = new System.Windows.Forms.CheckBox();
			this.cbD0 = new System.Windows.Forms.CheckBox();
			this.cbD5 = new System.Windows.Forms.CheckBox();
			this.cbD1 = new System.Windows.Forms.CheckBox();
			this.cbD4 = new System.Windows.Forms.CheckBox();
			this.cbD3 = new System.Windows.Forms.CheckBox();
			this.button1 = new System.Windows.Forms.Button();
			this.cmbD1Mode = new System.Windows.Forms.ComboBox();
			this.cmbD3Mode = new System.Windows.Forms.ComboBox();
			this.cmbD2Mode = new System.Windows.Forms.ComboBox();
			this.cmbD6Mode = new System.Windows.Forms.ComboBox();
			this.cmbD5Mode = new System.Windows.Forms.ComboBox();
			this.cmbD4Mode = new System.Windows.Forms.ComboBox();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.cmbDigOut0 = new System.Windows.Forms.ComboBox();
			this.cmbDigOut1 = new System.Windows.Forms.ComboBox();
			this.cmbDigOut3 = new System.Windows.Forms.ComboBox();
			this.cmbDigOut2 = new System.Windows.Forms.ComboBox();
			this.cmbDigOut5 = new System.Windows.Forms.ComboBox();
			this.cmbDigOut4 = new System.Windows.Forms.ComboBox();
			this.cmbDigOut6 = new System.Windows.Forms.ComboBox();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnStart
			// 
			this.btnStart.Enabled = false;
			this.btnStart.Location = new System.Drawing.Point(230, 589);
			this.btnStart.Name = "btnStart";
			this.btnStart.Size = new System.Drawing.Size(75, 23);
			this.btnStart.TabIndex = 0;
			this.btnStart.Text = "Start";
			this.btnStart.UseVisualStyleBackColor = true;
			this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
			// 
			// tbOutput
			// 
			this.tbOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbOutput.Location = new System.Drawing.Point(483, 12);
			this.tbOutput.Multiline = true;
			this.tbOutput.Name = "tbOutput";
			this.tbOutput.Size = new System.Drawing.Size(900, 711);
			this.tbOutput.TabIndex = 1;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.cmbLED);
			this.groupBox1.Location = new System.Drawing.Point(12, 274);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(149, 53);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "LED Color";
			// 
			// cmbLED
			// 
			this.cmbLED.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbLED.FormattingEnabled = true;
			this.cmbLED.Items.AddRange(new object[] {
            "Black",
            "Blue",
            "Green",
            "Cyan",
            "Red",
            "Magenta",
            "Yellow",
            "White"});
			this.cmbLED.Location = new System.Drawing.Point(6, 19);
			this.cmbLED.Name = "cmbLED";
			this.cmbLED.Size = new System.Drawing.Size(121, 21);
			this.cmbLED.TabIndex = 0;
			this.cmbLED.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.cbCH8);
			this.groupBox2.Controls.Add(this.cbCH7);
			this.groupBox2.Controls.Add(this.cbCH6);
			this.groupBox2.Controls.Add(this.cbCH5);
			this.groupBox2.Controls.Add(this.cbCH4);
			this.groupBox2.Controls.Add(this.cbCH3);
			this.groupBox2.Controls.Add(this.cbCH2);
			this.groupBox2.Controls.Add(this.cbCH1);
			this.groupBox2.Location = new System.Drawing.Point(12, 12);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(75, 256);
			this.groupBox2.TabIndex = 3;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Analog";
			// 
			// cbCH8
			// 
			this.cbCH8.AutoSize = true;
			this.cbCH8.Location = new System.Drawing.Point(6, 215);
			this.cbCH8.Name = "cbCH8";
			this.cbCH8.Size = new System.Drawing.Size(47, 17);
			this.cbCH8.TabIndex = 7;
			this.cbCH8.Text = "CH8";
			this.cbCH8.UseVisualStyleBackColor = true;
			// 
			// cbCH7
			// 
			this.cbCH7.AutoSize = true;
			this.cbCH7.Location = new System.Drawing.Point(6, 187);
			this.cbCH7.Name = "cbCH7";
			this.cbCH7.Size = new System.Drawing.Size(47, 17);
			this.cbCH7.TabIndex = 6;
			this.cbCH7.Text = "CH7";
			this.cbCH7.UseVisualStyleBackColor = true;
			// 
			// cbCH6
			// 
			this.cbCH6.AutoSize = true;
			this.cbCH6.Location = new System.Drawing.Point(6, 159);
			this.cbCH6.Name = "cbCH6";
			this.cbCH6.Size = new System.Drawing.Size(47, 17);
			this.cbCH6.TabIndex = 5;
			this.cbCH6.Text = "CH6";
			this.cbCH6.UseVisualStyleBackColor = true;
			// 
			// cbCH5
			// 
			this.cbCH5.AutoSize = true;
			this.cbCH5.Location = new System.Drawing.Point(6, 131);
			this.cbCH5.Name = "cbCH5";
			this.cbCH5.Size = new System.Drawing.Size(47, 17);
			this.cbCH5.TabIndex = 4;
			this.cbCH5.Text = "CH5";
			this.cbCH5.UseVisualStyleBackColor = true;
			// 
			// cbCH4
			// 
			this.cbCH4.AutoSize = true;
			this.cbCH4.Location = new System.Drawing.Point(6, 103);
			this.cbCH4.Name = "cbCH4";
			this.cbCH4.Size = new System.Drawing.Size(47, 17);
			this.cbCH4.TabIndex = 3;
			this.cbCH4.Text = "CH4";
			this.cbCH4.UseVisualStyleBackColor = true;
			// 
			// cbCH3
			// 
			this.cbCH3.AutoSize = true;
			this.cbCH3.Location = new System.Drawing.Point(6, 75);
			this.cbCH3.Name = "cbCH3";
			this.cbCH3.Size = new System.Drawing.Size(47, 17);
			this.cbCH3.TabIndex = 2;
			this.cbCH3.Text = "CH3";
			this.cbCH3.UseVisualStyleBackColor = true;
			// 
			// cbCH2
			// 
			this.cbCH2.AutoSize = true;
			this.cbCH2.Location = new System.Drawing.Point(6, 47);
			this.cbCH2.Name = "cbCH2";
			this.cbCH2.Size = new System.Drawing.Size(47, 17);
			this.cbCH2.TabIndex = 1;
			this.cbCH2.Text = "CH2";
			this.cbCH2.UseVisualStyleBackColor = true;
			// 
			// cbCH1
			// 
			this.cbCH1.AutoSize = true;
			this.cbCH1.Checked = true;
			this.cbCH1.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbCH1.Location = new System.Drawing.Point(6, 19);
			this.cbCH1.Name = "cbCH1";
			this.cbCH1.Size = new System.Drawing.Size(47, 17);
			this.cbCH1.TabIndex = 0;
			this.cbCH1.Text = "CH1";
			this.cbCH1.UseVisualStyleBackColor = true;
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.cmbD6Mode);
			this.groupBox3.Controls.Add(this.cmbD5Mode);
			this.groupBox3.Controls.Add(this.cmbD4Mode);
			this.groupBox3.Controls.Add(this.cmbD3Mode);
			this.groupBox3.Controls.Add(this.cmbD2Mode);
			this.groupBox3.Controls.Add(this.cmbD1Mode);
			this.groupBox3.Controls.Add(this.cmbD0Mode);
			this.groupBox3.Controls.Add(this.cbD2);
			this.groupBox3.Controls.Add(this.cbD6);
			this.groupBox3.Controls.Add(this.cbD0);
			this.groupBox3.Controls.Add(this.cbD5);
			this.groupBox3.Controls.Add(this.cbD1);
			this.groupBox3.Controls.Add(this.cbD4);
			this.groupBox3.Controls.Add(this.cbD3);
			this.groupBox3.Location = new System.Drawing.Point(93, 12);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(169, 227);
			this.groupBox3.TabIndex = 4;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Digital Port Setup";
			// 
			// cmbD0Mode
			// 
			this.cmbD0Mode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbD0Mode.FormattingEnabled = true;
			this.cmbD0Mode.Items.AddRange(new object[] {
            "Input",
            "Switch"});
			this.cmbD0Mode.Location = new System.Drawing.Point(52, 17);
			this.cmbD0Mode.Name = "cmbD0Mode";
			this.cmbD0Mode.Size = new System.Drawing.Size(108, 21);
			this.cmbD0Mode.TabIndex = 6;
			// 
			// cbD2
			// 
			this.cbD2.AutoSize = true;
			this.cbD2.Location = new System.Drawing.Point(6, 75);
			this.cbD2.Name = "cbD2";
			this.cbD2.Size = new System.Drawing.Size(40, 17);
			this.cbD2.TabIndex = 10;
			this.cbD2.Text = "D2";
			this.cbD2.UseVisualStyleBackColor = true;
			// 
			// cbD6
			// 
			this.cbD6.AutoSize = true;
			this.cbD6.Location = new System.Drawing.Point(6, 187);
			this.cbD6.Name = "cbD6";
			this.cbD6.Size = new System.Drawing.Size(40, 17);
			this.cbD6.TabIndex = 14;
			this.cbD6.Text = "D6";
			this.cbD6.UseVisualStyleBackColor = true;
			// 
			// cbD0
			// 
			this.cbD0.AutoSize = true;
			this.cbD0.Checked = true;
			this.cbD0.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbD0.Location = new System.Drawing.Point(6, 19);
			this.cbD0.Name = "cbD0";
			this.cbD0.Size = new System.Drawing.Size(40, 17);
			this.cbD0.TabIndex = 8;
			this.cbD0.Text = "D0";
			this.cbD0.UseVisualStyleBackColor = true;
			// 
			// cbD5
			// 
			this.cbD5.AutoSize = true;
			this.cbD5.Location = new System.Drawing.Point(6, 159);
			this.cbD5.Name = "cbD5";
			this.cbD5.Size = new System.Drawing.Size(40, 17);
			this.cbD5.TabIndex = 13;
			this.cbD5.Text = "D5";
			this.cbD5.UseVisualStyleBackColor = true;
			// 
			// cbD1
			// 
			this.cbD1.AutoSize = true;
			this.cbD1.Location = new System.Drawing.Point(6, 47);
			this.cbD1.Name = "cbD1";
			this.cbD1.Size = new System.Drawing.Size(40, 17);
			this.cbD1.TabIndex = 9;
			this.cbD1.Text = "D1";
			this.cbD1.UseVisualStyleBackColor = true;
			// 
			// cbD4
			// 
			this.cbD4.AutoSize = true;
			this.cbD4.Location = new System.Drawing.Point(6, 131);
			this.cbD4.Name = "cbD4";
			this.cbD4.Size = new System.Drawing.Size(40, 17);
			this.cbD4.TabIndex = 12;
			this.cbD4.Text = "D4";
			this.cbD4.UseVisualStyleBackColor = true;
			// 
			// cbD3
			// 
			this.cbD3.AutoSize = true;
			this.cbD3.Location = new System.Drawing.Point(6, 103);
			this.cbD3.Name = "cbD3";
			this.cbD3.Size = new System.Drawing.Size(40, 17);
			this.cbD3.TabIndex = 11;
			this.cbD3.Text = "D3";
			this.cbD3.UseVisualStyleBackColor = true;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(93, 245);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(169, 23);
			this.button1.TabIndex = 5;
			this.button1.Text = "Update Digital Outputs";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// cmbD1Mode
			// 
			this.cmbD1Mode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbD1Mode.FormattingEnabled = true;
			this.cmbD1Mode.Items.AddRange(new object[] {
            "Input",
            "Switch"});
			this.cmbD1Mode.Location = new System.Drawing.Point(52, 45);
			this.cmbD1Mode.Name = "cmbD1Mode";
			this.cmbD1Mode.Size = new System.Drawing.Size(108, 21);
			this.cmbD1Mode.TabIndex = 15;
			// 
			// cmbD3Mode
			// 
			this.cmbD3Mode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbD3Mode.FormattingEnabled = true;
			this.cmbD3Mode.Items.AddRange(new object[] {
            "Input",
            "Switch"});
			this.cmbD3Mode.Location = new System.Drawing.Point(52, 101);
			this.cmbD3Mode.Name = "cmbD3Mode";
			this.cmbD3Mode.Size = new System.Drawing.Size(108, 21);
			this.cmbD3Mode.TabIndex = 17;
			// 
			// cmbD2Mode
			// 
			this.cmbD2Mode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbD2Mode.FormattingEnabled = true;
			this.cmbD2Mode.Items.AddRange(new object[] {
            "Input",
            "Switch"});
			this.cmbD2Mode.Location = new System.Drawing.Point(52, 73);
			this.cmbD2Mode.Name = "cmbD2Mode";
			this.cmbD2Mode.Size = new System.Drawing.Size(108, 21);
			this.cmbD2Mode.TabIndex = 16;
			// 
			// cmbD6Mode
			// 
			this.cmbD6Mode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbD6Mode.FormattingEnabled = true;
			this.cmbD6Mode.Items.AddRange(new object[] {
            "Input",
            "Switch"});
			this.cmbD6Mode.Location = new System.Drawing.Point(52, 185);
			this.cmbD6Mode.Name = "cmbD6Mode";
			this.cmbD6Mode.Size = new System.Drawing.Size(108, 21);
			this.cmbD6Mode.TabIndex = 20;
			// 
			// cmbD5Mode
			// 
			this.cmbD5Mode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbD5Mode.FormattingEnabled = true;
			this.cmbD5Mode.Items.AddRange(new object[] {
            "Input",
            "Switch"});
			this.cmbD5Mode.Location = new System.Drawing.Point(52, 157);
			this.cmbD5Mode.Name = "cmbD5Mode";
			this.cmbD5Mode.Size = new System.Drawing.Size(108, 21);
			this.cmbD5Mode.TabIndex = 19;
			// 
			// cmbD4Mode
			// 
			this.cmbD4Mode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbD4Mode.FormattingEnabled = true;
			this.cmbD4Mode.Items.AddRange(new object[] {
            "Input",
            "Switch"});
			this.cmbD4Mode.Location = new System.Drawing.Point(52, 129);
			this.cmbD4Mode.Name = "cmbD4Mode";
			this.cmbD4Mode.Size = new System.Drawing.Size(108, 21);
			this.cmbD4Mode.TabIndex = 18;
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.cmbDigOut6);
			this.groupBox4.Controls.Add(this.cmbDigOut5);
			this.groupBox4.Controls.Add(this.cmbDigOut4);
			this.groupBox4.Controls.Add(this.cmbDigOut3);
			this.groupBox4.Controls.Add(this.cmbDigOut2);
			this.groupBox4.Controls.Add(this.cmbDigOut1);
			this.groupBox4.Controls.Add(this.cmbDigOut0);
			this.groupBox4.Location = new System.Drawing.Point(268, 12);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(70, 227);
			this.groupBox4.TabIndex = 6;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Output";
			// 
			// cmbDigOut0
			// 
			this.cmbDigOut0.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbDigOut0.FormattingEnabled = true;
			this.cmbDigOut0.Items.AddRange(new object[] {
            "1",
            "0"});
			this.cmbDigOut0.Location = new System.Drawing.Point(6, 17);
			this.cmbDigOut0.Name = "cmbDigOut0";
			this.cmbDigOut0.Size = new System.Drawing.Size(51, 21);
			this.cmbDigOut0.TabIndex = 0;
			// 
			// cmbDigOut1
			// 
			this.cmbDigOut1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbDigOut1.FormattingEnabled = true;
			this.cmbDigOut1.Items.AddRange(new object[] {
            "1",
            "0"});
			this.cmbDigOut1.Location = new System.Drawing.Point(6, 45);
			this.cmbDigOut1.Name = "cmbDigOut1";
			this.cmbDigOut1.Size = new System.Drawing.Size(51, 21);
			this.cmbDigOut1.TabIndex = 1;
			// 
			// cmbDigOut3
			// 
			this.cmbDigOut3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbDigOut3.FormattingEnabled = true;
			this.cmbDigOut3.Items.AddRange(new object[] {
            "1",
            "0"});
			this.cmbDigOut3.Location = new System.Drawing.Point(6, 101);
			this.cmbDigOut3.Name = "cmbDigOut3";
			this.cmbDigOut3.Size = new System.Drawing.Size(51, 21);
			this.cmbDigOut3.TabIndex = 3;
			// 
			// cmbDigOut2
			// 
			this.cmbDigOut2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbDigOut2.FormattingEnabled = true;
			this.cmbDigOut2.Items.AddRange(new object[] {
            "1",
            "0"});
			this.cmbDigOut2.Location = new System.Drawing.Point(6, 73);
			this.cmbDigOut2.Name = "cmbDigOut2";
			this.cmbDigOut2.Size = new System.Drawing.Size(51, 21);
			this.cmbDigOut2.TabIndex = 2;
			// 
			// cmbDigOut5
			// 
			this.cmbDigOut5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbDigOut5.FormattingEnabled = true;
			this.cmbDigOut5.Items.AddRange(new object[] {
            "1",
            "0"});
			this.cmbDigOut5.Location = new System.Drawing.Point(6, 156);
			this.cmbDigOut5.Name = "cmbDigOut5";
			this.cmbDigOut5.Size = new System.Drawing.Size(51, 21);
			this.cmbDigOut5.TabIndex = 5;
			// 
			// cmbDigOut4
			// 
			this.cmbDigOut4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbDigOut4.FormattingEnabled = true;
			this.cmbDigOut4.Items.AddRange(new object[] {
            "1",
            "0"});
			this.cmbDigOut4.Location = new System.Drawing.Point(6, 128);
			this.cmbDigOut4.Name = "cmbDigOut4";
			this.cmbDigOut4.Size = new System.Drawing.Size(51, 21);
			this.cmbDigOut4.TabIndex = 4;
			// 
			// cmbDigOut6
			// 
			this.cmbDigOut6.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbDigOut6.FormattingEnabled = true;
			this.cmbDigOut6.Items.AddRange(new object[] {
            "1",
            "0"});
			this.cmbDigOut6.Location = new System.Drawing.Point(6, 183);
			this.cmbDigOut6.Name = "cmbDigOut6";
			this.cmbDigOut6.Size = new System.Drawing.Size(51, 21);
			this.cmbDigOut6.TabIndex = 6;
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add(this.textBox1);
			this.groupBox5.Controls.Add(this.label2);
			this.groupBox5.Controls.Add(this.label1);
			this.groupBox5.Location = new System.Drawing.Point(12, 333);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(149, 70);
			this.groupBox5.TabIndex = 7;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "Rate Moving Average";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(18, 33);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(25, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "1 ≤ ";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(95, 33);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(31, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "≤  64";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(49, 30);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(34, 20);
			this.textBox1.TabIndex = 2;
			this.textBox1.Text = "1";
			this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1395, 735);
			this.Controls.Add(this.groupBox5);
			this.Controls.Add(this.groupBox4);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.tbOutput);
			this.Controls.Add(this.btnStart);
			this.Name = "Form1";
			this.Text = "DI-2108 CSharp Program";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
			this.Load += new System.EventHandler(this.Form1_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.groupBox4.ResumeLayout(false);
			this.groupBox5.ResumeLayout(false);
			this.groupBox5.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button btnStart;
    private System.Windows.Forms.TextBox tbOutput;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.ComboBox cmbLED;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.CheckBox cbCH8;
		private System.Windows.Forms.CheckBox cbCH7;
		private System.Windows.Forms.CheckBox cbCH6;
		private System.Windows.Forms.CheckBox cbCH5;
		private System.Windows.Forms.CheckBox cbCH4;
		private System.Windows.Forms.CheckBox cbCH3;
		private System.Windows.Forms.CheckBox cbCH2;
		private System.Windows.Forms.CheckBox cbCH1;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.CheckBox cbD2;
		private System.Windows.Forms.CheckBox cbD6;
		private System.Windows.Forms.CheckBox cbD0;
		private System.Windows.Forms.CheckBox cbD5;
		private System.Windows.Forms.CheckBox cbD1;
		private System.Windows.Forms.CheckBox cbD4;
		private System.Windows.Forms.CheckBox cbD3;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.ComboBox cmbD0Mode;
		private System.Windows.Forms.ComboBox cmbD6Mode;
		private System.Windows.Forms.ComboBox cmbD5Mode;
		private System.Windows.Forms.ComboBox cmbD4Mode;
		private System.Windows.Forms.ComboBox cmbD3Mode;
		private System.Windows.Forms.ComboBox cmbD2Mode;
		private System.Windows.Forms.ComboBox cmbD1Mode;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.ComboBox cmbDigOut0;
		private System.Windows.Forms.ComboBox cmbDigOut6;
		private System.Windows.Forms.ComboBox cmbDigOut5;
		private System.Windows.Forms.ComboBox cmbDigOut4;
		private System.Windows.Forms.ComboBox cmbDigOut3;
		private System.Windows.Forms.ComboBox cmbDigOut2;
		private System.Windows.Forms.ComboBox cmbDigOut1;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
	}
}

