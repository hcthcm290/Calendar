using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calender
{
    class Year
    {
        private static int yCurrent = 0;
        public static void SyncYear()
        {
            yCurrent = DateTime.Now.Year;
        }
        public static int GetCurrentYear()
        {
            return yCurrent;
        }
        public static void ToNextYear()
        {
            yCurrent++;
        }
        public static void ToPrevYear()
        {
            yCurrent--;
        }
    }
}
