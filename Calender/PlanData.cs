using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calender
{
    class PlanData
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

        public List<PlanItem> GetItem(int day)
        {
            return data.FindAll(x => x.day == day);
        }
    }
}
