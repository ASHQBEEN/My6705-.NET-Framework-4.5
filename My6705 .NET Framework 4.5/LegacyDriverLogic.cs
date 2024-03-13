using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Advantech.Motion;

namespace My6705.NET_Framework_4._5
{
    public class LegacyDriverLogic
    {
        //Flag to control parameters load
        public bool ParametersBeenSet { get; set; } = false;

        #region Parameters/Config load/save
        //
        // Load config file
        // ***CONTAINING REQUIREMENT-RELATED METHODS***
        //


        #endregion
        #region Main form API methods (Driver Move, Limiters control)

        public void BtnDO_Click(PictureBox pictureBoxDO, ushort DOChannel, int i)
        {
            UInt32 Result;
            byte DoValue;
            string strTemp;
            if (pictureBoxDO.BackColor == System.Drawing.Color.Red)
            {
                DoValue = 0;
            }
            else
                DoValue = 1;
            //Set DO value to channel
            Result = Motion.mAcm_AxDoSetBit(Machine.Board[i], DOChannel, DoValue);
            if (Result != (uint)ErrorCode.SUCCESS)
            {
                strTemp = "Set AxDoSetBit Failed With Error Code: [0x" + Convert.ToString(Result, 16) + "]";
                ShowMessages(strTemp, Result);
                return;
            }
            else
            {
                if (pictureBoxDO.BackColor == System.Drawing.Color.Red)
                    pictureBoxDO.BackColor = System.Drawing.Color.Green;
                else
                    pictureBoxDO.BackColor = System.Drawing.Color.Red;
            }
        }

        //
        // Ticker methods, called every timer tick
        //
        public void GetIOTicker(int index, PictureBox[] pictureBoxPos, PictureBox[] pictureBoxNeg)
        {
            UInt32 Result;
            UInt32 IOStatus = new UInt32();

            Result = Motion.mAcm_AxGetMotionIO(Machine.Board[index], ref IOStatus);
            if (Result == (uint)ErrorCode.SUCCESS)
            {
                if ((IOStatus & (uint)Ax_Motion_IO.AX_MOTION_IO_LMTP) > 0) pictureBoxPos[index].BackColor = Color.Red;
                else pictureBoxPos[index].BackColor = Color.Gray;

                if ((IOStatus & (uint)Ax_Motion_IO.AX_MOTION_IO_LMTN) > 0) pictureBoxNeg[index].BackColor = Color.Red;
                else pictureBoxNeg[index].BackColor = Color.Gray;
            }
        }

        #endregion
        // Error messages wrapper from Advantech example's
        public void ShowMessages(string DetailMessage, uint errorCode)
        {
            StringBuilder ErrorMsg = new StringBuilder("", 100);
            //Get the error message according to error code returned from API
            Boolean res = Motion.mAcm_GetErrorMessage(errorCode, ErrorMsg, 100);
            string ErrorMessage = "";
            if (res) ErrorMessage = ErrorMsg.ToString();
            MessageBox.Show(DetailMessage + "\r\nError Message:" + ErrorMessage, "6705 Software", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
