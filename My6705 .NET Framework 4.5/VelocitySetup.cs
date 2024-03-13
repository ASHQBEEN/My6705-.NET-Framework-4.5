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
                if (File.Exists(Machine.Board.jsonPath))
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
                Machine.Board.LoadBoardProperties();
            }

            for (int i = 0; i < Machine.Board.AxesCount; i++)
            {
                nVelManipSlow[i].Text = Convert.ToString(Machine.SlowVelocity[i]);
                nVelManipFast[i].Text = Convert.ToString(Machine.FastVelocity[i]);
                nAcc[i].Text = Convert.ToString(Machine.Acceleration[i]);
                nVelDr[i].Text = Convert.ToString(Machine.DriverVelocity[i]);
                ndMaxCoord[i].Text = Convert.ToString(Machine.MaxCoordinate[i]);
                if (Machine.Jerk[i] == 0) rbT[i].Checked = true;
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
            double[] jerk = new double[Machine.Board.AxesCount];
            double[] velDr = new double[Machine.Board.AxesCount];
            double[] acc = new double[Machine.Board.AxesCount];
            double[] velManFast = new double[Machine.Board.AxesCount];
            double[] velManSlow = new double[Machine.Board.AxesCount];
            double[] maxCoord = new double[Machine.Board.AxesCount];

            for (int i = 0; i < Machine.Board.AxesCount; i++)
            {
                if (rbT[i].Checked == true) jerk[i] = 0;
                else jerk[i] = 1;
                acc[i] = Convert.ToDouble(nAcc[i].Value);
                velDr[i] = Convert.ToDouble(nVelDr[i].Value);
                velManSlow[i] = Convert.ToDouble(nVelManipSlow[i].Value);
                velManFast[i] = Convert.ToDouble(nVelManipFast[i].Value);
                maxCoord[i] = Convert.ToDouble(ndMaxCoord[i].Value);
            }

            Machine.Jerk = jerk;
            AxesController.SetJerk(Machine.Board, Machine.Jerk);
            Machine.Acceleration = acc;
            AxesController.SetActAcc(Machine.Board, Machine.Acceleration);
            AxesController.SetDeceleration(Machine.Board, acc);
            Machine.SlowVelocity = velManSlow;
            Machine.FastVelocity = velManFast;
            Machine.DriverVelocity = velDr;
            Machine.MaxCoordinate = maxCoord;

            dr.ParametersBeenSet = true;
            //ParametersBeenSet = true;
        }

        private void btnLoadParameters_Click(object sender, EventArgs e)
        {
            if (File.Exists(Machine.Board.jsonPath))
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
            double[] jerk = new double[Machine.Board.AxesCount];

            for (int i = 0; i < Machine.Board.AxesCount; i++)
            {
                tempAcc[i] = Convert.ToDouble(nAcc[i].Value);
                tempSlowManipVel[i] = Convert.ToDouble(nVelManipSlow[i].Value);
                tempFastManipVel[i] = Convert.ToDouble(nVelManipFast[i].Value);
                tempDrVel[i] = Convert.ToDouble(nVelDr[i].Value);
                tempMaxCoord[i] = Convert.ToDouble(ndMaxCoord[i].Value);
                if (rbT[i].Checked == true) jerk[i] = 0;
                else jerk[i] = 1;
            }
            Machine.Acceleration = tempAcc;
            Machine.SlowVelocity = tempSlowManipVel;
            Machine.FastVelocity = tempFastManipVel;
            Machine.DriverVelocity = tempDrVel;
            Machine.Jerk = jerk;
            Machine.MaxCoordinate = tempMaxCoord;

            Machine.Board.SaveBoardProperties();
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
