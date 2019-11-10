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
    public partial class AJob : UserControl
    {
        PlanItem item;
        public AJob(string title, string description)
        {
            InitializeComponent();
            Title.Text = title;
            Description.Text = description;
        }

        public AJob(PlanItem planItem)
        {
            InitializeComponent();
            item = planItem;
            Title.Text = item.title;
            Description.Text = item.description;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            item.title = Title.Text;
            item.description = Description.Text;
        }
    }
}
