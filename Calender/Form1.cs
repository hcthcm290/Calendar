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

        private void InitDesign()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            DevExpress.XtraScheduler.TimeRuler timeRuler1 = new DevExpress.XtraScheduler.TimeRuler();
            DevExpress.XtraScheduler.TimeRuler timeRuler2 = new DevExpress.XtraScheduler.TimeRuler();
            DevExpress.XtraScheduler.TimeRuler timeRuler3 = new DevExpress.XtraScheduler.TimeRuler();
            this.schedulerDataStorage1 = new DevExpress.XtraScheduler.SchedulerDataStorage(this.components);
            this.vScrollBar1 = new DevExpress.XtraEditors.VScrollBar();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.notifyIcon2 = new System.Windows.Forms.NotifyIcon(this.components);
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.panel2 = new System.Windows.Forms.Panel();
            this.PresentMonth = new System.Windows.Forms.Label();
            this.lbyear = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.statisticsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timetableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statisticsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.TimeTablePanel = new System.Windows.Forms.Panel();
            this.schedulerControl1 = new DevExpress.XtraScheduler.SchedulerControl();
            this.SettingPanel = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.labelNotify = new System.Windows.Forms.Label();
            this.labelColor = new System.Windows.Forms.Label();
            this.buttonSaveSetting = new System.Windows.Forms.Button();
            this.buttonColor = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dayView = new System.Windows.Forms.FlowLayoutPanel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.addbutton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.prevmonth = new System.Windows.Forms.Button();
            this.nextmonth = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerDataStorage1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel6.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.TimeTablePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerControl1)).BeginInit();
            this.SettingPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // schedulerDataStorage1
            // 
            // 
            // 
            // 
            this.schedulerDataStorage1.AppointmentDependencies.AutoReload = false;
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Location = new System.Drawing.Point(0, 0);
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(21, 80);
            this.vScrollBar1.TabIndex = 0;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Calendar";
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // notifyIcon2
            // 
            this.notifyIcon2.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon2.Icon")));
            this.notifyIcon2.Text = "notifyIcon2";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.nextmonth);
            this.panel2.Controls.Add(this.prevmonth);
            this.panel2.Controls.Add(this.PresentMonth);
            this.panel2.Controls.Add(this.lbyear);
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Controls.Add(this.menuStrip1);
            this.panel2.ForeColor = System.Drawing.Color.DarkOrange;
            this.panel2.Location = new System.Drawing.Point(563, 3);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(707, 688);
            this.panel2.TabIndex = 0;
            // 
            // PresentMonth
            // 
            this.PresentMonth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PresentMonth.BackColor = System.Drawing.Color.Transparent;
            this.PresentMonth.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PresentMonth.Font = new System.Drawing.Font("Segoe UI Light", 36F);
            this.PresentMonth.ForeColor = System.Drawing.Color.DarkGray;
            this.PresentMonth.Location = new System.Drawing.Point(225, 197);
            this.PresentMonth.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.PresentMonth.Name = "PresentMonth";
            this.PresentMonth.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.PresentMonth.Size = new System.Drawing.Size(399, 69);
            this.PresentMonth.TabIndex = 4;
            this.PresentMonth.Text = "January";
            this.PresentMonth.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.PresentMonth.Click += new System.EventHandler(this.PresentMonth_Click);
            // 
            // lbyear
            // 
            this.lbyear.AutoSize = true;
            this.lbyear.BackColor = System.Drawing.Color.Transparent;
            this.lbyear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbyear.Font = new System.Drawing.Font("Segoe UI Black", 96F, System.Drawing.FontStyle.Bold);
            this.lbyear.Location = new System.Drawing.Point(292, 57);
            this.lbyear.Name = "lbyear";
            this.lbyear.Size = new System.Drawing.Size(365, 170);
            this.lbyear.TabIndex = 6;
            this.lbyear.Text = "2019";
            this.lbyear.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel6
            // 
            this.panel6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel6.BackColor = System.Drawing.Color.Transparent;
            this.panel6.Controls.Add(this.label8);
            this.panel6.Controls.Add(this.label7);
            this.panel6.Controls.Add(this.label6);
            this.panel6.Controls.Add(this.label5);
            this.panel6.Controls.Add(this.label4);
            this.panel6.Controls.Add(this.label3);
            this.panel6.Controls.Add(this.label2);
            this.panel6.Location = new System.Drawing.Point(67, 267);
            this.panel6.Margin = new System.Windows.Forms.Padding(4);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(638, 339);
            this.panel6.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI Black", 18F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(486, 27);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 32);
            this.label8.TabIndex = 6;
            this.label8.Text = "SAT";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Black", 18F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(427, 27);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 32);
            this.label7.TabIndex = 5;
            this.label7.Text = "FRI";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Black", 18F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(353, 27);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 32);
            this.label6.TabIndex = 4;
            this.label6.Text = "THU";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Black", 18F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(275, 27);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 32);
            this.label5.TabIndex = 3;
            this.label5.Text = "WED";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Black", 18F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(201, 27);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 32);
            this.label4.TabIndex = 2;
            this.label4.Text = "TUE";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Black", 18F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(115, 27);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 32);
            this.label3.TabIndex = 1;
            this.label3.Text = "MON";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Black", 18F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.DarkOrange;
            this.label2.Location = new System.Drawing.Point(39, 27);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 32);
            this.label2.TabIndex = 0;
            this.label2.Text = "SUN";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // menuStrip1
            // 
            this.menuStrip1.AllowMerge = false;
            this.menuStrip1.BackColor = System.Drawing.Color.White;
            this.menuStrip1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statisticsToolStripMenuItem,
            this.timetableToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.statisticsToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(707, 33);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // statisticsToolStripMenuItem
            // 
            this.statisticsToolStripMenuItem.AutoSize = false;
            this.statisticsToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.statisticsToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.statisticsToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.statisticsToolStripMenuItem.Name = "statisticsToolStripMenuItem";
            this.statisticsToolStripMenuItem.Size = new System.Drawing.Size(103, 29);
            this.statisticsToolStripMenuItem.Text = "Calendar";
            this.statisticsToolStripMenuItem.Click += new System.EventHandler(this.statisticsToolStripMenuItem_Click);
            // 
            // timetableToolStripMenuItem
            // 
            this.timetableToolStripMenuItem.AutoSize = false;
            this.timetableToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.timetableToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.timetableToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.timetableToolStripMenuItem.Name = "timetableToolStripMenuItem";
            this.timetableToolStripMenuItem.Size = new System.Drawing.Size(111, 29);
            this.timetableToolStripMenuItem.Text = "Timetable";
            this.timetableToolStripMenuItem.Click += new System.EventHandler(this.timetableToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.AutoSize = false;
            this.settingsToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.settingsToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.settingsToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(96, 29);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // statisticsToolStripMenuItem1
            // 
            this.statisticsToolStripMenuItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.statisticsToolStripMenuItem1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.statisticsToolStripMenuItem1.ForeColor = System.Drawing.Color.Black;
            this.statisticsToolStripMenuItem1.Name = "statisticsToolStripMenuItem1";
            this.statisticsToolStripMenuItem1.Size = new System.Drawing.Size(101, 29);
            this.statisticsToolStripMenuItem1.Text = "Statistics";
            // 
            // TimeTablePanel
            // 
            this.TimeTablePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TimeTablePanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.TimeTablePanel.Controls.Add(this.schedulerControl1);
            this.TimeTablePanel.Location = new System.Drawing.Point(0, 46);
            this.TimeTablePanel.Margin = new System.Windows.Forms.Padding(4);
            this.TimeTablePanel.Name = "TimeTablePanel";
            this.TimeTablePanel.Size = new System.Drawing.Size(707, 641);
            this.TimeTablePanel.TabIndex = 4;
            this.TimeTablePanel.Visible = false;
            // 
            // schedulerControl1
            // 
            this.schedulerControl1.ActiveViewType = DevExpress.XtraScheduler.SchedulerViewType.FullWeek;
            this.schedulerControl1.DataStorage = this.schedulerDataStorage1;
            this.schedulerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.schedulerControl1.Location = new System.Drawing.Point(0, 0);
            this.schedulerControl1.Margin = new System.Windows.Forms.Padding(4);
            this.schedulerControl1.Name = "schedulerControl1";
            this.schedulerControl1.Size = new System.Drawing.Size(707, 641);
            this.schedulerControl1.Start = new System.DateTime(2019, 11, 3, 0, 0, 0, 0);
            this.schedulerControl1.TabIndex = 0;
            this.schedulerControl1.Text = "schedulerControl1";
            this.schedulerControl1.Views.DayView.TimeRulers.Add(timeRuler1);
            this.schedulerControl1.Views.FullWeekView.Enabled = true;
            this.schedulerControl1.Views.FullWeekView.TimeRulers.Add(timeRuler2);
            this.schedulerControl1.Views.WorkWeekView.TimeRulers.Add(timeRuler3);
            this.schedulerControl1.EditAppointmentFormShowing += new DevExpress.XtraScheduler.AppointmentFormEventHandler(this.schedulerControl1_EditAppointmentFormShowing);
            this.schedulerControl1.EditAppointmentDependencyFormShowing += new DevExpress.XtraScheduler.AppointmentDependencyFormEventHandler(this.schedulerControl1_EditAppointmentDependencyFormShowing);
            // 
            // SettingPanel
            // 
            this.SettingPanel.Controls.Add(this.pictureBox2);
            this.SettingPanel.Controls.Add(this.pictureBox1);
            this.SettingPanel.Controls.Add(this.radioButton2);
            this.SettingPanel.Controls.Add(this.radioButton1);
            this.SettingPanel.Controls.Add(this.labelNotify);
            this.SettingPanel.Controls.Add(this.labelColor);
            this.SettingPanel.Controls.Add(this.buttonSaveSetting);
            this.SettingPanel.Controls.Add(this.buttonColor);
            this.SettingPanel.Location = new System.Drawing.Point(0, 43);
            this.SettingPanel.Name = "SettingPanel";
            this.SettingPanel.Size = new System.Drawing.Size(702, 634);
            this.SettingPanel.TabIndex = 4;
            this.SettingPanel.Visible = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Calender.Properties.Resources.noti;
            this.pictureBox2.Location = new System.Drawing.Point(49, 144);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(100, 52);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 8;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Calender.Properties.Resources.choosecolor;
            this.pictureBox1.Location = new System.Drawing.Point(49, 36);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // radioButton2
            // 
            this.radioButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton2.Location = new System.Drawing.Point(535, 157);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(128, 33);
            this.radioButton2.TabIndex = 6;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Disable";
            this.radioButton2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton1.Location = new System.Drawing.Point(358, 152);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(117, 42);
            this.radioButton1.TabIndex = 5;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Enable";
            this.radioButton1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // labelNotify
            // 
            this.labelNotify.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNotify.Location = new System.Drawing.Point(146, 147);
            this.labelNotify.Name = "labelNotify";
            this.labelNotify.Size = new System.Drawing.Size(182, 49);
            this.labelNotify.TabIndex = 4;
            this.labelNotify.Text = "Notification:";
            this.labelNotify.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelNotify.Click += new System.EventHandler(this.labelNotify_Click);
            // 
            // labelColor
            // 
            this.labelColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelColor.Location = new System.Drawing.Point(146, 37);
            this.labelColor.Name = "labelColor";
            this.labelColor.Size = new System.Drawing.Size(172, 49);
            this.labelColor.TabIndex = 3;
            this.labelColor.Text = "Color:";
            this.labelColor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonSaveSetting
            // 
            this.buttonSaveSetting.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSaveSetting.Location = new System.Drawing.Point(433, 529);
            this.buttonSaveSetting.Name = "buttonSaveSetting";
            this.buttonSaveSetting.Size = new System.Drawing.Size(230, 58);
            this.buttonSaveSetting.TabIndex = 2;
            this.buttonSaveSetting.Text = "Save";
            this.buttonSaveSetting.UseVisualStyleBackColor = true;
            this.buttonSaveSetting.Click += new System.EventHandler(this.buttonSaveSetting_Click);
            // 
            // buttonColor
            // 
            this.buttonColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonColor.Location = new System.Drawing.Point(415, 34);
            this.buttonColor.Name = "buttonColor";
            this.buttonColor.Size = new System.Drawing.Size(172, 49);
            this.buttonColor.TabIndex = 1;
            this.buttonColor.Text = "Choose Color";
            this.buttonColor.UseVisualStyleBackColor = true;
            this.buttonColor.Click += new System.EventHandler(this.buttonColor_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.DarkOrange;
            this.panel3.Controls.Add(this.dayView);
            this.panel3.Controls.Add(this.panel8);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(5);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(567, 691);
            this.panel3.TabIndex = 1;
            // 
            // dayView
            // 
            this.dayView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dayView.BackColor = System.Drawing.Color.Transparent;
            this.dayView.Location = new System.Drawing.Point(29, 116);
            this.dayView.Margin = new System.Windows.Forms.Padding(4);
            this.dayView.Name = "dayView";
            this.dayView.Size = new System.Drawing.Size(532, 555);
            this.dayView.TabIndex = 3;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.DarkOrange;
            this.panel8.Controls.Add(this.addbutton);
            this.panel8.Controls.Add(this.label1);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Margin = new System.Windows.Forms.Padding(4);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(567, 110);
            this.panel8.TabIndex = 2;
            // 
            // addbutton
            // 
            this.addbutton.AutoSize = true;
            this.addbutton.BackColor = System.Drawing.Color.DarkOrange;
            this.addbutton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.addbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addbutton.ForeColor = System.Drawing.Color.Transparent;
            this.addbutton.Image = global::Calender.Properties.Resources.AddButton;
            this.addbutton.Location = new System.Drawing.Point(458, 11);
            this.addbutton.Margin = new System.Windows.Forms.Padding(4);
            this.addbutton.Name = "addbutton";
            this.addbutton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.addbutton.Size = new System.Drawing.Size(88, 88);
            this.addbutton.TabIndex = 1;
            this.addbutton.UseVisualStyleBackColor = false;
            this.addbutton.Click += new System.EventHandler(this.Addbutton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semilight", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(19, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 65);
            this.label1.TabIndex = 0;
            this.label1.Text = "Today";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Coral;
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(-4, -3);
            this.panel1.Margin = new System.Windows.Forms.Padding(5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1270, 691);
            this.panel1.TabIndex = 0;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // prevmonth
            // 
            this.prevmonth.BackColor = System.Drawing.Color.Transparent;
            this.prevmonth.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.prevmonth.ForeColor = System.Drawing.Color.Transparent;
            this.prevmonth.Image = ((System.Drawing.Image)(resources.GetObject("prevmonth.Image")));
            this.prevmonth.Location = new System.Drawing.Point(45, 439);
            this.prevmonth.Name = "prevmonth";
            this.prevmonth.Size = new System.Drawing.Size(24, 64);
            this.prevmonth.TabIndex = 7;
            this.prevmonth.UseVisualStyleBackColor = false;
            // 
            // nextmonth
            // 
            this.nextmonth.BackColor = System.Drawing.Color.Transparent;
            this.nextmonth.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nextmonth.ForeColor = System.Drawing.Color.Transparent;
            this.nextmonth.Image = ((System.Drawing.Image)(resources.GetObject("nextmonth.Image")));
            this.nextmonth.Location = new System.Drawing.Point(642, 439);
            this.nextmonth.Name = "nextmonth";
            this.nextmonth.Size = new System.Drawing.Size(24, 64);
            this.nextmonth.TabIndex = 8;
            this.nextmonth.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Coral;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MinimumSize = new System.Drawing.Size(1280, 720);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "CalendEr";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.schedulerDataStorage1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.TimeTablePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.schedulerControl1)).EndInit();
            this.SettingPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        public Form1()
        {
            Year.SyncYear();
            Months.SyncMonth();
            InitializeComponent();
            dayView.AutoScroll = true;
            if (dayView.VerticalScroll.Visible == true)
                dayView.BackColor = Color.Black;
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

            addbutton.FlatStyle = FlatStyle.Flat;
            addbutton.FlatAppearance.BorderSize = 0;
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
                    DateButton[i, j].FlatStyle = FlatStyle.Flat;
                    DateButton[i, j].FlatAppearance.BorderSize = 0;
                    DateButton[i, j].Font = new Font("Segoe UI SemiLight", 19);
                    DateButton[i, j].ForeColor = Color.Black;
                    DateButton[i, j].Width = label2.Width+4;
                    DateButton[i, j].Height = label2.Width - 20;
                    DateButton[i, j].Location = new Point(label2.Location.X -7 + (label2.Width+4 + Const.DateButtonOffSet) * j,
                                                          label2.Location.Y + (label2.Width -20  + Const.DateButtonOffSet) * (i + 1));
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
                    DateButton[i, j].ForeColor = Color.DimGray;

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
                            DateButton[i, j].BackColor = Color.Transparent;
                            DateButton[i,j].Font= new Font("Segoe UI Black", 19);
                            DateButton[i, j].ForeColor = Color.Black;

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
                label1.Font = new System.Drawing.Font("Segoe UI Semilight", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                label1.Text = "Today";
            }
            else
            {
                label1.Font = new System.Drawing.Font("Segoe UI Semilight", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            schedulerControl1.GoToToday();
            TimeTablePanel.Visible = true;
            panel6.Visible = false;
            SettingPanel.Visible = false;
            this.Refresh();
        }

        private void statisticsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TimeTablePanel.Visible = false;
            SettingPanel.Visible = false;
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
            //this.statisticsToolStripMenuItem.ForeColor = Settings1.Default.Color;
            //this.timetableToolStripMenuItem.ForeColor = Settings1.Default.Color;
            //this.settingsToolStripMenuItem.ForeColor = Settings1.Default.Color;
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

        private void PresentMonth_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
    } 
}
