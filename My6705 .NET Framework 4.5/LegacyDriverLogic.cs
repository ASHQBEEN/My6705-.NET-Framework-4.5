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
        public string LoadPath { get; set; } = "_path_cfg.txt";
        //Flag to control parameters load
        public bool ParametersBeenSet { get; set; } = false;

        #region Parameters/Config load/save
        //
        // Load config file
        // ***CONTAINING REQUIREMENT-RELATED METHODS***
        //
        public void LoadCfg(string path)
        {
            Machine.b.LoadConfig(path);

            //Since Acceleration = Deceleration (requirement)
            AxesController.SetDeceleration(Machine.b, Machine.Instance.Acceleration);
            AxesController.SetLowVelocity(Machine.b, Machine.Instance.LowVelocity);
            AxesController.SetActAcc(Machine.b, Machine.Instance.Acceleration);
            AxesController.SetJerk(Machine.b, Machine.Instance.Jerk);
        }
        public DialogResult SelectPath(string loadPath)
        {
            OpenFileDialog openFileConfig = new OpenFileDialog();
            if (openFileConfig.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(loadPath, openFileConfig.FileName);
                return DialogResult.OK;
            }
            else return DialogResult.No;
            //File.Create(loadPath).Dispose();
        }
        public string ReadPath(string loadPath)
        {
            if (File.Exists(loadPath))
            {
                StreamReader sr = File.OpenText(loadPath);
                string path = sr.ReadLine();
                sr.Close();
                return path;
            }
            return null;
        }
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
            Result = Motion.mAcm_AxDoSetBit(Machine.b[i], DOChannel, DoValue);
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

        int ticksBeforeStop = 5000; // Home timer variable to control time spend on reaching the limiter
        //
        // Ticker methods, called every timer tick
        //
        public void GetIOTicker(int index, PictureBox[] pictureBoxPos, PictureBox[] pictureBoxNeg)
        {
            UInt32 Result;
            UInt32 IOStatus = new UInt32();

            Result = Motion.mAcm_AxGetMotionIO(Machine.b[index], ref IOStatus);
            if (Result == (uint)ErrorCode.SUCCESS)
            {
                if ((IOStatus & (uint)Ax_Motion_IO.AX_MOTION_IO_LMTP) > 0) pictureBoxPos[index].BackColor = Color.Red;
                else pictureBoxPos[index].BackColor = Color.Gray;

                if ((IOStatus & (uint)Ax_Motion_IO.AX_MOTION_IO_LMTN) > 0) pictureBoxNeg[index].BackColor = Color.Red;
                else pictureBoxNeg[index].BackColor = Color.Gray;
            }
        }
        public int HomeTicker(int j, int t1, Timer timer)
        {
            switch (j)
            {
                case 0:
                    AxesController.AxisMoveHome(Machine.b[Axes.Z], 1, 1);
                    j = 1;
                    break;
                case 1:
                    if (Environment.TickCount - t1 > ticksBeforeStop)
                    {
                        timer.Stop();
                        AxesController.StopContinuousMovementEmg(Machine.b[Axes.Z]);
                        j = -1;
                        MessageBox.Show("Не удалось обнаружить датчик ИП");
                        break;
                    }
                    if (AxesController.GetAxisState(Machine.b[2]) == (ushort)AxisState.STA_AX_HOMING) break;
                    j = 2;
                    break;
                case 2:
                    AxesController.AxisMoveHome(Machine.b[Axes.X], 1, 1);
                    j = 3;
                    break;
                case 3:
                    if (Environment.TickCount - t1 > ticksBeforeStop * 2)
                    {
                        timer.Stop();
                        AxesController.StopContinuousMovementEmg(Machine.b[Axes.X]);
                        j = -1;
                        MessageBox.Show("Не удалось обнаружить датчик ИП");
                        break;
                    }
                    if (AxesController.GetAxisState(Machine.b[0]) == (ushort)AxisState.STA_AX_HOMING) break;
                    j = 4;
                    break;
                case 4:
                    AxesController.AxisMoveHome(Machine.b[Axes.Y], 1, 1);
                    j = 5;
                    break;
                case 5:
                    if (Environment.TickCount - t1 > ticksBeforeStop * 3)
                    {
                        timer.Stop();
                        AxesController.StopContinuousMovementEmg(Machine.b[Axes.Y]);
                        j = -1;
                        MessageBox.Show("Не удалось обнаружить датчик ИП");
                        break;
                    }
                    if (AxesController.GetAxisState(Machine.b[1]) == (ushort)AxisState.STA_AX_HOMING) break;
                    j = 6; break;
                case 6:
                    AxesController.AxisMoveHome(Machine.b[Axes.Phi], 1, 1);
                    j = 7;
                    break;
                case 7:
                    if (Environment.TickCount - t1 > ticksBeforeStop * 4)
                    {
                        timer.Stop();
                        AxesController.StopContinuousMovementEmg(Machine.b[Axes.Phi]);
                        j = -1;
                        MessageBox.Show("Не удалось обнаружить датчик ИП");
                        break;
                    }
                    if (AxesController.GetAxisState(Machine.b[3]) == (ushort)AxisState.STA_AX_HOMING) break;
                    else
                    {
                        j = -1;
                    }
                    break;
                default: break;
            }
            return j;
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
