using Advantech.Motion;
using System;
using System.Text;
using System.Windows.Forms;

namespace My6705.NET_Framework_4._5
{
    /// <summary>
    /// Проверяет на ошибку/исключение при вызове команд из Advantech.Motion
    /// </summary>
    public static class BoardActionPerformer
    {
        public static void PerformBoardAction(Func<UInt32> action, string errorMessagePrefix)
        {
            uint errorCode = action();
            string errorMessage = $"{errorMessagePrefix} Failed With Error Code: [0x";
            if (errorCode != (uint)ErrorCode.SUCCESS)
            {
                errorMessage += Convert.ToString(errorCode, 16) + ']';
                StringBuilder ErrorMsg = new StringBuilder("", 100);
                //Get the error message according to error code returned from API
                Boolean res = Motion.mAcm_GetErrorMessage(errorCode, ErrorMsg, 100);
                string ErrorMessage = "";
                if (res) ErrorMessage = ErrorMsg.ToString();
                MessageBox.Show(errorMessage + "\r\nError Message:" + ErrorMessage, "6705 Software", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw new Exception();
            }
        }
    }
}