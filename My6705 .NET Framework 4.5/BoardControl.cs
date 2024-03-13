using Advantech.Motion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace My6705.NET_Framework_4._5
{
    public static class BoardControl
    {
        public static void StartContinuousMovementPositiveChecked(this Board b, int axisIndex)
        {
            if (AxesController.GetAxisState(b[axisIndex]) == (ushort)AxisState.STA_AX_READY)
            {
                //если максимальная координата задана и нынешняя координата больше максимальной
                if ((Machine.MaxCoordinate[axisIndex] != 0) &&
                    (AxesController.GetAxisCommandPosition(b[axisIndex]) >=
                    Machine.MaxCoordinate[axisIndex]))

                {
                    MessageBox.Show("Достигнут максимум перемещения координаты");
                    return;
                }
                AxesController.StartContinuousMovement(b, axisIndex, 0);
            }
        }

    }
}
