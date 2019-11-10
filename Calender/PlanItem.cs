using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calender
{
    public class PlanItem
    {
        public PlanItem(int day, string title, string description)
        {
            this.day = day;
            this.title = title;
            this.description = description;
        }
        public int day;
        public string title;
        public string description;
    }
}
