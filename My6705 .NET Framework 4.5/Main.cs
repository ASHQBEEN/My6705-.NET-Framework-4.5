﻿using System;
using System.Windows.Forms;
using System.IO;
using DirectShowLib;
using Emgu.CV;
using Emgu.CV.Structure;
using System.Drawing;
using Advantech.Motion;

namespace My6705.NET_Framework_4._5
{
    public partial class Main : Form
    {
        LegacyDriverLogic dr = new LegacyDriverLogic();
        ComPort comPort = new ComPort();
        Graph graph = new Graph();
        TestData td = new TestData();

        private VideoCapture capture = null;
        private DsDevice[] webCams = null;

        public Main()
        {
            InitializeComponent();
        }

        private void velParametersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VelocitySetup velset = new VelocitySetup(dr);
            velset.Show();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            try
            {
                webCams = DsDevice.GetDevicesOfCat(FilterCategory.VideoInputDevice);
                for (int i = 0; i < webCams.Length; i++)
                {
                    cmbCams.Items.Add(webCams[i].Name);
                }
                cmbCams.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            Machine.LoadMachineParameters();

            //First we are looking in our .exe directory for file that contains the path to config
            //if it exists - load the config file
            //else - create with a string containing path config file and then load

            string path = dr.ReadPath(dr.LoadPath);
            if (!File.Exists(path))
            {
                DialogResult cfgDlg = MessageBox.Show("Конфигурационный файл не был обнаружен, укажите к нему путь." +
                    "\nИначе будут использованы параметры по умолчанию.", "Предупреждение", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (cfgDlg == DialogResult.OK)
                {
                    if (dr.SelectPath(dr.LoadPath) == DialogResult.OK)
                    {
                        path = dr.ReadPath(dr.LoadPath);
                        dr.LoadCfg(path);
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    return;
                }
            }
            else dr.LoadCfg(path);
        }

        private void loadConfigToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigSetup configSetup = new ConfigSetup(dr);
            configSetup.Show();
        }

        private void IOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IOSetup ioSetup = new IOSetup(dr);
            ioSetup.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            PictureBox[] pictureBoxNeg = { pbLimNeg0, pbLimNeg1, pbLimNeg2, pbLimNeg3 };
            PictureBox[] pictureBoxPos = { pbLimPos0, pbLimPos1, pbLimPos2, pbLimPos3 };
            TextBox[] tbStates = { tbCmdPos0, tbCmdPos1, tbCmdPos2, tbCmdPos3 };

            //Get current command position of the specified axis
            TextBox[] nCmdPos = { tbCmdPos0, tbCmdPos1, tbCmdPos2, tbCmdPos3 };
            double[] cmdPos = AxesController.GetCommandPositionsAsArray(Machine.board);
            for (int i = 0; i < Machine.board.AxesCount; i++)
            {
                nCmdPos[i].Text = Convert.ToString(cmdPos[i]);
                dr.GetIOTicker(i, pictureBoxPos, pictureBoxNeg);
            }

            //error checker cycle
            for (int i = 0; i < Machine.board.AxesCount; i++)
            {
                if (AxesController.GetAxisState(Machine.board[i]) == (ushort)AxisState.STA_AX_ERROR_STOP)
                {
                    tbStates[i].BackColor = Color.Red;
                }
                else
                {
                    tbStates[i].BackColor = Color.White;
                }
            }

            //max coord checker
            for (int i = 0; i < Machine.board.AxesCount; i++)
            {
                if (Machine.Instance.MaxCoordinate[i] != 0)
                    if (AxesController.GetAxisCommandPosition(Machine.board[2]) >= Machine.Instance.MaxCoordinate[i])
                    {
                        AxesController.StopContinuousMovementEmg(Machine.board[i]);
                    }
            }
        }

        int homeTickerState = 0;
        private void btnHome_Click(object sender, EventArgs e)
        {
            btnServo.Enabled = false;
            KeyboardControl.blockControls = true;
            homeTickerState = 1;
            SetHomeTicker(homeTickerState, Environment.TickCount);
            btnHome.Enabled = false;
            AxesController.SetHighVelocity(Machine.board, Machine.Instance.DriverVelocity);
            timerHome.Start();

        }

        Action homeTicker;
        private readonly int ticksBeforeStop = 5000; // Home timer variable to control time spend on reaching the limiter

