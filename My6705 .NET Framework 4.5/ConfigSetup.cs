using System;
using System.Windows.Forms;

namespace My6705.NET_Framework_4._5
{
    public partial class ConfigSetup : Form
    {
        LegacyDriverLogic dr;
        public ConfigSetup(LegacyDriverLogic dr)
        {
            InitializeComponent();
            this.dr = dr;
        }

        private void btnLoadCfg_Click(object sender, EventArgs e)
        {
            string path;
            if (cbMemCfg.Checked == true)
            {
                if (dr.SelectPath(dr.LoadPath) == DialogResult.OK)
                {
                    path = dr.ReadPath(dr.LoadPath);
                    dr.LoadCfg(path);
                    Close();
                }
            }
            else
            {
                OpenFileDialog openFileConfig = new OpenFileDialog();
                if (openFileConfig.ShowDialog() == DialogResult.OK)
                {
                    path = openFileConfig.FileName;
                    dr.LoadCfg(path);
                    Close();
                }
            }
        }
    }
}
