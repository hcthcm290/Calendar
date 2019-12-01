using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Media;
using DevExpress.XtraScheduler;
using System.Drawing.Imaging;


namespace Calender
{
    public partial class Form1 : Form
    {
        string filepath = "data.xml";
        static public PlanData allPlan = new PlanData();
        New_Event new_Event;
        static public List<PlanItem> alertForToday = new List<PlanItem>();
        Timer timer;
        DateTime focusedDate;
        static public Color[] PriorityColorForDay = new Color[32];

        public Form1()
        {
            Year.SyncYear();
            Months.SyncMonth();
            InitializeComponent();
            addbutton.FlatAppearance.BorderSize = 0;
            if (Settings1.Default.Notification == true)
                this.radioButton1.Checked = true;
            else
                this.radioButton2.Checked = true;
            this.PresentMonth.Text = Months.ToString();
            try
            {
                allPlan = (PlanData)DeserializeFromXML(filepath);
            }
            catch
            {
            }
            if (allPlan == null)
            {
                allPlan = new PlanData();
            }
            this.CenterToScreen();
            new_Event = new New_Event(allPlan);
            LoadItemToDayView(Year.GetCurrentYear(), Months.iCurrent, DateTime.Now.Day);

            List<GroupPlanItem> groupsAlert = allPlan.ListGroupAlertForToday(DateTime.Now);
            for(int i=0; i<groupsAlert.Count; i++)
            {
                alertForToday.AddRange(groupsAlert[i].ListAlertForToday(DateTime.Now));
            }

            LoadDataToTimeTable();
            InitDateMatrix();
            timer = new Timer();
            timer.Tick += Notify;
            timer.Interval = (60 - DateTime.Now.Second)*1000;
            timer.Start();
            focusedDate = DateTime.Now;
        }

        void LoadDataToTimeTable()
        {
            this.schedulerDataStorage1 = new DevExpress.XtraScheduler.SchedulerDataStorage(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.schedulerDataStorage1)).BeginInit();
            this.schedulerControl1.DataStorage = this.schedulerDataStorage1;
            this.schedulerControl1.DataStorage.Appointments.CustomFieldMappings.Add(new
                AppointmentCustomFieldMapping("group", "member", FieldValueType.Object));
            this.schedulerControl1.DataStorage.Appointments.CustomFieldMappings.Add(new
                AppointmentCustomFieldMapping("item", "member2", FieldValueType.Object));

            for (int g = 0; g < allPlan.group.Count; g++)
            {
                for (int i = 0; i < allPlan.group[g].data.Count; i++)
                {
                    Appointment apt = schedulerControl1.DataStorage.CreateAppointment(AppointmentType.Normal);
                    apt.Start = allPlan.group[g].data[i].startTime;
                    apt.End = allPlan.group[g].data[i].endTime;
                    apt.Subject = allPlan.group[g].data[i].title;
                    apt.Description = allPlan.group[g].data[i].note;
                    apt.Location = allPlan.group[g].data[i].location;
                    apt.LabelKey = 4 - (int)allPlan.group[g].data[i].priority;
                    apt.CustomFields["group"] = allPlan.group[g];
                    apt.CustomFields["item"] = allPlan.group[g].data[i];
                    schedulerControl1.DataStorage.Appointments.Add(apt);
                }
            }
        }

