using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calender
{
    public enum PriorityEnum
    {
        normal,
        medium,
        high,
        urgent,
    }

    [Serializable]
    public class PlanItem
    {
        public PlanItem()
        {

        }

        public PlanItem(string title, string note, DateTime startTime, DateTime endTime, PriorityEnum priority, DateTime alert, string location = "")
        {
            this.title = title;
            this.note = note;
            this.startTime = startTime;
            this.endTime = endTime;
            this.location = location;
            this.priority = priority;
            this.alert = alert;
        }

        public string title;
        public DateTime startTime;
        public DateTime endTime;
        public String location;
        public string note;
        public PriorityEnum priority;
        public DateTime alert;
    }
}
