using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calender
{
    public partial class Item : UserControl
    {
        GroupPlanItem group;
        PlanItem item;

        public Item(GroupPlanItem group, PlanItem item, DateTime today)
        {
            InitializeComponent();
            this.group = group;
            this.item = item;
            this.title.Text = item.title;
            this.location.Text = item.location;
            if (today.Day == item.startTime.Day && today.Month == item.startTime.Month && today.Year == item.startTime.Year)
            {
                this.startTime.Text = item.startTime.Hour.ToString("00.##") + ":" + item.startTime.Minute.ToString("00.##");
            }
            else
            {
                this.startTime.Text = "00:00";
            }

            if (today.Day == item.endTime.Day && today.Month == item.endTime.Month && today.Year == item.endTime.Year)
            {
                this.endTime.Text = item.endTime.Hour.ToString("00.##") + ":" + item.endTime.Minute.ToString("00.##");
            }
            else
            {
                this.endTime.Text = "23:59";
            }
        }

        private void Item_Load(object sender, EventArgs e)
        {

        }
    }
}
