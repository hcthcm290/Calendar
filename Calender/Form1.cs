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
    public partial class Form1 : Form
    {
        PlanData allPlan;
        PlanData todayPlan;

        public Form1()
        {
            InitializeComponent();
            Year.SyncYear();
            InitDateMatrix();
            allPlan = new PlanData();
            allPlan.Insert(new PlanItem(11, "plan A", "Go A Long"));
            allPlan.Insert(new PlanItem(11, "plan B", "Rush B"));
            allPlan.Insert(new PlanItem(12, "plan a", "Go A long"));
            todayPlan = new PlanData();
            this.CenterToScreen();
        }

        void InitDateMatrix()
        {
            DateButton = new Button[5, 7];
            for(int i=0; i<5; i++)
            {
                for(int j=0; j<7; j++)
                {
                    DateButton[i, j] = new Button();
                    DateButton[i, j].Width = Const.DateButtonWidth;
                    DateButton[i, j].Height = Const.DateButtonHeight;
                    DateButton[i, j].Location = new Point(Const.DateButtonStartX + (Const.DateButtonWidth  + Const.DateButtonOffSet) * j,
                                                          Const.DateButtonStartY + (Const.DateButtonHeight + Const.DateButtonOffSet) * i);
                    DateButton[i, j].UseVisualStyleBackColor = true;
                    DateButton[i, j].Text = "";
                    panel6.Controls.Add(DateButton[i, j]);
                }
            }
            GenerateDaysForDateButtons(Months.iCurrent);
        }

        void GenerateDaysForDateButtons(int month)
        {
            int maxDay = GetMaxDaysOfMonth(month, Year.GetCurrentYear());
            DateTime d = new DateTime(Year.GetCurrentYear(), month, 1);
            int dayOfWeek = -1;
            switch(d.DayOfWeek)
            {
                case DayOfWeek.Sunday:
                    dayOfWeek = 0;
                    break;
                case DayOfWeek.Monday:
                    dayOfWeek = 1;
                    break;
                case DayOfWeek.Tuesday:
                    dayOfWeek = 2;
                    break;
                case DayOfWeek.Wednesday:
                    dayOfWeek = 3;
                    break;
                case DayOfWeek.Thursday:
                    dayOfWeek = 4;
                    break;
                case DayOfWeek.Friday:
                    dayOfWeek = 5;
                    break;
                case DayOfWeek.Saturday:
                    dayOfWeek = 6;
                    break;
            }
            bool started = false;
            int count = 1;
            for(int i=0; i<5; i++)
            {
                for(int j=0; j<7; j++)
                {
                    DateButton[i, j].Text = "";
                    if(j == dayOfWeek)
                    {
                        started = true;
                    }
                    if(started && count <= maxDay)
                    {
                        DateButton[i, j].Text = count.ToString();
                        DateButton[i, j].Click += DateButton_Click;
                        count++;
                    }
                }
            }
        }

        int GetMaxDaysOfMonth(int month, int year)
        {
            switch(month)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    {
                        return 31;
                    }
                case 4:
                case 6:
                case 9:
                case 11:
                    return 30;
                case 2:
                    {
                        if (year % 4 == 0)
                        {
                            if (year % 100 == 0 && year % 400 != 0)
                            {
                                return 28;
                            }
                            return 29;
                        }
                        return 28;
                    }
            }
            return -1;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void MonthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void Panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Addbutton_Click(object sender, EventArgs e)
        {
            new_Event.ShowDialog();
        }        

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void MenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void PrevMonth_Click(object sender, EventArgs e)
        {
            Months.ToPrevMonth();
            PresentMonth.Text = Months.GetMonth();
            GenerateDaysForDateButtons(Months.iCurrent);
        }

        private void NextMonth_Click(object sender, EventArgs e)
        {
            Months.ToNextMonth();
            PresentMonth.Text = Months.GetMonth();
            GenerateDaysForDateButtons(Months.iCurrent);
        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DateButton_Click(object sender, EventArgs e)
        {
            Button bt = (Button)sender;
            if (bt.Text != "")
            {
                todayPlan.data = allPlan.GetItem(Convert.ToInt32(bt.Text));
            }
            TodayPlanPanel.Controls.Clear();
            for(int i=0; i<todayPlan.data.Count(); i++)
            {
                TodayPlanPanel.Controls.Add(new AJob(todayPlan.data[i]));
                TodayPlanPanel.Refresh();
            }
        }
    }
}
