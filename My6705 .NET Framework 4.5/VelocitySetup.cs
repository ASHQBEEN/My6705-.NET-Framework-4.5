using System;
using System.Windows.Forms;
using System.IO;

namespace My6705.NET_Framework_4._5
{
    public partial class VelocitySetup : Form
    {
        LegacyDriverLogic dr;
        public VelocitySetup(LegacyDriverLogic dr)
        {
            InitializeComponent();
            this.dr = dr;
        }

        private void VelocitySetup_Load(object sender, EventArgs e)
        {
            if (dr.ParametersBeenSet)
            {
                ParseParams(false);
            }
            else
            {
                if (File.Exists(Machine.ParametersFilePath))
                {
                    ParseParams(true);
                }
                else ParseParams(false);
            }
        }

        private void ParseParams(bool loadVels)
        {
            NumericUpDown[] nVelManipSlow = { ndSlowVel0, ndSlowVel1, ndSlowVel2, ndSlowVel3 };
            NumericUpDown[] nVelManipFast = { ndFastVel0, ndFastVel1, ndFastVel2, ndFastVel3 };
            NumericUpDown[] nVelDr = { ndDrVel0, ndDrVel1, ndDrVel2, ndDrVel3 };
            NumericUpDown[] nAcc = { ndAcc0, ndAcc1, ndAcc2, ndAcc3 };
            RadioButton[] rbT = { rbT0, rbT1, rbT2, rbT3 };
            RadioButton[] rbS = { rbS0, rbS1, rbS2, rbS3 };
            NumericUpDown[] ndMaxCoord = { ndMaxCoord0, ndMaxCoord1, ndMaxCoord2, ndMaxCoord3 };


            //getting or loading virtual values
            if (loadVels)
            {
                Machine.LoadMachineParameters();
            }

            for (int i = 0; i < Machine.board.AxesCount; i++)
            {
                nVelManipSlow[i].Text = Convert.ToString(Machine.Instance.SlowManipulatorVelocity[i]);
                nVelManipFast[i].Text = Convert.ToString(Machine.Instance.FastManipulatorVelocity[i]);
                nAcc[i].Text = Convert.ToString(Machine.Instance.Acceleration[i]);
                nVelDr[i].Text = Convert.ToString(Machine.Instance.DriverVelocity[i]);
                ndMaxCoord[i].Text = Convert.ToString(Machine.Instance.MaxCoordinate[i]);
                if (Machine.Instance.Jerk[i] == 0) rbT[i].Checked = true;
                else rbS[i].Checked = true;
            }
        }

        private void btnSetParameters_Click(object sender, EventArgs e)
        {
            NumericUpDown[] nVelManipSlow = { ndSlowVel0, ndSlowVel1, ndSlowVel2, ndSlowVel3 };
            NumericUpDown[] nVelManipFast = { ndFastVel0, ndFastVel1, ndFastVel2, ndFastVel3 };
            NumericUpDown[] nVelDr = { ndDrVel0, ndDrVel1, ndDrVel2, ndDrVel3 };
            NumericUpDown[] nAcc = { ndAcc0, ndAcc1, ndAcc2, ndAcc3 };
            RadioButton[] rbT = { rbT0, rbT1, rbT2, rbT3 };
            NumericUpDown[] ndMaxCoord = { ndMaxCoord0, ndMaxCoord1, ndMaxCoord2, ndMaxCoord3 };
            //buffer values
            double[] jerk = new double[Machine.board.AxesCount];
            double[] velDr = new double[Machine.board.AxesCount];
            double[] acc = new double[Machine.board.AxesCount];
            double[] velManFast = new double[Machine.board.AxesCount];
            double[] velManSlow = new double[Machine.board.AxesCount];
            double[] maxCoord = new double[Machine.board.AxesCount];

            for (int i = 0; i < Machine.board.AxesCount; i++)
            {
                if (rbT[i].Checked == true) jerk[i] = 0;
                else jerk[i] = 1;
                acc[i] = Convert.ToDouble(nAcc[i].Value);
                velDr[i] = Convert.ToDouble(nVelDr[i].Value);
                velManSlow[i] = Convert.ToDouble(nVelManipSlow[i].Value);
                velManFast[i] = Convert.ToDouble(nVelManipFast[i].Value);
                maxCoord[i] = Convert.ToDouble(ndMaxCoord[i].Value);
            }

            Machine.Instance.Jerk = jerk;
            AxesController.SetJerk(Machine.board, Machine.Instance.Jerk);
            Machine.Instance.Acceleration = acc;
            AxesController.SetActAcc(Machine.board, Machine.Instance.Acceleration);
            AxesController.SetDeceleration(Machine.board, acc);
            Machine.Instance.SlowManipulatorVelocity = velManSlow;
            Machine.Instance.FastManipulatorVelocity = velManFast;
            Machine.Instance.DriverVelocity = velDr;
            Machine.Instance.MaxCoordinate = maxCoord;

            dr.ParametersBeenSet = true;
            //ParametersBeenSet = true;
        }

