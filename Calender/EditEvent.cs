using System;
using System.Drawing;
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
            
            highTT.SetToolTip(highLB, "High");
            mediumTT.SetToolTip(MediumLB, "Medium");
            normalTT.SetToolTip(normalLB, "Normal");

            this.group = group;
            this.item = item;
            if (item.title != "")
            {
                this.titleTB.Text = item.title;
                this.titleTB.ForeColor = SystemColors.ControlText;
            }
            if (item.note != "")
            {
                this.notesTB.Text = item.note;
                this.notesTB.ForeColor = SystemColors.ControlText;
            }
            if (item.location != "")
            {
                this.locationTB.Text = item.location;
                this.locationTB.ForeColor = SystemColors.ControlText;
            }

            this.startDateDE.DateTime = item.startTime;
            this.endDateDE.DateTime = item.endTime;

            this.startTimeTP.Value = item.startTime;
            this.endTimeTP.Value = item.endTime;

            this.timeSpan = item.endTime - item.startTime;

            this.cbbRepeat.SelectedIndex = group.repeatKind;

            this.repeatValueTB.Text = group.repeatValue.ToString();

            if(cbbRepeat.SelectedIndex == 5)
            {
                repeatValueTB.Visible = true;
            }

            TimeSpan ts = item.startTime - item.alert;
            
            if(ts.Hours == 1)
            {
                this.alertCB.SelectedIndex = 0;
            } 
            else if(ts.Minutes == 30)
            {
                this.alertCB.SelectedIndex = 1;
            }
            else if (ts.Minutes == 15)
            {
                this.alertCB.SelectedIndex = 2;
            }
            else
            {
                this.alertCB.SelectedIndex = 3;
            }

            this.repeatEndDE.DateTime = group.repeatEnd;
            
            if(item.notification == true)
            {
                alertOff_Click(new object(), new EventArgs());
            }

            if(item.priority == PriorityEnum.normal)
            {
                NormalLB_Click(new object(), new EventArgs());
            }
            if (item.priority == PriorityEnum.medium)
            {
                MediumLB_Click(new object(), new EventArgs());
            }
            if (item.priority == PriorityEnum.high)
            {
                HighLB_Click(new object(), new EventArgs());
            }
        }
        
        private bool DontChangeRepeat()
        {
            if(this.cbbRepeat.SelectedIndex == 0 && group.repeatKind == 0) 
            {
                return false;
            }

            if(this.cbbRepeat.SelectedIndex != group.repeatKind) // if repeatkind change
            {
                return true;
            }
            else if(repeatEndDE.DateTime.Date != group.repeatEnd.Date) // if repeatkind dont change but repeat end date change
            {
                return true;
            }
            else if(this.cbbRepeat.SelectedIndex == 5 && 
                    group.repeatValue.ToString() != this.repeatValueTB.Text) // if repeat kind still custom and repeat end
            {                                                                //  date dont change but repeat value change
                return true;
            }

            return false;
        }
        
        public override void SaveButton_Click(object sender, EventArgs e)
        {
            TimeSpan alertTimeSpane = new TimeSpan();
            if (alertCB.SelectedIndex == 0)
            {
                alertTimeSpane = new TimeSpan(1, 0, 0);
            }
            else if (alertCB.SelectedIndex == 1)
            {
                alertTimeSpane = new TimeSpan(0, 30, 0);
            }
            else if (alertCB.SelectedIndex == 2)
            {
                alertTimeSpane = new TimeSpan(0, 15, 0);
            }
            else if (alertCB.SelectedIndex == 3)
            {
                alertTimeSpane = new TimeSpan(0, 0, 0);
            }

            // start time
            int tDay_Start, tMonth_Start, tYear_Start, tHour_Start, tMinute_Start;
            tDay_Start = startDateDE.DateTime.Day;
            tMonth_Start = startDateDE.DateTime.Month;
            tYear_Start = startDateDE.DateTime.Year;
            tHour_Start = startTimeTP.Value.Hour;
            tMinute_Start = startTimeTP.Value.Minute;
            DateTime start = new DateTime(tYear_Start, tMonth_Start, tDay_Start, tHour_Start, tMinute_Start, 0);

            // end time
            int tDay_End, tMonth_End, tYear_End, tHour_End, tMinute_End;
            tDay_End = endDateDE.DateTime.Day;
            tMonth_End = endDateDE.DateTime.Month;
            tYear_End = endDateDE.DateTime.Year;
            tHour_End = endTimeTP.Value.Hour;
            tMinute_End = endTimeTP.Value.Minute;
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
            tDay_RepeatEnd = repeatEndDE.DateTime.Day;
            tMonth_RepeatEnd = repeatEndDE.DateTime.Month;
            tYear_RepeatEnd = repeatEndDE.DateTime.Year;
            DateTime repeatEnd = new DateTime(tYear_RepeatEnd, tMonth_RepeatEnd, tDay_RepeatEnd, 23, 59, 59);

            // check repeat end
            if (repeatEnd < end && cbbRepeat.SelectedIndex != 0)
            {
                MessageBox.Show("The end for Repeat end must after the end of event");
                return;
            }

            string title = titleTB.Text;
            if (titleTB.ForeColor != SystemColors.ControlText) // Title cannot be an empty string
            {
                errorProvider2.SetError(titleTB, "Title cannnot be blank");
                title = "";
                return;
            }

            string location = locationTB.Text;
            if (locationTB.ForeColor != SystemColors.ControlText)
            {
                location = "";
            }

            string note = notesTB.Text;
            if (notesTB.ForeColor != SystemColors.ControlText)
            {
                note = "";
            }

            // if repeat dont change
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
                        item.title = title;
                        item.note = note;
                        item.location = location;
                        item.priority = priority;
                        item.notification = notification;
                        item.alert = start - alertTimeSpane;
                    }
                    // this and following items
                    else if (result == DialogResult.No)
                    {
                        int i = group.data.IndexOf(item);
                        for (; i < group.data.Count; i++)
                        {
                            group.data[i].title = title;
                            group.data[i].note = note;
                            group.data[i].location = location;
                            group.data[i].priority = priority;
                            group.data[i].notification = notification;
                            group.data[i].alert = start - alertTimeSpane;
                        }
                    }
                    // all items
                    else if (result == DialogResult.OK)
                    {
                        int i = 0;
                        for (; i < group.data.Count; i++)
                        {
                            group.data[i].title = title;
                            group.data[i].note = note;
                            group.data[i].location = location;
                            group.data[i].priority = priority;
                            group.data[i].notification = notification;
                            group.data[i].alert = start - alertTimeSpane;
                        }
                    }
                    // cancel
                    else
                    {
                        return;
                    }
                }
                else // if change the start and end of item
                {
                    EditOption opt = new EditOption();
                    DialogResult result = new DialogResult();
                    result = opt.ShowDialog();
                    // only this item
                    if (result == DialogResult.Yes)
                    {
                        item.title = title;
                        item.note = note;
                        item.location = location;
                        item.priority = priority;
                        item.notification = notification;
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
                    else if (result == DialogResult.OK)
                    {
                        int i = 0;
                        group.data.RemoveRange(i, group.data.Count);
                        base.SaveButton_Click(sender, e);
                    }
                    // cancel
                    else
                    {
                        return;
                    }
                }
            }
            else // change the repeat
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
                else if (result == DialogResult.OK)
                {
                    int i = 0;
                    group.data.RemoveRange(i, group.data.Count);
                    base.SaveButton_Click(sender, e);
                }
                // cancel
                else
                {
                    return;
                }
            }
            
            group.Sort();
            Form1.GeneratePriorityColorArray();
            this.Close();
        }

        private void deleteLB_Click(object sender, EventArgs e)
        {
            EditOption opt = new EditOption();
            DialogResult result = new DialogResult();
            result = opt.ShowDialog();
            // only this item
            if (result == DialogResult.Yes)
            {
                int i = group.data.IndexOf(item);
                group.data.RemoveRange(i, 1);
            }
            // this and following items
            else if (result == DialogResult.No)
            {
                int i = group.data.IndexOf(item);
                group.data.RemoveRange(i, group.data.Count - i);
            }
            // all items
            else if (result == DialogResult.OK)
            {
                int i = 0;
                group.data.RemoveRange(i, group.data.Count);
            }
            // cancel
            else
            {
                return;
            }
            group.Sort();
            Form1.GeneratePriorityColorArray();
            this.Close();
        }
    }
    
}
