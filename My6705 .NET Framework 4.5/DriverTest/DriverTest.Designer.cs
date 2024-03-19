namespace My6705.NET_Framework_4._5
{
    partial class DriverTest
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
            this.nudPosition1X = new System.Windows.Forms.NumericUpDown();
            this.nudPosition1Y = new System.Windows.Forms.NumericUpDown();
            this.nudPosition1Z = new System.Windows.Forms.NumericUpDown();
            this.nudPosition1Phi = new System.Windows.Forms.NumericUpDown();
            this.nudPosition2X = new System.Windows.Forms.NumericUpDown();
            this.nudPosition2Y = new System.Windows.Forms.NumericUpDown();
            this.nudPosition2Z = new System.Windows.Forms.NumericUpDown();
            this.nudPosition2Phi = new System.Windows.Forms.NumericUpDown();
            this.tbInterpolationState = new System.Windows.Forms.TextBox();
            this.tmrInterpolationGroupState = new System.Windows.Forms.Timer(this.components);
            this.nudDelay = new System.Windows.Forms.NumericUpDown();
            this.cbAddAxisPhi = new System.Windows.Forms.CheckBox();
            this.cbAddAxisZ = new System.Windows.Forms.CheckBox();
            this.cbAddAxisY = new System.Windows.Forms.CheckBox();
            this.cbAddAxisX = new System.Windows.Forms.CheckBox();
            this.btnStartInterpolatedMovement = new System.Windows.Forms.Button();
            this.rbBackAndForth = new System.Windows.Forms.RadioButton();
            this.rbStep = new System.Windows.Forms.RadioButton();
            this.rbDriveX = new System.Windows.Forms.RadioButton();
            this.rbDriveY = new System.Windows.Forms.RadioButton();
            this.rbDriveZ = new System.Windows.Forms.RadioButton();
            this.rbDrivePhi = new System.Windows.Forms.RadioButton();
            this.lblDelay = new System.Windows.Forms.Label();
            this.lblGpDriveAx = new System.Windows.Forms.Label();
            this.lblPos2 = new System.Windows.Forms.Label();
            this.lblPos1 = new System.Windows.Forms.Label();
            this.lblAddAx = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.driverTestTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.nudPosition1X)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPosition1Y)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPosition1Z)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPosition1Phi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPosition2X)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPosition2Y)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPosition2Z)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPosition2Phi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDelay)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // nudPosition1X
            // 
            this.nudPosition1X.Enabled = false;
            this.nudPosition1X.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudPosition1X.Location = new System.Drawing.Point(117, 58);
            this.nudPosition1X.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudPosition1X.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudPosition1X.Name = "nudPosition1X";
            this.nudPosition1X.Size = new System.Drawing.Size(150, 26);
            this.nudPosition1X.TabIndex = 0;
            this.nudPosition1X.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.nudPosition1X.ValueChanged += new System.EventHandler(this.nudPosition1X_ValueChanged);
            // 
            // nudPosition1Y
            // 
            this.nudPosition1Y.Enabled = false;
            this.nudPosition1Y.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudPosition1Y.Location = new System.Drawing.Point(117, 97);
            this.nudPosition1Y.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudPosition1Y.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudPosition1Y.Name = "nudPosition1Y";
            this.nudPosition1Y.Size = new System.Drawing.Size(150, 26);
            this.nudPosition1Y.TabIndex = 1;
            this.nudPosition1Y.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.nudPosition1Y.ValueChanged += new System.EventHandler(this.nudPosition1Y_ValueChanged);
            // 
            // nudPosition1Z
            // 
            this.nudPosition1Z.Enabled = false;
            this.nudPosition1Z.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudPosition1Z.Location = new System.Drawing.Point(117, 135);
            this.nudPosition1Z.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudPosition1Z.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudPosition1Z.Name = "nudPosition1Z";
            this.nudPosition1Z.Size = new System.Drawing.Size(150, 26);
            this.nudPosition1Z.TabIndex = 2;
            this.nudPosition1Z.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.nudPosition1Z.ValueChanged += new System.EventHandler(this.nudPosition1Z_ValueChanged);
            // 
            // nudPosition1Phi
            // 
            this.nudPosition1Phi.Enabled = false;
            this.nudPosition1Phi.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudPosition1Phi.Location = new System.Drawing.Point(117, 174);
            this.nudPosition1Phi.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudPosition1Phi.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudPosition1Phi.Name = "nudPosition1Phi";
            this.nudPosition1Phi.Size = new System.Drawing.Size(150, 26);
            this.nudPosition1Phi.TabIndex = 3;
            this.nudPosition1Phi.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.nudPosition1Phi.ValueChanged += new System.EventHandler(this.nudPosition1Phi_ValueChanged);
            // 
            // nudPosition2X
            // 
            this.nudPosition2X.Enabled = false;
            this.nudPosition2X.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudPosition2X.Location = new System.Drawing.Point(340, 54);
            this.nudPosition2X.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudPosition2X.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudPosition2X.Name = "nudPosition2X";
            this.nudPosition2X.Size = new System.Drawing.Size(150, 26);
            this.nudPosition2X.TabIndex = 4;
            this.nudPosition2X.Value = new decimal(new int[] {
            8000,
            0,
            0,
            0});
            this.nudPosition2X.ValueChanged += new System.EventHandler(this.nudPosition2X_ValueChanged);
            // 
            // nudPosition2Y
            // 
            this.nudPosition2Y.Enabled = false;
            this.nudPosition2Y.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudPosition2Y.Location = new System.Drawing.Point(340, 94);
            this.nudPosition2Y.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudPosition2Y.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudPosition2Y.Name = "nudPosition2Y";
            this.nudPosition2Y.Size = new System.Drawing.Size(150, 26);
            this.nudPosition2Y.TabIndex = 5;
            this.nudPosition2Y.Value = new decimal(new int[] {
            8000,
            0,
            0,
            0});
            this.nudPosition2Y.ValueChanged += new System.EventHandler(this.nudPosition2Y_ValueChanged);
            // 
            // nudPosition2Z
            // 
            this.nudPosition2Z.Enabled = false;
            this.nudPosition2Z.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudPosition2Z.Location = new System.Drawing.Point(340, 134);
            this.nudPosition2Z.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudPosition2Z.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudPosition2Z.Name = "nudPosition2Z";
            this.nudPosition2Z.Size = new System.Drawing.Size(150, 26);
            this.nudPosition2Z.TabIndex = 6;
            this.nudPosition2Z.Value = new decimal(new int[] {
            8000,
            0,
            0,
            0});
            this.nudPosition2Z.ValueChanged += new System.EventHandler(this.nudPosition2Z_ValueChanged);
            // 
            // nudPosition2Phi
            // 
            this.nudPosition2Phi.Enabled = false;
            this.nudPosition2Phi.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudPosition2Phi.Location = new System.Drawing.Point(340, 174);
            this.nudPosition2Phi.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudPosition2Phi.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudPosition2Phi.Name = "nudPosition2Phi";
            this.nudPosition2Phi.Size = new System.Drawing.Size(150, 26);
            this.nudPosition2Phi.TabIndex = 7;
            this.nudPosition2Phi.Value = new decimal(new int[] {
            8000,
            0,
            0,
            0});
            this.nudPosition2Phi.ValueChanged += new System.EventHandler(this.nudPosition2Phi_ValueChanged);
            // 
            // tbInterpolationState
            // 
            this.tbInterpolationState.Location = new System.Drawing.Point(442, 234);
            this.tbInterpolationState.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbInterpolationState.Name = "tbInterpolationState";
            this.tbInterpolationState.ReadOnly = true;
            this.tbInterpolationState.Size = new System.Drawing.Size(134, 26);
            this.tbInterpolationState.TabIndex = 8;
            // 
            // tmrInterpolationGroupState
            // 
            this.tmrInterpolationGroupState.Tick += new System.EventHandler(this.tmrInterpolationGroupState_Tick);
            // 
            // nudDelay
            // 
            this.nudDelay.Location = new System.Drawing.Point(340, 235);
            this.nudDelay.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudDelay.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudDelay.Name = "nudDelay";
            this.nudDelay.Size = new System.Drawing.Size(93, 26);
            this.nudDelay.TabIndex = 10;
            this.nudDelay.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // cbAddAxisPhi
            // 
            this.cbAddAxisPhi.AutoSize = true;
            this.cbAddAxisPhi.Location = new System.Drawing.Point(34, 175);
            this.cbAddAxisPhi.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbAddAxisPhi.Name = "cbAddAxisPhi";
            this.cbAddAxisPhi.Size = new System.Drawing.Size(44, 24);
            this.cbAddAxisPhi.TabIndex = 15;
            this.cbAddAxisPhi.Text = "φ";
            this.cbAddAxisPhi.UseVisualStyleBackColor = true;
            this.cbAddAxisPhi.CheckedChanged += new System.EventHandler(this.cbAddAxisPhi_CheckedChanged);
            // 
            // cbAddAxisZ
            // 
            this.cbAddAxisZ.AutoSize = true;
            this.cbAddAxisZ.Location = new System.Drawing.Point(34, 137);
            this.cbAddAxisZ.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbAddAxisZ.Name = "cbAddAxisZ";
            this.cbAddAxisZ.Size = new System.Drawing.Size(45, 24);
            this.cbAddAxisZ.TabIndex = 14;
            this.cbAddAxisZ.Text = "Z";
            this.cbAddAxisZ.UseVisualStyleBackColor = true;
            this.cbAddAxisZ.CheckedChanged += new System.EventHandler(this.cbAddAxisZ_CheckedChanged);
            // 
            // cbAddAxisY
            // 
            this.cbAddAxisY.AutoSize = true;
            this.cbAddAxisY.Location = new System.Drawing.Point(34, 98);
            this.cbAddAxisY.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbAddAxisY.Name = "cbAddAxisY";
            this.cbAddAxisY.Size = new System.Drawing.Size(46, 24);
            this.cbAddAxisY.TabIndex = 13;
            this.cbAddAxisY.Text = "Y";
            this.cbAddAxisY.UseVisualStyleBackColor = true;
            this.cbAddAxisY.CheckedChanged += new System.EventHandler(this.cbAddAxisY_CheckedChanged);
            // 
            // cbAddAxisX
            // 
            this.cbAddAxisX.AutoSize = true;
            this.cbAddAxisX.Location = new System.Drawing.Point(34, 60);
            this.cbAddAxisX.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbAddAxisX.Name = "cbAddAxisX";
            this.cbAddAxisX.Size = new System.Drawing.Size(46, 24);
            this.cbAddAxisX.TabIndex = 12;
            this.cbAddAxisX.Text = "X";
            this.cbAddAxisX.UseVisualStyleBackColor = true;
            this.cbAddAxisX.CheckedChanged += new System.EventHandler(this.cbAddAxisX_CheckedChanged);
            // 
            // btnStartInterpolatedMovement
            // 
            this.btnStartInterpolatedMovement.Location = new System.Drawing.Point(34, 235);
            this.btnStartInterpolatedMovement.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnStartInterpolatedMovement.Name = "btnStartInterpolatedMovement";
            this.btnStartInterpolatedMovement.Size = new System.Drawing.Size(196, 63);
            this.btnStartInterpolatedMovement.TabIndex = 16;
            this.btnStartInterpolatedMovement.Text = "Начать\r\nдвижение";
            this.btnStartInterpolatedMovement.UseVisualStyleBackColor = true;
            this.btnStartInterpolatedMovement.Click += new System.EventHandler(this.btnStartTestClick);
            // 
            // rbBackAndForth
            // 
            this.rbBackAndForth.AutoSize = true;
            this.rbBackAndForth.Checked = true;
            this.rbBackAndForth.Location = new System.Drawing.Point(22, -3);
            this.rbBackAndForth.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbBackAndForth.Name = "rbBackAndForth";
            this.rbBackAndForth.Size = new System.Drawing.Size(72, 24);
            this.rbBackAndForth.TabIndex = 17;
            this.rbBackAndForth.TabStop = true;
            this.rbBackAndForth.Text = "Авто";
            this.rbBackAndForth.UseVisualStyleBackColor = true;
            // 
            // rbStep
            // 
            this.rbStep.AutoSize = true;
            this.rbStep.Location = new System.Drawing.Point(112, -3);
            this.rbStep.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbStep.Name = "rbStep";
            this.rbStep.Size = new System.Drawing.Size(63, 24);
            this.rbStep.TabIndex = 18;
            this.rbStep.TabStop = true;
            this.rbStep.Text = "Шаг";
            this.rbStep.UseVisualStyleBackColor = true;
            // 
            // rbDriveX
            // 
            this.rbDriveX.AutoSize = true;
            this.rbDriveX.Enabled = false;
            this.rbDriveX.Location = new System.Drawing.Point(526, 57);
            this.rbDriveX.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbDriveX.Name = "rbDriveX";
            this.rbDriveX.Size = new System.Drawing.Size(38, 24);
            this.rbDriveX.TabIndex = 20;
            this.rbDriveX.TabStop = true;
            this.rbDriveX.Text = " ";
            this.rbDriveX.UseVisualStyleBackColor = true;
            // 
            // rbDriveY
            // 
            this.rbDriveY.AutoSize = true;
            this.rbDriveY.Enabled = false;
            this.rbDriveY.Location = new System.Drawing.Point(526, 95);
            this.rbDriveY.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbDriveY.Name = "rbDriveY";
            this.rbDriveY.Size = new System.Drawing.Size(38, 24);
            this.rbDriveY.TabIndex = 21;
            this.rbDriveY.TabStop = true;
            this.rbDriveY.Text = " ";
            this.rbDriveY.UseVisualStyleBackColor = true;
            // 
            // rbDriveZ
            // 
            this.rbDriveZ.AutoSize = true;
            this.rbDriveZ.Enabled = false;
            this.rbDriveZ.Location = new System.Drawing.Point(526, 137);
            this.rbDriveZ.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbDriveZ.Name = "rbDriveZ";
            this.rbDriveZ.Size = new System.Drawing.Size(38, 24);
            this.rbDriveZ.TabIndex = 22;
            this.rbDriveZ.TabStop = true;
            this.rbDriveZ.Text = " ";
            this.rbDriveZ.UseVisualStyleBackColor = true;
            // 
            // rbDrivePhi
            // 
            this.rbDrivePhi.AutoSize = true;
            this.rbDrivePhi.Enabled = false;
            this.rbDrivePhi.Location = new System.Drawing.Point(526, 178);
            this.rbDrivePhi.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbDrivePhi.Name = "rbDrivePhi";
            this.rbDrivePhi.Size = new System.Drawing.Size(38, 24);
            this.rbDrivePhi.TabIndex = 23;
            this.rbDrivePhi.TabStop = true;
            this.rbDrivePhi.Text = " ";
            this.rbDrivePhi.UseVisualStyleBackColor = true;
            // 
            // lblDelay
            // 
            this.lblDelay.AutoSize = true;
            this.lblDelay.Location = new System.Drawing.Point(244, 238);
            this.lblDelay.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDelay.Name = "lblDelay";
            this.lblDelay.Size = new System.Drawing.Size(86, 20);
            this.lblDelay.TabIndex = 29;
            this.lblDelay.Text = "Задержка";
            // 
            // lblGpDriveAx
            // 
            this.lblGpDriveAx.AutoSize = true;
            this.lblGpDriveAx.Location = new System.Drawing.Point(496, 9);
            this.lblGpDriveAx.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGpDriveAx.Name = "lblGpDriveAx";
            this.lblGpDriveAx.Size = new System.Drawing.Size(82, 40);
            this.lblGpDriveAx.TabIndex = 28;
            this.lblGpDriveAx.Text = "Ведущая \r\nось";
            this.lblGpDriveAx.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPos2
            // 
            this.lblPos2.AutoSize = true;
            this.lblPos2.Location = new System.Drawing.Point(362, 9);
            this.lblPos2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPos2.Name = "lblPos2";
            this.lblPos2.Size = new System.Drawing.Size(104, 40);
            this.lblPos2.TabIndex = 27;
            this.lblPos2.Text = "Координаты\r\nпозиции 2";
            this.lblPos2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPos1
            // 
            this.lblPos1.AutoSize = true;
            this.lblPos1.Location = new System.Drawing.Point(135, 14);
            this.lblPos1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPos1.Name = "lblPos1";
            this.lblPos1.Size = new System.Drawing.Size(104, 40);
            this.lblPos1.TabIndex = 26;
            this.lblPos1.Text = "Координаты\r\nпозиции 1";
            this.lblPos1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAddAx
            // 
            this.lblAddAx.AutoSize = true;
            this.lblAddAx.Location = new System.Drawing.Point(18, 14);
            this.lblAddAx.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAddAx.Name = "lblAddAx";
            this.lblAddAx.Size = new System.Drawing.Size(84, 40);
            this.lblAddAx.TabIndex = 25;
            this.lblAddAx.Text = "Добавить\r\nось";
            this.lblAddAx.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rbStep);
            this.panel1.Controls.Add(this.rbBackAndForth);
            this.panel1.Location = new System.Drawing.Point(240, 275);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(201, 23);
            this.panel1.TabIndex = 30;
            // 
            // driverTestTimer
            // 
            this.driverTestTimer.Interval = 10;
            this.driverTestTimer.Tick += new System.EventHandler(this.driverTestTimer_Tick);
            // 
            // DriverTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 323);
            this.Controls.Add(this.rbDrivePhi);
            this.Controls.Add(this.rbDriveX);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.rbDriveZ);
            this.Controls.Add(this.lblDelay);
            this.Controls.Add(this.rbDriveY);
            this.Controls.Add(this.lblGpDriveAx);
            this.Controls.Add(this.lblPos2);
            this.Controls.Add(this.lblPos1);
            this.Controls.Add(this.lblAddAx);
            this.Controls.Add(this.btnStartInterpolatedMovement);
            this.Controls.Add(this.cbAddAxisPhi);
            this.Controls.Add(this.cbAddAxisZ);
            this.Controls.Add(this.cbAddAxisY);
            this.Controls.Add(this.cbAddAxisX);
            this.Controls.Add(this.nudDelay);
            this.Controls.Add(this.tbInterpolationState);
            this.Controls.Add(this.nudPosition2Phi);
            this.Controls.Add(this.nudPosition2Z);
            this.Controls.Add(this.nudPosition2Y);
            this.Controls.Add(this.nudPosition2X);
            this.Controls.Add(this.nudPosition1Phi);
            this.Controls.Add(this.nudPosition1Z);
            this.Controls.Add(this.nudPosition1Y);
            this.Controls.Add(this.nudPosition1X);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "DriverTest";
            this.Text = "Тест приводов";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DriverTest_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.nudPosition1X)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPosition1Y)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPosition1Z)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPosition1Phi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPosition2X)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPosition2Y)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPosition2Z)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPosition2Phi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDelay)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nudPosition1X;
        private System.Windows.Forms.NumericUpDown nudPosition1Y;
        private System.Windows.Forms.NumericUpDown nudPosition1Z;
        private System.Windows.Forms.NumericUpDown nudPosition1Phi;
        private System.Windows.Forms.NumericUpDown nudPosition2X;
        private System.Windows.Forms.NumericUpDown nudPosition2Y;
        private System.Windows.Forms.NumericUpDown nudPosition2Z;
        private System.Windows.Forms.NumericUpDown nudPosition2Phi;
        private System.Windows.Forms.TextBox tbInterpolationState;
        private System.Windows.Forms.Timer tmrInterpolationGroupState;
        private System.Windows.Forms.NumericUpDown nudDelay;
        private System.Windows.Forms.CheckBox cbAddAxisPhi;
        private System.Windows.Forms.CheckBox cbAddAxisZ;
        private System.Windows.Forms.CheckBox cbAddAxisY;
        private System.Windows.Forms.CheckBox cbAddAxisX;
        private System.Windows.Forms.RadioButton rbBackAndForth;
        private System.Windows.Forms.RadioButton rbStep;
        private System.Windows.Forms.RadioButton rbDriveX;
        private System.Windows.Forms.RadioButton rbDriveY;
        private System.Windows.Forms.RadioButton rbDriveZ;
        private System.Windows.Forms.RadioButton rbDrivePhi;
        private System.Windows.Forms.Label lblDelay;
        private System.Windows.Forms.Label lblGpDriveAx;
        private System.Windows.Forms.Label lblPos2;
        private System.Windows.Forms.Label lblPos1;
        private System.Windows.Forms.Label lblAddAx;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnStartInterpolatedMovement;
        private System.Windows.Forms.Timer driverTestTimer;
    }
}