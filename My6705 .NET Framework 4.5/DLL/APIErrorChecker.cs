using Advantech.Motion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace My6705.NET_Framework_4._5.DLL
{
    public static class APIErrorChecker
    {
        public static void Check(uint errorCode, string errorPrefix)
        {
            string errorMessage = $"{errorPrefix} Failed With Error Code: [0x";
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
