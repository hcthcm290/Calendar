using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calender
{
    [Serializable]
    public class PlanItem
    {
        public PlanItem()
        {

        }
        public PlanItem(int day, string title, string description)
        {
            this.day = day;
            this.title = title;
            this.description = description;
        }
        public int day { get; set; }
        public string title { get; set; }
        public string description { get; set; }
    }
}
