﻿using System;
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

            DateTime datetime = DateTime.Now;
            for(int i = datetime.Year; i < datetime.Year + 10; i++)
            {
                this.Year_Start.Items.Add(i.ToString());
                this.Year_End.Items.Add(i.ToString());
            }

            this.Priority.Items.Add("Normal");
            this.Priority.Items.Add("Medium");
            this.Priority.Items.Add("High");
            this.Priority.Items.Add("Urgent");
            this.Priority.SelectedIndex = 0;

            this.Repeat.Items.Add("Daily");
            this.Repeat.Items.Add("A Week");
            this.Repeat.Items.Add("A Month");
            this.Repeat.Items.Add("A Year");
            this.Repeat.Items.Add("Custom");
            this.Repeat.SelectedIndex = 0;

            this.RepeatDayLabel.Parent = this.RepeatPanel;
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
                int day;
                Int32.TryParse(cb.Text, out day);
                if (day < 1)
                {
                    cb.Text = "1";
                }
                if (day > 31)
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
                int month;
                Int32.TryParse(cb.Text, out month);
                if (month < 1)
                {
                    cb.Text = "1";
                }
                if (month > 12)
                {
                    cb.Text = "12";
                }
            }
        }

        private void Day_Leave(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)(sender);
            int day;
            Int32.TryParse(cb.Text, out day);
            if (day < 1)
            {
                cb.Text = "1";
            }
            if (day > 31)
            {
                cb.Text = "31";
            }
        }

        private void Month_Leave(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)(sender);
            int month;
            Int32.TryParse(cb.Text, out month);
            if (month < 1)
            {
                cb.Text = "1";
            }
            if (month > 12)
            {
                cb.Text = "12";
            }
        }

        private void TB_Enter(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text == tb.Name)
            {
                tb.Text = "";
            }
        }

        private void TB_Leave(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text == "")
            {
                tb.Text = tb.Name;
            }
        }

        private void Repeat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(Repeat.SelectedItem.ToString() == "Custom")
            {
                Repeat.DropDownStyle = ComboBoxStyle.DropDown;
                Repeat.Text = "1";
                RepeatDayLabel.Visible = true;
                RepeatDayLabel.BringToFront();
            }
            else if(Repeat.DropDownStyle == ComboBoxStyle.DropDown && Repeat.SelectedItem.ToString() != "Custom")
            {
                Repeat.DropDownStyle = ComboBoxStyle.DropDownList;
                Repeat.SelectedIndex = 0;
                RepeatDayLabel.Visible = false;
                RepeatDayLabel.BringToFront();
                Repeat.Text = "";
            }
        }

        private void Repeat_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter && Repeat.DropDownStyle == ComboBoxStyle.DropDown)
            {
                int result;
                Int32.TryParse(Repeat.Text, out result);
                Repeat.Text = result.ToString();
            }
        }

        private void Repeat_Leave(object sender, EventArgs e)
        {
            if(Repeat.DropDownStyle == ComboBoxStyle.DropDown)
            {
                int result;
                Int32.TryParse(Repeat.Text, out result);
                if(result <= 0)
                {
                    result = 1;
                }
                Repeat.Text = result.ToString();
            }
        }
    }
}