        private void HomeSensorNotFoundStop(int axisIndex)
        {
            timerHome.Stop();
            btnServo.Enabled = true;
            btnHome.Enabled = true;
            AxesController.StopContinuousMovementEmg(Machine.board[axisIndex]);
            homeTickerState = 0;
            KeyboardControl.blockControls = false;
            MessageBox.Show("Не удалось обнаружить датчик ИП");
        }
        private readonly double basingDistance = 1000;
        private readonly ushort stateHoming = (ushort)AxisState.STA_AX_HOMING;
        private readonly ushort stateMoving = (ushort)AxisState.STA_AX_PTP_MOT;
        public void SetHomeTicker(int homeTickerState, int t1)
        {
            homeTicker = () =>
            {
                switch (homeTickerState)
                {
                    case 1:
                        AxesController.AxisMoveHome(Machine.board[Axes.Z], 1, 1);
                        homeTickerState++;
                        break;
                    case 2:
                        if (Environment.TickCount - t1 > ticksBeforeStop)
                        {
                            HomeSensorNotFoundStop(2);
                            break;
                        }
                        if (AxesController.GetAxisState(Machine.board[2]) == stateHoming) break;
                        homeTickerState++;
                        break;
                    case 3:
                        AxesController.AxisRelativeMove(Machine.board[2], basingDistance);
                        homeTickerState++;
                        break;
                    case 4:
                        if (AxesController.GetAxisState(Machine.board[2]) == stateMoving) break;
                        AxesController.ResetCmdPosition(Machine.board[2]);
                        homeTickerState++;
                        break;
                    case 5:
                        AxesController.AxisMoveHome(Machine.board[Axes.X], 1, 1);
                        homeTickerState++;
                        break;
                    case 6:
                        if (Environment.TickCount - t1 > ticksBeforeStop)
                        {
                            HomeSensorNotFoundStop(0);
                            break;
                        }
                        if (AxesController.GetAxisState(Machine.board[0]) == stateHoming) break;
                        homeTickerState++;
                        break;
                    case 7:
                        AxesController.AxisRelativeMove(Machine.board[0], basingDistance);
                        homeTickerState++;
                        break;
                    case 8:
                        if (AxesController.GetAxisState(Machine.board[0]) == stateMoving) break;
                        homeTickerState++;
                        AxesController.ResetCmdPosition(Machine.board[0]);
                        break;
                    case 9:
                        AxesController.AxisMoveHome(Machine.board[Axes.Y], 1, 1);
                        homeTickerState++;
                        break;
                    case 10:
                        if (Environment.TickCount - t1 > ticksBeforeStop)
                        {
                            HomeSensorNotFoundStop(1);
                            break;
                        }
                        if (AxesController.GetAxisState(Machine.board[1]) == stateHoming) break;
                        homeTickerState++; break;
                    case 11:
                        AxesController.AxisRelativeMove(Machine.board[1], basingDistance);
                        homeTickerState++;
                        break;
                    case 12:
                        if (AxesController.GetAxisState(Machine.board[1]) == stateMoving) break;
                        AxesController.ResetCmdPosition(Machine.board[1]);
                        homeTickerState++;
                        break;
                    case 13:
                        AxesController.AxisMoveHome(Machine.board[Axes.Phi], 1, 1);
                        homeTickerState++;
                        break;
                    case 14:
                        if (Environment.TickCount - t1 > ticksBeforeStop)
                        {
                            HomeSensorNotFoundStop(3);
                            break;
                        }
                        if (AxesController.GetAxisState(Machine.board[3]) == stateHoming) break;
                        else
                        {
                            homeTickerState = 0;
                        }
                        break;
                    case 15:
                        AxesController.AxisRelativeMove(Machine.board[3], basingDistance);
                        homeTickerState++;
                        break;
                    case 16:
                        if (AxesController.GetAxisState(Machine.board[3]) == stateMoving) break;
                        AxesController.ResetCmdPosition(Machine.board[3]);
                        homeTickerState = 0;
                        break;
                }
            };
        }

        private void timerHomer_Tick(object sender, EventArgs e)
        {
            //Home Timer
            if (homeTickerState == 0)
            {
                btnHome.Enabled = true;
                btnServo.Enabled = true;
                timerHome.Stop();
                KeyboardControl.blockControls = false;
                return;
            }
            homeTicker();
        }

        bool servoAll = false;  // Controls servo state
        public void ServoAll(Button button)
        {
            string btnServoOnCaption = "Servo On";
            string btnServoOffCaption = "Servo Off";
            if (servoAll == false)
            {
                AxesController.AllAxesServoOn(Machine.board);
                servoAll = true;
                button.Text = btnServoOffCaption;
                btnHome.Enabled = true;
            }
            else
            {
                AxesController.AllAxesServoOff(Machine.board);
                servoAll = false;
                button.Text = btnServoOnCaption;
                btnHome.Enabled = false;
            }
        }

        private void btnServo_Click(object sender, EventArgs e)
        {
            ServoAll(btnServo);

        }

