using System;

namespace DDD.WinForm.Common
{
    class CommonFunc
    {
        public static string RoundString(float value, int decimalPoint)
        {
            var temp = Convert.ToSingle(Math.Round(value, decimalPoint));
            return temp.ToString("F" + decimalPoint);
        }
    }
}
