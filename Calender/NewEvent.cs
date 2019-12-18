﻿using System;
using System.Drawing;
using System.Windows.Forms;
using ClockPicker;

namespace Calender
{
    public partial class New_Event : Form
    {
        public PlanData thisPlan;
        
        public New_Event()
        {
            InitializeComponent();
            Init();
            this.Refresh();

        }
        public New_Event(PlanData planData)
        {
            InitializeComponent();
            Init();
            thisPlan = planData;
            this.StartPosition = FormStartPosition.CenterParent;
        }
        public New_Event(PlanData planData, DateTime focusedDate)
        {
            InitializeComponent();
            Init();
            thisPlan = planData;
            this.StartPosition = FormStartPosition.CenterParent;/*
            this.Day_Start.Text = this.Day_End.Text = focusedDate.Day.ToString();
            this.Month_Start.Text = this.Month_End.Text = focusedDate.Month.ToString();
            this.Year_Start.Text = this.Year_End.Text = focusedDate.Year.ToString();
            */
            this.label1.Focus();
            startDateDE.DateTime = focusedDate;
            EndDateDE.DateTime = focusedDate;
            string sad = startTimeTP.Text;
        }

        void Init()
        {
            /*
            for (int i = 1; i <= 31; i++)
            {
                this.Day_End.Items.Add(i.ToString());
                this.Day_Start.Items.Add(i.ToString());
                this.Day_RepeatEnd.Items.Add(i.ToString());
            }

            for (int i = 1; i <= 12; i++)
            {
                this.Month_Start.Items.Add(i.ToString());
                this.Month_End.Items.Add(i.ToString());
                this.Month_RepeatEnd.Items.Add(i.ToString());
            }

            DateTime datetime = DateTime.Now;
            for (int i = datetime.Year; i < datetime.Year + 10; i++)
            {
                this.Year_Start.Items.Add(i.ToString());
                this.Year_End.Items.Add(i.ToString());
                this.Year_RepeatEnd.Items.Add(i.ToString());
            }

            for (int i = 0; i <= 23; i++)
            {
                this.Hour_Start.Items.Add(i.ToString());
                this.Hour_End.Items.Add(i.ToString());
            }

            for (int i = 0; i <= 59; i++)
            {
                this.Minute_Start.Items.Add(i.ToString());
                this.Minute_End.Items.Add(i.ToString());
            }
            */
            this.cbbRepeat.Items.Add("No repeat");
            this.cbbRepeat.Items.Add("Every day");
            this.cbbRepeat.Items.Add("Every week");
            this.cbbRepeat.Items.Add("Every month");
            this.cbbRepeat.Items.Add("Every year");
            this.cbbRepeat.Items.Add("Custom");
            this.cbbRepeat.SelectedIndex = 0;

            this.cbbalert.Items.Add("1 hour before");
            this.cbbalert.Items.Add("30 mins before");
            this.cbbalert.Items.Add("15 mins before");
            this.cbbalert.Items.Add("At time of event");
            this.cbbalert.SelectedIndex = 3;


        }
        private void New_Event_Load(object sender, EventArgs e)
        {

        }
        private void Silent_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
        private void Day_KeyDown(object sender, KeyEventArgs e)
        {
            ComboBox cb = (ComboBox)(sender);
            if (e.KeyCode == Keys.Enter)
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
                e.Handled = true;
                e.SuppressKeyPress = true;
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

                e.Handled = true;
                e.SuppressKeyPress = true;
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
            if (tb.Text.ToLower() == tb.Name)
            {
                tb.Text = "";
            }
        }
        private void TB_Leave(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text == "")
            {
                tb.Text = tb.Name.Substring(0, 1).ToUpper() + tb.Name.Substring(1);
            }
        }
        private void Repeat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbRepeat.SelectedItem.ToString() == "custom")
            {
                repeatValue.Visible = true;
                repeatValue.BringToFront();
                repeatValue.Focus();
                //edit this
            }
            else
            {
                repeatValue.Visible = false;
                label1.Focus();
                //edit this
            }
            /*
            if (cbbRepeat.SelectedItem.ToString() == "none")
            {
                Day_RepeatEnd.Enabled = false;
                Month_RepeatEnd.Enabled = false;
                Year_RepeatEnd.Enabled = false;

                Day_RepeatEnd.Text = "dd";
                Month_RepeatEnd.Text = "mm";
                Year_RepeatEnd.Text = "yyyy";
            }
            else
            {
                Day_RepeatEnd.Enabled = true;
                Month_RepeatEnd.Enabled = true;
                Year_RepeatEnd.Enabled = true;
            }
            */
        }
        public bool CheckLegitDate(int year, int month, int day)
        {
            if (day > Year.GetMaxDaysOfMonth(year, month))
            {
                return false;
            }
            return true;
        }
        public virtual void SaveButton_Click(object sender, EventArgs e)
        {
            TimeSpan alertTimeSpane = new TimeSpan();
            if(cbbalert.SelectedIndex == 0)
            {
                alertTimeSpane = new TimeSpan(1, 0, 0);
            }
            else if (cbbalert.SelectedIndex == 1)
            {
                alertTimeSpane = new TimeSpan(0, 30, 0);
            }
            else if (cbbalert.SelectedIndex == 2)
            {
                alertTimeSpane = new TimeSpan(0, 15, 0);
            }
            else if (cbbalert.SelectedIndex == 3)
            {
                alertTimeSpane = new TimeSpan(0, 0, 0);
            }

            GroupPlanItem newGroup = new GroupPlanItem();
            /*
            int tDay_Start, tMonth_Start, tYear_Start, tHour_Start, tMinute_Start;
          
            Int32.TryParse(Day_Start.Text, out tDay_Start);
            Int32.TryParse(Month_Start.Text, out tMonth_Start);
            Int32.TryParse(Year_Start.Text, out tYear_Start);
            Int32.TryParse(Hour_Start.Text, out tHour_Start);
            Int32.TryParse(Minute_Start.Text, out tMinute_Start);
            if (CheckLegitDate(tYear_Start, tMonth_Start, tDay_Start) == false)
            {
                MessageBox.Show("Invalid Start Date");
                return;
            }
            
            DateTime start = new DateTime(tYear_Start, tMonth_Start, tDay_Start, tHour_Start, tMinute_Start, 0);

            int tDay_End, tMonth_End, tYear_End, tHour_End, tMinute_End;
            Int32.TryParse(Day_End.Text, out tDay_End);
            Int32.TryParse(Month_End.Text, out tMonth_End);
            Int32.TryParse(Year_End.Text, out tYear_End);
            Int32.TryParse(Hour_End.Text, out tHour_End);
            Int32.TryParse(Minute_End.Text, out tMinute_End);
            if (CheckLegitDate(tYear_End, tMonth_End, tDay_End) == false)
            {
                MessageBox.Show("Invalid End Date");
                return;
            }
            DateTime end = new DateTime(tYear_End, tMonth_End, tDay_End, tHour_End, tMinute_End, 0);

            if (end <= start)
            {
                MessageBox.Show("End Day must after Start Day");
                return;
            }
            */
            ////////////////////////////////////////////////////////////////
            ///
            // FOR NONE //
            if (cbbRepeat.Text.ToString() == "None")
            {
                newGroup.repeatKind = 0;                thisPlan.Insert(newGroup);
                this.Close();
                return;
            }
            /*
            int tDay_RepeatEnd, tMonth_RepeatEnd, tYear_RepeatEnd;
            Int32.TryParse(Day_RepeatEnd.Text, out tDay_RepeatEnd);
            Int32.TryParse(Month_RepeatEnd.Text, out tMonth_RepeatEnd);
            Int32.TryParse(Year_RepeatEnd.Text, out tYear_RepeatEnd);
            if (CheckLegitDate(tYear_RepeatEnd, tMonth_RepeatEnd, tDay_RepeatEnd) == false)
            {
                MessageBox.Show("Invalid RepeatEnd Date");
                return;
            }
            DateTime repeatEnd = new DateTime(tYear_RepeatEnd, tMonth_RepeatEnd, tDay_RepeatEnd, 23, 59, 59);

            if (repeatEnd < end)
            {
                MessageBox.Show("The end for Repeat end must after the end of event");
                return;
            }

            newGroup.repeatEnd = repeatEnd;

            if (cbbRepeat.Text.ToString() == "Daily")
            {
                newGroup.repeatKind = 1;
                while (true)
                {

                    start = start.AddDays(1);
                    end = end.AddDays(1);

                    if (start > repeatEnd)
                    {
                        thisPlan.Insert(newGroup);
                        this.Close();
                        return;
                    }
                }
            }
            else if (cbbRepeat.Text.ToString() == "A Week")
            {
                newGroup.repeatKind = 2;
                while (true)
                {

                    start = start.AddDays(7);
                    end = end.AddDays(7);

                    if (start > repeatEnd)
                    {
                        thisPlan.Insert(newGroup);
                        this.Close();
                        return;
                    }
                }
            }
            else if (cbbRepeat.Text.ToString() == "A Month")
            {
                newGroup.repeatKind = 3;

                TimeSpan timeSpan = end - start;
                while (true)
                {
                    do
                    {
                        Date.AddMonth(tYear_Start, tMonth_Start, out tYear_Start, out tMonth_Start, 1);
                    }
                    while (tDay_Start > Year.GetMaxDaysOfMonth(tYear_Start, tMonth_Start));

                    start = new DateTime(tYear_Start, tMonth_Start, tDay_Start, tHour_Start, tMinute_Start, 0);
                    if (start > repeatEnd)
                    {
                        thisPlan.Insert(newGroup);
                        this.Close();
                        return;
                    }
                }
            }
            
            else if (cbbRepeat.Text.ToString() == "A Year")
            {
                newGroup.repeatKind = 4;

                TimeSpan timeSpan = end - start;
                while (true)
                {
                    do
                    {
                        Date.AddMonth(tYear_Start, tMonth_Start, out tYear_Start, out tMonth_Start, 12);
                    }
                    while (tDay_Start > Year.GetMaxDaysOfMonth(tYear_Start, tMonth_Start));

                    start = new DateTime(tYear_Start, tMonth_Start, tDay_Start, tHour_Start, tMinute_Start, 0);
                    if (start > repeatEnd)
                    {
                        thisPlan.Insert(newGroup);
                        this.Close();
                        return;
                    }
                }
            }
            else
            {
                newGroup.repeatKind = 5;
                newGroup.repeatValue = Convert.ToInt32(repeatValue.Text);

                while (true)
                {
                    start = start.AddDays(Convert.ToInt32(repeatValue.Text));
                    end = end.AddDays(Convert.ToInt32(repeatValue.Text));

                    if (start > repeatEnd)
                    {
                        thisPlan.Insert(newGroup);
                        this.Close();
                        return;
                    }
                }
            }
            */
        }

        /*
        private void Day_Start_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            Day_End.SelectedIndex = cb.SelectedIndex;
        }

        private void Month_Start_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            Month_End.SelectedIndex = cb.SelectedIndex;
        }

        private void Year_Start_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            Year_End.SelectedIndex = cb.SelectedIndex;
        }

        private void Day_Start_TextChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            Day_End.Text = cb.Text;
        }

        private void Month_Start_TextChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            Month_End.Text = cb.Text;
        }

        private void Year_Start_TextChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            Year_End.Text = cb.Text;
        }

        private void RepeatEndLabel_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void Minute_Start_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
        */
        private void Minute_End_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Hour_Start_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void New_Event_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            e.Graphics.FillEllipse(new SolidBrush(Color.FromArgb(202, 64, 77)), new RectangleF(304, 345, 22, 22));
            e.Graphics.FillEllipse(new SolidBrush(Color.FromArgb(238, 196, 106)), new RectangleF(251, 345, 22, 22));
            e.Graphics.FillEllipse(new SolidBrush(Color.FromArgb(68, 75, 83)), new RectangleF(198, 345, 22, 22));
            e.Graphics.DrawRectangle(new Pen(new SolidBrush(Color.Black), 10), new Rectangle(0, 0, this.Width, this.Height));
        }

        private void Day_End_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void New_Event_MouseDown(object sender, MouseEventArgs e)
        {
            label1.Focus();
        }

        private void dateEdit1_Click(object sender, EventArgs e)
        {

        }

        private void dateEdit1_Click_1(object sender, EventArgs e)
        {
            startDateDE.ShowPopup();
        }

        private void dateEdit2_Click(object sender, EventArgs e)
        {
            EndDateDE.ShowPopup();
        }

        private void dateEdit1_EditValueChanged(object sender, EventArgs e)
        {
            label1.Focus();
        }

        private void dateEdit2_EditValueChanged(object sender, EventArgs e)
        {
            label1.Focus();
        }

        private void timePicker1_Leave(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
