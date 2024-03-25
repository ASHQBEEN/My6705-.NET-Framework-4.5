namespace My6705.NET_Framework_4._5
{
    partial class WireTest
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
            this.testHandlerTimer = new System.Windows.Forms.Timer(this.components);
            this.tbTestResult = new System.Windows.Forms.TextBox();
            this.cbBoundSet = new System.Windows.Forms.CheckBox();
            this.nudForceBound = new System.Windows.Forms.NumericUpDown();
            this.rbBreakTest = new System.Windows.Forms.RadioButton();
            this.rbStretchTest = new System.Windows.Forms.RadioButton();
            this.rbShearTest = new System.Windows.Forms.RadioButton();
            this.tbTestValues = new System.Windows.Forms.RichTextBox();
            this.cmbTests = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSetTestPoint = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnMoveToStart = new System.Windows.Forms.Button();
            this.lblCOMValues = new System.Windows.Forms.Label();
            this.lblTestResult = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnLockWire = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.zgcGraph = new ZedGraph.ZedGraphControl();
            this.nudWireBreakDelay = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.nudTestSpeed = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnLoadTestSpeed = new System.Windows.Forms.Button();
            this.btnSaveTestSpeed = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudForceBound)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWireBreakDelay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTestSpeed)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // testHandlerTimer
            // 
            this.testHandlerTimer.Interval = 250;
            this.testHandlerTimer.Tick += new System.EventHandler(this.testHandlerTimer_Tick);
            // 
            // tbTestResult
            // 
            this.tbTestResult.Location = new System.Drawing.Point(1256, 463);
            this.tbTestResult.Name = "tbTestResult";
            this.tbTestResult.ReadOnly = true;
            this.tbTestResult.Size = new System.Drawing.Size(144, 26);
            this.tbTestResult.TabIndex = 1;
            // 
            // cbBoundSet
            // 
            this.cbBoundSet.AutoSize = true;
            this.cbBoundSet.Location = new System.Drawing.Point(86, 213);
            this.cbBoundSet.Name = "cbBoundSet";
            this.cbBoundSet.Size = new System.Drawing.Size(142, 24);
            this.cbBoundSet.TabIndex = 2;
            this.cbBoundSet.Text = "Огр. усилие, г:";
            this.cbBoundSet.UseVisualStyleBackColor = true;
            // 
            // nudForceBound
            // 
            this.nudForceBound.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudForceBound.Location = new System.Drawing.Point(233, 212);
            this.nudForceBound.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.nudForceBound.Name = "nudForceBound";
            this.nudForceBound.Size = new System.Drawing.Size(99, 26);
            this.nudForceBound.TabIndex = 3;
            this.nudForceBound.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            // 
            // rbBreakTest
            // 
            this.rbBreakTest.AutoSize = true;
            this.rbBreakTest.Checked = true;
            this.rbBreakTest.Location = new System.Drawing.Point(11, 25);
            this.rbBreakTest.Name = "rbBreakTest";
            this.rbBreakTest.Size = new System.Drawing.Size(90, 24);
            this.rbBreakTest.TabIndex = 4;
            this.rbBreakTest.TabStop = true;
            this.rbBreakTest.Text = "Разрыв";
            this.rbBreakTest.UseVisualStyleBackColor = true;
            this.rbBreakTest.CheckedChanged += new System.EventHandler(this.rbBreakTest_CheckedChanged);
            // 
            // rbStretchTest
            // 
            this.rbStretchTest.AutoSize = true;
            this.rbStretchTest.Location = new System.Drawing.Point(112, 25);
            this.rbStretchTest.Name = "rbStretchTest";
            this.rbStretchTest.Size = new System.Drawing.Size(126, 24);
            this.rbStretchTest.TabIndex = 5;
            this.rbStretchTest.TabStop = true;
            this.rbStretchTest.Text = "Растяжение";
            this.rbStretchTest.UseVisualStyleBackColor = true;
            this.rbStretchTest.CheckedChanged += new System.EventHandler(this.rbStretchTest_CheckedChanged);
            // 
            // rbShearTest
            // 
            this.rbShearTest.AutoSize = true;
            this.rbShearTest.Location = new System.Drawing.Point(252, 25);
            this.rbShearTest.Name = "rbShearTest";
            this.rbShearTest.Size = new System.Drawing.Size(81, 24);
            this.rbShearTest.TabIndex = 6;
            this.rbShearTest.TabStop = true;
            this.rbShearTest.Text = "Сдвиг";
            this.rbShearTest.UseVisualStyleBackColor = true;
            this.rbShearTest.CheckedChanged += new System.EventHandler(this.rbShearTest_CheckedChanged);
            // 
            // tbTestValues
            // 
            this.tbTestValues.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbTestValues.Location = new System.Drawing.Point(1120, 404);
            this.tbTestValues.Name = "tbTestValues";
            this.tbTestValues.ReadOnly = true;
            this.tbTestValues.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.tbTestValues.Size = new System.Drawing.Size(280, 53);
            this.tbTestValues.TabIndex = 7;
            this.tbTestValues.Text = "";
            // 
            // cmbTests
            // 
            this.cmbTests.FormattingEnabled = true;
            this.cmbTests.Location = new System.Drawing.Point(415, 12);
            this.cmbTests.Name = "cmbTests";
            this.cmbTests.Size = new System.Drawing.Size(268, 28);
            this.cmbTests.TabIndex = 8;
            this.cmbTests.SelectedIndexChanged += new System.EventHandler(this.cmbTests_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(55, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "1500";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(164, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "1500";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(277, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 20);
            this.label3.TabIndex = 11;
            this.label3.Text = "1500";
            // 
            // btnSetTestPoint
            // 
            this.btnSetTestPoint.Location = new System.Drawing.Point(1267, 512);
            this.btnSetTestPoint.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSetTestPoint.Name = "btnSetTestPoint";
            this.btnSetTestPoint.Size = new System.Drawing.Size(144, 67);
            this.btnSetTestPoint.TabIndex = 16;
            this.btnSetTestPoint.Text = "Обучить координату";
            this.btnSetTestPoint.UseVisualStyleBackColor = true;
            this.btnSetTestPoint.Click += new System.EventHandler(this.btnSetTestPoint_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(248, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 20);
            this.label4.TabIndex = 19;
            this.label4.Text = "Z:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(134, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 20);
            this.label5.TabIndex = 18;
            this.label5.Text = "Y:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(24, 20);
            this.label6.TabIndex = 17;
            this.label6.Text = "X:";
            // 
            // btnMoveToStart
            // 
            this.btnMoveToStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnMoveToStart.Location = new System.Drawing.Point(1101, 512);
            this.btnMoveToStart.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnMoveToStart.Name = "btnMoveToStart";
            this.btnMoveToStart.Size = new System.Drawing.Size(152, 67);
            this.btnMoveToStart.TabIndex = 20;
            this.btnMoveToStart.Text = "В точку теста";
            this.btnMoveToStart.UseVisualStyleBackColor = true;
            this.btnMoveToStart.Click += new System.EventHandler(this.btnToStartPosition_Click);
            // 
            // lblCOMValues
            // 
            this.lblCOMValues.AutoSize = true;
            this.lblCOMValues.Location = new System.Drawing.Point(1214, 381);
            this.lblCOMValues.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCOMValues.Name = "lblCOMValues";
            this.lblCOMValues.Size = new System.Drawing.Size(148, 20);
            this.lblCOMValues.TabIndex = 21;
            this.lblCOMValues.Text = "Тестовые данные:";
            // 
            // lblTestResult
            // 
            this.lblTestResult.AutoSize = true;
            this.lblTestResult.Location = new System.Drawing.Point(1116, 466);
            this.lblTestResult.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTestResult.Name = "lblTestResult";
            this.lblTestResult.Size = new System.Drawing.Size(126, 20);
            this.lblTestResult.TabIndex = 22;
            this.lblTestResult.Text = "Макс. усилие, г:";
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnStart.Location = new System.Drawing.Point(1101, 589);
            this.btnStart.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(152, 77);
            this.btnStart.TabIndex = 23;
            this.btnStart.Text = "Начать измерение";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.Start);
            // 
            // btnLockWire
            // 
            this.btnLockWire.Location = new System.Drawing.Point(1265, 589);
            this.btnLockWire.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnLockWire.Name = "btnLockWire";
            this.btnLockWire.Size = new System.Drawing.Size(145, 77);
            this.btnLockWire.TabIndex = 24;
            this.btnLockWire.Text = "Зафиксировать\r\nпроволоку\r\nCAPSLOCK\r\n";
            this.btnLockWire.UseVisualStyleBackColor = true;
            this.btnLockWire.Click += new System.EventHandler(this.btnLockWire_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(297, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(112, 20);
            this.label7.TabIndex = 25;
            this.label7.Text = "№ Измерения";
            // 
            // zgcGraph
            // 
            this.zgcGraph.Location = new System.Drawing.Point(13, 48);
            this.zgcGraph.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.zgcGraph.Name = "zgcGraph";
            this.zgcGraph.ScrollGrace = 0D;
            this.zgcGraph.ScrollMaxX = 0D;
            this.zgcGraph.ScrollMaxY = 0D;
            this.zgcGraph.ScrollMaxY2 = 0D;
            this.zgcGraph.ScrollMinX = 0D;
            this.zgcGraph.ScrollMinY = 0D;
            this.zgcGraph.ScrollMinY2 = 0D;
            this.zgcGraph.Size = new System.Drawing.Size(1040, 594);
            this.zgcGraph.TabIndex = 27;
            this.zgcGraph.UseExtendedPrintDialog = true;
            // 
            // nudWireBreakDelay
            // 
            this.nudWireBreakDelay.Location = new System.Drawing.Point(234, 173);
            this.nudWireBreakDelay.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudWireBreakDelay.Name = "nudWireBreakDelay";
            this.nudWireBreakDelay.Size = new System.Drawing.Size(99, 26);
            this.nudWireBreakDelay.TabIndex = 29;
            this.nudWireBreakDelay.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(5, 175);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(223, 20);
            this.label9.TabIndex = 30;
            this.label9.Text = "Задержка после разрыва, c:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(23, 62);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(203, 20);
            this.label10.TabIndex = 32;
            this.label10.Text = "Скорость при тесте, мк/с:";
            // 
            // nudTestSpeed
            // 
            this.nudTestSpeed.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nudTestSpeed.Location = new System.Drawing.Point(234, 60);
            this.nudTestSpeed.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudTestSpeed.Name = "nudTestSpeed";
            this.nudTestSpeed.Size = new System.Drawing.Size(99, 26);
            this.nudTestSpeed.TabIndex = 31;
            this.nudTestSpeed.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.nudTestSpeed.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            this.nudTestSpeed.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nudTestSpeed_KeyDown);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(1075, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(379, 351);
            this.groupBox1.TabIndex = 33;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Настройки теста";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Location = new System.Drawing.Point(16, 290);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(347, 55);
            this.groupBox3.TabIndex = 34;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Точка теста:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnLoadTestSpeed);
            this.groupBox2.Controls.Add(this.btnSaveTestSpeed);
            this.groupBox2.Controls.Add(this.nudForceBound);
            this.groupBox2.Controls.Add(this.rbShearTest);
            this.groupBox2.Controls.Add(this.cbBoundSet);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.nudWireBreakDelay);
            this.groupBox2.Controls.Add(this.rbBreakTest);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.nudTestSpeed);
            this.groupBox2.Controls.Add(this.rbStretchTest);
            this.groupBox2.Location = new System.Drawing.Point(16, 25);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(347, 251);
            this.groupBox2.TabIndex = 34;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Тип теста:";
            // 
            // btnLoadTestSpeed
            // 
            this.btnLoadTestSpeed.Location = new System.Drawing.Point(197, 100);
            this.btnLoadTestSpeed.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnLoadTestSpeed.Name = "btnLoadTestSpeed";
            this.btnLoadTestSpeed.Size = new System.Drawing.Size(112, 52);
            this.btnLoadTestSpeed.TabIndex = 35;
            this.btnLoadTestSpeed.Text = "Загрузить скорости";
            this.btnLoadTestSpeed.UseVisualStyleBackColor = true;
            this.btnLoadTestSpeed.Click += new System.EventHandler(this.btnLoadTestSpeed_Click);
            // 
            // btnSaveTestSpeed
            // 
            this.btnSaveTestSpeed.Location = new System.Drawing.Point(39, 100);
            this.btnSaveTestSpeed.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSaveTestSpeed.Name = "btnSaveTestSpeed";
            this.btnSaveTestSpeed.Size = new System.Drawing.Size(112, 52);
            this.btnSaveTestSpeed.TabIndex = 34;
            this.btnSaveTestSpeed.Text = "Сохранить скорости";
            this.btnSaveTestSpeed.UseVisualStyleBackColor = true;
            this.btnSaveTestSpeed.Click += new System.EventHandler(this.btnSaveTestSpeed_Click);
            // 
            // WireTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1473, 696);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.zgcGraph);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnLockWire);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.lblTestResult);
            this.Controls.Add(this.lblCOMValues);
            this.Controls.Add(this.btnMoveToStart);
            this.Controls.Add(this.btnSetTestPoint);
            this.Controls.Add(this.cmbTests);
            this.Controls.Add(this.tbTestValues);
            this.Controls.Add(this.tbTestResult);
            this.Name = "WireTest";
            this.Text = "Тест прочности";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.WireTest_FormClosed);
            this.Load += new System.EventHandler(this.WireTest_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.StopTestBySpaceKey);
            ((System.ComponentModel.ISupportInitialize)(this.nudForceBound)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWireBreakDelay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTestSpeed)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer testHandlerTimer;
        private System.Windows.Forms.TextBox tbTestResult;
        private System.Windows.Forms.CheckBox cbBoundSet;
        private System.Windows.Forms.NumericUpDown nudForceBound;
        private System.Windows.Forms.RadioButton rbBreakTest;
        private System.Windows.Forms.RadioButton rbStretchTest;
        private System.Windows.Forms.RadioButton rbShearTest;
        private System.Windows.Forms.RichTextBox tbTestValues;
        private System.Windows.Forms.ComboBox cmbTests;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSetTestPoint;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnMoveToStart;
        private System.Windows.Forms.Label lblCOMValues;
        private System.Windows.Forms.Label lblTestResult;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnLockWire;
        private System.Windows.Forms.Label label7;
        private ZedGraph.ZedGraphControl zgcGraph;
        private System.Windows.Forms.NumericUpDown nudWireBreakDelay;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown nudTestSpeed;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnLoadTestSpeed;
        private System.Windows.Forms.Button btnSaveTestSpeed;
    }
}