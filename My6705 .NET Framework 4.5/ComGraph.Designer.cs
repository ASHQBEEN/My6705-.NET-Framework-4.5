namespace My6705.NET_Framework_4._5
{
    partial class ComGraph
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
            this.zgc = new ZedGraph.ZedGraphControl();
            this.tmrDrawLine = new System.Windows.Forms.Timer(this.components);
            this.tmrComDataGetter = new System.Windows.Forms.Timer(this.components);
            this.tbComData = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // zgc
            // 
            this.zgc.Location = new System.Drawing.Point(12, 12);
            this.zgc.Name = "zgc";
            this.zgc.ScrollGrace = 0D;
            this.zgc.ScrollMaxX = 0D;
            this.zgc.ScrollMaxY = 0D;
            this.zgc.ScrollMaxY2 = 0D;
            this.zgc.ScrollMinX = 0D;
            this.zgc.ScrollMinY = 0D;
            this.zgc.ScrollMinY2 = 0D;
            this.zgc.Size = new System.Drawing.Size(600, 417);
            this.zgc.TabIndex = 0;
            this.zgc.UseExtendedPrintDialog = true;
            // 
            // tmrDrawLine
            // 
            this.tmrDrawLine.Enabled = true;
            this.tmrDrawLine.Interval = 250;
            this.tmrDrawLine.Tick += new System.EventHandler(this.tmrDrawLine_Tick);
            // 
            // tmrComDataGetter
            // 
            this.tmrComDataGetter.Enabled = true;
            this.tmrComDataGetter.Interval = 250;
            this.tmrComDataGetter.Tick += new System.EventHandler(this.tmrComDataGetter_Tick);
            // 
            // tbComData
            // 
            this.tbComData.BackColor = System.Drawing.Color.White;
            this.tbComData.Font = new System.Drawing.Font("DSEG7 Modern", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbComData.ForeColor = System.Drawing.Color.Black;
            this.tbComData.Location = new System.Drawing.Point(438, 24);
            this.tbComData.Name = "tbComData";
            this.tbComData.ReadOnly = true;
            this.tbComData.Size = new System.Drawing.Size(149, 34);
            this.tbComData.TabIndex = 25;
            this.tbComData.Text = "0.0";
            this.tbComData.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ComGraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 441);
            this.Controls.Add(this.tbComData);
            this.Controls.Add(this.zgc);
            this.Name = "ComGraph";
            this.Text = "График данных COM";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ZedGraph.ZedGraphControl zgc;
        private System.Windows.Forms.Timer tmrDrawLine;
        private System.Windows.Forms.Timer tmrComDataGetter;
        private System.Windows.Forms.TextBox tbComData;
    }
}