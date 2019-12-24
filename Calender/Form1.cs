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

        // data for chart & summary
        int[] jobsDoneInEachMonth;
        int[,] jobsDoneInEachDay;
        int allDoneJobs;
        int jobsDoneToday;

    /*    private void InitDesign()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            DevExpress.XtraScheduler.TimeRuler timeRuler28 = new DevExpress.XtraScheduler.TimeRuler();
            DevExpress.XtraScheduler.TimeRuler timeRuler29 = new DevExpress.XtraScheduler.TimeRuler();
            DevExpress.XtraScheduler.TimeRuler timeRuler30 = new DevExpress.XtraScheduler.TimeRuler();
            this.schedulerDataStorage1 = new DevExpress.XtraScheduler.SchedulerDataStorage(this.components);
            this.vScrollBar1 = new DevExpress.XtraEditors.VScrollBar();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.notifyIcon2 = new System.Windows.Forms.NotifyIcon(this.components);
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.panel2 = new System.Windows.Forms.Panel();
            this.nextmonth = new System.Windows.Forms.Button();
            this.prevmonth = new System.Windows.Forms.Button();
            this.PresentMonth = new System.Windows.Forms.Label();
            this.YearLabel = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.calendarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timetableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statisticsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SettingPanel = new System.Windows.Forms.Panel();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblSave = new System.Windows.Forms.Label();
            this.lblDefault = new System.Windows.Forms.Label();
            this.TimeTablePanel = new System.Windows.Forms.Panel();
            this.schedulerControl1 = new DevExpress.XtraScheduler.SchedulerControl();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dayView = new System.Windows.Forms.FlowLayoutPanel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.addbutton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.pnlStatistics = new System.Windows.Forms.Panel();
            this.lbSummary = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.sumall = new System.Windows.Forms.Label();
            this.summonth = new System.Windows.Forms.Label();
            this.sumday = new System.Windows.Forms.Label();
            this.lbReports = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerDataStorage1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel6.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SettingPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.TimeTablePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerControl1)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlStatistics.SuspendLayout();
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
            this.panel2.Controls.Add(this.pnlStatistics);
            this.panel2.Controls.Add(this.nextmonth);
            this.panel2.Controls.Add(this.prevmonth);
            this.panel2.Controls.Add(this.PresentMonth);
            this.panel2.Controls.Add(this.YearLabel);
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Controls.Add(this.menuStrip1);
            this.panel2.ForeColor = System.Drawing.Color.DarkOrange;
            this.panel2.Location = new System.Drawing.Point(563, 3);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(707, 688);
            this.panel2.TabIndex = 0;
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
            this.nextmonth.Click += new System.EventHandler(this.NextMonth_Click);
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
            this.prevmonth.Click += new System.EventHandler(this.PrevMonth_Click);
            // 
            // PresentMonth
            // 
            this.PresentMonth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PresentMonth.BackColor = System.Drawing.Color.Transparent;
            this.PresentMonth.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PresentMonth.Font = new System.Drawing.Font("Segoe UI Light", 36F);
            this.PresentMonth.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(75)))), ((int)(((byte)(83)))));
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
            // YearLabel
            // 
            this.YearLabel.AutoSize = true;
            this.YearLabel.BackColor = System.Drawing.Color.Transparent;
            this.YearLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.YearLabel.Font = new System.Drawing.Font("Segoe UI Black", 96F, System.Drawing.FontStyle.Bold);
            this.YearLabel.Location = new System.Drawing.Point(292, 57);
            this.YearLabel.Name = "YearLabel";
            this.YearLabel.Size = new System.Drawing.Size(365, 170);
            this.YearLabel.TabIndex = 6;
            this.YearLabel.Text = "2019";
            this.YearLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(75)))), ((int)(((byte)(83)))));
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
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(75)))), ((int)(((byte)(83)))));
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
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(75)))), ((int)(((byte)(83)))));
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
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(75)))), ((int)(((byte)(83)))));
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
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(75)))), ((int)(((byte)(83)))));
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
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(75)))), ((int)(((byte)(83)))));
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
            this.calendarToolStripMenuItem,
            this.timetableToolStripMenuItem,
            this.statisticsToolStripMenuItem1,
            this.settingsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(707, 33);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // calendarToolStripMenuItem
            // 
            this.calendarToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.calendarToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.calendarToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.calendarToolStripMenuItem.Name = "calendarToolStripMenuItem";
            this.calendarToolStripMenuItem.Size = new System.Drawing.Size(100, 29);
            this.calendarToolStripMenuItem.Text = "Calendar";
            this.calendarToolStripMenuItem.Click += new System.EventHandler(this.calendarToolStripMenuItem_Click);
            // 
            // timetableToolStripMenuItem
            // 
            this.timetableToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.timetableToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.timetableToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.timetableToolStripMenuItem.Name = "timetableToolStripMenuItem";
            this.timetableToolStripMenuItem.Size = new System.Drawing.Size(107, 29);
            this.timetableToolStripMenuItem.Text = "Timetable";
            this.timetableToolStripMenuItem.Click += new System.EventHandler(this.timetableToolStripMenuItem_Click);
            // 
            // statisticsToolStripMenuItem1
            // 
            this.statisticsToolStripMenuItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.statisticsToolStripMenuItem1.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.statisticsToolStripMenuItem1.ForeColor = System.Drawing.Color.Black;
            this.statisticsToolStripMenuItem1.Name = "statisticsToolStripMenuItem1";
            this.statisticsToolStripMenuItem1.Size = new System.Drawing.Size(96, 29);
            this.statisticsToolStripMenuItem1.Text = "Statistics";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.settingsToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.settingsToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(91, 29);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // SettingPanel
            // 
            this.SettingPanel.BackColor = System.Drawing.Color.Transparent;
            this.SettingPanel.Controls.Add(this.pictureBox6);
            this.SettingPanel.Controls.Add(this.pictureBox5);
            this.SettingPanel.Controls.Add(this.pictureBox4);
            this.SettingPanel.Controls.Add(this.pictureBox3);
            this.SettingPanel.Controls.Add(this.pictureBox2);
            this.SettingPanel.Controls.Add(this.textBox2);
            this.SettingPanel.Controls.Add(this.pictureBox1);
            this.SettingPanel.Controls.Add(this.radioButton3);
            this.SettingPanel.Controls.Add(this.radioButton2);
            this.SettingPanel.Controls.Add(this.radioButton1);
            this.SettingPanel.Controls.Add(this.textBox1);
            this.SettingPanel.Controls.Add(this.label10);
            this.SettingPanel.Controls.Add(this.label9);
            this.SettingPanel.Controls.Add(this.label13);
            this.SettingPanel.Controls.Add(this.label12);
            this.SettingPanel.Controls.Add(this.label11);
            this.SettingPanel.Controls.Add(this.lblSave);
            this.SettingPanel.Controls.Add(this.lblDefault);
            this.SettingPanel.Location = new System.Drawing.Point(0, 43);
            this.SettingPanel.Name = "SettingPanel";
            this.SettingPanel.Size = new System.Drawing.Size(702, 634);
            this.SettingPanel.TabIndex = 4;
            this.SettingPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.SettingPanel_Paint);
            // 
            // pictureBox6
            // 
            this.pictureBox6.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox6.BackgroundImage")));
            this.pictureBox6.Location = new System.Drawing.Point(415, 139);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(30, 30);
            this.pictureBox6.TabIndex = 17;
            this.pictureBox6.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox5.BackgroundImage")));
            this.pictureBox5.Location = new System.Drawing.Point(455, 139);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(30, 30);
            this.pictureBox5.TabIndex = 16;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox4.BackgroundImage")));
            this.pictureBox4.Location = new System.Drawing.Point(535, 139);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(30, 30);
            this.pictureBox4.TabIndex = 15;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox3.BackgroundImage")));
            this.pictureBox3.Location = new System.Drawing.Point(495, 139);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(30, 30);
            this.pictureBox3.TabIndex = 14;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click_1);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.Location = new System.Drawing.Point(530, 190);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(35, 35);
            this.pictureBox2.TabIndex = 13;
            this.pictureBox2.TabStop = false;
            // 
            // textBox2
            // 
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.textBox2.ForeColor = System.Drawing.Color.Black;
            this.textBox2.Location = new System.Drawing.Point(456, 195);
            this.textBox2.Name = "textBox2";
            this.textBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox2.Size = new System.Drawing.Size(68, 25);
            this.textBox2.TabIndex = 12;
            this.textBox2.Text = "On";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.Location = new System.Drawing.Point(530, 190);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(35, 35);
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.radioButton3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(64)))), ((int)(((byte)(77)))));
            this.radioButton3.Location = new System.Drawing.Point(352, 373);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.radioButton3.Size = new System.Drawing.Size(213, 29);
            this.radioButton3.TabIndex = 10;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "Urgent priority events";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.radioButton2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(196)))), ((int)(((byte)(106)))));
            this.radioButton2.Location = new System.Drawing.Point(370, 338);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.radioButton2.Size = new System.Drawing.Size(195, 29);
            this.radioButton2.TabIndex = 9;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "High priority events";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.radioButton1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(75)))), ((int)(((byte)(83)))));
            this.radioButton1.Location = new System.Drawing.Point(340, 303);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.radioButton1.Size = new System.Drawing.Size(225, 29);
            this.radioButton1.TabIndex = 8;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Medium priority events";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.textBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(200)))), ((int)(((byte)(207)))));
            this.textBox1.Location = new System.Drawing.Point(220, 250);
            this.textBox1.Name = "textBox1";
            this.textBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox1.Size = new System.Drawing.Size(345, 25);
            this.textBox1.TabIndex = 7;
            this.textBox1.Text = "Type email here";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 32F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(76, 30);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(190, 59);
            this.label10.TabIndex = 6;
            this.label10.Text = "Settings";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(81, 305);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(167, 25);
            this.label9.TabIndex = 5;
            this.label9.Text = "Email notification";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(81, 250);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(59, 25);
            this.label13.TabIndex = 4;
            this.label13.Text = "Email";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(81, 195);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(118, 25);
            this.label12.TabIndex = 3;
            this.label12.Text = "Notification";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(81, 140);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(71, 25);
            this.label11.TabIndex = 2;
            this.label11.Text = "Theme";
            // 
            // lblSave
            // 
            this.lblSave.AutoSize = true;
            this.lblSave.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(169)))), ((int)(((byte)(119)))));
            this.lblSave.Location = new System.Drawing.Point(520, 444);
            this.lblSave.Name = "lblSave";
            this.lblSave.Size = new System.Drawing.Size(53, 25);
            this.lblSave.TabIndex = 1;
            this.lblSave.Text = "Save";
            // 
            // lblDefault
            // 
            this.lblDefault.AutoSize = true;
            this.lblDefault.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.lblDefault.ForeColor = System.Drawing.Color.Black;
            this.lblDefault.Location = new System.Drawing.Point(371, 444);
            this.lblDefault.Name = "lblDefault";
            this.lblDefault.Size = new System.Drawing.Size(143, 25);
            this.lblDefault.TabIndex = 0;
            this.lblDefault.Text = "Default settings";
            // 
            // TimeTablePanel
            // 
            this.TimeTablePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TimeTablePanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.TimeTablePanel.Controls.Add(this.schedulerControl1);
            this.TimeTablePanel.Location = new System.Drawing.Point(4, 43);
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
            this.schedulerControl1.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.schedulerControl1.Location = new System.Drawing.Point(0, 0);
            this.schedulerControl1.Margin = new System.Windows.Forms.Padding(4);
            this.schedulerControl1.Name = "schedulerControl1";
            this.schedulerControl1.OptionsCustomization.AllowAppointmentDrag = DevExpress.XtraScheduler.UsedAppointmentType.None;
            this.schedulerControl1.Size = new System.Drawing.Size(707, 641);
            this.schedulerControl1.Start = new System.DateTime(2019, 10, 27, 0, 0, 0, 0);
            this.schedulerControl1.TabIndex = 0;
            this.schedulerControl1.Text = "schedulerControl1";
            this.schedulerControl1.Views.DayView.TimeRulers.Add(timeRuler28);
            this.schedulerControl1.Views.FullWeekView.Enabled = true;
            this.schedulerControl1.Views.FullWeekView.TimeRulers.Add(timeRuler29);
            this.schedulerControl1.Views.WorkWeekView.TimeRulers.Add(timeRuler30);
            this.schedulerControl1.AllowAppointmentDrag += new DevExpress.XtraScheduler.AppointmentOperationEventHandler(this.schedulerControl1_AllowAppointmentDrag);
            this.schedulerControl1.AppointmentDrag += new DevExpress.XtraScheduler.AppointmentDragEventHandler(this.schedulerControl1_AppointmentDrag);
            this.schedulerControl1.EditAppointmentFormShowing += new DevExpress.XtraScheduler.AppointmentFormEventHandler(this.schedulerControl1_EditAppointmentFormShowing);
            this.schedulerControl1.EditAppointmentDependencyFormShowing += new DevExpress.XtraScheduler.AppointmentDependencyFormEventHandler(this.schedulerControl1_EditAppointmentDependencyFormShowing);
            this.schedulerControl1.CustomDrawAppointmentBackground += new DevExpress.XtraScheduler.CustomDrawObjectEventHandler(this.schedulerControl1_CustomDrawAppointmentBackground);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(169)))), ((int)(((byte)(119)))));
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
            this.dayView.Location = new System.Drawing.Point(29, 105);
            this.dayView.Margin = new System.Windows.Forms.Padding(4);
            this.dayView.Name = "dayView";
            this.dayView.Size = new System.Drawing.Size(532, 557);
            this.dayView.TabIndex = 3;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(169)))), ((int)(((byte)(119)))));
            this.panel8.Controls.Add(this.addbutton);
            this.panel8.Controls.Add(this.label1);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Margin = new System.Windows.Forms.Padding(4);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(567, 97);
            this.panel8.TabIndex = 2;
            // 
            // addbutton
            // 
            this.addbutton.AutoSize = true;
            this.addbutton.BackColor = System.Drawing.Color.Transparent;
            this.addbutton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.addbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addbutton.ForeColor = System.Drawing.Color.Transparent;
            this.addbutton.Image = ((System.Drawing.Image)(resources.GetObject("addbutton.Image")));
            this.addbutton.Location = new System.Drawing.Point(490, 34);
            this.addbutton.Margin = new System.Windows.Forms.Padding(4);
            this.addbutton.Name = "addbutton";
            this.addbutton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.addbutton.Size = new System.Drawing.Size(48, 48);
            this.addbutton.TabIndex = 1;
            this.addbutton.UseVisualStyleBackColor = false;
            this.addbutton.Click += new System.EventHandler(this.Addbutton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(19, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 65);
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
            // pnlStatistics
            // 
            this.pnlStatistics.Controls.Add(this.label20);
            this.pnlStatistics.Controls.Add(this.label18);
            this.pnlStatistics.Controls.Add(this.lbReports);
            this.pnlStatistics.Controls.Add(this.sumday);
            this.pnlStatistics.Controls.Add(this.summonth);
            this.pnlStatistics.Controls.Add(this.sumall);
            this.pnlStatistics.Controls.Add(this.label17);
            this.pnlStatistics.Controls.Add(this.label16);
            this.pnlStatistics.Controls.Add(this.label15);
            this.pnlStatistics.Controls.Add(this.lbSummary);
            this.pnlStatistics.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.pnlStatistics.ForeColor = System.Drawing.Color.Black;
            this.pnlStatistics.Location = new System.Drawing.Point(9, 36);
            this.pnlStatistics.Name = "pnlStatistics";
            this.pnlStatistics.Size = new System.Drawing.Size(690, 633);
            this.pnlStatistics.TabIndex = 9;
            this.pnlStatistics.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlStatistics_Paint);
            // 
            // label14
            // 
            this.lbSummary.AutoSize = true;
            this.lbSummary.Font = new System.Drawing.Font("Segoe UI", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSummary.Location = new System.Drawing.Point(30, 20);
            this.lbSummary.Name = "label14";
            this.lbSummary.Size = new System.Drawing.Size(189, 50);
            this.lbSummary.TabIndex = 0;
            this.lbSummary.Text = "Summary";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI Light", 14F);
            this.label15.Location = new System.Drawing.Point(213, 85);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(232, 25);
            this.label15.TabIndex = 1;
            this.label15.Text = "Tasks completed this month";
            this.label15.Click += new System.EventHandler(this.label15_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI Light", 14F);
            this.label16.Location = new System.Drawing.Point(34, 85);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(166, 25);
            this.label16.TabIndex = 2;
            this.label16.Text = "All completed tasks";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Segoe UI Light", 14F);
            this.label17.Location = new System.Drawing.Point(454, 85);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(193, 25);
            this.label17.TabIndex = 3;
            this.label17.Text = "Tasks completed today";
            // 
            // sumall
            // 
            this.sumall.AutoSize = true;
            this.sumall.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.sumall.Location = new System.Drawing.Point(34, 110);
            this.sumall.Name = "sumall";
            this.sumall.Size = new System.Drawing.Size(34, 25);
            this.sumall.TabIndex = 4;
            this.sumall.Text = "20";
            // 
            // summonth
            // 
            this.summonth.AutoSize = true;
            this.summonth.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.summonth.Location = new System.Drawing.Point(215, 110);
            this.summonth.Name = "summonth";
            this.summonth.Size = new System.Drawing.Size(34, 25);
            this.summonth.TabIndex = 5;
            this.summonth.Text = "20";
            // 
            // sumday
            // 
            this.sumday.AutoSize = true;
            this.sumday.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.sumday.Location = new System.Drawing.Point(454, 110);
            this.sumday.Name = "sumday";
            this.sumday.Size = new System.Drawing.Size(34, 25);
            this.sumday.TabIndex = 6;
            this.sumday.Text = "20";
            // 
            // label19
            // 
            this.lbReports.AutoSize = true;
            this.lbReports.Font = new System.Drawing.Font("Segoe UI", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbReports.Location = new System.Drawing.Point(30, 163);
            this.lbReports.Name = "label19";
            this.lbReports.Size = new System.Drawing.Size(157, 50);
            this.lbReports.TabIndex = 8;
            this.lbReports.Text = "Reports";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.Transparent;
            this.label18.Font = new System.Drawing.Font("Segoe UI Light", 14F);
            this.label18.Location = new System.Drawing.Point(494, 183);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(78, 25);
            this.label18.TabIndex = 9;
            this.label18.Text = "Monthly";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.Transparent;
            this.label20.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(169)))), ((int)(((byte)(119)))));
            this.label20.Location = new System.Drawing.Point(573, 183);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(65, 25);
            this.label20.TabIndex = 10;
            this.label20.Text = "Yearly";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(200)))), ((int)(((byte)(207)))));
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MinimumSize = new System.Drawing.Size(1280, 720);
            this.Name = "Form1";
            this.Text = "CalendEr";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.schedulerDataStorage1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.SettingPanel.ResumeLayout(false);
            this.SettingPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.TimeTablePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.schedulerControl1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.pnlStatistics.ResumeLayout(false);
            this.pnlStatistics.PerformLayout();
            this.ResumeLayout(false);

        } */
        //end init design

        public Form1()
        {
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

            // load setting
            // 1: load color
            themeColor = new Color();
            if(Settings1.Default.Theme == 0)
            {
                themeColor = Color.DarkOrange;
            }
            else if (Settings1.Default.Theme == 1)
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
            this.PresentMonth.ForeColor = themeColor;
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
            }
            else
            {
                alertOff.Visible = true;
                alertOn.Visible = false;
                notificationStatusLB.Text = "Off";
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
                        int countEventForToday = allPlan.ListGroupItemsForToday(new DateTime(Year.GetCurrentYear(), month, count)).Count;
                        if (countEventForToday < 3)
                        {
                            PriorityColorForDay[count] = Color.Black;
                        }
                        else if (countEventForToday < 6)
                        {
                            PriorityColorForDay[count] = Color.FromArgb(255, 195, 0);
                        }
                        else if (countEventForToday < 8)
                        {
                            PriorityColorForDay[count] = Color.FromArgb(255, 87, 51);
                        }
                        else
                        {
                            PriorityColorForDay[count] = Color.FromArgb(199, 0, 57);
                        }
                        DateButton[i, j].Text = count.ToString();
                        DateButton[i, j].FlatAppearance.MouseOverBackColor = Color.FromArgb(50, 0, 0, 0);
                        DateButton[i, j].Enabled = true;
                        DateButton[i, j].ForeColor = PriorityColorForDay[count];
                        if (count == DateTime.Now.Day && month == DateTime.Now.Month && Year.GetCurrentYear() == DateTime.Now.Year)
                        {
                            DateButton[i, j].BackColor = Color.Transparent;
                            DateButton[i, j].Font = new Font("Segoe UI Black", 19);
                            DateButton[i, j].ForeColor = Color.FromArgb(68, 75, 83);
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
            new_Event = new New_Event(allPlan, focusedDate);
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

        public void ReloadItemToDayView()
        {
            LoadItemToDayView(focusedDate.Year, focusedDate.Month, focusedDate.Day);
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
                    dayView.Controls.Add(new Item(groups[i], items[j], today, this));
                }
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

                New_Event new_Event = new New_Event(allPlan, schedulerControl.DayView.SelectedInterval.Start);
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

        private void schedulerControl1_CustomDrawAppointmentBackground(object sender, CustomDrawObjectEventArgs e)
        {
            AppointmentViewInfo viewInfo = e.ObjectInfo as AppointmentViewInfo;
            e.DrawDefault();
            int widthCell = viewInfo.Bounds.Width / 4;
            PlanItem pi = (PlanItem)(viewInfo.Appointment.CustomFields["item"]);
            if (pi.priority == PriorityEnum.normal)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(100, 99, 110, 114)), new Rectangle(viewInfo.Bounds.X, viewInfo.Bounds.Y, viewInfo.Bounds.Width, viewInfo.Bounds.Height));
            }
            if (pi.priority == PriorityEnum.medium)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(255, 255, 195, 0)), new Rectangle(viewInfo.Bounds.X, viewInfo.Bounds.Y, viewInfo.Bounds.Width, viewInfo.Bounds.Height));
            }
            if (pi.priority == PriorityEnum.high)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(255, 87, 51)), new Rectangle(viewInfo.Bounds.X, viewInfo.Bounds.Y, viewInfo.Bounds.Width, viewInfo.Bounds.Height));
            }
            if (pi.priority == PriorityEnum.urgent)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(199, 0, 57)), new Rectangle(viewInfo.Bounds.X, viewInfo.Bounds.Y, viewInfo.Bounds.Width, viewInfo.Bounds.Height));
            }
            e.Handled = true;
        }

        private void schedulerControl1_AppointmentDrag(object sender, AppointmentDragEventArgs e)
        {
            e.Allow = false;
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

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {
            Color c = Color.FromArgb(78, 169, 119);
            this.panel3.BackColor = c;
            this.panel8.BackColor = c;
            this.addbutton.BackColor = c;
            this.panel2.ForeColor = c;
            this.PresentMonth.ForeColor = c;
            lblSave.ForeColor = c;
            label2.ForeColor = c;
            Settings1.Default.Theme = 3;

            sideBySideBarSeriesView1.Color = c;
            if (cbbMonthly.Visible == true) lbMonthly.ForeColor = c;
            else lbYearly.ForeColor = c;
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
                            }
                            else
                            {
                                if( startDay != endDay)
                                {
                                    jobsDoneInEachDay[startMonth, startDay]++;
                                    jobsDoneInEachDay[startMonth, endDay]++;
                                    jobsDoneInEachDay[startMonth, 0] += 2;
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
            this.PresentMonth.ForeColor = c;
            label2.ForeColor = c;
            lblSave.ForeColor = c;
            Settings1.Default.Theme = 1;

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
            this.PresentMonth.ForeColor = c;
            label2.ForeColor = c;
            lblSave.ForeColor = c;
            Settings1.Default.Theme = 2;

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
            this.PresentMonth.ForeColor = c;
            label2.ForeColor = c;
            lblSave.ForeColor = c;
            Settings1.Default.Theme = 4;

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
            Color c = Color.DarkOrange;
            this.panel3.BackColor = c;
            this.panel8.BackColor = c;
            this.addbutton.BackColor = c;
            this.panel2.ForeColor = c;
            this.PresentMonth.ForeColor = c;
            label2.ForeColor = c;
            sideBySideBarSeriesView1.Color = c;
            Settings1.Default.Theme = 0;

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

        private void schedulerControl1_PopupMenuShowing(object sender, EventArgs e)
        {
            
        }
    }
}
