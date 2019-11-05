using System;
using System.Windows.Forms;

namespace Calender
{
    public partial class New_Event : Form
    {
        public New_Event()
        {
            InitializeComponent();
            Init();
        }

        void Init()
        {
            for (int i = 1; i <= 31; i++)
            {
                this.Day_End.Items.Add(i.ToString());
                this.Day_Start.Items.Add(i.ToString());
            }
            for(int i = 1; i<=12; i++)
            {
                this.Month_Start.Items.Add(i.ToString());
                this.Month_End.Items.Add(i.ToString());
            }
        }

        private void Panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void New_Event_Load(object sender, EventArgs e)
        {

        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ComboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {

        }

        private void ComboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Day_KeyDown(object sender, KeyEventArgs e)
        {
            ComboBox cb = (ComboBox)(sender);
            if(e.KeyCode == Keys.Enter)
            {
                if(Convert.ToInt32(cb.Text) < 1)
                {
                    cb.Text = "1";
                }
                if(Convert.ToInt32(cb.Text) > 31)
                {
                    cb.Text = "31";
                }
            }
        }

        private void Month_KeyDown(object sender, KeyEventArgs e)
        {
            ComboBox cb = (ComboBox)(sender);
            if (e.KeyCode == Keys.Enter)
            {
                if (Convert.ToInt32(cb.Text) < 1)
                {
                    cb.Text = "1";
                }
                if (Convert.ToInt32(cb.Text) > 12)
                {
                    cb.Text = "12";
                }
            }
        }

    }
}
