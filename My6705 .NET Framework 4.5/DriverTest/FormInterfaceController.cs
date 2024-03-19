using System;
using System.Windows.Forms;
using System.Linq;
using System.Collections.Generic;

namespace My6705.NET_Framework_4._5
{
    public partial class DriverTest
    {
        private Dictionary<CheckBox, RadioButton> checkboxesToRadioButtons = new Dictionary<CheckBox, RadioButton>();

        private void ActivateInterfaceByCb(object sender)
        {
            CheckBox checkbox = (CheckBox)sender;
            RadioButton radioButton;
            if (checkboxesToRadioButtons.TryGetValue(checkbox, out radioButton))
            {
                bool cben = false;
                for (int i = 0; i < 4; i++)
                {
                    if (checkboxesToRadioButtons.ElementAt(i).Value.Checked) cben = true;
                }

                if (!radioButton.Checked && !cben)
                {
                    radioButton.Checked = checkbox.Checked;
                }

                if (checkbox.Checked == false && checkboxesToRadioButtons[checkbox].Checked)
                {
                    radioButton.Checked = false;

                    // Находим следующий активный радиобаттон
                    int nextActiveIndex = FindNextActiveRadioButton(cbAddedAxes);

                    // Если такой радиобаттон найден, устанавливаем у него свойство Checked в значение true
                    if (nextActiveIndex < checkboxesToRadioButtons.Count)
                    {
                        checkboxesToRadioButtons.ElementAt(nextActiveIndex).Value.Checked = true;
                    }
                }
            }
        }

        private int FindNextActiveRadioButton(CheckBox[] checkboxes)
        {
            int nextActiveIndex = 0;
            while (nextActiveIndex < checkboxes.Length && !checkboxes[nextActiveIndex].Checked)
            {
                nextActiveIndex++;
            }

            return nextActiveIndex;
        }
        private void cbAddAxisX_CheckedChanged(object sender, EventArgs e)
        {
            ActivateInterfaceByCb(sender);
            nudPosition1X.Enabled = !nudPosition1X.Enabled;
            nudPosition2X.Enabled = !nudPosition2X.Enabled;
            rbDriveX.Enabled = !rbDriveX.Enabled;
        }

        private void cbAddAxisY_CheckedChanged(object sender, EventArgs e)
        {
            ActivateInterfaceByCb(sender);
            nudPosition1Y.Enabled = !nudPosition1Y.Enabled;
            nudPosition2Y.Enabled = !nudPosition2Y.Enabled;
            rbDriveY.Enabled = !rbDriveY.Enabled;
        }

        private void cbAddAxisZ_CheckedChanged(object sender, EventArgs e)
        {
            ActivateInterfaceByCb(sender);
            nudPosition1Z.Enabled = !nudPosition1Z.Enabled;
            nudPosition2Z.Enabled = !nudPosition2Z.Enabled;
            rbDriveZ.Enabled = !rbDriveZ.Enabled;
        }

        private void cbAddAxisPhi_CheckedChanged(object sender, EventArgs e)
        {
            ActivateInterfaceByCb(sender);
            nudPosition1Phi.Enabled = !nudPosition1Phi.Enabled;
            nudPosition2Phi.Enabled = !nudPosition2Phi.Enabled;
            rbDrivePhi.Enabled = !rbDrivePhi.Enabled;
        }

        void SetMaxCoord()
        {
            NumericUpDown[] nudPosition1 = { nudPosition1X, nudPosition1Y, nudPosition1Z, nudPosition1Phi };
            NumericUpDown[] nudPosition2 = { nudPosition2X, nudPosition2Y, nudPosition2Z, nudPosition2Phi };

            for (int i = 0; i < 4; i++)
            {
                if (Machine.MaxCoordinate[i] == 0) continue;
                decimal maxValue = Convert.ToDecimal(Machine.MaxCoordinate[i]);
                nudPosition2[i].Maximum = maxValue;
                nudPosition1[i].Maximum = maxValue;
            }
        }
        private void nudPosition1X_ValueChanged(object sender, EventArgs e)
        {
            SetMaxCoord();
        }

        private void nudPosition2Z_ValueChanged(object sender, EventArgs e)
        {
            SetMaxCoord();
        }

        private void nudPosition2Y_ValueChanged(object sender, EventArgs e)
        {
            SetMaxCoord();
        }

        private void nudPosition2X_ValueChanged(object sender, EventArgs e)
        {
            SetMaxCoord();
        }

        private void nudPosition1Phi_ValueChanged(object sender, EventArgs e)
        {
            SetMaxCoord();
        }

        private void nudPosition1Z_ValueChanged(object sender, EventArgs e)
        {
            SetMaxCoord();
        }

        private void nudPosition1Y_ValueChanged(object sender, EventArgs e)
        {
            SetMaxCoord();
        }

        private void nudPosition2Phi_ValueChanged(object sender, EventArgs e)
        {
            SetMaxCoord();
        }
    }
}
