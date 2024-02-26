namespace My6705.NET_Framework_4._5
{
    partial class Main
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.velParametersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadConfigToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.IOToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.driverTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comGraphToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tbCmdPos0 = new System.Windows.Forms.TextBox();
            this.tbCmdPos1 = new System.Windows.Forms.TextBox();
            this.tbCmdPos2 = new System.Windows.Forms.TextBox();
            this.tbCmdPos3 = new System.Windows.Forms.TextBox();
            this.timerCmdPos = new System.Windows.Forms.Timer(this.components);
            this.pbLimPos0 = new System.Windows.Forms.PictureBox();
            this.pbLimNeg0 = new System.Windows.Forms.PictureBox();
            this.pbLimNeg1 = new System.Windows.Forms.PictureBox();
            this.pbLimPos1 = new System.Windows.Forms.PictureBox();
            this.pbLimNeg2 = new System.Windows.Forms.PictureBox();
            this.pbLimPos2 = new System.Windows.Forms.PictureBox();
            this.pbLimNeg3 = new System.Windows.Forms.PictureBox();
            this.pbLimPos3 = new System.Windows.Forms.PictureBox();
            this.lblXPos = new System.Windows.Forms.Label();
            this.lblXNeg = new System.Windows.Forms.Label();
            this.lblYNeg = new System.Windows.Forms.Label();
            this.lblZNeg = new System.Windows.Forms.Label();
            this.lblYPos = new System.Windows.Forms.Label();
            this.lblFPos = new System.Windows.Forms.Label();
            this.lblFNeg = new System.Windows.Forms.Label();
            this.lblZPos = new System.Windows.Forms.Label();
            this.btnHome = new System.Windows.Forms.Button();
            this.timerHome = new System.Windows.Forms.Timer(this.components);
            this.btnServo = new System.Windows.Forms.Button();
            this.tbComData = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnOpenPort = new System.Windows.Forms.Button();
            this.cmbComPort = new System.Windows.Forms.ComboBox();
            this.tmrCheckComPorts = new System.Windows.Forms.Timer(this.components);
            this.tmrComDataGetter = new System.Windows.Forms.Timer(this.components);
            this.btnTest1 = new System.Windows.Forms.Button();
            this.cmbCams = new System.Windows.Forms.ComboBox();
            this.btnOpenCam = new System.Windows.Forms.Button();
            this.trbX = new System.Windows.Forms.TrackBar();
            this.cbEnCross = new System.Windows.Forms.CheckBox();
            this.trbY = new System.Windows.Forms.TrackBar();
            this.lblTrbX = new System.Windows.Forms.Label();
            this.lblTrbY = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLimPos0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLimNeg0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLimNeg1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLimPos1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLimNeg2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLimPos2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLimNeg3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLimPos3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbY)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.velParametersToolStripMenuItem,
            this.loadConfigToolStripMenuItem,
            this.IOToolStripMenuItem,
            this.driverTestToolStripMenuItem,
            this.comGraphToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 1, 0, 1);
            this.menuStrip1.Size = new System.Drawing.Size(839, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // velParametersToolStripMenuItem
            // 
            this.velParametersToolStripMenuItem.Name = "velParametersToolStripMenuItem";
            this.velParametersToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.velParametersToolStripMenuItem.Text = "Параметры скорости";
            this.velParametersToolStripMenuItem.Click += new System.EventHandler(this.velParametersToolStripMenuItem_Click);
            // 
            // loadConfigToolStripMenuItem
            // 
            this.loadConfigToolStripMenuItem.Name = "loadConfigToolStripMenuItem";
            this.loadConfigToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.loadConfigToolStripMenuItem.Text = "Файл конфигурации";
            this.loadConfigToolStripMenuItem.Click += new System.EventHandler(this.loadConfigToolStripMenuItem_Click);
            // 
            // IOToolStripMenuItem
            // 
            this.IOToolStripMenuItem.Name = "IOToolStripMenuItem";
            this.IOToolStripMenuItem.Size = new System.Drawing.Size(84, 22);
            this.IOToolStripMenuItem.Text = "Ввод-вывод";
            this.IOToolStripMenuItem.Click += new System.EventHandler(this.IOToolStripMenuItem_Click);
            // 
            // driverTestToolStripMenuItem
            // 
            this.driverTestToolStripMenuItem.Name = "driverTestToolStripMenuItem";
            this.driverTestToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.driverTestToolStripMenuItem.Text = "Тест приводов";
            this.driverTestToolStripMenuItem.Click += new System.EventHandler(this.driverTestToolStripMenuItem_Click);
            // 
            // comGraphToolStripMenuItem
            // 
            this.comGraphToolStripMenuItem.Name = "comGraphToolStripMenuItem";
            this.comGraphToolStripMenuItem.Size = new System.Drawing.Size(104, 22);
            this.comGraphToolStripMenuItem.Text = "График данных";
            this.comGraphToolStripMenuItem.Click += new System.EventHandler(this.comSetupToolStripMenuItem_Click);
            // 
            // tbCmdPos0
            // 
            this.tbCmdPos0.Location = new System.Drawing.Point(57, 579);
            this.tbCmdPos0.Name = "tbCmdPos0";
            this.tbCmdPos0.ReadOnly = true;
            this.tbCmdPos0.Size = new System.Drawing.Size(68, 20);
            this.tbCmdPos0.TabIndex = 1;
            // 
            // tbCmdPos1
            // 
            this.tbCmdPos1.Location = new System.Drawing.Point(279, 579);
            this.tbCmdPos1.Name = "tbCmdPos1";
            this.tbCmdPos1.ReadOnly = true;
            this.tbCmdPos1.Size = new System.Drawing.Size(68, 20);
            this.tbCmdPos1.TabIndex = 2;
            // 
            // tbCmdPos2
            // 
            this.tbCmdPos2.Location = new System.Drawing.Point(502, 579);
            this.tbCmdPos2.Name = "tbCmdPos2";
            this.tbCmdPos2.ReadOnly = true;
            this.tbCmdPos2.Size = new System.Drawing.Size(68, 20);
            this.tbCmdPos2.TabIndex = 3;
            // 
            // tbCmdPos3
            // 
            this.tbCmdPos3.Location = new System.Drawing.Point(721, 579);
            this.tbCmdPos3.Name = "tbCmdPos3";
            this.tbCmdPos3.ReadOnly = true;
            this.tbCmdPos3.Size = new System.Drawing.Size(68, 20);
            this.tbCmdPos3.TabIndex = 4;
            // 
            // timerCmdPos
            // 
            this.timerCmdPos.Enabled = true;
            this.timerCmdPos.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pbLimPos0
            // 
            this.pbLimPos0.BackColor = System.Drawing.Color.Silver;
            this.pbLimPos0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbLimPos0.Location = new System.Drawing.Point(129, 581);
            this.pbLimPos0.Name = "pbLimPos0";
            this.pbLimPos0.Size = new System.Drawing.Size(14, 14);
            this.pbLimPos0.TabIndex = 5;
            this.pbLimPos0.TabStop = false;
            // 
            // pbLimNeg0
            // 
            this.pbLimNeg0.BackColor = System.Drawing.Color.Silver;
            this.pbLimNeg0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbLimNeg0.Location = new System.Drawing.Point(39, 581);
            this.pbLimNeg0.Name = "pbLimNeg0";
            this.pbLimNeg0.Size = new System.Drawing.Size(14, 14);
            this.pbLimNeg0.TabIndex = 6;
            this.pbLimNeg0.TabStop = false;
            // 
            // pbLimNeg1
            // 
            this.pbLimNeg1.BackColor = System.Drawing.Color.Silver;
            this.pbLimNeg1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbLimNeg1.Location = new System.Drawing.Point(260, 581);
            this.pbLimNeg1.Name = "pbLimNeg1";
            this.pbLimNeg1.Size = new System.Drawing.Size(14, 14);
            this.pbLimNeg1.TabIndex = 7;
            this.pbLimNeg1.TabStop = false;
            // 
            // pbLimPos1
            // 
            this.pbLimPos1.BackColor = System.Drawing.Color.Silver;
            this.pbLimPos1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbLimPos1.Location = new System.Drawing.Point(351, 581);
            this.pbLimPos1.Name = "pbLimPos1";
            this.pbLimPos1.Size = new System.Drawing.Size(14, 14);
            this.pbLimPos1.TabIndex = 8;
            this.pbLimPos1.TabStop = false;
            // 
            // pbLimNeg2
            // 
            this.pbLimNeg2.BackColor = System.Drawing.Color.Silver;
            this.pbLimNeg2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbLimNeg2.Location = new System.Drawing.Point(483, 581);
            this.pbLimNeg2.Name = "pbLimNeg2";
            this.pbLimNeg2.Size = new System.Drawing.Size(14, 14);
            this.pbLimNeg2.TabIndex = 9;
            this.pbLimNeg2.TabStop = false;
            // 
            // pbLimPos2
            // 
            this.pbLimPos2.BackColor = System.Drawing.Color.Silver;
            this.pbLimPos2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbLimPos2.Location = new System.Drawing.Point(574, 581);
            this.pbLimPos2.Name = "pbLimPos2";
            this.pbLimPos2.Size = new System.Drawing.Size(14, 14);
            this.pbLimPos2.TabIndex = 10;
            this.pbLimPos2.TabStop = false;
            // 
            // pbLimNeg3
            // 
            this.pbLimNeg3.BackColor = System.Drawing.Color.Silver;
            this.pbLimNeg3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbLimNeg3.Location = new System.Drawing.Point(702, 581);
            this.pbLimNeg3.Name = "pbLimNeg3";
            this.pbLimNeg3.Size = new System.Drawing.Size(14, 14);
            this.pbLimNeg3.TabIndex = 11;
            this.pbLimNeg3.TabStop = false;
            // 
            // pbLimPos3
            // 
            this.pbLimPos3.BackColor = System.Drawing.Color.Silver;
            this.pbLimPos3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbLimPos3.Location = new System.Drawing.Point(793, 581);
            this.pbLimPos3.Name = "pbLimPos3";
            this.pbLimPos3.Size = new System.Drawing.Size(14, 14);
            this.pbLimPos3.TabIndex = 12;
            this.pbLimPos3.TabStop = false;
            // 
            // lblXPos
            // 
            this.lblXPos.AutoSize = true;
            this.lblXPos.Location = new System.Drawing.Point(147, 581);
            this.lblXPos.Name = "lblXPos";
            this.lblXPos.Size = new System.Drawing.Size(20, 13);
            this.lblXPos.TabIndex = 13;
            this.lblXPos.Text = "+X";
            // 
            // lblXNeg
            // 
            this.lblXNeg.AutoSize = true;
            this.lblXNeg.Location = new System.Drawing.Point(17, 581);
            this.lblXNeg.Name = "lblXNeg";
            this.lblXNeg.Size = new System.Drawing.Size(17, 13);
            this.lblXNeg.TabIndex = 14;
            this.lblXNeg.Text = "-X";
            // 
            // lblYNeg
            // 
            this.lblYNeg.AutoSize = true;
            this.lblYNeg.Location = new System.Drawing.Point(238, 581);
            this.lblYNeg.Name = "lblYNeg";
            this.lblYNeg.Size = new System.Drawing.Size(17, 13);
            this.lblYNeg.TabIndex = 15;
            this.lblYNeg.Text = "-Y";
            // 
            // lblZNeg
            // 
            this.lblZNeg.AutoSize = true;
            this.lblZNeg.Location = new System.Drawing.Point(462, 581);
            this.lblZNeg.Name = "lblZNeg";
            this.lblZNeg.Size = new System.Drawing.Size(17, 13);
            this.lblZNeg.TabIndex = 16;
            this.lblZNeg.Text = "-Z";
            // 
            // lblYPos
            // 
            this.lblYPos.AutoSize = true;
            this.lblYPos.Location = new System.Drawing.Point(370, 581);
            this.lblYPos.Name = "lblYPos";
            this.lblYPos.Size = new System.Drawing.Size(20, 13);
            this.lblYPos.TabIndex = 17;
            this.lblYPos.Text = "+Y";
            // 
            // lblFPos
            // 
            this.lblFPos.AutoSize = true;
            this.lblFPos.Location = new System.Drawing.Point(812, 581);
            this.lblFPos.Name = "lblFPos";
            this.lblFPos.Size = new System.Drawing.Size(21, 13);
            this.lblFPos.TabIndex = 18;
            this.lblFPos.Text = "+φ";
            // 
            // lblFNeg
            // 
            this.lblFNeg.AutoSize = true;
            this.lblFNeg.Location = new System.Drawing.Point(681, 581);
            this.lblFNeg.Name = "lblFNeg";
            this.lblFNeg.Size = new System.Drawing.Size(18, 13);
            this.lblFNeg.TabIndex = 19;
            this.lblFNeg.Text = "-φ";
            // 
            // lblZPos
            // 
            this.lblZPos.AutoSize = true;
            this.lblZPos.Location = new System.Drawing.Point(593, 581);
            this.lblZPos.Name = "lblZPos";
            this.lblZPos.Size = new System.Drawing.Size(20, 13);
            this.lblZPos.TabIndex = 20;
            this.lblZPos.Text = "+Z";
            // 
            // btnHome
            // 
            this.btnHome.Enabled = false;
            this.btnHome.Location = new System.Drawing.Point(669, 280);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(75, 23);
            this.btnHome.TabIndex = 21;
            this.btnHome.Text = "Home";
            this.btnHome.UseVisualStyleBackColor = true;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // timerHome
            // 
            this.timerHome.Tick += new System.EventHandler(this.timerHomer_Tick);
            // 
            // btnServo
            // 
            this.btnServo.Location = new System.Drawing.Point(669, 309);
            this.btnServo.Name = "btnServo";
            this.btnServo.Size = new System.Drawing.Size(75, 23);
            this.btnServo.TabIndex = 22;
            this.btnServo.Text = "Servo On";
            this.btnServo.UseVisualStyleBackColor = true;
            this.btnServo.Click += new System.EventHandler(this.btnServo_Click);
            // 
            // tbComData
            // 
            this.tbComData.BackColor = System.Drawing.Color.Black;
            this.tbComData.Font = new System.Drawing.Font("DSEG7 Modern", 22F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbComData.ForeColor = System.Drawing.Color.Cyan;
            this.tbComData.Location = new System.Drawing.Point(611, 25);
            this.tbComData.Name = "tbComData";
            this.tbComData.ReadOnly = true;
            this.tbComData.Size = new System.Drawing.Size(178, 39);
            this.tbComData.TabIndex = 24;
            this.tbComData.Text = "0.00";
            this.tbComData.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.LightGray;
            this.pictureBox1.ImageLocation = "";
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(12, 27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(533, 390);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 25;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // btnOpenPort
            // 
            this.btnOpenPort.Location = new System.Drawing.Point(611, 70);
            this.btnOpenPort.Name = "btnOpenPort";
            this.btnOpenPort.Size = new System.Drawing.Size(94, 23);
            this.btnOpenPort.TabIndex = 26;
            this.btnOpenPort.Text = "Открыть порт";
            this.btnOpenPort.UseVisualStyleBackColor = true;
            this.btnOpenPort.Click += new System.EventHandler(this.btnOpenPort_Click);
            // 
            // cmbComPort
            // 
            this.cmbComPort.FormattingEnabled = true;
            this.cmbComPort.Location = new System.Drawing.Point(714, 72);
            this.cmbComPort.Name = "cmbComPort";
            this.cmbComPort.Size = new System.Drawing.Size(75, 21);
            this.cmbComPort.TabIndex = 27;
            // 
            // tmrCheckComPorts
            // 
            this.tmrCheckComPorts.Enabled = true;
            this.tmrCheckComPorts.Tick += new System.EventHandler(this.tmrCheckComPorts_Tick);
            // 
            // tmrComDataGetter
            // 
            this.tmrComDataGetter.Interval = 250;
            this.tmrComDataGetter.Tick += new System.EventHandler(this.tmrComDataGetter_Tick);
            // 
            // btnTest1
            // 
            this.btnTest1.Location = new System.Drawing.Point(669, 194);
            this.btnTest1.Name = "btnTest1";
            this.btnTest1.Size = new System.Drawing.Size(75, 23);
            this.btnTest1.TabIndex = 28;
            this.btnTest1.Text = "Тесты";
            this.btnTest1.UseVisualStyleBackColor = true;
            this.btnTest1.Click += new System.EventHandler(this.btnTest1_Click);
            // 
            // cmbCams
            // 
            this.cmbCams.FormattingEnabled = true;
            this.cmbCams.Location = new System.Drawing.Point(143, 426);
            this.cmbCams.Name = "cmbCams";
            this.cmbCams.Size = new System.Drawing.Size(118, 21);
            this.cmbCams.TabIndex = 31;
            // 
            // btnOpenCam
            // 
            this.btnOpenCam.Location = new System.Drawing.Point(12, 424);
            this.btnOpenCam.Name = "btnOpenCam";
            this.btnOpenCam.Size = new System.Drawing.Size(124, 23);
            this.btnOpenCam.TabIndex = 32;
            this.btnOpenCam.Text = "Начать просмотр";
            this.btnOpenCam.UseVisualStyleBackColor = true;
            this.btnOpenCam.Click += new System.EventHandler(this.btnOpenCam_Click);
            // 
            // trbX
            // 
            this.trbX.Enabled = false;
            this.trbX.LargeChange = 0;
            this.trbX.Location = new System.Drawing.Point(331, 426);
            this.trbX.Maximum = 100;
            this.trbX.Minimum = 10;
            this.trbX.Name = "trbX";
            this.trbX.Size = new System.Drawing.Size(104, 45);
            this.trbX.SmallChange = 0;
            this.trbX.TabIndex = 36;
            this.trbX.TickFrequency = 100;
            this.trbX.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trbX.Value = 10;
            this.trbX.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // cbEnCross
            // 
            this.cbEnCross.AutoSize = true;
            this.cbEnCross.Location = new System.Drawing.Point(280, 428);
            this.cbEnCross.Name = "cbEnCross";
            this.cbEnCross.Size = new System.Drawing.Size(57, 17);
            this.cbEnCross.TabIndex = 37;
            this.cbEnCross.Text = "Визир";
            this.cbEnCross.UseVisualStyleBackColor = true;
            this.cbEnCross.CheckedChanged += new System.EventHandler(this.cbEnCross_CheckedChanged);
            // 
            // trbY
            // 
            this.trbY.Enabled = false;
            this.trbY.LargeChange = 0;
            this.trbY.Location = new System.Drawing.Point(441, 426);
            this.trbY.Maximum = 100;
            this.trbY.Minimum = 10;
            this.trbY.Name = "trbY";
            this.trbY.Size = new System.Drawing.Size(104, 45);
            this.trbY.SmallChange = 0;
            this.trbY.TabIndex = 38;
            this.trbY.TickFrequency = 100;
            this.trbY.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trbY.Value = 10;
            this.trbY.Scroll += new System.EventHandler(this.trbY_Scroll);
            // 
            // lblTrbX
            // 
            this.lblTrbX.AutoSize = true;
            this.lblTrbX.Location = new System.Drawing.Point(376, 441);
            this.lblTrbX.Name = "lblTrbX";
            this.lblTrbX.Size = new System.Drawing.Size(14, 13);
            this.lblTrbX.TabIndex = 39;
            this.lblTrbX.Text = "X";
            // 
            // lblTrbY
            // 
            this.lblTrbY.AutoSize = true;
            this.lblTrbY.Location = new System.Drawing.Point(487, 441);
            this.lblTrbY.Name = "lblTrbY";
            this.lblTrbY.Size = new System.Drawing.Size(14, 13);
            this.lblTrbY.TabIndex = 40;
            this.lblTrbY.Text = "Y";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(669, 339);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 41;
            this.button1.Text = "Reset Errors";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(839, 629);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblTrbY);
            this.Controls.Add(this.lblTrbX);
            this.Controls.Add(this.trbY);
            this.Controls.Add(this.cbEnCross);
            this.Controls.Add(this.trbX);
            this.Controls.Add(this.btnOpenCam);
            this.Controls.Add(this.cmbCams);
            this.Controls.Add(this.btnTest1);
            this.Controls.Add(this.cmbComPort);
            this.Controls.Add(this.btnOpenPort);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.tbComData);
            this.Controls.Add(this.btnServo);
            this.Controls.Add(this.btnHome);
            this.Controls.Add(this.lblZPos);
            this.Controls.Add(this.lblFNeg);
            this.Controls.Add(this.lblFPos);
            this.Controls.Add(this.lblYPos);
            this.Controls.Add(this.lblZNeg);
            this.Controls.Add(this.lblYNeg);
            this.Controls.Add(this.lblXNeg);
            this.Controls.Add(this.lblXPos);
            this.Controls.Add(this.pbLimPos3);
            this.Controls.Add(this.pbLimNeg3);
            this.Controls.Add(this.pbLimPos2);
            this.Controls.Add(this.pbLimNeg2);
            this.Controls.Add(this.pbLimPos1);
            this.Controls.Add(this.pbLimNeg1);
            this.Controls.Add(this.pbLimNeg0);
            this.Controls.Add(this.pbLimPos0);
            this.Controls.Add(this.tbCmdPos3);
            this.Controls.Add(this.tbCmdPos2);
            this.Controls.Add(this.tbCmdPos1);
            this.Controls.Add(this.tbCmdPos0);
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "6705 by Zadarozhny Dzmitry";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLimPos0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLimNeg0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLimNeg1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLimPos1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLimNeg2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLimPos2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLimNeg3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLimPos3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbY)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem velParametersToolStripMenuItem;
        private System.Windows.Forms.TextBox tbCmdPos0;
        private System.Windows.Forms.TextBox tbCmdPos1;
        private System.Windows.Forms.TextBox tbCmdPos2;
        private System.Windows.Forms.TextBox tbCmdPos3;
        private System.Windows.Forms.ToolStripMenuItem loadConfigToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem IOToolStripMenuItem;
        private System.Windows.Forms.Timer timerCmdPos;
        private System.Windows.Forms.PictureBox pbLimPos0;
        private System.Windows.Forms.PictureBox pbLimNeg0;
        private System.Windows.Forms.PictureBox pbLimNeg1;
        private System.Windows.Forms.PictureBox pbLimPos1;
        private System.Windows.Forms.PictureBox pbLimNeg2;
        private System.Windows.Forms.PictureBox pbLimPos2;
        private System.Windows.Forms.PictureBox pbLimNeg3;
        private System.Windows.Forms.PictureBox pbLimPos3;
        private System.Windows.Forms.Label lblXPos;
        private System.Windows.Forms.Label lblXNeg;
        private System.Windows.Forms.Label lblYNeg;
        private System.Windows.Forms.Label lblZNeg;
        private System.Windows.Forms.Label lblYPos;
        private System.Windows.Forms.Label lblFPos;
        private System.Windows.Forms.Label lblFNeg;
        private System.Windows.Forms.Label lblZPos;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Timer timerHome;
        private System.Windows.Forms.Button btnServo;
        private System.Windows.Forms.TextBox tbComData;
        private System.Windows.Forms.ToolStripMenuItem driverTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem comGraphToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnOpenPort;
        private System.Windows.Forms.ComboBox cmbComPort;
        private System.Windows.Forms.Timer tmrCheckComPorts;
        private System.Windows.Forms.Timer tmrComDataGetter;
        private System.Windows.Forms.Button btnTest1;
        private System.Windows.Forms.ComboBox cmbCams;
        private System.Windows.Forms.Button btnOpenCam;
        private System.Windows.Forms.TrackBar trbX;
        private System.Windows.Forms.CheckBox cbEnCross;
        private System.Windows.Forms.TrackBar trbY;
        private System.Windows.Forms.Label lblTrbX;
        private System.Windows.Forms.Label lblTrbY;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}

