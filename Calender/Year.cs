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

        static public int GetMaxDaysOfMonth(int year, int month)
        {
            switch (month)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    {
                        return 31;
                    }
                case 4:
                case 6:
                case 9:
                case 11:
                    return 30;
                case 2:
                    {
                        if (year % 4 == 0)
                        {
                            if (year % 100 == 0 && year % 400 != 0)
                            {
                                return 28;
                            }
                            return 29;
                        }
                        return 28;
                    }
            }
            return -1;
        }
    }
}
