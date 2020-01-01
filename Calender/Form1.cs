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
using System.Net.Mail;
using System.Net;
using DevExpress.XtraScheduler.Drawing;
using DevExpress.Utils.Drawing;
using Microsoft.Win32;
using System.Security.AccessControl;
using System.Xml;
using System.Security.Principal;

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
        Button focusedButton;
        static public Color[] PriorityColorForDay = new Color[32];
        Color themeColor;
        Appointment focusedAppointment;
        bool canClose;
        bool menuStripCanClose;

        // data for chart & summary
        int[] jobsDoneInEachMonth;
        int[,] jobsDoneInEachDay;
        int allDoneJobs;
        int jobsDoneToday;

        private static readonly string StartupKey = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run";
        private static readonly string StartupValue = "Calender";
        public static void AddDirectorySecurity(string FileName, string Account, FileSystemRights Rights, AccessControlType ControlType)
        {
            // Create a new DirectoryInfo object.
            DirectoryInfo dInfo = new DirectoryInfo(FileName);

            // Get a DirectorySecurity object that represents the 
            // current security settings.
            DirectorySecurity dSecurity = dInfo.GetAccessControl();

            // Add the FileSystemAccessRule to the security settings. 
            dSecurity.AddAccessRule(new FileSystemAccessRule(Account,
                                                            Rights,
                                                            ControlType));

            // Set the new access settings.
            dInfo.SetAccessControl(dSecurity);

        }

        public Form1()
        {
            RegistryKey regkey = Registry.CurrentUser.CreateSubKey("Software\\Calender");

            RegistryKey regstart = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run");

            string keyvalue = "1";
            try
            {
                regkey.SetValue("Index", keyvalue);
                regstart.SetValue("Calender", Application.StartupPath + "\\Calender.exe");
            }
            catch(System.Exception e)
            {

            }

            Console.ReadLine();

            jobsDoneInEachMonth = new int[13];
            jobsDoneInEachDay = new int[13,32];
            allDoneJobs = 0;
            jobsDoneToday = JobsDoneInToday();

            Year.SyncYear();
            Months.SyncMonth();
            InitializeComponent();

            // init series for chart control
            series1 = new DevExpress.XtraCharts.Series();
            sideBySideBarSeriesView1 = new DevExpress.XtraCharts.SideBySideBarSeriesView();
            ((System.ComponentModel.ISupportInitialize)(series1)).BeginInit(); 
            series1.ArgumentDataMember = "Argument";
            series1.ArgumentScaleType = DevExpress.XtraCharts.ScaleType.Numerical;
            series1.Name = "Number of completed tasks";
            series1.ValueDataMembersSerializable = "Value";
            this.chartControl1.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series1};
            ((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
            //xyDiagram1.AxisX.WholeRange.SetMinMaxValues(1, 31);

            dayView.AutoScroll = true;
            if (dayView.VerticalScroll.Visible == true)
                dayView.BackColor = Color.Black;
            addbutton.FlatAppearance.BorderSize = 0;
            this.PresentMonth.Text = Months.ToString();
            try
            {
                allPlan = (PlanData)DeserializeFromXML(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\" + filepath);
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
            for (int i = 0; i < groupsAlert.Count; i++)
            {
                alertForToday.AddRange(groupsAlert[i].ListAlertForToday(DateTime.Now));
            }

            LoadDataToTimeTable();
            InitDateMatrix();
            timer = new Timer();
            timer.Tick += Notify;
            timer.Interval = (60 - DateTime.Now.Second) * 1000;
            timer.Start();
            focusedDate = DateTime.Now;

            addbutton.FlatStyle = FlatStyle.Flat;
            addbutton.FlatAppearance.BorderSize = 0;

            //schedulerControl1.AllowAppointmentDrag = false;

            calendarToolStripMenuItem_Click(new object(), new EventArgs());
            focusedButton = new Button();

            // cbbYearly.Text & add year if in new year
            this.cbbYearly.Text = DateTime.Now.Year.ToString();
            AddYearForCombobox();

            YearLabel.Text = Year.GetCurrentYear().ToString();

            // load setting
            // 1: load color
            themeColor = Color.FromArgb(238, 197, 106);
            if (Settings1.Default.Theme == 1)
            {
                themeColor = Color.FromArgb(112, 76, 161);
            }
            else if (Settings1.Default.Theme == 2)
            {
                themeColor = Color.FromArgb(238, 197, 106);
            }
            else if (Settings1.Default.Theme == 3)
            {
                themeColor = Color.FromArgb(78, 169, 119);
            }
            else if (Settings1.Default.Theme == 4)
            {
                themeColor = Color.FromArgb(194, 200, 207);
            }
            this.panel3.BackColor = themeColor;
            this.panel8.BackColor = themeColor;
            this.addbutton.BackColor = themeColor;
            this.panel2.ForeColor = themeColor;
            //this.PresentMonth.ForeColor = themeColor;
            label2.ForeColor = themeColor;

            this.lbYearly.ForeColor = themeColor;
            sideBySideBarSeriesView1.Color = themeColor;
            series1.View = sideBySideBarSeriesView1;

            // 2: load notifacaiton status
            if(Settings1.Default.Notification == true)
            {
                alertOff.Visible = false;
                alertOn.Visible = true;
                notificationStatusLB.Text = "On";
                notifycationToolStripMenuItem.Checked = true;
            }
            else
            {
                alertOff.Visible = true;
                alertOn.Visible = false;
                notificationStatusLB.Text = "Off";
                notifycationToolStripMenuItem.Checked = false;
            }

            // 3: load email address
            if(Settings1.Default.Email != "")
            {
                emailTB.Text = Settings1.Default.Email;
                emailTB.ForeColor = SystemColors.ControlText;
            }

            // 4: load email notification kind
            normalChB.Checked = Settings1.Default.normalEmailNoti;
            mediumChB.Checked = Settings1.Default.mediumEmailNoti;
            highChB.Checked = Settings1.Default.highEmailNoti;

            // set can close for the form, form only close when close is click in item in tray bar
            this.canClose = false;

            // Use this for selected certain of MenuStripItem that allow MenuStrip to close
            menuStripCanClose = false;
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
            DateButton = new Button[6, 7];
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    DateButton[i, j] = new Button();
                    DateButton[i, j].FlatStyle = FlatStyle.Flat;
                    DateButton[i, j].FlatAppearance.BorderSize = 0;
                    DateButton[i, j].FlatAppearance.MouseOverBackColor = Color.Transparent;
                    DateButton[i, j].Font = new Font("Segoe UI SemiLight", 19);
                    DateButton[i, j].ForeColor = Color.FromArgb(68, 75, 83);
                    DateButton[i, j].Width = label2.Width + 4;
                    DateButton[i, j].Height = label2.Width - 20;
                    DateButton[i, j].Location = new Point(label2.Location.X - 7 + (label2.Width + 4 + Const.DateButtonOffSet) * j,
                                                          label2.Location.Y + (label2.Width - 20 + Const.DateButtonOffSet) * (i + 1));
                    DateButton[i, j].UseVisualStyleBackColor = true;
                    DateButton[i, j].Text = "";
                    DateButton[i, j].Click += DayButton_Click;

                    panel6.Controls.Add(DateButton[i, j]);
                }
            }
            for (int i = 1; i < 32; i++)
            {
                PriorityColorForDay[i] = new Color();
            }
            GenerateDaysForDateButtons(Months.iCurrent);
        }

        public void GenerateDaysForDateButtons(int month)
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
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    DateButton[i, j].Text = "";
                    DateButton[i, j].BackColor = Color.Transparent;
                    DateButton[i, j].ForeColor = Color.FromArgb(68, 75, 83);
                    DateButton[i, j].Font = new Font("Segoe UI", 19);
                    DateButton[i, j].FlatAppearance.MouseOverBackColor = Color.Transparent;
                    DateButton[i, j].Enabled = false;

                    if (j == dayOfWeek)
                    {
                        started = true;
                    }
                    if (started && count <= maxDay)
                    {
                        DateTime day = new DateTime(Year.GetCurrentYear(), Months.iCurrent, count);
                        List<GroupPlanItem> groupPlanForToday = allPlan.ListGroupItemsForToday(new DateTime(Year.GetCurrentYear(), month, count));
                        List<PlanItem> allPlanForToday = new List<PlanItem>();
                        int BusyScore = 0;
                        foreach(var group in groupPlanForToday)
                        {
                            allPlanForToday.AddRange(group.ListItemsForToday(day));
                        }

                        foreach(var item in allPlanForToday)
                        {
                            if(item.priority == PriorityEnum.normal)
                            {
                                BusyScore += 1;
                            }
                            else if (item.priority == PriorityEnum.medium)
                            {
                                BusyScore += 2;
                            }
                            else if(item.priority == PriorityEnum.high)
                            {
                                BusyScore += 3;
                            }
                        }

                        if (BusyScore < 5)
                        {
                            PriorityColorForDay[count] = Color.FromArgb(68, 75, 83);
                        }
                        else if (BusyScore < 10)
                        {
                            PriorityColorForDay[count] = Color.FromArgb(231, 168, 54);
                        }
                        else
                        {
                            PriorityColorForDay[count] = Color.FromArgb(176, 24, 32);
                        }
                        DateButton[i, j].Text = count.ToString();
                        DateButton[i, j].FlatAppearance.MouseOverBackColor = Color.FromArgb(229, 229, 229);
                        DateButton[i, j].Enabled = true;
                        DateButton[i, j].ForeColor = PriorityColorForDay[count];
                        if (count == DateTime.Now.Day && month == DateTime.Now.Month && Year.GetCurrentYear() == DateTime.Now.Year)
                        {
                            DateButton[i, j].BackColor = Color.Transparent;
                            DateButton[i, j].Font = new Font("Segoe UI Black", 19);
                        }
                        if (count == focusedDate.Day && month == focusedDate.Month && Year.GetCurrentYear() == focusedDate.Year)
                        {
                            DateButton[i, j].BackColor = Color.FromArgb(50, 0, 0, 0);
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
        private void Addbutton_Click(object sender, EventArgs e)
        {
            new_Event = new New_Event(allPlan, new DateTime(focusedDate.Year, focusedDate.Month, focusedDate.Day, DateTime.Now.Hour, DateTime.Now.Minute, 0));
            new_Event.ShowDialog();
            LoadItemToDayView(focusedDate.Year, focusedDate.Month, focusedDate.Day);
            LoadDataToTimeTable();
            GenerateDaysForDateButtons(Months.iCurrent);
        }

        private void PrevMonth_Click(object sender, EventArgs e)
        {
            Months.ToPrevMonth();
            PresentMonth.Text = Months.ToString();
            YearLabel.Text = Year.GetCurrentYear().ToString();
            GenerateDaysForDateButtons(Months.iCurrent);
        }

        private void NextMonth_Click(object sender, EventArgs e)
        {
            Months.ToNextMonth();
            PresentMonth.Text = Months.ToString();
            YearLabel.Text = Year.GetCurrentYear().ToString();
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
            using (StringWriter str = new StringWriter())
            using (XmlTextWriter xml = new XmlTextWriter(filepath, null))
            {
                xml.Flush();
            }
            FileStream fs = new FileStream(filepath, FileMode.OpenOrCreate, FileAccess.Write);
            XmlSerializer sr = new XmlSerializer(typeof(PlanData));
            sr.Serialize(fs, allPlan);
            fs.Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SerializeToXML(allPlan,Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\" + filepath);
            if (!canClose)
            {
                e.Cancel = true;
                notifyIcon1.Visible = true;
                Hide();
                menuStripCanClose = false;
            }
        }

        public void ReloadItemToDayView()
        {
            LoadItemToDayView(focusedDate.Year, focusedDate.Month, focusedDate.Day);
        }
        private void LoadItemToDayView(int year, int month, int day)
        {
            dayView.Controls.Clear();
            DateTime today = new DateTime(year, month, day);
            List<GroupPlanItem> groups = allPlan.ListGroupItemsForToday(today);
            List<Tuple<GroupPlanItem, PlanItem>> pairItems = new List<Tuple<GroupPlanItem, PlanItem>>();
            
            for (int i = 0; i < groups.Count; i++)
            {
                List<PlanItem> items = groups[i].ListItemsForToday(today);
                for (int j = 0; j < items.Count; j++)
                {
                    pairItems.Add(new Tuple<GroupPlanItem, PlanItem>(groups[i], items[j]));
                }
            }

            PairGroupItemComparer pairGroupItemComparer = new PairGroupItemComparer();
            pairItems.Sort(pairGroupItemComparer);

            for (int i = 0; i < pairItems.Count; i++)
            {
                dayView.Controls.Add(new Item(pairItems[i].Item1, pairItems[i].Item2, today, this));
            }
        }

        private void DayButton_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.Text == "")
                return;
            focusedDate = new DateTime(Year.GetCurrentYear(), Months.iCurrent, Convert.ToInt32(b.Text));
            focusedButton.BackColor = Color.Transparent;
            b.BackColor = Color.FromArgb(229, 229, 229);
            focusedButton = b;
            if (focusedDate.Day == DateTime.Now.Day && focusedDate.Month == DateTime.Now.Month && focusedDate.Month == DateTime.Now.Month)
            {
                label1.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                label1.Text = "Today";
            }
            else
            {
                label1.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                label1.Text = focusedDate.Day.ToString() + "/" + focusedDate.Month.ToString() + "/" + focusedDate.Year.ToString();
            }
            LoadItemToDayView(Year.GetCurrentYear(), Months.iCurrent, Convert.ToInt32(b.Text));
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
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
            if (Settings1.Default.Notification == true)
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
                        alertForToday[i].alert.Minute == dt.Minute &&
                        alertForToday[i].notification == true
                       )
                    {
                        notifyIcon1.Visible = true;
                        notifyIcon1.BalloonTipTitle = alertForToday[i].title;
                        if(notifyIcon1.BalloonTipTitle == "")
                        {
                            notifyIcon1.BalloonTipTitle = "You have an upcoming event";
                        }
                        notifyIcon1.BalloonTipText = alertForToday[i].location + " / " + alertForToday[i].note;
                        if (notifyIcon1.BalloonTipText == "")
                        {
                            notifyIcon1.BalloonTipTitle = " ";
                        }
                        notifyIcon1.ShowBalloonTip(3000);

                        if((alertForToday[i].priority == PriorityEnum.normal && Settings1.Default.normalEmailNoti == true) ||
                           (alertForToday[i].priority == PriorityEnum.medium && Settings1.Default.mediumEmailNoti == true) ||
                           (alertForToday[i].priority == PriorityEnum.high && Settings1.Default.highEmailNoti == true))
                        {
                            SendEmailNotification("You have an upcoming task" + Environment.NewLine +
                                                  "Name: " + alertForToday[i].title + Environment.NewLine + 
                                                  "At " + alertForToday[i].location + Environment.NewLine +
                                                  "Notes: " + alertForToday[i].note);
                        }
                    }
                }
                timer.Interval = 60000;
            }
        }

        private void timetableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            schedulerControl1.GoToToday();
            TimeTablePanel.Visible = true;
            panel6.Visible = false;
            YearLabel.Visible = false;
            PresentMonth.Visible = false;
            nextmonth.Visible = false;
            prevmonth.Visible = false;
            SettingPanel.Visible = false;
            pnlStatistics.Visible = false;
            this.Refresh();
        }

        private void calendarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TimeTablePanel.Visible = false;
            SettingPanel.Visible = false;
            pnlStatistics.Visible = false;
            panel6.Visible = true;
            YearLabel.Visible = true;
            PresentMonth.Visible = true;
            nextmonth.Visible = true;
            prevmonth.Visible = true;
            this.Refresh();
        }

        private void StatisticsToolStripMenuItem1_Click(object sender, System.EventArgs e)
        {
            ReloadChartData();

            TimeTablePanel.Visible = false;
            panel6.Visible = false;
            YearLabel.Visible = false;
            PresentMonth.Visible = false;
            SettingPanel.Visible = false;
            nextmonth.Visible = false;
            prevmonth.Visible = false;
            pnlStatistics.Visible = true;
            this.Refresh();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TimeTablePanel.Visible = false;
            panel6.Visible = false;
            YearLabel.Visible = false;
            PresentMonth.Visible = false;
            nextmonth.Visible = false;
            prevmonth.Visible = false;
            pnlStatistics.Visible = false;
            SettingPanel.Visible = true;
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
            if (e.Appointment.CustomFields.Count == 0)
            {
                SchedulerControl schedulerControl = sender as SchedulerControl;

                New_Event new_Event = new New_Event(allPlan, schedulerControl.DayView.SelectedInterval.Start, schedulerControl.DayView.SelectedInterval.End);
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

        private void PresentMonth_Click(object sender, EventArgs e)
        {

        }

        private void SendEmailNotification(string body)
        {
            try
            {
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();

                message.From = new MailAddress("Dragonnica123@gmail.com");
                message.To.Add(new MailAddress("18520359@gm.uit.edu.vn"));
                message.Subject = "Auto Mail Notification";
                message.Body = body;
                message.IsBodyHtml = false;

                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("Dragonnica123@gmail.com", "0964495600");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("err: " + ex.Message);
            }
        }

        private void schedulerControl1_AllowAppointmentDrag(object sender, AppointmentOperationEventArgs e)
        {
            e.Allow = false;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void SettingPanel_Paint(object sender, PaintEventArgs e)
        {
        }
        private void pnlStatistics_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        //private void CountJob(int year)
        //{
        //    jobsDoneInEachMonth = new int[13];
        //    allDoneJobs = 0;

        //    int numberOfGroup = allPlan.group.Count;
        //    int numberOfItem;

        //    for (int i = 0; i < numberOfGroup; i++)
        //    {
        //        numberOfItem = allPlan.group[i].data.Count;
        //        for (int j = 0; j < numberOfItem; j++)
        //        {
        //            if (allPlan.group[i].data[j].done == true)
        //            {
        //                allDoneJobs++;
        //                int startYear = allPlan.group[i].data[j].startTime.Year;
        //                int endYear = allPlan.group[i].data[j].endTime.Year;
        //                int startMonth = allPlan.group[i].data[j].startTime.Month;
        //                int endMonth = allPlan.group[i].data[j].endTime.Month;

        //                if (startYear == year && endYear == year)
        //                {
        //                    if (startMonth != endMonth)
        //                    {
        //                        jobsDoneInEachMonth[startMonth]++;
        //                        jobsDoneInEachMonth[endMonth]++;
        //                    }
        //                    else jobsDoneInEachMonth[startMonth]++;
        //                }
        //                else
        //                {
        //                    if (startYear == year) jobsDoneInEachMonth[startMonth]++;
        //                    else if (endYear == year) jobsDoneInEachMonth[endMonth]++;
        //                }
        //            }
        //        }
        //    }
        //}

        private void CountJob(int year)
        {
            jobsDoneInEachDay = new int[13,32];
            allDoneJobs = 0;

            int numberOfGroup = allPlan.group.Count;
            int numberOfItem;

            for (int i = 0; i < numberOfGroup; i++)
            {
                numberOfItem = allPlan.group[i].data.Count;
                for (int j = 0; j < numberOfItem; j++)
                {
                    if (allPlan.group[i].data[j].done == true)
                    {
                        allDoneJobs++;
                        int startYear = allPlan.group[i].data[j].startTime.Year;
                        int endYear = allPlan.group[i].data[j].endTime.Year;
                        int startMonth = allPlan.group[i].data[j].startTime.Month;
                        int endMonth = allPlan.group[i].data[j].endTime.Month;
                        int startDay = allPlan.group[i].data[j].startTime.Day;
                        int endDay = allPlan.group[i].data[j].endTime.Day;

                        if (startYear == year && endYear == year)
                        {
                            if( startMonth != endMonth)
                            {
                                jobsDoneInEachDay[startMonth, startDay]++;
                                jobsDoneInEachDay[endMonth, endDay]++;
                                jobsDoneInEachDay[startMonth, 0]++;
                                jobsDoneInEachDay[endMonth, 0]++;
                                allDoneJobs++;
                            }
                            else
                            {
                                if( startDay != endDay)
                                {
                                    jobsDoneInEachDay[startMonth, startDay]++;
                                    jobsDoneInEachDay[startMonth, endDay]++;
                                    jobsDoneInEachDay[startMonth, 0] += 2;
                                    allDoneJobs++;
                                }
                                else
                                {
                                    jobsDoneInEachDay[startMonth, startDay]++;
                                    jobsDoneInEachDay[startMonth, 0]++;
                                }
                            }
                        }
                        else
                        {
                            if (startYear == year)
                            {
                                jobsDoneInEachDay[startMonth, startDay]++;
                                jobsDoneInEachDay[startMonth, 0]++;
                            }
                            else if (endYear == year)
                            {
                                jobsDoneInEachDay[endMonth, endDay]++;
                                jobsDoneInEachDay[endMonth, 0]++;
                            }
                        }
                    }
                }
            }
        }
        private DataTable JobsDoneInMonth()
        {
            DataTable dataTable = new DataTable("table1");
            dataTable.Columns.Add("Argument", typeof(Int32));
            dataTable.Columns.Add("Value", typeof(Int32));

            DataRow row = null;
            for (int i = 1; i <= 12; i++)
            {

                row = dataTable.NewRow();
                row["Argument"] = i;
                row["Value"] = jobsDoneInEachDay[i,0];
                dataTable.Rows.Add(row);
            }
            return dataTable;
        }
        private DataTable JobsDoneInDay()
        {
            DataTable dataTable = new DataTable("table2");
            dataTable.Columns.Add("Argument", typeof(Int32));
            dataTable.Columns.Add("Value", typeof(Int32));

            DataRow row = null;
            int year = Convert.ToInt32(this.cbbYearly.Text);
            int month = Convert.ToInt32(this.cbbMonthly.Text);
            int numberOfDay = Year.GetMaxDaysOfMonth(year, month);
            for (int i = 1; i <= numberOfDay; i++)
            {
                row = dataTable.NewRow();
                row["Argument"] = i;
                row["Value"] = jobsDoneInEachDay[month,i];
                dataTable.Rows.Add(row);
            }
            return dataTable;
        }
        private int JobsDoneInToday()
        {
            int month = DateTime.Now.Month;
            int day = DateTime.Now.Day;
            return jobsDoneInEachDay[month, day];
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            CountJob(Convert.ToInt32(this.cbbYearly.Text));
            try
            {
                series1.DataSource = JobsDoneInMonth();    
            }
            catch { }

            // all jobs completed in data
            sumall.Text = allDoneJobs.ToString();

            // jobs in month completed
            int month = DateTime.Now.Month;
            summonth.Text = jobsDoneInEachDay[month,0].ToString();

            // jobs in today completed
            sumday.Text = jobsDoneToday.ToString();
        }
        private void AddYearForCombobox()
        {
            do
            {
                this.cbbYearly.Items.Add(2013 + this.cbbYearly.Items.Count);
            } while (DateTime.Now.Year > (2013 + this.cbbYearly.Items.Count - 1));
        }
        private void ReloadChartData()
        {
            CountJob(Convert.ToInt32(this.cbbYearly.Text));
            if (this.cbbMonthly.Visible == true) series1.DataSource = JobsDoneInDay();
            else series1.DataSource = JobsDoneInMonth();

            int month = DateTime.Now.Month;
            int day = DateTime.Now.Day;

            sumall.Text = allDoneJobs.ToString();
            summonth.Text = jobsDoneInEachDay[month,0].ToString();
            sumday.Text = JobsDoneInToday().ToString();
        }
        private void cbbYearly_TextChanged(object sender, EventArgs e)
        {
            ReloadChartData();
        }
        private void cbbMonthly_TextChanged(object sender, EventArgs e)
        {
            series1.DataSource = JobsDoneInDay();
        }

        private void lbYearly_Click(object sender, EventArgs e)
        {
            this.lbYearly.Font = new Font("Segoe UI Black", 10F, System.Drawing.FontStyle.Bold);
            this.lbYearly.ForeColor = themeColor;
            this.lbMonthly.Font = new Font("Segoe UI Light", 10F);
            this.lbMonthly.ForeColor = Color.Black;
            this.cbbMonthly.Visible = false;

            series1.DataSource = JobsDoneInMonth();
            //series1.Name = "Number of job in each month done";
        }

        private void lbMonthly_Click(object sender, EventArgs e)
        {
            this.lbMonthly.Font = new Font("Segoe UI Black", 10F, System.Drawing.FontStyle.Bold);
            this.lbMonthly.ForeColor = themeColor;
            this.lbYearly.Font = new Font("Segoe UI Light", 10F);
            this.lbYearly.ForeColor = Color.Black;
            this.cbbMonthly.Visible = true;

            series1.DataSource = JobsDoneInDay();
            //series1.Name = "Number of job in each day done";

            
        }

        private void theme1PB_Click(object sender, EventArgs e)
        {
            Color c = Color.FromArgb(112, 76, 161);
            this.panel3.BackColor = c;
            this.panel8.BackColor = c;
            this.addbutton.BackColor = c;
            this.panel2.ForeColor = c;
            //this.PresentMonth.ForeColor = c;
            label2.ForeColor = c;
            lblSave.ForeColor = c;
            Settings1.Default.Theme = 1;
            themeColor = c;

            sideBySideBarSeriesView1.Color = c;
            if (cbbMonthly.Visible == true) lbMonthly.ForeColor = c;
            else lbYearly.ForeColor = c;
        }
        private void theme2PB_Click(object sender, EventArgs e)
        {
            Color c = Color.FromArgb(238, 197, 106);
            this.panel3.BackColor = c;
            this.panel8.BackColor = c;
            this.addbutton.BackColor = c;
            this.panel2.ForeColor = c;
            //this.PresentMonth.ForeColor = c;
            label2.ForeColor = c;
            lblSave.ForeColor = c;
            Settings1.Default.Theme = 2;
            themeColor = c;

            sideBySideBarSeriesView1.Color = c;
            if (cbbMonthly.Visible == true) lbMonthly.ForeColor = c;
            else lbYearly.ForeColor = c;
        }
        private void theme3PB_Click(object sender, EventArgs e)
        {
            Color c = Color.FromArgb(78, 169, 119);
            this.panel3.BackColor = c;
            this.panel8.BackColor = c;
            this.addbutton.BackColor = c;
            this.panel2.ForeColor = c;
            //this.PresentMonth.ForeColor = c;
            lblSave.ForeColor = c;
            label2.ForeColor = c;
            Settings1.Default.Theme = 3;
            themeColor = c;

            sideBySideBarSeriesView1.Color = c;
            if (cbbMonthly.Visible == true) lbMonthly.ForeColor = c;
            else lbYearly.ForeColor = c;
        }
        private void theme4PB_Click(object sender, EventArgs e)
        {
            Color c = Color.FromArgb(194, 200, 207);
            this.panel3.BackColor = c;
            this.panel8.BackColor = c;
            this.addbutton.BackColor = c;
            this.panel2.ForeColor = c;
            //this.PresentMonth.ForeColor = c;
            label2.ForeColor = c;
            lblSave.ForeColor = c;
            Settings1.Default.Theme = 4;
            themeColor = c;

            sideBySideBarSeriesView1.Color = c;
            if (cbbMonthly.Visible == true) lbMonthly.ForeColor = c;
            else lbYearly.ForeColor = c;
        }

        private void lblSave_Click(object sender, EventArgs e)
        {
            if (emailTB.ForeColor == SystemColors.ControlText)
            {
                Settings1.Default.Email = emailTB.Text;
            }
            else
            {
                Settings1.Default.Email = "";
            }
            Settings1.Default.Save();
        }

        private void lblSave_MouseDown(object sender, MouseEventArgs e)
        {
            lblSave.BackColor = Color.FromArgb(30, 0, 0, 0);
        }

        private void lblSave_MouseUp(object sender, MouseEventArgs e)
        {
            lblSave.BackColor = Color.Transparent;
        }

        private void lblDefault_Click(object sender, EventArgs e)
        {
            // theme
            Color c = Color.FromArgb(78, 169, 119);
            this.panel3.BackColor = c;
            this.panel8.BackColor = c;
            this.addbutton.BackColor = c;
            this.panel2.ForeColor = c;
            //this.PresentMonth.ForeColor = c;
            label2.ForeColor = c;
            sideBySideBarSeriesView1.Color = c;
            Settings1.Default.Theme = 3;
            themeColor = c;

            if (cbbMonthly.Visible == true) lbMonthly.ForeColor = c;
            else lbYearly.ForeColor = c;

            // notification
            alertOff_Click(sender, e);
            Settings1.Default.Notification = true;

            // email notifacation kind
            normalChB.Checked = false;
            mediumChB.Checked = false;
            highChB.Checked = false;

            Settings1.Default.Save();
        }

        private void lblDefault_MouseDown(object sender, MouseEventArgs e)
        {
            lblDefault.BackColor = Color.FromArgb(30, 0, 0, 0);
        }

        private void lblDefault_MouseUp(object sender, MouseEventArgs e)
        {
            lblDefault.BackColor = Color.Transparent;
        }

        private void alertOff_Click(object sender, EventArgs e)
        {
            Settings1.Default.Notification = true;
            alertOff.Visible = false;
            alertOn.Visible = true;
            notificationStatusLB.Text = "On";
        }

        private void alertOn_Click(object sender, EventArgs e)
        {
            Settings1.Default.Notification = false;
            alertOff.Visible = true;
            alertOn.Visible = false;
            notificationStatusLB.Text = "Off";
        }

        private void emailTB_Enter(object sender, EventArgs e)
        {
            if(emailTB.ForeColor != SystemColors.ControlText)
            {
                emailTB.Text = "";
                emailTB.ForeColor = SystemColors.ControlText;
            }
        }

        private void emailTB_Leave(object sender, EventArgs e)
        {
            if (emailTB.Text == "")
            {
                emailTB.Text = "Type email here";
                this.emailTB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(200)))), ((int)(((byte)(207)))));
            }
        }

        private void normalChB_CheckedChanged(object sender, EventArgs e)
        {
            Settings1.Default.normalEmailNoti = normalChB.Checked;
        }

        private void mediumChB_CheckedChanged(object sender, EventArgs e)
        {
            Settings1.Default.mediumEmailNoti = mediumChB.Checked;
        }

        private void highChB_CheckedChanged(object sender, EventArgs e)
        {
            Settings1.Default.highEmailNoti = highChB.Checked;
        }

        private void theme1PB_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            if (Settings1.Default.Theme == 1)
            {
                e.Graphics.FillEllipse(new SolidBrush(Color.FromArgb(112, 76, 161)), theme1PB.DisplayRectangle);
            }
            else
            {
                e.Graphics.FillEllipse(new SolidBrush(Color.FromArgb(219, 210, 231)), theme1PB.DisplayRectangle);
            }
        }

        private void theme2PB_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            if (Settings1.Default.Theme == 2)
            {
                e.Graphics.FillEllipse(new SolidBrush(Color.FromArgb(238, 197, 106)), theme1PB.DisplayRectangle);
            }
            else
            {
                e.Graphics.FillEllipse(new SolidBrush(Color.FromArgb(251, 240, 218)), theme1PB.DisplayRectangle);
            }
        }

        private void theme3PB_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            if (Settings1.Default.Theme == 3)
            {
                e.Graphics.FillEllipse(new SolidBrush(Color.FromArgb(78, 169, 119)), theme1PB.DisplayRectangle);
            }
            else
            {
                e.Graphics.FillEllipse(new SolidBrush(Color.FromArgb(211, 233, 221)), theme1PB.DisplayRectangle);
            }
        }

        private void theme4PB_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            if (Settings1.Default.Theme == 4)
            {
                e.Graphics.FillEllipse(new SolidBrush(Color.FromArgb(194, 200, 207)), theme1PB.DisplayRectangle);
            }
            else
            {
                e.Graphics.FillEllipse(new SolidBrush(Color.FromArgb(240, 241, 243)), theme1PB.DisplayRectangle);
            }
        }

        private void emailTB_TextChanged(object sender, EventArgs e)
        {
            emailTB.SelectionStart = emailTB.Text.Length;
        }

        private void schedulerControl1_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            if (e.Menu.Id == SchedulerMenuItemId.DefaultMenu)
            {
                e.Menu.RemoveMenuItem(SchedulerMenuItemId.NewAllDayEvent);
                e.Menu.RemoveMenuItem(SchedulerMenuItemId.NewRecurringAppointment);
                e.Menu.RemoveMenuItem(SchedulerMenuItemId.NewRecurringEvent);
                e.Menu.Items.Remove(e.Menu.Items[3]);
            } 
            else if(e.Menu.Id == SchedulerMenuItemId.AppointmentMenu)
            {
                e.Menu.Items.Remove(e.Menu.Items[1]);
                e.Menu.Items.Remove(e.Menu.Items[1]);
                e.Menu.Items.Remove(e.Menu.Items[1]);
                e.Menu.Items.Remove(e.Menu.Items[1]);
                e.Menu.Items.Remove(e.Menu.Items[1]);
                e.Menu.Items.Add(new DevExpress.Utils.Menu.DXMenuItem("Delete", DeleteAppointment));
            }
            else
            {
                e.Menu.Items.Clear();
            }
        }

        private void DeleteAppointment(object sender, EventArgs e)
        {
            EditEvent edit = new EditEvent(allPlan, (GroupPlanItem)focusedAppointment.CustomFields["group"], (PlanItem)focusedAppointment.CustomFields["item"]);
            
            edit.deleteLB_Click_WithoutClosing(sender, e);
            LoadDataToTimeTable();
            LoadItemToDayView(focusedDate.Year, focusedDate.Month, focusedDate.Day);
        }

        private void schedulerControl1_MouseMove(object sender, MouseEventArgs e)
        {
            SchedulerControl scheduler = sender as SchedulerControl;
            if (scheduler == null) return;

            Point pos = new Point(e.X, e.Y);
            SchedulerViewInfoBase viewInfo = schedulerControl1.ActiveView.ViewInfo;
            SchedulerHitInfo hitInfo = viewInfo.CalcHitInfo(pos, false);

            if (hitInfo.HitTest == SchedulerHitTest.AppointmentContent)
            {
                focusedAppointment = ((AppointmentViewInfo)hitInfo.ViewInfo).Appointment;
            }
            else
            {
                focusedAppointment = null;
            }
        }

        private void schedulerControl1_CustomDrawAppointmentFlyoutSubject(object sender, CustomDrawAppointmentFlyoutSubjectEventArgs e)
        {
            PlanItem pi = (PlanItem)(e.Appointment.CustomFields["item"]);
            Color themeColor = new Color();
            Color textColor = Color.Black;
            if (pi.priority == PriorityEnum.normal)
            {
                themeColor = Color.FromArgb(117, 122, 129);
                textColor = Color.FromArgb(49, 51, 54);
            }
            if (pi.priority == PriorityEnum.medium)
            {
                themeColor = Color.FromArgb(248, 221, 148);
                textColor = Color.FromArgb(106, 103, 69);
            }
            if (pi.priority == PriorityEnum.high)
            {
                themeColor = Color.FromArgb(225, 113, 125);
                textColor = Color.FromArgb(87, 44, 48);
            }
            e.Cache.FillRectangle(new SolidBrush(themeColor), e.Bounds);
            e.DrawStatusDefault();
            e.Cache.DrawString(pi.title, new Font("Segoe UI", 11f, FontStyle.Bold), new SolidBrush(textColor),
                new Rectangle(e.Bounds.X + 10, e.Bounds.Y + 10, e.Bounds.Width, e.Bounds.Height),
                StringFormat.GenericTypographic);
            e.Handled = true;
        }

        private void schedulerControl1_CustomizeAppointmentFlyout(object sender, CustomizeAppointmentFlyoutEventArgs e)
        {
            e.ShowSubject = true;
            e.Subject = String.Format("{0} - {1:f}", e.Subject.Split()[0], e.Start);
            e.SubjectAppearance.Font = new Font("Segoe UI", 10f);
            e.ShowReminder = false;
            e.ShowLocation = true;
            e.ShowEndDate = true;
            e.ShowStartDate = true;
            e.ShowStatus = true;
        }

        private void schedulerControl1_CustomDrawAppointment(object sender, CustomDrawObjectEventArgs e)
        {
            AppointmentViewInfo viewInfo = e.ObjectInfo as AppointmentViewInfo;

            Color textColor = new Color();
            PlanItem pi = (PlanItem)(viewInfo.Appointment.CustomFields["item"]);
            if (pi.priority == PriorityEnum.normal)
            {
                textColor = Color.FromArgb(49, 51, 54);
            }
            if (pi.priority == PriorityEnum.medium)
            {
                textColor = Color.FromArgb(106, 103, 69);
            }
            if (pi.priority == PriorityEnum.high)
            {
                textColor = Color.FromArgb(87, 44, 48);
            }

            Rectangle mainContentBounds = new Rectangle(viewInfo.InnerBounds.X - 5, viewInfo.InnerBounds.Y,
                viewInfo.InnerBounds.Width, viewInfo.InnerBounds.Height);

            
            // Draw the appointment caption text. 
            e.Cache.DrawString(viewInfo.DisplayText.Trim(), viewInfo.Appearance.Font,
                new SolidBrush(textColor), mainContentBounds, StringFormat.GenericTypographic);
            SizeF subjSize = e.Graphics.MeasureString(viewInfo.DisplayText.Trim(), viewInfo.Appearance.Font, mainContentBounds.Width);
            int lineYposition = (int)subjSize.Height;

            Rectangle descriptionLocation = new Rectangle(mainContentBounds.X, mainContentBounds.Y + lineYposition,
                mainContentBounds.Width, mainContentBounds.Height - lineYposition);
            e.Handled = true;
        }

        private void schedulerControl1_CustomDrawAppointmentBackground(object sender, CustomDrawObjectEventArgs e)
        {
            AppointmentViewInfo viewInfo = e.ObjectInfo as AppointmentViewInfo;
            int widthCell = viewInfo.Bounds.Width / 4;
            Rectangle mainContentBounds = new Rectangle(viewInfo.InnerBounds.X, viewInfo.InnerBounds.Y, viewInfo.InnerBounds.Width, viewInfo.InnerBounds.Height);
            PlanItem pi = (PlanItem)(viewInfo.Appointment.CustomFields["item"]);
            if (pi.priority == PriorityEnum.normal)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(151, 155, 160)), new Rectangle(viewInfo.Bounds.X, viewInfo.Bounds.Y, viewInfo.Bounds.Width, viewInfo.Bounds.Height));
            }
            if (pi.priority == PriorityEnum.medium)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(248, 221, 148)), new Rectangle(viewInfo.Bounds.X, viewInfo.Bounds.Y, viewInfo.Bounds.Width, viewInfo.Bounds.Height));
            }
            if (pi.priority == PriorityEnum.high)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(225, 113, 125)), new Rectangle(viewInfo.Bounds.X, viewInfo.Bounds.Y, viewInfo.Bounds.Width, viewInfo.Bounds.Height));
            }
            e.Handled = true;
        }

        private void schedulerControl1_Click(object sender, EventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            notifyIcon1.Visible = false;
            Show();
            menuStripCanClose = true;
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            canClose = true;
            this.Close();
        }

        private void notifycationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            notifycationToolStripMenuItem.Checked = !notifycationToolStripMenuItem.Checked;
            if(notifycationToolStripMenuItem.Checked)
            {
                alertOff_Click(sender, e);
            }
            else
            {
                alertOn_Click(sender, e);
            }
            menuStripCanClose = false;
        }

        private void notifyIconMenuStrip_Closing(object sender, ToolStripDropDownClosingEventArgs e)
        {
            if(!menuStripCanClose)
            {
                e.Cancel = true;
            }
        }
    }
}
