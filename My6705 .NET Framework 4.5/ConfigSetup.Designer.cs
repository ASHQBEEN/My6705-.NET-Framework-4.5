namespace My6705.NET_Framework_4._5
{
    partial class ConfigSetup
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
            this.btnLoadCfg = new System.Windows.Forms.Button();
            this.cbMemCfg = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnLoadCfg
            // 
            this.btnLoadCfg.AutoSize = true;
            this.btnLoadCfg.Location = new System.Drawing.Point(18, 12);
            this.btnLoadCfg.Name = "btnLoadCfg";
            this.btnLoadCfg.Size = new System.Drawing.Size(208, 23);
            this.btnLoadCfg.TabIndex = 0;
            this.btnLoadCfg.Text = "Загрузить новый файл конфигурации";
            this.btnLoadCfg.UseVisualStyleBackColor = true;
            this.btnLoadCfg.Click += new System.EventHandler(this.btnLoadCfg_Click);
            // 
            // cbMemCfg
            // 
            this.cbMemCfg.AutoSize = true;
            this.cbMemCfg.Location = new System.Drawing.Point(18, 41);
            this.cbMemCfg.Name = "cbMemCfg";
            this.cbMemCfg.Size = new System.Drawing.Size(214, 30);
            this.cbMemCfg.TabIndex = 1;
            this.cbMemCfg.Text = "Автоматически загружать этот файл\r\n конфигурации в будущем";
            this.cbMemCfg.UseVisualStyleBackColor = true;
            // 
            // ConfigSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(243, 80);
            this.Controls.Add(this.cbMemCfg);
            this.Controls.Add(this.btnLoadCfg);
            this.Name = "ConfigSetup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Файл конфигурации";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLoadCfg;
        private System.Windows.Forms.CheckBox cbMemCfg;
    }
}