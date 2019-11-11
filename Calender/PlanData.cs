using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Calender
{
    [Serializable]
    public class PlanData
    {
        public List<PlanItem> data = new List<PlanItem>();

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

        public List<PlanItem> ListAlertForToday(DateTime today)
        {
            return data.FindAll(element => (element.alert.Day == today.Day && 
                                            element.alert.Month == today.Month &&
                                            element.alert.Year == today.Year));
        }

        public List<PlanItem> ListItemsForToday(DateTime today)
        {
            return data.FindAll(element => (element.alert.Day == today.Day &&
                                            element.alert.Month == today.Month &&
                                            element.alert.Year == today.Year));
        }

        
    }
}
