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

        public Item(GroupPlanItem group, PlanItem item)
        {
            InitializeComponent();
            this.group = group;
            this.item = item;
            this.title.Text = item.title;
            this.location.Text = item.location;
            this.startTime.Text = item.startTime.Hour.ToString() + ":" + item.startTime.Minute.ToString();
            this.endTime.Text = item.endTime.Hour.ToString() + ":" + item.endTime.Minute.ToString();
        }

        private void Item_Load(object sender, EventArgs e)
        {

        }
    }
}