        private void driverTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //AxesController.SetHighVelocity(Machine.board, Machine.Instance.FastManipulatorVelocity);
            DriverTest interpolatedMovement = new DriverTest();
            interpolatedMovement.Show();
        }

        private void btnOpenPort_Click(object sender, EventArgs e)
        {
            bool error = false;
            // If the port is open, close it.
            if (comPort.ComIsOpen())
            {
                comPort.ComClose();
                btnOpenPort.Text = "Открыть порт";
            }
            else
            {
                try
                {
                    comPort.SetPortName(cmbComPort.Text);
                    btnOpenPort.Text = "Закрыть порт";
                    // Open the port
                    comPort.ComOpen();
                    // Start Graph Timer
                }
                catch (UnauthorizedAccessException) { error = true; }
                catch (IOException) { error = true; }
                catch (ArgumentException) { error = true; }

                if (error)
                    MessageBox.Show("Не удалось открыть COM-порт. Скорее всего он уже подключен, недоступен или вовсе отключен.", "Ошибка COM-порта", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            // Change the state of the form's controls
            //EnableControls();

            tmrComDataGetter.Start();
        }

        private void tmrComDataGetter_Tick(object sender, EventArgs e)
        {
            tbComData.Text = comPort.getPortDataTicker();
        }

        private void tmrCheckComPorts_Tick(object sender, EventArgs e)
        {
            comPort.RefreshComPortList(cmbComPort);
        }

        bool camIsActive = false;
        private void comSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            comPort.openGraph();
        }

        int selectedCamID = new int();
        private void btnOpenCam_Click(object sender, EventArgs e)
        {
            if (camIsActive)
            {
                try
                {
                    if (capture != null)
                    {
                        //capture.Pause();
                        cbEnCross.Checked = false;
                        capture.Dispose();
                        capture = null;
                        pictureBox1.Image.Dispose();
                        pictureBox1.Image = null;
                        camIsActive = false;
                        btnOpenCam.Text = "Начать просмотр";
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                try
                {
                    if (webCams.Length == 0)
                    {
                        throw new Exception("Нет доступных камер");
                    }
                    else if (cmbCams.SelectedItem == null)
                    {
                        throw new Exception("Необходимо выбрать камеру");
                    }
                    else if (capture != null)
                    {
                        capture.Start();
                    }
                    else
                    {
                        selectedCamID = cmbCams.SelectedIndex;
                        capture = new VideoCapture(selectedCamID);
                        capture.ImageGrabbed += Capture_ImageGrabbed;
                        capture.Start();
                        camIsActive = true;
                        btnOpenCam.Text = "Закончить просмотр";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Capture_ImageGrabbed(object sender, EventArgs e)
        {
            using (Image<Gray, Single> image = new Image<Gray, Single>(1000, 800))
            {
                try
                {
                    Mat m = new Mat();
                    capture.Retrieve(m);
                    pictureBox1.Image = m.ToImage<Bgr, byte>().Flip(Emgu.CV.CvEnum.FlipType.Horizontal).Bitmap;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        int rectW = 10, rectH = 10, ofset = 5;

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (cbEnCross.Checked)
            {
                Pen p = new Pen(Color.Cyan, 2);
                Rectangle rect = new Rectangle(pictureBox1.Width / 2 - rectW / 2, pictureBox1.Height / 2 - rectH / 2, rectW, rectH);
                e.Graphics.DrawRectangle(p, rect);
                Point px1 = new Point(pictureBox1.Width / 2 - rectW / 2 - ofset, pictureBox1.Height / 2);
                Point px2 = new Point(pictureBox1.Width / 2 + rectW / 2 + ofset, pictureBox1.Height / 2);
                Point py1 = new Point(pictureBox1.Width / 2, pictureBox1.Height / 2 - rectH / 2 - ofset);
                Point py2 = new Point(pictureBox1.Width / 2, pictureBox1.Height / 2 + rectH / 2 + ofset);
                e.Graphics.DrawLine(p, px1, px2);
                e.Graphics.DrawLine(p, py1, py2);
            }
        }

        private void cbEnCross_CheckedChanged(object sender, EventArgs e)
        {
            trbX.Enabled = cbEnCross.Checked;
            trbY.Enabled = cbEnCross.Checked;
        }

        private void btnTest1_Click(object sender, EventArgs e)
        {
            TestsForm testsForm = new TestsForm(comPort, graph, td, dr);
            testsForm.ShowDialog();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AxesController.ResetAllErrors(Machine.board);
        }

        private void trbY_Scroll(object sender, EventArgs e)
        {
            rectH = trbY.Value;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            rectW = trbX.Value;
        }

    } // class
} // namespace
