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
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.velParametersToolStripMenuItem,
            this.loadConfigToolStripMenuItem,
            this.IOToolStripMenuItem,
            this.driverTestToolStripMenuItem,
            this.comGraphToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(6, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1258, 33);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // velParametersToolStripMenuItem
            // 
            this.velParametersToolStripMenuItem.Name = "velParametersToolStripMenuItem";
            this.velParametersToolStripMenuItem.Size = new System.Drawing.Size(203, 29);
            this.velParametersToolStripMenuItem.Text = "Параметры скорости";
            this.velParametersToolStripMenuItem.Click += new System.EventHandler(this.velParametersToolStripMenuItem_Click);
            // 
            // loadConfigToolStripMenuItem
            // 
            this.loadConfigToolStripMenuItem.Name = "loadConfigToolStripMenuItem";
            this.loadConfigToolStripMenuItem.Size = new System.Drawing.Size(193, 29);
            this.loadConfigToolStripMenuItem.Text = "Файл конфигурации";
            this.loadConfigToolStripMenuItem.Click += new System.EventHandler(this.loadConfigToolStripMenuItem_Click);
            // 
            // IOToolStripMenuItem
            // 
            this.IOToolStripMenuItem.Name = "IOToolStripMenuItem";
            this.IOToolStripMenuItem.Size = new System.Drawing.Size(130, 29);
            this.IOToolStripMenuItem.Text = "Ввод-вывод";
            this.IOToolStripMenuItem.Click += new System.EventHandler(this.IOToolStripMenuItem_Click);
            // 
            // driverTestToolStripMenuItem
            // 
            this.driverTestToolStripMenuItem.Name = "driverTestToolStripMenuItem";
            this.driverTestToolStripMenuItem.Size = new System.Drawing.Size(149, 29);
            this.driverTestToolStripMenuItem.Text = "Тест приводов";
            this.driverTestToolStripMenuItem.Click += new System.EventHandler(this.driverTestToolStripMenuItem_Click);
            // 
            // comGraphToolStripMenuItem
            // 
            this.comGraphToolStripMenuItem.Name = "comGraphToolStripMenuItem";
            this.comGraphToolStripMenuItem.Size = new System.Drawing.Size(152, 29);
            this.comGraphToolStripMenuItem.Text = "График данных";
            this.comGraphToolStripMenuItem.Click += new System.EventHandler(this.comSetupToolStripMenuItem_Click);
            // 
            // tbCmdPos0
            // 
            this.tbCmdPos0.Location = new System.Drawing.Point(86, 891);
            this.tbCmdPos0.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbCmdPos0.Name = "tbCmdPos0";
            this.tbCmdPos0.ReadOnly = true;
            this.tbCmdPos0.Size = new System.Drawing.Size(100, 26);
            this.tbCmdPos0.TabIndex = 1;
            // 
            // tbCmdPos1
            // 
            this.tbCmdPos1.Location = new System.Drawing.Point(418, 891);
            this.tbCmdPos1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbCmdPos1.Name = "tbCmdPos1";
            this.tbCmdPos1.ReadOnly = true;
            this.tbCmdPos1.Size = new System.Drawing.Size(100, 26);
            this.tbCmdPos1.TabIndex = 2;
            // 
            // tbCmdPos2
            // 
            this.tbCmdPos2.Location = new System.Drawing.Point(753, 891);
            this.tbCmdPos2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbCmdPos2.Name = "tbCmdPos2";
            this.tbCmdPos2.ReadOnly = true;
            this.tbCmdPos2.Size = new System.Drawing.Size(100, 26);
            this.tbCmdPos2.TabIndex = 3;
            // 
            // tbCmdPos3
            // 
            this.tbCmdPos3.Location = new System.Drawing.Point(1082, 891);
            this.tbCmdPos3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbCmdPos3.Name = "tbCmdPos3";
            this.tbCmdPos3.ReadOnly = true;
            this.tbCmdPos3.Size = new System.Drawing.Size(100, 26);
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
            this.pbLimPos0.Location = new System.Drawing.Point(194, 894);
            this.pbLimPos0.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pbLimPos0.Name = "pbLimPos0";
            this.pbLimPos0.Size = new System.Drawing.Size(20, 20);
            this.pbLimPos0.TabIndex = 5;
            this.pbLimPos0.TabStop = false;
            // 
            // pbLimNeg0
            // 
            this.pbLimNeg0.BackColor = System.Drawing.Color.Silver;
            this.pbLimNeg0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbLimNeg0.Location = new System.Drawing.Point(58, 894);
            this.pbLimNeg0.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pbLimNeg0.Name = "pbLimNeg0";
            this.pbLimNeg0.Size = new System.Drawing.Size(20, 20);
            this.pbLimNeg0.TabIndex = 6;
            this.pbLimNeg0.TabStop = false;
            // 
            // pbLimNeg1
            // 
            this.pbLimNeg1.BackColor = System.Drawing.Color.Silver;
            this.pbLimNeg1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbLimNeg1.Location = new System.Drawing.Point(390, 894);
            this.pbLimNeg1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pbLimNeg1.Name = "pbLimNeg1";
            this.pbLimNeg1.Size = new System.Drawing.Size(20, 20);
            this.pbLimNeg1.TabIndex = 7;
            this.pbLimNeg1.TabStop = false;
            // 
            // pbLimPos1
            // 
            this.pbLimPos1.BackColor = System.Drawing.Color.Silver;
            this.pbLimPos1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbLimPos1.Location = new System.Drawing.Point(526, 894);
            this.pbLimPos1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pbLimPos1.Name = "pbLimPos1";
            this.pbLimPos1.Size = new System.Drawing.Size(20, 20);
            this.pbLimPos1.TabIndex = 8;
            this.pbLimPos1.TabStop = false;
            // 
            // pbLimNeg2
            // 
            this.pbLimNeg2.BackColor = System.Drawing.Color.Silver;
            this.pbLimNeg2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbLimNeg2.Location = new System.Drawing.Point(724, 894);
            this.pbLimNeg2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pbLimNeg2.Name = "pbLimNeg2";
            this.pbLimNeg2.Size = new System.Drawing.Size(20, 20);
            this.pbLimNeg2.TabIndex = 9;
            this.pbLimNeg2.TabStop = false;
            // 
            // pbLimPos2
            // 
            this.pbLimPos2.BackColor = System.Drawing.Color.Silver;
            this.pbLimPos2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbLimPos2.Location = new System.Drawing.Point(861, 894);
            this.pbLimPos2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pbLimPos2.Name = "pbLimPos2";
            this.pbLimPos2.Size = new System.Drawing.Size(20, 20);
            this.pbLimPos2.TabIndex = 10;
            this.pbLimPos2.TabStop = false;
            // 
            // pbLimNeg3
            // 
            this.pbLimNeg3.BackColor = System.Drawing.Color.Silver;
            this.pbLimNeg3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbLimNeg3.Location = new System.Drawing.Point(1053, 894);
            this.pbLimNeg3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pbLimNeg3.Name = "pbLimNeg3";
            this.pbLimNeg3.Size = new System.Drawing.Size(20, 20);
            this.pbLimNeg3.TabIndex = 11;
            this.pbLimNeg3.TabStop = false;
            // 
            // pbLimPos3
            // 
            this.pbLimPos3.BackColor = System.Drawing.Color.Silver;
            this.pbLimPos3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbLimPos3.Location = new System.Drawing.Point(1190, 894);
            this.pbLimPos3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pbLimPos3.Name = "pbLimPos3";
            this.pbLimPos3.Size = new System.Drawing.Size(20, 20);
            this.pbLimPos3.TabIndex = 12;
            this.pbLimPos3.TabStop = false;
            // 
            // lblXPos
            // 
            this.lblXPos.AutoSize = true;
            this.lblXPos.Location = new System.Drawing.Point(220, 894);
            this.lblXPos.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblXPos.Name = "lblXPos";
            this.lblXPos.Size = new System.Drawing.Size(29, 20);
            this.lblXPos.TabIndex = 13;
            this.lblXPos.Text = "+X";
            // 
            // lblXNeg
            // 
            this.lblXNeg.AutoSize = true;
            this.lblXNeg.Location = new System.Drawing.Point(26, 894);
            this.lblXNeg.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblXNeg.Name = "lblXNeg";
            this.lblXNeg.Size = new System.Drawing.Size(25, 20);
            this.lblXNeg.TabIndex = 14;
            this.lblXNeg.Text = "-X";
            // 
            // lblYNeg
            // 
            this.lblYNeg.AutoSize = true;
            this.lblYNeg.Location = new System.Drawing.Point(357, 894);
            this.lblYNeg.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblYNeg.Name = "lblYNeg";
            this.lblYNeg.Size = new System.Drawing.Size(25, 20);
            this.lblYNeg.TabIndex = 15;
            this.lblYNeg.Text = "-Y";
            // 
            // lblZNeg
            // 
            this.lblZNeg.AutoSize = true;
            this.lblZNeg.Location = new System.Drawing.Point(693, 894);
            this.lblZNeg.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblZNeg.Name = "lblZNeg";
            this.lblZNeg.Size = new System.Drawing.Size(24, 20);
            this.lblZNeg.TabIndex = 16;
            this.lblZNeg.Text = "-Z";
            // 
            // lblYPos
            // 
            this.lblYPos.AutoSize = true;
            this.lblYPos.Location = new System.Drawing.Point(555, 894);
            this.lblYPos.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblYPos.Name = "lblYPos";
            this.lblYPos.Size = new System.Drawing.Size(29, 20);
            this.lblYPos.TabIndex = 17;
            this.lblYPos.Text = "+Y";
            // 
            // lblFPos
            // 
            this.lblFPos.AutoSize = true;
            this.lblFPos.Location = new System.Drawing.Point(1218, 894);
            this.lblFPos.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFPos.Name = "lblFPos";
            this.lblFPos.Size = new System.Drawing.Size(27, 20);
            this.lblFPos.TabIndex = 18;
            this.lblFPos.Text = "+φ";
            // 
            // lblFNeg
            // 
            this.lblFNeg.AutoSize = true;
            this.lblFNeg.Location = new System.Drawing.Point(1022, 894);
            this.lblFNeg.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFNeg.Name = "lblFNeg";
            this.lblFNeg.Size = new System.Drawing.Size(23, 20);
            this.lblFNeg.TabIndex = 19;
            this.lblFNeg.Text = "-φ";
            // 
            // lblZPos
            // 
            this.lblZPos.AutoSize = true;
            this.lblZPos.Location = new System.Drawing.Point(890, 894);
            this.lblZPos.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblZPos.Name = "lblZPos";
            this.lblZPos.Size = new System.Drawing.Size(28, 20);
            this.lblZPos.TabIndex = 20;
            this.lblZPos.Text = "+Z";
            // 
            // btnHome
            // 
            this.btnHome.Enabled = false;
            this.btnHome.Location = new System.Drawing.Point(1004, 431);
            this.btnHome.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(112, 35);
            this.btnHome.TabIndex = 21;
            this.btnHome.Text = "Home";
            this.btnHome.UseVisualStyleBackColor = true;
            // 
            // btnServo
            // 
            this.btnServo.Location = new System.Drawing.Point(1004, 475);
            this.btnServo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnServo.Name = "btnServo";
            this.btnServo.Size = new System.Drawing.Size(112, 35);
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
            this.tbComData.Location = new System.Drawing.Point(916, 38);
            this.tbComData.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbComData.Name = "tbComData";
            this.tbComData.ReadOnly = true;
            this.tbComData.Size = new System.Drawing.Size(265, 55);
            this.tbComData.TabIndex = 24;
            this.tbComData.Text = "0.00";
            this.tbComData.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.LightGray;
            this.pictureBox1.ImageLocation = "";
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(18, 42);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(800, 600);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 25;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // btnOpenPort
            // 
            this.btnOpenPort.Location = new System.Drawing.Point(916, 108);
            this.btnOpenPort.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnOpenPort.Name = "btnOpenPort";
            this.btnOpenPort.Size = new System.Drawing.Size(141, 35);
            this.btnOpenPort.TabIndex = 26;
            this.btnOpenPort.Text = "Открыть порт";
            this.btnOpenPort.UseVisualStyleBackColor = true;
            this.btnOpenPort.Click += new System.EventHandler(this.btnOpenPort_Click);
            // 
            // cmbComPort
            // 
            this.cmbComPort.FormattingEnabled = true;
            this.cmbComPort.Location = new System.Drawing.Point(1071, 111);
            this.cmbComPort.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbComPort.Name = "cmbComPort";
            this.cmbComPort.Size = new System.Drawing.Size(110, 28);
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
            this.btnTest1.Location = new System.Drawing.Point(1004, 298);
            this.btnTest1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnTest1.Name = "btnTest1";
            this.btnTest1.Size = new System.Drawing.Size(112, 35);
            this.btnTest1.TabIndex = 28;
            this.btnTest1.Text = "Тесты";
            this.btnTest1.UseVisualStyleBackColor = true;
            this.btnTest1.Click += new System.EventHandler(this.btnTest1_Click);
            // 
            // cmbCams
            // 
            this.cmbCams.FormattingEnabled = true;
            this.cmbCams.Location = new System.Drawing.Point(214, 655);
            this.cmbCams.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbCams.Name = "cmbCams";
            this.cmbCams.Size = new System.Drawing.Size(175, 28);
            this.cmbCams.TabIndex = 31;
            // 
            // btnOpenCam
            // 
            this.btnOpenCam.Location = new System.Drawing.Point(18, 652);
            this.btnOpenCam.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnOpenCam.Name = "btnOpenCam";
            this.btnOpenCam.Size = new System.Drawing.Size(186, 35);
            this.btnOpenCam.TabIndex = 32;
            this.btnOpenCam.Text = "Начать просмотр";
            this.btnOpenCam.UseVisualStyleBackColor = true;
            this.btnOpenCam.Click += new System.EventHandler(this.btnOpenCam_Click);
            // 
            // trbX
            // 
            this.trbX.Enabled = false;
            this.trbX.LargeChange = 0;
            this.trbX.Location = new System.Drawing.Point(496, 655);
            this.trbX.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.trbX.Maximum = 100;
            this.trbX.Minimum = 10;
            this.trbX.Name = "trbX";
            this.trbX.Size = new System.Drawing.Size(156, 69);
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
            this.cbEnCross.Location = new System.Drawing.Point(420, 658);
            this.cbEnCross.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbEnCross.Name = "cbEnCross";
            this.cbEnCross.Size = new System.Drawing.Size(81, 24);
            this.cbEnCross.TabIndex = 37;
            this.cbEnCross.Text = "Визир";
            this.cbEnCross.UseVisualStyleBackColor = true;
            this.cbEnCross.CheckedChanged += new System.EventHandler(this.cbEnCross_CheckedChanged);
            // 
            // trbY
            // 
            this.trbY.Enabled = false;
            this.trbY.LargeChange = 0;
            this.trbY.Location = new System.Drawing.Point(662, 655);
            this.trbY.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.trbY.Maximum = 100;
            this.trbY.Minimum = 10;
            this.trbY.Name = "trbY";
            this.trbY.Size = new System.Drawing.Size(156, 69);
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
            this.lblTrbX.Location = new System.Drawing.Point(564, 678);
            this.lblTrbX.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTrbX.Name = "lblTrbX";
            this.lblTrbX.Size = new System.Drawing.Size(20, 20);
            this.lblTrbX.TabIndex = 39;
            this.lblTrbX.Text = "X";
            // 
            // lblTrbY
            // 
            this.lblTrbY.AutoSize = true;
            this.lblTrbY.Location = new System.Drawing.Point(730, 678);
            this.lblTrbY.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTrbY.Name = "lblTrbY";
            this.lblTrbY.Size = new System.Drawing.Size(20, 20);
            this.lblTrbY.TabIndex = 40;
            this.lblTrbY.Text = "Y";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1004, 522);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 35);
            this.button1.TabIndex = 41;
            this.button1.Text = "Reset Errors";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1026, 713);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 42;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1258, 968);
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
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
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
    }
}

