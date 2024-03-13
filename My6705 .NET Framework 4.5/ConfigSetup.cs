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
            if (cbMemCfg.Checked)
            {
                    OpenFileDialog openFileConfig = new OpenFileDialog();
                    if (openFileConfig.ShowDialog() == DialogResult.OK)
                        Machine.Board.AdvantechConfigPath = openFileConfig.FileName;
                    Machine.Board.SaveBoardProperties();
                    Machine.Board.LoadOverridedConfig();
                    Close();
            }
            else
            {
                OpenFileDialog openFileConfig = new OpenFileDialog();
                if (openFileConfig.ShowDialog() == DialogResult.OK)
                {
                    Machine.Board.LoadOverridedConfig();
                    Close();
                }
            }
        }
    }
}
