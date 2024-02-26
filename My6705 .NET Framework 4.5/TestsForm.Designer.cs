namespace My6705.NET_Framework_4._5
{
    partial class TestsForm
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
            this.cmbTestRun = new System.Windows.Forms.ComboBox();
            this.zgc = new ZedGraph.ZedGraphControl();
            this.tbTestResult = new System.Windows.Forms.TextBox();
            this.btnStartTest = new System.Windows.Forms.Button();
            this.tmrDrawLine = new System.Windows.Forms.Timer(this.components);
            this.tmrComDataGetter = new System.Windows.Forms.Timer(this.components);
            this.rbBreak = new System.Windows.Forms.RadioButton();
            this.rbShear = new System.Windows.Forms.RadioButton();
            this.rbStretch = new System.Windows.Forms.RadioButton();
            this.lblCOMValues = new System.Windows.Forms.Label();
            this.lblMaxCOMValue = new System.Windows.Forms.Label();
            this.btnToStartPosition = new System.Windows.Forms.Button();
            this.btnSetupWire = new System.Windows.Forms.Button();
            this.rtbComValues = new System.Windows.Forms.RichTextBox();
            this.btnSaveCoord = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbSetBound = new System.Windows.Forms.CheckBox();
            this.nudForceBound = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nudForceBound)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbTestRun
            // 
            this.cmbTestRun.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTestRun.FormattingEnabled = true;
            this.cmbTestRun.Location = new System.Drawing.Point(330, 18);
            this.cmbTestRun.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbTestRun.Name = "cmbTestRun";
            this.cmbTestRun.Size = new System.Drawing.Size(250, 28);
            this.cmbTestRun.TabIndex = 0;
            this.cmbTestRun.TabStop = false;
            this.cmbTestRun.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // zgc
            // 
            this.zgc.Location = new System.Drawing.Point(18, 60);
            this.zgc.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.zgc.Name = "zgc";
            this.zgc.ScrollGrace = 0D;
            this.zgc.ScrollMaxX = 0D;
            this.zgc.ScrollMaxY = 0D;
            this.zgc.ScrollMaxY2 = 0D;
            this.zgc.ScrollMinX = 0D;
            this.zgc.ScrollMinY = 0D;
            this.zgc.ScrollMinY2 = 0D;
            this.zgc.Size = new System.Drawing.Size(855, 502);
            this.zgc.TabIndex = 1;
            this.zgc.UseExtendedPrintDialog = true;
            // 
            // tbTestResult
            // 
            this.tbTestResult.Location = new System.Drawing.Point(1092, 185);
            this.tbTestResult.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbTestResult.Name = "tbTestResult";
            this.tbTestResult.ReadOnly = true;
            this.tbTestResult.Size = new System.Drawing.Size(97, 26);
            this.tbTestResult.TabIndex = 3;
            this.tbTestResult.TabStop = false;
            // 
            // btnStartTest
            // 
            this.btnStartTest.Location = new System.Drawing.Point(974, 508);
            this.btnStartTest.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnStartTest.Name = "btnStartTest";
            this.btnStartTest.Size = new System.Drawing.Size(152, 54);
            this.btnStartTest.TabIndex = 4;
            this.btnStartTest.Text = "Начать измерение";
            this.btnStartTest.UseVisualStyleBackColor = true;
            this.btnStartTest.Click += new System.EventHandler(this.btnStartTest_Click);
            // 
            // tmrDrawLine
            // 
            this.tmrDrawLine.Interval = 250;
            this.tmrDrawLine.Tick += new System.EventHandler(this.tmrDrawLine_Tick);
            // 
            // tmrComDataGetter
            // 
            this.tmrComDataGetter.Interval = 250;
            this.tmrComDataGetter.Tick += new System.EventHandler(this.tmrComDataGetter_Tick);
            // 
            // rbBreak
            // 
            this.rbBreak.AutoSize = true;
            this.rbBreak.Checked = true;
            this.rbBreak.Location = new System.Drawing.Point(886, 62);
            this.rbBreak.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbBreak.Name = "rbBreak";
            this.rbBreak.Size = new System.Drawing.Size(90, 24);
            this.rbBreak.TabIndex = 5;
            this.rbBreak.Text = "Разрыв";
            this.rbBreak.UseVisualStyleBackColor = true;
            this.rbBreak.CheckedChanged += new System.EventHandler(this.rbBreak_CheckedChanged);
            // 
            // rbShear
            // 
            this.rbShear.AutoSize = true;
            this.rbShear.Location = new System.Drawing.Point(886, 132);
            this.rbShear.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbShear.Name = "rbShear";
            this.rbShear.Size = new System.Drawing.Size(81, 24);
            this.rbShear.TabIndex = 6;
            this.rbShear.Text = "Сдвиг";
            this.rbShear.UseVisualStyleBackColor = true;
            this.rbShear.CheckedChanged += new System.EventHandler(this.rbShear_CheckedChanged);
            // 
            // rbStretch
            // 
            this.rbStretch.AutoSize = true;
            this.rbStretch.Location = new System.Drawing.Point(886, 97);
            this.rbStretch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbStretch.Name = "rbStretch";
            this.rbStretch.Size = new System.Drawing.Size(126, 24);
            this.rbStretch.TabIndex = 7;
            this.rbStretch.Text = "Растяжение";
            this.rbStretch.UseVisualStyleBackColor = true;
            this.rbStretch.CheckedChanged += new System.EventHandler(this.rbStretch_CheckedChanged);
            // 
            // lblCOMValues
            // 
            this.lblCOMValues.AutoSize = true;
            this.lblCOMValues.Location = new System.Drawing.Point(1046, 18);
            this.lblCOMValues.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCOMValues.Name = "lblCOMValues";
            this.lblCOMValues.Size = new System.Drawing.Size(121, 20);
            this.lblCOMValues.TabIndex = 8;
            this.lblCOMValues.Text = "Данные порта:";
            // 
            // lblMaxCOMValue
            // 
            this.lblMaxCOMValue.AutoSize = true;
            this.lblMaxCOMValue.Location = new System.Drawing.Point(958, 191);
            this.lblMaxCOMValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMaxCOMValue.Name = "lblMaxCOMValue";
            this.lblMaxCOMValue.Size = new System.Drawing.Size(126, 20);
            this.lblMaxCOMValue.TabIndex = 10;
            this.lblMaxCOMValue.Text = "Макс. усилие, г:";
            // 
            // btnToStartPosition
            // 
            this.btnToStartPosition.Location = new System.Drawing.Point(974, 400);
            this.btnToStartPosition.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnToStartPosition.Name = "btnToStartPosition";
            this.btnToStartPosition.Size = new System.Drawing.Size(152, 35);
            this.btnToStartPosition.TabIndex = 12;
            this.btnToStartPosition.Text = "В точку теста";
            this.btnToStartPosition.UseVisualStyleBackColor = true;
            this.btnToStartPosition.Click += new System.EventHandler(this.btnToStartPosition_Click);
            // 
            // btnSetupWire
            // 
            this.btnSetupWire.Location = new System.Drawing.Point(974, 445);
            this.btnSetupWire.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSetupWire.Name = "btnSetupWire";
            this.btnSetupWire.Size = new System.Drawing.Size(152, 54);
            this.btnSetupWire.TabIndex = 13;
            this.btnSetupWire.Text = "Зафиксировать проволоку";
            this.btnSetupWire.UseVisualStyleBackColor = true;
            this.btnSetupWire.Click += new System.EventHandler(this.btnSetupWire_Click);
            // 
            // rtbComValues
            // 
            this.rtbComValues.BackColor = System.Drawing.SystemColors.Control;
            this.rtbComValues.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtbComValues.Location = new System.Drawing.Point(1041, 43);
            this.rtbComValues.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rtbComValues.Name = "rtbComValues";
            this.rtbComValues.ReadOnly = true;
            this.rtbComValues.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rtbComValues.Size = new System.Drawing.Size(148, 130);
            this.rtbComValues.TabIndex = 14;
            this.rtbComValues.TabStop = false;
            this.rtbComValues.Text = "";
            // 
            // btnSaveCoord
            // 
            this.btnSaveCoord.Location = new System.Drawing.Point(974, 288);
            this.btnSaveCoord.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSaveCoord.Name = "btnSaveCoord";
            this.btnSaveCoord.Size = new System.Drawing.Size(152, 54);
            this.btnSaveCoord.TabIndex = 15;
            this.btnSaveCoord.Text = "Обучить координату";
            this.btnSaveCoord.UseVisualStyleBackColor = true;
            this.btnSaveCoord.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(909, 224);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 20);
            this.label1.TabIndex = 17;
            this.label1.Text = "Ограничить усилие, г:";
            // 
            // cbSetBound
            // 
            this.cbSetBound.AutoSize = true;
            this.cbSetBound.Location = new System.Drawing.Point(882, 223);
            this.cbSetBound.Name = "cbSetBound";
            this.cbSetBound.Size = new System.Drawing.Size(22, 21);
            this.cbSetBound.TabIndex = 18;
            this.cbSetBound.UseVisualStyleBackColor = true;
            this.cbSetBound.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // nudForceBound
            // 
            this.nudForceBound.Enabled = false;
            this.nudForceBound.Location = new System.Drawing.Point(1091, 219);
            this.nudForceBound.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.nudForceBound.Name = "nudForceBound";
            this.nudForceBound.Size = new System.Drawing.Size(97, 26);
            this.nudForceBound.TabIndex = 19;
            this.nudForceBound.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // TestsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1212, 585);
            this.Controls.Add(this.nudForceBound);
            this.Controls.Add(this.cbSetBound);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSaveCoord);
            this.Controls.Add(this.rtbComValues);
            this.Controls.Add(this.btnSetupWire);
            this.Controls.Add(this.btnToStartPosition);
            this.Controls.Add(this.lblMaxCOMValue);
            this.Controls.Add(this.lblCOMValues);
            this.Controls.Add(this.rbStretch);
            this.Controls.Add(this.rbShear);
            this.Controls.Add(this.rbBreak);
            this.Controls.Add(this.zgc);
            this.Controls.Add(this.btnStartTest);
            this.Controls.Add(this.tbTestResult);
            this.Controls.Add(this.cmbTestRun);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "TestsForm";
            this.Text = "TestsForm";
            this.Load += new System.EventHandler(this.TestsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudForceBound)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbTestRun;
        private ZedGraph.ZedGraphControl zgc;
        private System.Windows.Forms.TextBox tbTestResult;
        private System.Windows.Forms.Button btnStartTest;
        private System.Windows.Forms.Timer tmrDrawLine;
        private System.Windows.Forms.Timer tmrComDataGetter;
        private System.Windows.Forms.RadioButton rbBreak;
        private System.Windows.Forms.RadioButton rbShear;
        private System.Windows.Forms.RadioButton rbStretch;
        private System.Windows.Forms.Label lblCOMValues;
        private System.Windows.Forms.Label lblMaxCOMValue;
        private System.Windows.Forms.Button btnToStartPosition;
        private System.Windows.Forms.Button btnSetupWire;
        private System.Windows.Forms.RichTextBox rtbComValues;
        private System.Windows.Forms.Button btnSaveCoord;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cbSetBound;
        private System.Windows.Forms.NumericUpDown nudForceBound;
    }
}