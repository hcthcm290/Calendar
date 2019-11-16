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
        public List<GroupPlanItem> group = new List<GroupPlanItem>();

        public void Insert(GroupPlanItem item)
        {
            group.Add(item);
        }

        public void Delete(GroupPlanItem item)
        {
            group.Remove(item);
        }

        public List<GroupPlanItem> ListGroupAlertForToday(DateTime today)
        {
            return group.FindAll(element => element.ExistsAlertForToday(today));
        }

        public List<GroupPlanItem> ListGroupItemsForToday(DateTime today)
        {
            return group.FindAll(element => element.ExistsItemForToday(today));
        }
    }
}
