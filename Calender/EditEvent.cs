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

            this.Repeat.SelectedIndex = group.repeatKind;
            if (group.repeatKind == 5)
            {
                repeatValue.Text = group.repeatValue.ToString();
            }

            this.Day_RepeatEnd.Text = group.repeatEnd.Day.ToString();
            this.Month_RepeatEnd.Text = group.repeatEnd.Month.ToString();
            this.Year_RepeatEnd.Text = group.repeatEnd.Year.ToString();

            this.priority.SelectedIndex = (int)item.priority;
        }

        private bool NeedNewGroup()
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

            if (!NeedNewGroup())
            {
                DialogResult dr = new DialogResult();
                EditOption editOption = new EditOption();
                dr = editOption.ShowDialog();

                // Only this item
                if(dr == DialogResult.Yes)
                {
                    group.Delete(item);
                    group.Insert(new PlanItem(title.Text, notes.Text, start, end, PriorityEnum.normal, DateTime.Now, location.Text));
                    group.Sort();
                    this.Close();
                    return;
                }
                // This and following item
                if (dr == DialogResult.No)
                {
                    group.DeleteItemAndFollowing(item);
                }
                // All Event
                else if(dr == DialogResult.Ignore)
                {
                    group.DeleteAll();
                }
                DateTime repeatEnd = group.repeatEnd;

                if (Repeat.Text.ToString() == "Daily")
                    {
                        while (true)
                        {
                            group.Insert(new PlanItem(title.Text, notes.Text, start, end, PriorityEnum.normal, DateTime.Now, location.Text));

                            start = start.AddDays(1);
                            end = end.AddDays(1);

                            if (start > repeatEnd)
                            {
                                this.Close();
                                break;
                            }
                        }
                    }
                else if (Repeat.Text.ToString() == "A Week")
                    {
                        while (true)
                        {
                            group.Insert(new PlanItem(title.Text, notes.Text, start, end, PriorityEnum.normal, DateTime.Now, location.Text));

                            start = start.AddDays(7);
                            end = end.AddDays(7);

                            if (start > repeatEnd)
                            {
                                this.Close();
                                break;
                            }
                        }
                    }
                else if (Repeat.Text.ToString() == "A Month")
                    {
                        TimeSpan timeSpan = end - start;
                        while (true)
                        {
                            group.Insert(new PlanItem(title.Text, notes.Text, start, start + timeSpan, PriorityEnum.normal, DateTime.Now, location.Text));

                            do
                            {
                                Date.AddMonth(tYear_Start, tMonth_Start, out tYear_Start, out tMonth_Start, 1);
                            }
                            while (tDay_Start > Year.GetMaxDaysOfMonth(tYear_Start, tMonth_Start));

                            start = new DateTime(tYear_Start, tMonth_Start, tDay_Start, tHour_Start, tMinute_Start, 0);
                            if (start > repeatEnd)
                            {
                                this.Close();
                                break;
                            }
                        }
                    }
                else if (Repeat.Text.ToString() == "A Year")
                    {
                        TimeSpan timeSpan = end - start;
                        while (true)
                        {
                            group.Insert(new PlanItem(title.Text, notes.Text, start, start + timeSpan, PriorityEnum.normal, DateTime.Now, location.Text));

                            do
                            {
                                Date.AddMonth(tYear_Start, tMonth_Start, out tYear_Start, out tMonth_Start, 12);
                            }
                            while (tDay_Start > Year.GetMaxDaysOfMonth(tYear_Start, tMonth_Start));

                            start = new DateTime(tYear_Start, tMonth_Start, tDay_Start, tHour_Start, tMinute_Start, 0);
                            if (start > repeatEnd)
                            {
                                this.Close();
                                break;
                            }
                        }
                    }
                else
                {
                    while (true)
                    {
                        group.Insert(new PlanItem(title.Text, notes.Text, start, end, PriorityEnum.normal, DateTime.Now, location.Text));

                        start = start.AddDays(Convert.ToInt32(repeatValue.Text));
                        end = end.AddDays(Convert.ToInt32(repeatValue.Text));

                        if (start > repeatEnd)
                        {
                            this.Close();
                            break;
                        }
                    }
                }
                group.Sort();
                
                this.Close();
            }
        }
    }
}
