using System;
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
        COMPort port = new COMPort();


        private VideoCapture capture = null;
        private DsDevice[] webCams = null;

        public Main()
        {
            InitializeComponent();

            Machine.Board.OpenBoard();

            btnHome.Click += Start;
            timerHome.Tick += TimerTick;
        }

        private void velParametersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VelocitySetup velset = new VelocitySetup(dr);
            velset.Show();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            timerCmdPos.Start();
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


            //First we are looking in our .exe directory for file that contains the path to config
            //if it exists - load the config file
            //else - create with a string containing path config file and then load

            if (File.Exists(Machine.Board.AdvantechConfigPath))
            {
                Machine.Board.LoadOverridedConfig();
            }
            else
            {
                DialogResult cfgDlg = MessageBox.Show("Конфигурационный файл не был обнаружен, укажите к нему путь." +
                    "\nИначе будут использованы параметры по умолчанию.", "Предупреждение", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (cfgDlg == DialogResult.OK)
                {
                    OpenFileDialog openFileConfig = new OpenFileDialog();
                    if (openFileConfig.ShowDialog() == DialogResult.OK)
                    {
                        Machine.Board.AdvantechConfigPath = openFileConfig.FileName;
                        Machine.Board.LoadOverridedConfig();
                    }
                    else
                    {
                        Activate();
                        Machine.Board.OverrideConfig();
                    }
                }
                else
                {
                    Machine.Board.OverrideConfig();
                }
            }
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
            TextBox[] tbCmdPos = { tbCmdPos0, tbCmdPos1, tbCmdPos2, tbCmdPos3 };
            TextBox[] tbActPos = { tbFeedbackPos0, tbFeedbackPos1, tbFeedbackPos2, tbFeedbackPos3 };
            double[] cmdPos = AxesController.GetCommandPositionsAsArray(Machine.Board);
            double[] feedbackPos = AxesController.GetActPositionsAsArray(Machine.Board);

            for (int i = 0; i < Machine.Board.AxesCount; i++)
            {
                tbCmdPos[i].Text = Convert.ToString(cmdPos[i]);
                tbActPos[i].Text = Convert.ToString(feedbackPos[i]);
                dr.GetIOTicker(i, pictureBoxPos, pictureBoxNeg);
            }

            //error checker cycle
            for (int i = 0; i < Machine.Board.AxesCount; i++)
            {
                if (AxesController.GetAxisState(Machine.Board[i]) == (ushort)AxisState.STA_AX_ERROR_STOP)
                {
                    tbStates[i].BackColor = Color.Red;
                }
                else
                {
                    tbStates[i].BackColor = Color.White;
                }
            }

            //max coord checker
            for (int i = 0; i < Machine.Board.AxesCount; i++)
            {
                if (AxesController.IfMaximumReached(i))
                {
                    AxesController.StopContinuousMovementEmg(Machine.Board[i]);
                }
            }
        }

        bool servoAll = false;  // Controls servo state
        public void ServoAll(Button button)
        {
            string btnServoOnCaption = "Servo On";
            string btnServoOffCaption = "Servo Off";
            if (servoAll == false)
            {
                AxesController.AllAxesServoOn(Machine.Board);
                servoAll = true;
                button.Text = btnServoOffCaption;
                btnHome.Enabled = true;
            }
            else
            {
                AxesController.AllAxesServoOff(Machine.Board);
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

        bool camIsActive = false;

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
                        //cbEnCross.Checked = false;
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



        

        private void btnTest1_Click(object sender, EventArgs e)
        {
            WireTest wt = new WireTest();
            wt.Show();

        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            HomeStop();
            Machine.Board.CloseBoard();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AxesController.ResetAllErrors(Machine.Board);
        }


        private void button2_Click(object sender, EventArgs e)
        {
            TestsForm testsForm = new TestsForm(comPort, graph, td, dr);
            testsForm.Show();
        }
    }
}