        void InitDateMatrix()
        {
            DateButton = new Button[5, 7];
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    DateButton[i, j] = new Button();
                    DateButton[i, j].Width = label2.Width;
                    DateButton[i, j].Height = label2.Height;
                    DateButton[i, j].Location = new Point(label2.Location.X + (label2.Width + Const.DateButtonOffSet) * j,
                                                          label2.Location.Y + (label2.Height + Const.DateButtonOffSet) * (i + 1));
                    DateButton[i, j].UseVisualStyleBackColor = true;
                    DateButton[i, j].Text = "";
                    DateButton[i, j].Click += DayButton_Click;

                    panel6.Controls.Add(DateButton[i, j]);
                }
            }
            for(int i=1; i<32; i++)
            {
                PriorityColorForDay[i] = new Color();
            }
            GenerateDaysForDateButtons(Months.iCurrent);
        }

        void GenerateDaysForDateButtons(int month)
        {
            int maxDay = Year.GetMaxDaysOfMonth(Year.GetCurrentYear(), month);
            DateTime d = new DateTime(Year.GetCurrentYear(), month, 1);
            int dayOfWeek = -1;
            switch (d.DayOfWeek)
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
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    DateButton[i, j].Text = "";
                    DateButton[i, j].BackColor = Color.Transparent;
                    if (j == dayOfWeek)
                    {
                        started = true;
                    }
                    if (started && count <= maxDay)
                    {
                        int countEventForToday = allPlan.ListGroupItemsForToday(new DateTime(Year.GetCurrentYear(), month, count)).Count;
                        if(countEventForToday < 3)
                        {
                            PriorityColorForDay[count] = Color.Black;
                        } 
                        else if(countEventForToday < 7)
                        {
                            PriorityColorForDay[count] = Color.FromArgb(255,195,0);
                        }
                        else if(countEventForToday < 10)
                        {
                            PriorityColorForDay[count] = Color.FromArgb(255, 87, 51);
                        }
                        else
                        {
                            PriorityColorForDay[count] = Color.FromArgb(199, 0, 57);
                        }
                        DateButton[i, j].Text = count.ToString();
                        if(count == DateTime.Now.Day && month == DateTime.Now.Month)
                        {
                            DateButton[i, j].BackColor = Color.OrangeRed;
                        }
                        count++;
                    }
                }
            }
        }
        static public void GeneratePriorityColorArray()
        {
            int maxDay = Year.GetMaxDaysOfMonth(Year.GetCurrentYear(), Months.iCurrent);
            for (int count = 1; count <= maxDay; count++)
            {
                int countEventForToday = allPlan.ListGroupItemsForToday(new DateTime(Year.GetCurrentYear(), Months.iCurrent, count)).Count;
                if (countEventForToday < 3)
                {
                    PriorityColorForDay[count] = Color.Black;
                }
                else if (countEventForToday < 7)
                {
                    PriorityColorForDay[count] = Color.FromArgb(255, 195, 0);
                }
                else if (countEventForToday < 10)
                {
                    PriorityColorForDay[count] = Color.FromArgb(255, 87, 51);
                }
                else
                {
                    PriorityColorForDay[count] = Color.FromArgb(199, 0, 57);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void MonthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void Addbutton_Click(object sender, EventArgs e)
        {
            new_Event = new New_Event(allPlan, focusedDate);
            new_Event.ShowDialog();
            LoadItemToDayView(focusedDate.Year, focusedDate.Month, focusedDate.Day);
            LoadDataToTimeTable();
            GeneratePriorityColorArray();
        }

        private void PrevMonth_Click(object sender, EventArgs e)
        {
            Months.ToPrevMonth();
            PresentMonth.Text = Months.ToString();
            GenerateDaysForDateButtons(Months.iCurrent);
        }

        private void NextMonth_Click(object sender, EventArgs e)
        {
            Months.ToNextMonth();
            PresentMonth.Text = Months.ToString();
            GenerateDaysForDateButtons(Months.iCurrent);
        }

        public object DeserializeFromXML(string filepath)
        {
            FileStream fs = new FileStream(filepath, FileMode.OpenOrCreate, FileAccess.Read);
            try
            {
                XmlSerializer sr = new XmlSerializer(typeof(PlanData));
                object result = sr.Deserialize(fs);
                fs.Close();
                return result;
            }
            catch
            {
                fs.Close();
                return null;
            }
        }

        private void SerializeToXML(object data, string filepath)
        {
            File.Delete(filepath);
            FileStream fs = new FileStream(filepath, FileMode.OpenOrCreate, FileAccess.Write);
            XmlSerializer sr = new XmlSerializer(typeof(PlanData));
            sr.Serialize(fs, allPlan);
            fs.Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SerializeToXML(allPlan, filepath);
        }

        private void LoadItemToDayView(int year, int month, int day)
        {
            dayView.Controls.Clear();

            DateTime today = new DateTime(year, month, day);
            List<GroupPlanItem> groups = allPlan.ListGroupItemsForToday(today);
            for (int i = 0; i < groups.Count; i++)
            {
                List<PlanItem> items = groups[i].ListItemsForToday(today);
                for (int j = 0; j < items.Count; j++)
                {
                    dayView.Controls.Add(new Item(groups[i], items[j], today));
                }
            }
        }

        private void DayButton_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.Text == "")
                return;
            focusedDate = new DateTime(Year.GetCurrentYear(), Months.iCurrent, Convert.ToInt32(b.Text));
            if(focusedDate.Day == DateTime.Now.Day && focusedDate.Month == DateTime.Now.Month && focusedDate.Month == DateTime.Now.Month)
            {
                label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                label1.Text = "Today";
            }
            else
            {
                label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 46F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                label1.Text = focusedDate.Day.ToString() + "/" + focusedDate.Month.ToString() + "/" + focusedDate.Year.ToString();
            }
            LoadItemToDayView(Year.GetCurrentYear(), Months.iCurrent, Convert.ToInt32(b.Text));
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if(this.WindowState == FormWindowState.Minimized)
            {
                notifyIcon1.Visible = true;
                Hide();
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon1.Visible = false;
        }

        private void Notify(object sender, EventArgs e)
        {
            if( Settings1.Default.Notification == true)
            {
                List<GroupPlanItem> groupsAlert = allPlan.ListGroupAlertForToday(DateTime.Now);
                alertForToday.RemoveRange(0, alertForToday.Count);
                for (int i = 0; i < groupsAlert.Count; i++)
                {
                    alertForToday.AddRange(groupsAlert[i].ListAlertForToday(DateTime.Now));
                }

                DateTime dt = DateTime.Now;
                for (int i = 0; i < alertForToday.Count; i++)
                {
                    if (
                        alertForToday[i].alert.Hour == dt.Hour &&
                        alertForToday[i].alert.Minute == dt.Minute
                       )
                    {
                        notifyIcon1.Visible = true;
                        notifyIcon1.BalloonTipTitle = alertForToday[i].title;
                        notifyIcon1.BalloonTipText = alertForToday[i].note;
                        notifyIcon1.ShowBalloonTip(3000);
                    }
                }
                timer.Interval = 60000;
            }
        }

        private void timetableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TimeTablePanel.Visible = true;
            panel4.Visible = false;
            panel6.Visible = false;
            SettingPanel.Visible = false;
            this.Refresh();
        }

        private void statisticsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TimeTablePanel.Visible = false;
            SettingPanel.Visible = false;
            panel4.Visible = true;
            panel6.Visible = true;
            this.Refresh();
        }

        private void schedulerControl1_EditAppointmentDependencyFormShowing(object sender, AppointmentDependencyFormEventArgs e)
        {
            new_Event = new New_Event(allPlan);
            new_Event.ShowDialog();
            e.Handled = true;
        }

        private void schedulerControl1_EditAppointmentFormShowing(object sender, AppointmentFormEventArgs e)
        {
            if(e.Appointment.CustomFields.Count == 0)
            {
                New_Event new_Event = new New_Event(allPlan);
                new_Event.ShowDialog();
                LoadDataToTimeTable();
                e.Handled = true;
                return;
            }
            EditEvent edit = new EditEvent(allPlan, (GroupPlanItem)e.Appointment.CustomFields["group"], (PlanItem)e.Appointment.CustomFields["item"]);
            edit.ShowDialog();
            LoadDataToTimeTable();
            e.Handled = true;
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TimeTablePanel.Visible = false;
            panel4.Visible = false;
            panel6.Visible = false;
            SettingPanel.Visible = true;
            this.Refresh();
        }

        private void buttonColor_Click(object sender, EventArgs e)
        {
            if( colorDialog1.ShowDialog() != DialogResult.Cancel)
            {
                Settings1.Default.Color = colorDialog1.Color;
            }
        }

        private void buttonSaveSetting_Click(object sender, EventArgs e)
        {
            this.panel3.BackColor = Settings1.Default.Color;
            this.panel8.BackColor = Settings1.Default.Color;
            this.addbutton.BackColor = Settings1.Default.Color;
            this.statisticsToolStripMenuItem.ForeColor = Settings1.Default.Color;
            this.timetableToolStripMenuItem.ForeColor = Settings1.Default.Color;
            this.settingsToolStripMenuItem.ForeColor = Settings1.Default.Color;
            this.panel2.ForeColor = Settings1.Default.Color;
            this.PresentMonth.ForeColor = Settings1.Default.Color;
            Settings1.Default.Save();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Settings1.Default.Notification = true;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            Settings1.Default.Notification = false;
        }

        private void labelNotify_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void NextMonth_Paint(object sender, PaintEventArgs e)
        {
            Button btn = (Button)sender;
            Graphics gfx = e.Graphics;
            gfx.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            using (Bitmap bmp = new Bitmap(global::Calender.Properties.Resources.new_right))
            {
                ColorMap[] colorMap = new ColorMap[1];
                colorMap[0] = new ColorMap();
                colorMap[0].OldColor = Color.Coral;
                colorMap[0].NewColor = Settings1.Default.Color;
                ImageAttributes attr = new ImageAttributes();
                attr.SetRemapTable(colorMap);
                Rectangle rect = new Rectangle((btn.Width - bmp.Width) / 2, (btn.Height - bmp.Height) / 2, bmp.Width, bmp.Height);
                gfx.DrawImage(bmp, rect, 0, 0, rect.Width, rect.Height, GraphicsUnit.Pixel, attr);
            }
            
        }
    } 
}
