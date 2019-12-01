using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calender
{
    public partial class EditEvent : New_Event
    {
        GroupPlanItem group;
        PlanItem item;
        public EditEvent()
        {
            InitializeComponent();
        }
        public EditEvent(PlanData planData, GroupPlanItem group, PlanItem item)
            :
            base(planData)
        {
            InitializeComponent();

            this.group = group;
            this.item = item;
            this.title.Text = item.title;
            this.location.Text = item.location;
            this.notes.Text = item.note;

            this.Day_Start.Text = item.startTime.Day.ToString();
            this.Month_Start.Text = item.startTime.Month.ToString();
            this.Year_Start.Text = item.startTime.Year.ToString();
            this.Hour_Start.Text = item.startTime.Hour.ToString();
            this.Minute_Start.Text = item.startTime.Minute.ToString();

            this.Day_End.Text = item.endTime.Day.ToString();
            this.Month_End.Text = item.endTime.Month.ToString();
            this.Year_End.Text = item.endTime.Year.ToString();
            this.Hour_End.Text = item.endTime.Hour.ToString();
            this.Minute_End.Text = item.endTime.Minute.ToString();

            CancelButton.FlatStyle = FlatStyle.Flat;
            CancelButton.FlatAppearance.BorderColor = Color.White;
            CancelButton.FlatAppearance.BorderSize = 0;

            SaveButton.FlatStyle = FlatStyle.Flat;
            SaveButton.FlatAppearance.BorderColor = Color.White;
            SaveButton.FlatAppearance.BorderSize = 0;

            this.Repeat.SelectedIndex = group.repeatKind;
            if (group.repeatKind == 5)
            {
                repeatValue.Text = group.repeatValue.ToString();
            }

            this.Day_RepeatEnd.Text = group.repeatEnd.Day.ToString();
            this.Month_RepeatEnd.Text = group.repeatEnd.Month.ToString();
            this.Year_RepeatEnd.Text = group.repeatEnd.Year.ToString();

            this.priority.SelectedIndex = (int)item.priority;

            TimeSpan ts = item.startTime - item.alert;
            if(ts.Hours == 1)
            {
                this.alert.SelectedIndex = 0;
            } 
            else if(ts.Minutes == 30)
            {
                this.alert.SelectedIndex = 1;
            }
            else if (ts.Minutes == 15)
            {
                this.alert.SelectedIndex = 2;
            }
            else
            {
                this.alert.SelectedIndex = 3;
            }
        }

        private bool DontChangeRepeat()
        {
            if(this.Repeat.SelectedIndex == 0 && group.repeatKind == 0)
            {
                return false;
            }

            if(this.Repeat.SelectedIndex != group.repeatKind)
            {
                return true;
            }
            else if(this.Day_RepeatEnd.Text != group.repeatEnd.Day.ToString() || this.Month_RepeatEnd.Text != group.repeatEnd.Month.ToString() || this.Year_RepeatEnd.Text != group.repeatEnd.Year.ToString())
            {
                return true;
            }
            else if(this.Repeat.SelectedIndex == 5 && group.repeatValue.ToString() != this.repeatValue.Text)
            {
                return true;
            }

            return false;
        }

        public override void SaveButton_Click(object sender, EventArgs e)
        {
            TimeSpan alertTimeSpane = new TimeSpan();
            if (alert.SelectedIndex == 0)
            {
                alertTimeSpane = new TimeSpan(1, 0, 0);
            }
            else if (alert.SelectedIndex == 1)
            {
                alertTimeSpane = new TimeSpan(0, 30, 0);
            }
            else if (alert.SelectedIndex == 2)
            {
                alertTimeSpane = new TimeSpan(0, 15, 0);
            }
            else if (alert.SelectedIndex == 3)
            {
                alertTimeSpane = new TimeSpan(0, 0, 0);
            }

            // start time
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

            // end time
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

            // check end and start
            if (end <= start)
            {
                MessageBox.Show("End Day must after Start Day");
                return;
            }

            // end of repeat
            int tDay_RepeatEnd, tMonth_RepeatEnd, tYear_RepeatEnd;
            Int32.TryParse(Day_RepeatEnd.Text, out tDay_RepeatEnd);
            Int32.TryParse(Month_RepeatEnd.Text, out tMonth_RepeatEnd);
            Int32.TryParse(Year_RepeatEnd.Text, out tYear_RepeatEnd);
            if (CheckLegitDate(tYear_RepeatEnd, tMonth_RepeatEnd, tDay_RepeatEnd) == false && Repeat.SelectedIndex != 0)
            {
                MessageBox.Show("Invalid RepeatEnd Date");
                return;
            }
            DateTime repeatEnd = new DateTime(tYear_RepeatEnd, tMonth_RepeatEnd, tDay_RepeatEnd, 23, 59, 59);

            // check repeat end
            if (repeatEnd < end && Repeat.SelectedIndex != 0)
            {
                MessageBox.Show("The end for Repeat end must after the end of event");
                return;
            }

            // if repeat and repeat end don't change
            if (!DontChangeRepeat())
            {
                // if dont change the start or the end of event
                if(start == item.startTime && end == item.endTime)
                {
                    EditOption opt = new EditOption();
                    DialogResult result = new DialogResult();
                    result = opt.ShowDialog();
                    // only this item
                    if (result == DialogResult.Yes)
                    {
                        item.title = this.title.Text;
                        item.location = this.location.Text;
                        item.note = this.notes.Text;
                        item.priority = (PriorityEnum)this.priority.SelectedIndex;
                        item.alert = start - alertTimeSpane;
                    }
                    // this and following items
                    else if (result == DialogResult.No)
                    {
                        int i = group.data.IndexOf(item);
                        for (; i < group.data.Count; i++)
                        {
                            group.data[i].title = this.title.Text;
                            group.data[i].location = this.location.Text;
                            group.data[i].note = this.notes.Text;
                            group.data[i].priority = (PriorityEnum)this.priority.SelectedIndex;
                            group.data[i].alert = start - alertTimeSpane;
                        }
                    }
                    // all items
                    else
                    {
                        int i = 0;
                        for (; i < group.data.Count; i++)
                        {
                            group.data[i].title = this.title.Text;
                            group.data[i].location = this.location.Text;
                            group.data[i].note = this.notes.Text;
                            group.data[i].priority = (PriorityEnum)this.priority.SelectedIndex;
                            group.data[i].alert = start - alertTimeSpane;
                        }
                    }
                }
                else
                {
                    EditOption opt = new EditOption();
                    DialogResult result = new DialogResult();
                    result = opt.ShowDialog();
                    // only this item
                    if (result == DialogResult.Yes)
                    {
                        item.title = this.title.Text;
                        item.location = this.location.Text;
                        item.note = this.notes.Text;
                        item.priority = (PriorityEnum)this.priority.SelectedIndex;
                        item.alert = start - alertTimeSpane;
                        item.startTime = start;
                        item.endTime = end;
                    }
                    // this and following items
                    else if (result == DialogResult.No)
                    {
                        int i = group.data.IndexOf(item);
                        group.data.RemoveRange(i, group.data.Count - i);
                        base.SaveButton_Click(sender, e);
                    }
                    // all items
                    else
                    {
                        int i = 0;
                        group.data.RemoveRange(i, group.data.Count - i);
                        base.SaveButton_Click(sender, e);
                    }
                }
            }
            else
            {
                EditOptionS opt = new EditOptionS();
                DialogResult result = new DialogResult();
                result = opt.ShowDialog();
                // this and following items
                if(result == DialogResult.No)
                {
                    int i = group.data.IndexOf(item);
                    group.data.RemoveRange(i, group.data.Count - i);
                    base.SaveButton_Click(sender, e);
                }
                // all items
                else
                {
                    int i = 0;
                    group.data.RemoveRange(i, group.data.Count - i);
                    base.SaveButton_Click(sender, e);
                }
            }
            
            group.Sort();
            Form1.GeneratePriorityColorArray();
            this.Close();
        }
    }
}