        private void btnLoadParameters_Click(object sender, EventArgs e)
        {
            if (File.Exists(Machine.ParametersFilePath))
            {
                ParseParams(true);
            }
            else MessageBox.Show("Вы ещё не сохраняли скорости.");
        }

        private void btnSaveParameters_Click(object sender, EventArgs e)
        {
            NumericUpDown[] nVelManipSlow = { ndSlowVel0, ndSlowVel1, ndSlowVel2, ndSlowVel3 };
            NumericUpDown[] nVelManipFast = { ndFastVel0, ndFastVel1, ndFastVel2, ndFastVel3 };
            NumericUpDown[] nVelDr = { ndDrVel0, ndDrVel1, ndDrVel2, ndDrVel3 };
            NumericUpDown[] nAcc = { ndAcc0, ndAcc1, ndAcc2, ndAcc3 };
            RadioButton[] rbT = { rbT0, rbT1, rbT2, rbT3 };
            NumericUpDown[] ndMaxCoord = { ndMaxCoord0, ndMaxCoord1, ndMaxCoord2, ndMaxCoord3 };


            double[] tempMaxCoord = new double[4];
            double[] tempAcc = new double[4];
            double[] tempSlowManipVel = new double[4];
            double[] tempFastManipVel = new double[4];
            double[] tempDrVel = new double[4];
            double[] jerk = new double[Machine.board.AxesCount];

            for (int i = 0; i < Machine.board.AxesCount; i++)
            {
                tempAcc[i] = Convert.ToDouble(nAcc[i].Value);
                tempSlowManipVel[i] = Convert.ToDouble(nVelManipSlow[i].Value);
                tempFastManipVel[i] = Convert.ToDouble(nVelManipFast[i].Value);
                tempDrVel[i] = Convert.ToDouble(nVelDr[i].Value);
                tempMaxCoord[i] = Convert.ToDouble(ndMaxCoord[i].Value);
                if (rbT[i].Checked == true) jerk[i] = 0;
                else jerk[i] = 1;
            }
            Machine.Instance.Acceleration = tempAcc;
            Machine.Instance.SlowManipulatorVelocity = tempSlowManipVel;
            Machine.Instance.FastManipulatorVelocity = tempFastManipVel;
            Machine.Instance.DriverVelocity = tempDrVel;
            Machine.Instance.Jerk = jerk;
            Machine.Instance.MaxCoordinate = tempMaxCoord;

            Machine.SaveMachineParameters();
            dr.ParametersBeenSet = true;
        }

        private void ndFastVel0_ValueChanged(object sender, EventArgs e)
        {
            ndSlowVel0.Maximum = ndFastVel0.Value;
        }

        private void ndFastVel1_ValueChanged(object sender, EventArgs e)
        {
            ndSlowVel1.Maximum = ndFastVel1.Value;
        }

        private void ndFastVel2_ValueChanged(object sender, EventArgs e)
        {
            ndSlowVel2.Maximum = ndFastVel2.Value;
        }

        private void ndFastVel3_ValueChanged(object sender, EventArgs e)
        {
            ndSlowVel3.Maximum = ndFastVel3.Value;
        }

        private void ndDrVel0_ValueChanged(object sender, EventArgs e)
        {
            ndFastVel0.Maximum = ndDrVel0.Value;
        }

        private void ndDrVel1_ValueChanged(object sender, EventArgs e)
        {
            ndFastVel1.Maximum = ndDrVel1.Value;
        }

        private void ndDrVel2_ValueChanged(object sender, EventArgs e)
        {
            ndFastVel2.Maximum = ndDrVel2.Value;
        }

        private void ndDrVel3_ValueChanged(object sender, EventArgs e)
        {
            ndFastVel3.Maximum = ndDrVel3.Value;
        }
    } // class
} // namespace
