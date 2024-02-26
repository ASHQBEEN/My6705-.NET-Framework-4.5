using Advantech.Motion;
using System;
using System.Windows.Forms;

namespace My6705.NET_Framework_4._5
{
    public partial class IOSetup : Form
    {
        LegacyDriverLogic dr;
        public IOSetup(LegacyDriverLogic dr)
        {
            InitializeComponent();
            this.dr = dr;
        }

        private void IOSetup_Load(object sender, EventArgs e)
        {
            onInitDO();
        }
        private void onInitDO()
        {
            UInt32 Result;
            byte bitDo = 0;
            ushort i = 4;
            PictureBox pictureBox;
            Button BtnDO;

            Button[] DOBtnsX = { btnDO40, btnDO50, btnDO60, btnDO70 };
            Button[] DOBtnsY = { btnDO41, btnDO51, btnDO61, btnDO71 };
            Button[] DOBtnsZ = { btnDO42, btnDO52, btnDO62, btnDO72 };
            Button[] DOBtnsF = { btnDO43, btnDO53, btnDO63, btnDO73 };
            Button[][] DOArr = { DOBtnsX, DOBtnsY, DOBtnsZ, DOBtnsF };

            PictureBox[] DOpbsX = { pbDO40, pbDO50, pbDO60, pbDO70 };
            PictureBox[] DOpbsY = { pbDO41, pbDO51, pbDO61, pbDO71 };
            PictureBox[] DOpbsZ = {pbDO42, pbDO52, pbDO62, pbDO72 };
            PictureBox[] DOpbsF = {pbDO43, pbDO53, pbDO63, pbDO73 };

            PictureBox[][] DOpbsArr = { DOpbsX, DOpbsY, DOpbsZ, DOpbsF };

            for (int j = 0; j < 4; j++)
            {
                for (i = 4; i < 8; i++)
                {
                    pictureBox = DOpbsArr[j][i - 4];
                    BtnDO = DOArr[j][i - 4];
                    //Get the specified channel's DO value
                    Result = Motion.mAcm_AxDoGetBit(Machine.b[j], i, ref bitDo);
                    if (Result != (uint)ErrorCode.SUCCESS)
                    {
                        pictureBox.Enabled = false;
                        BtnDO.Enabled = false;
                    }
                    else
                    {
                        pictureBox.Enabled = true;
                        BtnDO.Enabled = true;
                        if (bitDo == 1)
                        {
                            pictureBox.BackColor = System.Drawing.Color.Red;
                        }
                        else
                        {
                            pictureBox.BackColor = System.Drawing.Color.Green;
                        }
                    }
                }
            }
        }

        private void btnRefreshOuts_Click(object sender, EventArgs e)
        {
            onInitDO();
        }

        private void btnDO40_Click(object sender, EventArgs e)
        {
            dr.BtnDO_Click(pbDO40, 4, 0);
        }

        private void btnDO41_Click(object sender, EventArgs e)
        {
            dr.BtnDO_Click(pbDO41, 4, 1);
        }

        private void btnDO42_Click(object sender, EventArgs e)
        {
            dr.BtnDO_Click(pbDO42, 4, 2);
        }

        private void btnDO43_Click(object sender, EventArgs e)
        {
            dr.BtnDO_Click(pbDO43, 4, 3);
        }

        private void btnDO50_Click(object sender, EventArgs e)
        {
            dr.BtnDO_Click(pbDO50, 5, 0);
        }

        private void btnDO51_Click(object sender, EventArgs e)
        {
            dr.BtnDO_Click(pbDO51, 5, 1);
        }

        private void btnDO52_Click(object sender, EventArgs e)
        {
            dr.BtnDO_Click(pbDO52, 5, 2);
        }

        private void btnDO53_Click(object sender, EventArgs e)
        {
            dr.BtnDO_Click(pbDO53, 5, 3);
        }

        private void btnDO60_Click(object sender, EventArgs e)
        {
            dr.BtnDO_Click(pbDO60, 6, 0);
        }

        private void btnDO61_Click(object sender, EventArgs e)
        {
            dr.BtnDO_Click(pbDO61, 6, 1);
        }

        private void btnDO62_Click(object sender, EventArgs e)
        {
            dr.BtnDO_Click(pbDO62, 6, 2);
        }

        private void btnDO63_Click(object sender, EventArgs e)
        {
            dr.BtnDO_Click(pbDO63, 6, 3);
        }

        private void btnDO73_Click(object sender, EventArgs e)
        {
            dr.BtnDO_Click(pbDO73, 7, 3);
        }

        private void btnDO71_Click(object sender, EventArgs e)
        {
            dr.BtnDO_Click(pbDO71, 7, 1);
        }

        private void btnDO72_Click(object sender, EventArgs e)
        {
            dr.BtnDO_Click(pbDO72, 7, 2);
        }

        private void btnDO70_Click(object sender, EventArgs e)
        {
            dr.BtnDO_Click(pbDO70, 7, 0);
        }
    } // class
} // namespace
