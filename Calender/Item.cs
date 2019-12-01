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

        private void edit_Click(object sender, EventArgs e)
        {
            EditEvent edit = new EditEvent(Form1.allPlan, group, item);
            edit.ShowDialog();
        }

        private void Item_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            if (item.priority == PriorityEnum.normal)
            {
                e.Graphics.FillEllipse(new SolidBrush(Color.FromArgb(99, 110, 114)), new RectangleF(20, 20, 20, 20));
            }
            else if (item.priority == PriorityEnum.medium)
            {
                e.Graphics.FillEllipse(new SolidBrush(Color.FromArgb(255, 195, 0)), new RectangleF(20, 20, 20, 20));
            }
            else if (item.priority == PriorityEnum.high)
            {
                e.Graphics.FillEllipse(new SolidBrush(Color.FromArgb(255, 87, 51)), new RectangleF(20, 20, 20, 20));
            }
            else if (item.priority == PriorityEnum.urgent)
            {
                e.Graphics.FillEllipse(new SolidBrush(Color.FromArgb(199, 0, 57)), new RectangleF(20, 20, 20, 20));
            }
        }
    }
}
