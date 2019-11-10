using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calender
{
    [Serializable]
    public class PlanData
    {
        public List<PlanItem> data { get; set; } = new List<PlanItem>();

        public PlanData()
        {

        }

        public PlanData(PlanItem item)
        {
            data.Add(item);
        }

        public void Insert(PlanItem item)
        {
            data.Add(item);
        }

        public void Delete(PlanItem item)
        {
            data.Remove(item);
        }

        public List<PlanItem> GetItem(int day)
        {
            return data.FindAll(x => x.day == day);
        }
    }
}
