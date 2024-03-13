using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace My6705.NET_Framework_4._5
{
    public class KeyboardControl
    {
        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;
        private const int WM_KEYUP = 0x0101;

        private static LowLevelKeyboardProc _proc = HookCallback;
        private static IntPtr _hookID = IntPtr.Zero;

        public static bool blockControls = false;

        public void PreInitialize()
        {
            _hookID = SetHook(_proc);
        }

        public void Initialize()
        {
            UnhookWindowsHookEx(_hookID);
        }

        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

        private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam) 
        {
            if (blockControls) return IntPtr.Zero;

            //Нажата ли клавиша передвижения
            if (nCode >= 0)
            {
                Keys key = (Keys)Marshal.ReadInt32(lParam);
                int axisIndex;

                //Соответсвие оси определённой клавише
                switch (key)
                {
                    case Keys.Right:
                    case Keys.Left:
                        axisIndex = 0;
                        break;
                    case Keys.Up:
                    case Keys.Down:
                        axisIndex = 1;
                        break;
                    case Keys.PageUp:
                    case Keys.PageDown:
                        axisIndex = 2;
                        break;
                    case Keys.Insert:
                    case Keys.Delete:
                        axisIndex = 3;
                        break;
                    default:
                        return IntPtr.Zero;
                }

                //событие KeyDown
                if (wParam == (IntPtr)WM_KEYDOWN)
                {
                    CtrlSpeedSwitch(axisIndex);
                    ushort direction;
                    const ushort PositiveDirection = 0, NegativeDirection = 1;
                    if (key == Keys.Right || key == Keys.Up || key == Keys.PageUp || key == Keys.Insert)
                        direction = PositiveDirection;
                    else
                        direction = NegativeDirection;
                    AxesController.StartContinuousMovementChecked(Machine.Board, axisIndex, direction);
                }

                //событие KeyUp
                if (wParam == (IntPtr)WM_KEYUP)
                {
                    AxesController.StopContinuousMovementEmg(Machine.Board[axisIndex]);
                }
            }

            // Передаем управление следующему хуку в цепочке
            return CallNextHookEx(_hookID, nCode, wParam, lParam);
        }

        private static IntPtr SetHook(LowLevelKeyboardProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(WH_KEYBOARD_LL, proc, GetModuleHandle(curModule.ModuleName), 0);
            }
        }

        private static void CtrlSpeedSwitch(int axisIndex)
        {
            double speed;
            if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
                speed = Machine.FastVelocity[axisIndex];
            else
                speed = Machine.SlowVelocity[axisIndex];
            AxesController.SetAxisHighVelocity(Machine.Board[axisIndex], speed);
        }

        #region DLL Imports
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);
        #endregion
    }
}
