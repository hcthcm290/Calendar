using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calender
{
    class Months
    {
        private enum Month
        {
            January     = 1,
            February    = 2,
            March       = 3,
            April       = 4,
            May         = 5,
            June        = 6,
            July        = 7,
            August      = 8,
            September   = 9,
            October     = 10,
            November    = 11,
            December    = 12,
        }
        public static string GetMonth()
        {
            foreach(Month m in Enum.GetValues(typeof(Month)))
            {
                if((int)m == iCurrent)
                {
                    return m.ToString();
                }
            }
            return "";
        }

        public static void ToNextMonth()
        {
            iCurrent = (iCurrent + 1) % 13;
            if(iCurrent == 0)
            {
                iCurrent = 1;
                Year.ToNextYear();
            }
        }

        public static void ToPrevMonth()
        {
            iCurrent = iCurrent - 1;
            if (iCurrent == 0)
            {
                iCurrent = 12;
                Year.ToPrevYear();
            }
        }

        public static void SyncMonth()
        {
            iCurrent = DateTime.Now.Month;
        }

        static public int iCurrent = 1;
    }
}
