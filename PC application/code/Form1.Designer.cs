namespace ir_pc_v1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.cmbCOM = new System.Windows.Forms.ComboBox();
            this.cmbBaudRate = new System.Windows.Forms.ComboBox();
            this.btnRozlacz = new System.Windows.Forms.Button();
            this.btnPolacz = new System.Windows.Forms.Button();
            this.btnOdswiez = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textInfo = new System.Windows.Forms.RichTextBox();
            this.btnZapisz = new System.Windows.Forms.Button();
            this.btnWczytaj = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.cmbBtn19 = new System.Windows.Forms.ComboBox();
            this.cmbBtn16 = new System.Windows.Forms.ComboBox();
            this.cmbBtn13 = new System.Windows.Forms.ComboBox();
            this.cmbBtn10 = new System.Windows.Forms.ComboBox();
            this.cmbBtn7 = new System.Windows.Forms.ComboBox();
            this.cmbBtn4 = new System.Windows.Forms.ComboBox();
            this.cmbBtn20 = new System.Windows.Forms.ComboBox();
            this.cmbBtn17 = new System.Windows.Forms.ComboBox();
            this.cmbBtn14 = new System.Windows.Forms.ComboBox();
            this.cmbBtn11 = new System.Windows.Forms.ComboBox();
            this.cmbBtn8 = new System.Windows.Forms.ComboBox();
            this.cmbBtn5 = new System.Windows.Forms.ComboBox();
            this.cmbBtn2 = new System.Windows.Forms.ComboBox();
            this.cmbBtn21 = new System.Windows.Forms.ComboBox();
            this.cmbBtn18 = new System.Windows.Forms.ComboBox();
            this.cmbBtn15 = new System.Windows.Forms.ComboBox();
            this.cmbBtn12 = new System.Windows.Forms.ComboBox();
            this.cmbBtn9 = new System.Windows.Forms.ComboBox();
            this.cmbBtn6 = new System.Windows.Forms.ComboBox();
            this.cmbBtn3 = new System.Windows.Forms.ComboBox();
            this.cmbBtn1 = new System.Windows.Forms.ComboBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "IR PC v1";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // serialPort1
            // 
            this.serialPort1.BaudRate = 19200;
            this.serialPort1.PortName = "0";
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // cmbCOM
            // 
            this.cmbCOM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCOM.Location = new System.Drawing.Point(8, 37);
            this.cmbCOM.Name = "cmbCOM";
            this.cmbCOM.Size = new System.Drawing.Size(121, 21);
            this.cmbCOM.TabIndex = 1;
            // 
            // cmbBaudRate
            // 
            this.cmbBaudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBaudRate.FormattingEnabled = true;
            this.cmbBaudRate.Location = new System.Drawing.Point(8, 84);
            this.cmbBaudRate.Name = "cmbBaudRate";
            this.cmbBaudRate.Size = new System.Drawing.Size(121, 21);
            this.cmbBaudRate.TabIndex = 2;
            // 
            // btnRozlacz
            // 
            this.btnRozlacz.Location = new System.Drawing.Point(8, 160);
            this.btnRozlacz.Name = "btnRozlacz";
            this.btnRozlacz.Size = new System.Drawing.Size(75, 23);
            this.btnRozlacz.TabIndex = 5;
            this.btnRozlacz.Text = "Rozłącz";
            this.btnRozlacz.UseVisualStyleBackColor = true;
            this.btnRozlacz.Click += new System.EventHandler(this.btnRozlacz_Click);
            // 
            // btnPolacz
            // 
            this.btnPolacz.Location = new System.Drawing.Point(8, 121);
            this.btnPolacz.Name = "btnPolacz";
            this.btnPolacz.Size = new System.Drawing.Size(75, 23);
            this.btnPolacz.TabIndex = 6;
            this.btnPolacz.Text = "Połącz";
            this.btnPolacz.UseVisualStyleBackColor = true;
            this.btnPolacz.Click += new System.EventHandler(this.btnPolacz_Click);
            // 
            // btnOdswiez
            // 
            this.btnOdswiez.Location = new System.Drawing.Point(153, 35);
            this.btnOdswiez.Name = "btnOdswiez";
            this.btnOdswiez.Size = new System.Drawing.Size(75, 23);
            this.btnOdswiez.TabIndex = 7;
            this.btnOdswiez.Text = "Odśwież";
            this.btnOdswiez.UseVisualStyleBackColor = true;
            this.btnOdswiez.Click += new System.EventHandler(this.btnOdswiez_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Wybierz port:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Wybierz prędkość:";
            // 
            // textInfo
            // 
            this.textInfo.BackColor = System.Drawing.SystemColors.Info;
            this.textInfo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textInfo.Location = new System.Drawing.Point(153, 84);
            this.textInfo.Name = "textInfo";
            this.textInfo.ReadOnly = true;
            this.textInfo.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.textInfo.Size = new System.Drawing.Size(373, 182);
            this.textInfo.TabIndex = 10;
            this.textInfo.Text = "";
            // 
            // btnZapisz
            // 
            this.btnZapisz.Location = new System.Drawing.Point(8, 20);
            this.btnZapisz.Name = "btnZapisz";
            this.btnZapisz.Size = new System.Drawing.Size(75, 23);
            this.btnZapisz.TabIndex = 11;
            this.btnZapisz.Text = "Zapisz";
            this.btnZapisz.UseVisualStyleBackColor = true;
            this.btnZapisz.Click += new System.EventHandler(this.btnZapisz_Click);
            // 
            // btnWczytaj
            // 
            this.btnWczytaj.Location = new System.Drawing.Point(7, 49);
            this.btnWczytaj.Name = "btnWczytaj";
            this.btnWczytaj.Size = new System.Drawing.Size(75, 23);
            this.btnWczytaj.TabIndex = 12;
            this.btnWczytaj.Text = "Wczytaj";
            this.btnWczytaj.UseVisualStyleBackColor = true;
            this.btnWczytaj.Click += new System.EventHandler(this.btnWczytaj_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(546, 316);
            this.tabControl1.TabIndex = 15;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.textInfo);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.cmbCOM);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.cmbBaudRate);
            this.tabPage1.Controls.Add(this.btnRozlacz);
            this.tabPage1.Controls.Add(this.btnOdswiez);
            this.tabPage1.Controls.Add(this.btnPolacz);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(538, 290);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Połączenie";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.cmbBtn19);
            this.tabPage2.Controls.Add(this.cmbBtn16);
            this.tabPage2.Controls.Add(this.cmbBtn13);
            this.tabPage2.Controls.Add(this.cmbBtn10);
            this.tabPage2.Controls.Add(this.cmbBtn7);
            this.tabPage2.Controls.Add(this.cmbBtn4);
            this.tabPage2.Controls.Add(this.cmbBtn20);
            this.tabPage2.Controls.Add(this.cmbBtn17);
            this.tabPage2.Controls.Add(this.cmbBtn14);
            this.tabPage2.Controls.Add(this.cmbBtn11);
            this.tabPage2.Controls.Add(this.cmbBtn8);
            this.tabPage2.Controls.Add(this.cmbBtn5);
            this.tabPage2.Controls.Add(this.cmbBtn2);
            this.tabPage2.Controls.Add(this.cmbBtn21);
            this.tabPage2.Controls.Add(this.cmbBtn18);
            this.tabPage2.Controls.Add(this.cmbBtn15);
            this.tabPage2.Controls.Add(this.cmbBtn12);
            this.tabPage2.Controls.Add(this.cmbBtn9);
            this.tabPage2.Controls.Add(this.cmbBtn6);
            this.tabPage2.Controls.Add(this.cmbBtn3);
            this.tabPage2.Controls.Add(this.cmbBtn1);
            this.tabPage2.Controls.Add(this.btnZapisz);
            this.tabPage2.Controls.Add(this.btnWczytaj);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(538, 290);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Konfiguracja";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // cmbBtn19
            // 
            this.cmbBtn19.FormattingEnabled = true;
            this.cmbBtn19.Location = new System.Drawing.Point(138, 182);
            this.cmbBtn19.Name = "cmbBtn19";
            this.cmbBtn19.Size = new System.Drawing.Size(126, 21);
            this.cmbBtn19.TabIndex = 46;
            this.cmbBtn19.SelectedIndexChanged += new System.EventHandler(this.cmbBtn19_SelectedIndexChanged);
            // 
            // cmbBtn16
            // 
            this.cmbBtn16.FormattingEnabled = true;
            this.cmbBtn16.Location = new System.Drawing.Point(138, 155);
            this.cmbBtn16.Name = "cmbBtn16";
            this.cmbBtn16.Size = new System.Drawing.Size(126, 21);
            this.cmbBtn16.TabIndex = 45;
            this.cmbBtn16.SelectedIndexChanged += new System.EventHandler(this.cmbBtn16_SelectedIndexChanged);
            // 
            // cmbBtn13
            // 
            this.cmbBtn13.FormattingEnabled = true;
            this.cmbBtn13.Location = new System.Drawing.Point(138, 128);
            this.cmbBtn13.Name = "cmbBtn13";
            this.cmbBtn13.Size = new System.Drawing.Size(126, 21);
            this.cmbBtn13.TabIndex = 44;
            this.cmbBtn13.SelectedIndexChanged += new System.EventHandler(this.cmbBtn13_SelectedIndexChanged);
            // 
            // cmbBtn10
            // 
            this.cmbBtn10.FormattingEnabled = true;
            this.cmbBtn10.Location = new System.Drawing.Point(138, 101);
            this.cmbBtn10.Name = "cmbBtn10";
            this.cmbBtn10.Size = new System.Drawing.Size(126, 21);
            this.cmbBtn10.TabIndex = 43;
            this.cmbBtn10.SelectedIndexChanged += new System.EventHandler(this.cmbBtn10_SelectedIndexChanged);
            // 
            // cmbBtn7
            // 
            this.cmbBtn7.FormattingEnabled = true;
            this.cmbBtn7.Location = new System.Drawing.Point(138, 74);
            this.cmbBtn7.Name = "cmbBtn7";
            this.cmbBtn7.Size = new System.Drawing.Size(126, 21);
            this.cmbBtn7.TabIndex = 42;
            this.cmbBtn7.SelectedIndexChanged += new System.EventHandler(this.cmbBtn7_SelectedIndexChanged);
            // 
            // cmbBtn4
            // 
            this.cmbBtn4.FormattingEnabled = true;
            this.cmbBtn4.Location = new System.Drawing.Point(138, 47);
            this.cmbBtn4.Name = "cmbBtn4";
            this.cmbBtn4.Size = new System.Drawing.Size(126, 21);
            this.cmbBtn4.TabIndex = 41;
            this.cmbBtn4.SelectedIndexChanged += new System.EventHandler(this.cmbBtn4_SelectedIndexChanged);
            // 
            // cmbBtn20
            // 
            this.cmbBtn20.FormattingEnabled = true;
            this.cmbBtn20.Location = new System.Drawing.Point(270, 182);
            this.cmbBtn20.Name = "cmbBtn20";
            this.cmbBtn20.Size = new System.Drawing.Size(126, 21);
            this.cmbBtn20.TabIndex = 40;
            this.cmbBtn20.SelectedIndexChanged += new System.EventHandler(this.cmbBtn20_SelectedIndexChanged);
            // 
            // cmbBtn17
            // 
            this.cmbBtn17.FormattingEnabled = true;
            this.cmbBtn17.Location = new System.Drawing.Point(270, 155);
            this.cmbBtn17.Name = "cmbBtn17";
            this.cmbBtn17.Size = new System.Drawing.Size(126, 21);
            this.cmbBtn17.TabIndex = 39;
            this.cmbBtn17.SelectedIndexChanged += new System.EventHandler(this.cmbBtn17_SelectedIndexChanged);
            // 
            // cmbBtn14
            // 
            this.cmbBtn14.FormattingEnabled = true;
            this.cmbBtn14.Location = new System.Drawing.Point(270, 128);
            this.cmbBtn14.Name = "cmbBtn14";
            this.cmbBtn14.Size = new System.Drawing.Size(126, 21);
            this.cmbBtn14.TabIndex = 38;
            this.cmbBtn14.SelectedIndexChanged += new System.EventHandler(this.cmbBtn14_SelectedIndexChanged);
            // 
            // cmbBtn11
            // 
            this.cmbBtn11.FormattingEnabled = true;
            this.cmbBtn11.Location = new System.Drawing.Point(270, 101);
            this.cmbBtn11.Name = "cmbBtn11";
            this.cmbBtn11.Size = new System.Drawing.Size(126, 21);
            this.cmbBtn11.TabIndex = 37;
            this.cmbBtn11.SelectedIndexChanged += new System.EventHandler(this.cmbBtn11_SelectedIndexChanged);
            // 
            // cmbBtn8
            // 
            this.cmbBtn8.FormattingEnabled = true;
            this.cmbBtn8.Location = new System.Drawing.Point(270, 74);
            this.cmbBtn8.Name = "cmbBtn8";
            this.cmbBtn8.Size = new System.Drawing.Size(126, 21);
            this.cmbBtn8.TabIndex = 36;
            this.cmbBtn8.SelectedIndexChanged += new System.EventHandler(this.cmbBtn8_SelectedIndexChanged);
            // 
            // cmbBtn5
            // 
            this.cmbBtn5.FormattingEnabled = true;
            this.cmbBtn5.Location = new System.Drawing.Point(270, 47);
            this.cmbBtn5.Name = "cmbBtn5";
            this.cmbBtn5.Size = new System.Drawing.Size(126, 21);
            this.cmbBtn5.TabIndex = 35;
            this.cmbBtn5.SelectedIndexChanged += new System.EventHandler(this.cmbBtn5_SelectedIndexChanged);
            // 
            // cmbBtn2
            // 
            this.cmbBtn2.FormattingEnabled = true;
            this.cmbBtn2.Location = new System.Drawing.Point(270, 20);
            this.cmbBtn2.Name = "cmbBtn2";
            this.cmbBtn2.Size = new System.Drawing.Size(126, 21);
            this.cmbBtn2.TabIndex = 34;
            this.cmbBtn2.SelectedIndexChanged += new System.EventHandler(this.cmbBtn2_SelectedIndexChanged);
            // 
            // cmbBtn21
            // 
            this.cmbBtn21.FormattingEnabled = true;
            this.cmbBtn21.Location = new System.Drawing.Point(402, 182);
            this.cmbBtn21.Name = "cmbBtn21";
            this.cmbBtn21.Size = new System.Drawing.Size(126, 21);
            this.cmbBtn21.TabIndex = 33;
            this.cmbBtn21.SelectedIndexChanged += new System.EventHandler(this.cmbBtn21_SelectedIndexChanged);
            // 
            // cmbBtn18
            // 
            this.cmbBtn18.FormattingEnabled = true;
            this.cmbBtn18.Location = new System.Drawing.Point(402, 155);
            this.cmbBtn18.Name = "cmbBtn18";
            this.cmbBtn18.Size = new System.Drawing.Size(126, 21);
            this.cmbBtn18.TabIndex = 30;
            this.cmbBtn18.SelectedIndexChanged += new System.EventHandler(this.cmbBtn18_SelectedIndexChanged);
            // 
            // cmbBtn15
            // 
            this.cmbBtn15.FormattingEnabled = true;
            this.cmbBtn15.Location = new System.Drawing.Point(402, 128);
            this.cmbBtn15.Name = "cmbBtn15";
            this.cmbBtn15.Size = new System.Drawing.Size(126, 21);
            this.cmbBtn15.TabIndex = 27;
            this.cmbBtn15.SelectedIndexChanged += new System.EventHandler(this.cmbBtn15_SelectedIndexChanged);
            // 
            // cmbBtn12
            // 
            this.cmbBtn12.FormattingEnabled = true;
            this.cmbBtn12.Location = new System.Drawing.Point(402, 101);
            this.cmbBtn12.Name = "cmbBtn12";
            this.cmbBtn12.Size = new System.Drawing.Size(126, 21);
            this.cmbBtn12.TabIndex = 24;
            this.cmbBtn12.SelectedIndexChanged += new System.EventHandler(this.cmbBtn12_SelectedIndexChanged);
            // 
            // cmbBtn9
            // 
            this.cmbBtn9.FormattingEnabled = true;
            this.cmbBtn9.Location = new System.Drawing.Point(402, 74);
            this.cmbBtn9.Name = "cmbBtn9";
            this.cmbBtn9.Size = new System.Drawing.Size(126, 21);
            this.cmbBtn9.TabIndex = 21;
            this.cmbBtn9.SelectedIndexChanged += new System.EventHandler(this.cmbBtn9_SelectedIndexChanged);
            // 
            // cmbBtn6
            // 
            this.cmbBtn6.FormattingEnabled = true;
            this.cmbBtn6.Location = new System.Drawing.Point(402, 47);
            this.cmbBtn6.Name = "cmbBtn6";
            this.cmbBtn6.Size = new System.Drawing.Size(126, 21);
            this.cmbBtn6.TabIndex = 18;
            this.cmbBtn6.SelectedIndexChanged += new System.EventHandler(this.cmbBtn6_SelectedIndexChanged);
            // 
            // cmbBtn3
            // 
            this.cmbBtn3.FormattingEnabled = true;
            this.cmbBtn3.Location = new System.Drawing.Point(402, 20);
            this.cmbBtn3.Name = "cmbBtn3";
            this.cmbBtn3.Size = new System.Drawing.Size(126, 21);
            this.cmbBtn3.TabIndex = 15;
            this.cmbBtn3.SelectedIndexChanged += new System.EventHandler(this.cmbBtn3_SelectedIndexChanged);
            // 
            // cmbBtn1
            // 
            this.cmbBtn1.FormattingEnabled = true;
            this.cmbBtn1.Location = new System.Drawing.Point(138, 20);
            this.cmbBtn1.Name = "cmbBtn1";
            this.cmbBtn1.Size = new System.Drawing.Size(126, 21);
            this.cmbBtn1.TabIndex = 13;
            this.cmbBtn1.SelectedIndexChanged += new System.EventHandler(this.cmbBtn1_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 313);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "IR PC";
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.ComboBox cmbCOM;
        private System.Windows.Forms.ComboBox cmbBaudRate;
        private System.Windows.Forms.Button btnRozlacz;
        private System.Windows.Forms.Button btnPolacz;
        private System.Windows.Forms.Button btnOdswiez;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox textInfo;
        private System.Windows.Forms.Button btnZapisz;
        private System.Windows.Forms.Button btnWczytaj;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ComboBox cmbBtn21;
        private System.Windows.Forms.ComboBox cmbBtn18;
        private System.Windows.Forms.ComboBox cmbBtn15;
        private System.Windows.Forms.ComboBox cmbBtn12;
        private System.Windows.Forms.ComboBox cmbBtn9;
        private System.Windows.Forms.ComboBox cmbBtn6;
        private System.Windows.Forms.ComboBox cmbBtn3;
        private System.Windows.Forms.ComboBox cmbBtn1;
        private System.Windows.Forms.ComboBox cmbBtn19;
        private System.Windows.Forms.ComboBox cmbBtn16;
        private System.Windows.Forms.ComboBox cmbBtn13;
        private System.Windows.Forms.ComboBox cmbBtn10;
        private System.Windows.Forms.ComboBox cmbBtn7;
        private System.Windows.Forms.ComboBox cmbBtn4;
        private System.Windows.Forms.ComboBox cmbBtn20;
        private System.Windows.Forms.ComboBox cmbBtn17;
        private System.Windows.Forms.ComboBox cmbBtn14;
        private System.Windows.Forms.ComboBox cmbBtn11;
        private System.Windows.Forms.ComboBox cmbBtn8;
        private System.Windows.Forms.ComboBox cmbBtn5;
        private System.Windows.Forms.ComboBox cmbBtn2;
    }
}

