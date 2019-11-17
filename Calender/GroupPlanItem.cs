using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calender
{
    public class GroupPlanItem
    {
        public List<PlanItem> data = new List<PlanItem>();
        public int repeatKind = 0; // 0 = None, 1 = Daily, 2 = A Week, 3 = A Month, 4 = A year, 5 = Custom
        public int repeatValue = 0;

        public void Insert(PlanItem item)
        {
            data.Add(item);
        }

        public void Delete(PlanItem item)
        {
            data.Remove(item);
        }

        public void Change(PlanItem oldItem, PlanItem newItem)
        {
            
            data.Remove(oldItem);
            data.Add(newItem);
        }

        public PlanItem AlertForToday(DateTime today)
        {
            return data.Find(element => (element.alert.Day == today.Day &&
                                            element.alert.Month == today.Month &&
                                            element.alert.Year == today.Year));
        }

        public PlanItem ItemsForToday(DateTime today)
        {
            DateTime endToday = new DateTime(today.Year, today.Month, today.Day);
            endToday = endToday.AddHours(23);
            endToday = endToday.AddMinutes(59);

            return data.Find(element => !(today > element.endTime || endToday < element.startTime));
        }

        public bool ExistsAlertForToday(DateTime today)
        {
            return data.Exists(element => (element.alert.Day == today.Day &&
                                           element.alert.Month == today.Month &&
                                           element.alert.Year == today.Year));
        }

        public bool ExistsItemForToday(DateTime today)
        {
            DateTime endToday = new DateTime(today.Year, today.Month, today.Day);
            endToday = endToday.AddHours(23);
            endToday = endToday.AddMinutes(59);

            return data.Exists(element => !(today > element.endTime || endToday < element.startTime));
        }
    }
}
