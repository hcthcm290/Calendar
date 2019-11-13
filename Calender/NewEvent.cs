using System;
using System.Windows.Forms;
using System.Drawing;

namespace Calender
{
    public partial class New_Event : Form
    {
        PlanData thisPlan;

        public New_Event(PlanData plandata)
        {
            InitializeComponent();
            Init();
            thisPlan = plandata;
        }

        void Init()
        {
            for (int i = 1; i <= 31; i++)
            {
                this.Day_End.Items.Add(i.ToString());
                this.Day_Start.Items.Add(i.ToString());
                this.Day_RepeatEnd.Items.Add(i.ToString());
            }

            for(int i = 1; i<=12; i++)
            {
                this.Month_Start.Items.Add(i.ToString());
                this.Month_End.Items.Add(i.ToString());
                this.Month_RepeatEnd.Items.Add(i.ToString());
            }

            DateTime datetime = DateTime.Now;
            for(int i = datetime.Year; i < datetime.Year + 10; i++)
            {
                this.Year_Start.Items.Add(i.ToString());
                this.Year_End.Items.Add(i.ToString());
                this.Year_RepeatEnd.Items.Add(i.ToString());
            }

            this.Priority.Items.Add("Normal");
            this.Priority.Items.Add("Medium");
            this.Priority.Items.Add("High");
            this.Priority.Items.Add("Urgent");
            this.Priority.SelectedIndex = 0;

            this.Repeat.Items.Add("None");
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
            }
            if(Repeat.SelectedItem.ToString() == "None")
            {
                Day_RepeatEnd.Enabled = false;
                Month_RepeatEnd.Enabled = false;
                Year_RepeatEnd.Enabled = false;

                Day_RepeatEnd.Text = "dd";
                Month_RepeatEnd.Text = "mm";
                Year_RepeatEnd.Text = "yyyy";
                RepeatEndPanel.BackColor = Color.Gray;
            }
            else
            {
                Day_RepeatEnd.Enabled = true;
                Month_RepeatEnd.Enabled = true;
                Year_RepeatEnd.Enabled = true;
                RepeatEndPanel.BackColor = Color.White;
            }
        }
        
        bool CheckLegitDate(int year, int month, int day)
        {
            if(day > Year.GetMaxDaysOfMonth(year, month))
            {
                return false;
            }
            return true;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            GroupPlanItem newGroup = new GroupPlanItem();

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
            DateTime start = new DateTime(tYear_Start, tMonth_Start, tDay_Start, tHour_Start, tMinute_Start,0);


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

            if(end <= start)
            {
                MessageBox.Show("End Day must after Start Day");
                return;
            }

            ////////////////////////////////////////////////////////////////
            ///
            // FOR NONE //
            if(Repeat.Text.ToString() == "None")
            {
                newGroup.Insert(new PlanItem(Title.Text, Notes.Text, start, end, PriorityEnum.normal, DateTime.Now));
                thisPlan.Insert(newGroup);
                this.Close();
                return;
            }

            int tDay_RepeatEnd, tMonth_RepeatEnd, tYear_RepeatEnd;
            Int32.TryParse(Day_RepeatEnd.Text, out tDay_RepeatEnd);
            Int32.TryParse(Month_RepeatEnd.Text, out tMonth_RepeatEnd);
            Int32.TryParse(Year_RepeatEnd.Text, out tYear_RepeatEnd);
            if (CheckLegitDate(tYear_RepeatEnd, tMonth_RepeatEnd, tDay_RepeatEnd) == false)
            {
                MessageBox.Show("Invalid RepeatEnd Date");
                return;
            }
            DateTime repeatEnd = new DateTime(tYear_RepeatEnd, tMonth_RepeatEnd, tDay_RepeatEnd);

            if(repeatEnd < end)
            {
                MessageBox.Show("The end for Repeat end must after the end of event");
                return;
            }

            if (Repeat.Text.ToString() == "Daily")
            {
                while(true)
                {
                    newGroup.Insert(new PlanItem(Title.Text, Notes.Text, start, end, PriorityEnum.normal, DateTime.Now));
                    

                    start = start.AddDays(1);
                    end = end.AddDays(1);

                    if(start > repeatEnd)
                    {
                        thisPlan.Insert(newGroup);
                        this.Close();
                        return;
                    }
                }
            }
            else if (Repeat.Text.ToString() == "A Week")
            {
                while (true)
                {
                    newGroup.Insert(new PlanItem(Title.Text, Notes.Text, start, end, PriorityEnum.normal, DateTime.Now));

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
            else if(Repeat.Text.ToString() == "A Month")
            {
                TimeSpan timeSpan = end - start;
                while (true)
                {
                    newGroup.Insert(new PlanItem(Title.Text, Notes.Text, start, start+timeSpan, PriorityEnum.normal, DateTime.Now));

                    do
                    {
                        Date.AddMonth(tYear_Start, tMonth_Start, out tYear_Start, out tMonth_Start, 1);
                    }
                    while (tDay_Start > Year.GetMaxDaysOfMonth(tYear_Start, tMonth_Start));

                    start = new DateTime(tYear_Start, tMonth_Start, tDay_Start, tHour_Start, tMinute_Start, 0);
                    if(start > repeatEnd)
                    {
                        thisPlan.Insert(newGroup);
                        this.Close();
                        return;
                    }
                }
            }
            else if(Repeat.Text.ToString() == "A Year")
            {
                TimeSpan timeSpan = end - start;
                while (true)
                {
                    newGroup.Insert(new PlanItem(Title.Text, Notes.Text, start, start + timeSpan, PriorityEnum.normal, DateTime.Now));

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
            else
            {
                while (true)
                {
                    newGroup.Insert(new PlanItem(Title.Text, Notes.Text, start, end, PriorityEnum.normal, DateTime.Now));

                    start = start.AddDays(Convert.ToInt32(Repeat.Text));
                    end = end.AddDays(Convert.ToInt32(Repeat.Text));

                    if (start > repeatEnd)
                    {
                        thisPlan.Insert(newGroup);
                        this.Close();
                        return;
                    }
                }
            }
        }
    }
}
