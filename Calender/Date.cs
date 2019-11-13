using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calender
{
    class Date
    {
        static public void AddMonth(int year, int month, out int out_year, out int out_month, int dMonth)
        {
            out_year = year;
            out_month = month + dMonth % 12;
            out_year += dMonth / 12;

            if(out_month > 12)
            {
                out_year += 1;
                out_month -= 12;
            }
        }
    }
}
