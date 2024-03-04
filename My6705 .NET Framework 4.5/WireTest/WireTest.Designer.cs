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
            this.rtbTestValues = new System.Windows.Forms.RichTextBox();
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
            this.lblMaxCOMValue = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnFixWire = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            ((System.ComponentModel.ISupportInitialize)(this.nudForceBound)).BeginInit();
            this.SuspendLayout();
            // 
            // testHandlerTimer
            // 
            this.testHandlerTimer.Interval = 250;
            this.testHandlerTimer.Tick += new System.EventHandler(this.testHandlerTimer_Tick);
            // 
            // tbTestResult
            // 
            this.tbTestResult.Location = new System.Drawing.Point(959, 167);
            this.tbTestResult.Name = "tbTestResult";
            this.tbTestResult.ReadOnly = true;
            this.tbTestResult.Size = new System.Drawing.Size(144, 26);
            this.tbTestResult.TabIndex = 1;
            // 
            // cbBoundSet
            // 
            this.cbBoundSet.AutoSize = true;
            this.cbBoundSet.Location = new System.Drawing.Point(803, 206);
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
            this.nudForceBound.Location = new System.Drawing.Point(959, 206);
            this.nudForceBound.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.nudForceBound.Name = "nudForceBound";
            this.nudForceBound.Size = new System.Drawing.Size(144, 26);
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
            this.rbBreakTest.Location = new System.Drawing.Point(819, 46);
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
            this.rbStretchTest.Location = new System.Drawing.Point(819, 83);
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
            this.rbShearTest.Location = new System.Drawing.Point(819, 122);
            this.rbShearTest.Name = "rbShearTest";
            this.rbShearTest.Size = new System.Drawing.Size(81, 24);
            this.rbShearTest.TabIndex = 6;
            this.rbShearTest.TabStop = true;
            this.rbShearTest.Text = "Сдвиг";
            this.rbShearTest.UseVisualStyleBackColor = true;
            this.rbShearTest.CheckedChanged += new System.EventHandler(this.rbShearTest_CheckedChanged);
            // 
            // rtbTestValues
            // 
            this.rtbTestValues.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtbTestValues.Location = new System.Drawing.Point(959, 38);
            this.rtbTestValues.Name = "rtbTestValues";
            this.rtbTestValues.ReadOnly = true;
            this.rtbTestValues.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rtbTestValues.Size = new System.Drawing.Size(144, 108);
            this.rtbTestValues.TabIndex = 7;
            this.rtbTestValues.Text = "";
            // 
            // cmbTests
            // 
            this.cmbTests.FormattingEnabled = true;
            this.cmbTests.Location = new System.Drawing.Point(292, 12);
            this.cmbTests.Name = "cmbTests";
            this.cmbTests.Size = new System.Drawing.Size(247, 28);
            this.cmbTests.TabIndex = 8;
            this.cmbTests.Text = "Выберите номер измерения";
            this.cmbTests.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(829, 257);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(938, 257);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1051, 257);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 20);
            this.label3.TabIndex = 11;
            this.label3.Text = "label3";
            // 
            // btnSetTestPoint
            // 
            this.btnSetTestPoint.Location = new System.Drawing.Point(959, 298);
            this.btnSetTestPoint.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSetTestPoint.Name = "btnSetTestPoint";
            this.btnSetTestPoint.Size = new System.Drawing.Size(144, 67);
            this.btnSetTestPoint.TabIndex = 16;
            this.btnSetTestPoint.Text = "Обучить координату";
            this.btnSetTestPoint.UseVisualStyleBackColor = true;
            this.btnSetTestPoint.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1022, 257);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 20);
            this.label4.TabIndex = 19;
            this.label4.Text = "Z:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(908, 257);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 20);
            this.label5.TabIndex = 18;
            this.label5.Text = "Y:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(799, 257);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(24, 20);
            this.label6.TabIndex = 17;
            this.label6.Text = "X:";
            // 
            // btnMoveToStart
            // 
            this.btnMoveToStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnMoveToStart.Location = new System.Drawing.Point(793, 298);
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
            this.lblCOMValues.Location = new System.Drawing.Point(955, 15);
            this.lblCOMValues.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCOMValues.Name = "lblCOMValues";
            this.lblCOMValues.Size = new System.Drawing.Size(148, 20);
            this.lblCOMValues.TabIndex = 21;
            this.lblCOMValues.Text = "Тестовые данные:";
            // 
            // lblMaxCOMValue
            // 
            this.lblMaxCOMValue.AutoSize = true;
            this.lblMaxCOMValue.Location = new System.Drawing.Point(819, 170);
            this.lblMaxCOMValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMaxCOMValue.Name = "lblMaxCOMValue";
            this.lblMaxCOMValue.Size = new System.Drawing.Size(126, 20);
            this.lblMaxCOMValue.TabIndex = 22;
            this.lblMaxCOMValue.Text = "Макс. усилие, г:";
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnStart.Location = new System.Drawing.Point(793, 375);
            this.btnStart.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(152, 77);
            this.btnStart.TabIndex = 23;
            this.btnStart.Text = "Начать измерение";
            this.btnStart.UseVisualStyleBackColor = true;
            // 
            // btnFixWire
            // 
            this.btnFixWire.Location = new System.Drawing.Point(957, 375);
            this.btnFixWire.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnFixWire.Name = "btnFixWire";
            this.btnFixWire.Size = new System.Drawing.Size(145, 77);
            this.btnFixWire.TabIndex = 24;
            this.btnFixWire.Text = "Зафиксировать\r\nпроволоку\r\nCAPSLOCK\r\n";
            this.btnFixWire.UseVisualStyleBackColor = true;
            this.btnFixWire.Click += new System.EventHandler(this.btnSetupWire_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(174, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(112, 20);
            this.label7.TabIndex = 25;
            this.label7.Text = "№ Измерения";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(835, 15);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 20);
            this.label8.TabIndex = 26;
            this.label8.Text = "Тип теста:";
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.Location = new System.Drawing.Point(13, 46);
            this.zedGraphControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.ScrollGrace = 0D;
            this.zedGraphControl1.ScrollMaxX = 0D;
            this.zedGraphControl1.ScrollMaxY = 0D;
            this.zedGraphControl1.ScrollMaxY2 = 0D;
            this.zedGraphControl1.ScrollMinX = 0D;
            this.zedGraphControl1.ScrollMinY = 0D;
            this.zedGraphControl1.ScrollMinY2 = 0D;
            this.zedGraphControl1.Size = new System.Drawing.Size(762, 406);
            this.zedGraphControl1.TabIndex = 27;
            this.zedGraphControl1.UseExtendedPrintDialog = true;
            // 
            // WireTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1115, 473);
            this.Controls.Add(this.zedGraphControl1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnFixWire);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.lblMaxCOMValue);
            this.Controls.Add(this.lblCOMValues);
            this.Controls.Add(this.btnMoveToStart);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnSetTestPoint);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbTests);
            this.Controls.Add(this.rtbTestValues);
            this.Controls.Add(this.rbShearTest);
            this.Controls.Add(this.rbStretchTest);
            this.Controls.Add(this.rbBreakTest);
            this.Controls.Add(this.nudForceBound);
            this.Controls.Add(this.cbBoundSet);
            this.Controls.Add(this.tbTestResult);
            this.Name = "WireTest";
            this.Text = "Тест прочности";
            this.Load += new System.EventHandler(this.WireTest_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudForceBound)).EndInit();
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
        private System.Windows.Forms.RichTextBox rtbTestValues;
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
        private System.Windows.Forms.Label lblMaxCOMValue;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnFixWire;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private ZedGraph.ZedGraphControl zedGraphControl1;
    }
}