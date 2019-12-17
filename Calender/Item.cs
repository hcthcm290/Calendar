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
            edit.FlatAppearance.BorderSize = 0;
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            if (item.priority == PriorityEnum.normal)
            {
                e.Graphics.FillEllipse(new SolidBrush(Color.FromArgb(202, 64, 77)), new RectangleF(17, 19, 26, 26));
                e.Graphics.FillEllipse(new SolidBrush(Color.White), new RectangleF(20, 22, 20, 20));
            }
            else if (item.priority == PriorityEnum.medium)
            {
                e.Graphics.FillEllipse(new SolidBrush(Color.FromArgb(238, 196, 106)), new RectangleF(17, 19, 26, 26));
                e.Graphics.FillEllipse(new SolidBrush(Color.White), new RectangleF(20, 22, 20, 20));

            }
            else if (item.priority == PriorityEnum.high)
            {
                e.Graphics.FillEllipse(new SolidBrush(Color.FromArgb(68, 75, 83)), new RectangleF(17, 19, 26, 26));
                e.Graphics.FillEllipse(new SolidBrush(Color.White), new RectangleF(20, 22, 20, 20));
            }
            else if (item.priority == PriorityEnum.urgent)
            {
                e.Graphics.FillEllipse(new SolidBrush(Color.FromArgb(0, 0, 0)), new RectangleF(17, 19, 26, 26));
                e.Graphics.FillEllipse(new SolidBrush(Color.White), new RectangleF(20, 22, 20, 20));
            }
            if (item.done == true)
            {
                tick.Visible = true;
            }
            else
            {
                tick.Visible = false;
            }
        }

        private void Item_Click(object sender, EventArgs e)
        {
            
        }

        private void location_Click(object sender, EventArgs e)
        {

        }

        private void tick_Click(object sender, EventArgs e)
        {
            this.item.done = !this.item.done;
            this.Refresh();
        }

        private void checkLabel_Click(object sender, EventArgs e)
        {
            tick_Click(sender, e);
        }
    }
}
