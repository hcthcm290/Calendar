using DevExpress.XtraCharts;

namespace Calender
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            DevExpress.XtraCharts.XYDiagram xyDiagram1 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.SideBySideBarSeriesView sideBySideBarSeriesView1 = new DevExpress.XtraCharts.SideBySideBarSeriesView();
            DevExpress.XtraScheduler.TimeRuler timeRuler1 = new DevExpress.XtraScheduler.TimeRuler();
            DevExpress.XtraScheduler.TimeRuler timeRuler2 = new DevExpress.XtraScheduler.TimeRuler();
            DevExpress.XtraScheduler.TimeRuler timeRuler3 = new DevExpress.XtraScheduler.TimeRuler();
            this.schedulerDataStorage1 = new DevExpress.XtraScheduler.SchedulerDataStorage(this.components);
            this.vScrollBar1 = new DevExpress.XtraEditors.VScrollBar();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.notifyIcon2 = new System.Windows.Forms.NotifyIcon(this.components);
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pnlStatistics = new System.Windows.Forms.Panel();
            this.cbbMonthly = new System.Windows.Forms.ComboBox();
            this.lbMonthly = new System.Windows.Forms.Label();
            this.lbYearly = new System.Windows.Forms.Label();
            this.cbbYearly = new System.Windows.Forms.ComboBox();
            this.chartControl1 = new DevExpress.XtraCharts.ChartControl();
            this.lbReports = new System.Windows.Forms.Label();
            this.sumday = new System.Windows.Forms.Label();
            this.summonth = new System.Windows.Forms.Label();
            this.sumall = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lbSummary = new System.Windows.Forms.Label();
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
            this.TimeTablePanel = new System.Windows.Forms.Panel();
            this.schedulerControl1 = new DevExpress.XtraScheduler.SchedulerControl();
            this.SettingPanel = new System.Windows.Forms.Panel();
            this.notificationStatusLB = new System.Windows.Forms.Label();
            this.theme1PB = new System.Windows.Forms.PictureBox();
            this.theme2PB = new System.Windows.Forms.PictureBox();
            this.theme4PB = new System.Windows.Forms.PictureBox();
            this.theme3PB = new System.Windows.Forms.PictureBox();
            this.alertOff = new System.Windows.Forms.PictureBox();
            this.alertOn = new System.Windows.Forms.PictureBox();
            this.highChB = new System.Windows.Forms.CheckBox();
            this.mediumChB = new System.Windows.Forms.CheckBox();
            this.normalChB = new System.Windows.Forms.CheckBox();
            this.emailTB = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.themeLB = new System.Windows.Forms.Label();
            this.lblSave = new System.Windows.Forms.Label();
            this.lblDefault = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dayView = new System.Windows.Forms.FlowLayoutPanel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.addbutton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerDataStorage1)).BeginInit();
            this.panel2.SuspendLayout();
            this.pnlStatistics.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesView1)).BeginInit();
            this.panel6.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.TimeTablePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerControl1)).BeginInit();
            this.SettingPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.theme1PB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.theme2PB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.theme4PB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.theme3PB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.alertOff)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.alertOn)).BeginInit();
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
            this.panel2.Controls.Add(this.pnlStatistics);
            this.panel2.Controls.Add(this.nextmonth);
            this.panel2.Controls.Add(this.prevmonth);
            this.panel2.Controls.Add(this.PresentMonth);
            this.panel2.Controls.Add(this.YearLabel);
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Controls.Add(this.menuStrip1);
            this.panel2.Controls.Add(this.TimeTablePanel);
            this.panel2.Controls.Add(this.SettingPanel);
            this.panel2.ForeColor = System.Drawing.Color.DarkOrange;
            this.panel2.Location = new System.Drawing.Point(563, 3);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(707, 688);
            this.panel2.TabIndex = 0;
            // 
            // pnlStatistics
            // 
            this.pnlStatistics.Controls.Add(this.cbbMonthly);
            this.pnlStatistics.Controls.Add(this.lbMonthly);
            this.pnlStatistics.Controls.Add(this.lbYearly);
            this.pnlStatistics.Controls.Add(this.cbbYearly);
            this.pnlStatistics.Controls.Add(this.chartControl1);
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
            this.pnlStatistics.Size = new System.Drawing.Size(690, 638);
            this.pnlStatistics.TabIndex = 9;
            this.pnlStatistics.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlStatistics_Paint);
            // 
            // cbbMonthly
            // 
            this.cbbMonthly.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbbMonthly.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.cbbMonthly.FormattingEnabled = true;
            this.cbbMonthly.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.cbbMonthly.Location = new System.Drawing.Point(535, 180);
            this.cbbMonthly.Name = "cbbMonthly";
            this.cbbMonthly.Size = new System.Drawing.Size(43, 29);
            this.cbbMonthly.TabIndex = 15;
            this.cbbMonthly.Text = "12";
            this.cbbMonthly.Visible = false;
            this.cbbMonthly.TextChanged += new System.EventHandler(this.cbbMonthly_TextChanged);
            // 
            // lbMonthly
            // 
            this.lbMonthly.AutoSize = true;
            this.lbMonthly.BackColor = System.Drawing.Color.Transparent;
            this.lbMonthly.Font = new System.Drawing.Font("Segoe UI Light", 10F);
            this.lbMonthly.Location = new System.Drawing.Point(193, 189);
            this.lbMonthly.Name = "lbMonthly";
            this.lbMonthly.Size = new System.Drawing.Size(56, 19);
            this.lbMonthly.TabIndex = 14;
            this.lbMonthly.Text = "Monthly";
            this.lbMonthly.Click += new System.EventHandler(this.lbMonthly_Click);
            // 
            // lbYearly
            // 
            this.lbYearly.AutoSize = true;
            this.lbYearly.BackColor = System.Drawing.Color.Transparent;
            this.lbYearly.Font = new System.Drawing.Font("Segoe UI Black", 10F, System.Drawing.FontStyle.Bold);
            this.lbYearly.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(169)))), ((int)(((byte)(119)))));
            this.lbYearly.Location = new System.Drawing.Point(193, 172);
            this.lbYearly.Name = "lbYearly";
            this.lbYearly.Size = new System.Drawing.Size(52, 19);
            this.lbYearly.TabIndex = 13;
            this.lbYearly.Text = "Yearly";
            this.lbYearly.Click += new System.EventHandler(this.lbYearly_Click);
            // 
            // cbbYearly
            // 
            this.cbbYearly.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbbYearly.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.cbbYearly.FormattingEnabled = true;
            this.cbbYearly.Items.AddRange(new object[] {
            "2013",
            "2014",
            "2015",
            "2016"});
            this.cbbYearly.Location = new System.Drawing.Point(584, 180);
            this.cbbYearly.Name = "cbbYearly";
            this.cbbYearly.Size = new System.Drawing.Size(63, 29);
            this.cbbYearly.TabIndex = 12;
            this.cbbYearly.Text = "2019";
            this.cbbYearly.TextChanged += new System.EventHandler(this.cbbYearly_TextChanged);
            // 
            // chartControl1
            // 
            xyDiagram1.AxisX.NumericScaleOptions.AutoGrid = false;
            xyDiagram1.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram1.AxisY.VisibleInPanesSerializable = "-1";
            this.chartControl1.Diagram = xyDiagram1;
            this.chartControl1.Legend.AlignmentHorizontal = DevExpress.XtraCharts.LegendAlignmentHorizontal.Left;
            this.chartControl1.Legend.AlignmentVertical = DevExpress.XtraCharts.LegendAlignmentVertical.BottomOutside;
            this.chartControl1.Legend.Name = "Default Legend";
            this.chartControl1.Location = new System.Drawing.Point(39, 231);
            this.chartControl1.Name = "chartControl1";
            series1.ArgumentDataMember = "Argument";
            series1.ArgumentScaleType = DevExpress.XtraCharts.ScaleType.Numerical;
            series1.Name = "Số lượng công việc của tháng đã hoàn thành";
            series1.ValueDataMembersSerializable = "Value";
            sideBySideBarSeriesView1.BarWidth = 1D;
            sideBySideBarSeriesView1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(208)))), ((int)(((byte)(80)))));
            series1.View = sideBySideBarSeriesView1;
            this.chartControl1.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series1};
            this.chartControl1.SeriesTemplate.SeriesColorizer = null;
            this.chartControl1.Size = new System.Drawing.Size(609, 392);
            this.chartControl1.TabIndex = 11;
            // 
            // lbReports
            // 
            this.lbReports.AutoSize = true;
            this.lbReports.Font = new System.Drawing.Font("Segoe UI", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbReports.Location = new System.Drawing.Point(30, 163);
            this.lbReports.Name = "lbReports";
            this.lbReports.Size = new System.Drawing.Size(157, 50);
            this.lbReports.TabIndex = 8;
            this.lbReports.Text = "Reports";
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
            // lbSummary
            // 
            this.lbSummary.AutoSize = true;
            this.lbSummary.Font = new System.Drawing.Font("Segoe UI", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSummary.Location = new System.Drawing.Point(30, 20);
            this.lbSummary.Name = "lbSummary";
            this.lbSummary.Size = new System.Drawing.Size(189, 50);
            this.lbSummary.TabIndex = 0;
            this.lbSummary.Text = "Summary";
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
            this.panel6.Size = new System.Drawing.Size(638, 401);
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
            this.statisticsToolStripMenuItem1.Click += new System.EventHandler(this.StatisticsToolStripMenuItem1_Click);
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
            this.schedulerControl1.Appearance.Appointment.BackColor2 = System.Drawing.SystemColors.Control;
            this.schedulerControl1.Appearance.Appointment.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.schedulerControl1.Appearance.Appointment.ForeColor = System.Drawing.SystemColors.Control;
            this.schedulerControl1.Appearance.Appointment.Options.UseFont = true;
            this.schedulerControl1.Appearance.Appointment.Options.UseForeColor = true;
            this.schedulerControl1.DataStorage = this.schedulerDataStorage1;
            this.schedulerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.schedulerControl1.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.schedulerControl1.Location = new System.Drawing.Point(0, 0);
            this.schedulerControl1.Margin = new System.Windows.Forms.Padding(4);
            this.schedulerControl1.Name = "schedulerControl1";
            this.schedulerControl1.OptionsBehavior.SelectOnRightClick = true;
            this.schedulerControl1.OptionsCustomization.AllowAppointmentDrag = DevExpress.XtraScheduler.UsedAppointmentType.None;
            this.schedulerControl1.Size = new System.Drawing.Size(707, 641);
            this.schedulerControl1.Start = new System.DateTime(2019, 10, 6, 0, 0, 0, 0);
            this.schedulerControl1.TabIndex = 0;
            this.schedulerControl1.Text = "schedulerControl1";
            this.schedulerControl1.Views.AgendaView.Enabled = false;
            this.schedulerControl1.Views.DayView.TimeRulers.Add(timeRuler1);
            this.schedulerControl1.Views.FullWeekView.Enabled = true;
            this.schedulerControl1.Views.FullWeekView.TimeRulers.Add(timeRuler2);
            this.schedulerControl1.Views.GanttView.Enabled = false;
            this.schedulerControl1.Views.TimelineView.Enabled = false;
            this.schedulerControl1.Views.WorkWeekView.TimeRulers.Add(timeRuler3);
            this.schedulerControl1.AllowAppointmentDrag += new DevExpress.XtraScheduler.AppointmentOperationEventHandler(this.schedulerControl1_AllowAppointmentDrag);
            this.schedulerControl1.PopupMenuShowing += new DevExpress.XtraScheduler.PopupMenuShowingEventHandler(this.schedulerControl1_PopupMenuShowing);
            this.schedulerControl1.CustomizeAppointmentFlyout += new DevExpress.XtraScheduler.CustomizeAppointmentFlyoutEventHandler(this.schedulerControl1_CustomizeAppointmentFlyout);
            this.schedulerControl1.EditAppointmentFormShowing += new DevExpress.XtraScheduler.AppointmentFormEventHandler(this.schedulerControl1_EditAppointmentFormShowing);
            this.schedulerControl1.EditAppointmentDependencyFormShowing += new DevExpress.XtraScheduler.AppointmentDependencyFormEventHandler(this.schedulerControl1_EditAppointmentDependencyFormShowing);
            this.schedulerControl1.CustomDrawAppointment += new DevExpress.XtraScheduler.CustomDrawObjectEventHandler(this.schedulerControl1_CustomDrawAppointment);
            this.schedulerControl1.CustomDrawAppointmentFlyoutSubject += new DevExpress.XtraScheduler.CustomDrawAppointmentFlyoutSubjectEventHandler(this.schedulerControl1_CustomDrawAppointmentFlyoutSubject);
            this.schedulerControl1.CustomDrawAppointmentBackground += new DevExpress.XtraScheduler.CustomDrawObjectEventHandler(this.schedulerControl1_CustomDrawAppointmentBackground);
            this.schedulerControl1.Click += new System.EventHandler(this.schedulerControl1_Click);
            this.schedulerControl1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.schedulerControl1_MouseMove);
            // 
            // SettingPanel
            // 
            this.SettingPanel.BackColor = System.Drawing.Color.Transparent;
            this.SettingPanel.Controls.Add(this.notificationStatusLB);
            this.SettingPanel.Controls.Add(this.theme1PB);
            this.SettingPanel.Controls.Add(this.theme2PB);
            this.SettingPanel.Controls.Add(this.theme4PB);
            this.SettingPanel.Controls.Add(this.theme3PB);
            this.SettingPanel.Controls.Add(this.alertOff);
            this.SettingPanel.Controls.Add(this.alertOn);
            this.SettingPanel.Controls.Add(this.highChB);
            this.SettingPanel.Controls.Add(this.mediumChB);
            this.SettingPanel.Controls.Add(this.normalChB);
            this.SettingPanel.Controls.Add(this.emailTB);
            this.SettingPanel.Controls.Add(this.label10);
            this.SettingPanel.Controls.Add(this.label9);
            this.SettingPanel.Controls.Add(this.label13);
            this.SettingPanel.Controls.Add(this.label12);
            this.SettingPanel.Controls.Add(this.themeLB);
            this.SettingPanel.Controls.Add(this.lblSave);
            this.SettingPanel.Controls.Add(this.lblDefault);
            this.SettingPanel.Location = new System.Drawing.Point(0, 43);
            this.SettingPanel.Name = "SettingPanel";
            this.SettingPanel.Size = new System.Drawing.Size(702, 634);
            this.SettingPanel.TabIndex = 4;
            this.SettingPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.SettingPanel_Paint);
            // 
            // notificationStatusLB
            // 
            this.notificationStatusLB.AutoSize = true;
            this.notificationStatusLB.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notificationStatusLB.ForeColor = System.Drawing.SystemColors.ControlText;
            this.notificationStatusLB.Location = new System.Drawing.Point(490, 195);
            this.notificationStatusLB.Name = "notificationStatusLB";
            this.notificationStatusLB.Size = new System.Drawing.Size(37, 25);
            this.notificationStatusLB.TabIndex = 18;
            this.notificationStatusLB.Text = "On";
            // 
            // theme1PB
            // 
            this.theme1PB.Location = new System.Drawing.Point(437, 134);
            this.theme1PB.Name = "theme1PB";
            this.theme1PB.Size = new System.Drawing.Size(30, 30);
            this.theme1PB.TabIndex = 17;
            this.theme1PB.TabStop = false;
            this.theme1PB.Click += new System.EventHandler(this.theme1PB_Click);
            this.theme1PB.Paint += new System.Windows.Forms.PaintEventHandler(this.theme1PB_Paint);
            // 
            // theme2PB
            // 
            this.theme2PB.Location = new System.Drawing.Point(477, 134);
            this.theme2PB.Name = "theme2PB";
            this.theme2PB.Size = new System.Drawing.Size(30, 30);
            this.theme2PB.TabIndex = 16;
            this.theme2PB.TabStop = false;
            this.theme2PB.Click += new System.EventHandler(this.theme2PB_Click);
            this.theme2PB.Paint += new System.Windows.Forms.PaintEventHandler(this.theme2PB_Paint);
            // 
            // theme4PB
            // 
            this.theme4PB.Location = new System.Drawing.Point(557, 134);
            this.theme4PB.Name = "theme4PB";
            this.theme4PB.Size = new System.Drawing.Size(30, 30);
            this.theme4PB.TabIndex = 15;
            this.theme4PB.TabStop = false;
            this.theme4PB.Click += new System.EventHandler(this.theme4PB_Click);
            this.theme4PB.Paint += new System.Windows.Forms.PaintEventHandler(this.theme4PB_Paint);
            // 
            // theme3PB
            // 
            this.theme3PB.Location = new System.Drawing.Point(517, 134);
            this.theme3PB.Name = "theme3PB";
            this.theme3PB.Size = new System.Drawing.Size(30, 30);
            this.theme3PB.TabIndex = 14;
            this.theme3PB.TabStop = false;
            this.theme3PB.Click += new System.EventHandler(this.theme3PB_Click);
            this.theme3PB.Paint += new System.Windows.Forms.PaintEventHandler(this.theme3PB_Paint);
            // 
            // alertOff
            // 
            this.alertOff.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("alertOff.BackgroundImage")));
            this.alertOff.Location = new System.Drawing.Point(552, 190);
            this.alertOff.Name = "alertOff";
            this.alertOff.Size = new System.Drawing.Size(35, 35);
            this.alertOff.TabIndex = 13;
            this.alertOff.TabStop = false;
            this.alertOff.Click += new System.EventHandler(this.alertOff_Click);
            // 
            // alertOn
            // 
            this.alertOn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("alertOn.BackgroundImage")));
            this.alertOn.Location = new System.Drawing.Point(552, 190);
            this.alertOn.Name = "alertOn";
            this.alertOn.Size = new System.Drawing.Size(35, 35);
            this.alertOn.TabIndex = 11;
            this.alertOn.TabStop = false;
            this.alertOn.Click += new System.EventHandler(this.alertOn_Click);
            // 
            // highChB
            // 
            this.highChB.AutoSize = true;
            this.highChB.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.highChB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(64)))), ((int)(((byte)(77)))));
            this.highChB.Location = new System.Drawing.Point(392, 373);
            this.highChB.Name = "highChB";
            this.highChB.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.highChB.Size = new System.Drawing.Size(196, 29);
            this.highChB.TabIndex = 10;
            this.highChB.Text = "High priority events";
            this.highChB.UseVisualStyleBackColor = true;
            this.highChB.CheckedChanged += new System.EventHandler(this.highChB_CheckedChanged);
            // 
            // mediumChB
            // 
            this.mediumChB.AutoSize = true;
            this.mediumChB.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.mediumChB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(196)))), ((int)(((byte)(106)))));
            this.mediumChB.Location = new System.Drawing.Point(362, 338);
            this.mediumChB.Name = "mediumChB";
            this.mediumChB.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.mediumChB.Size = new System.Drawing.Size(226, 29);
            this.mediumChB.TabIndex = 9;
            this.mediumChB.Text = "Medium priority events";
            this.mediumChB.UseVisualStyleBackColor = true;
            this.mediumChB.CheckedChanged += new System.EventHandler(this.mediumChB_CheckedChanged);
            // 
            // normalChB
            // 
            this.normalChB.AutoSize = true;
            this.normalChB.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.normalChB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(75)))), ((int)(((byte)(83)))));
            this.normalChB.Location = new System.Drawing.Point(369, 303);
            this.normalChB.Name = "normalChB";
            this.normalChB.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.normalChB.Size = new System.Drawing.Size(219, 29);
            this.normalChB.TabIndex = 8;
            this.normalChB.Text = "Normal priority events";
            this.normalChB.UseVisualStyleBackColor = true;
            this.normalChB.CheckedChanged += new System.EventHandler(this.normalChB_CheckedChanged);
            // 
            // emailTB
            // 
            this.emailTB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.emailTB.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.emailTB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(200)))), ((int)(((byte)(207)))));
            this.emailTB.Location = new System.Drawing.Point(242, 251);
            this.emailTB.Name = "emailTB";
            this.emailTB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.emailTB.Size = new System.Drawing.Size(345, 25);
            this.emailTB.TabIndex = 7;
            this.emailTB.Text = "Type email here";
            this.emailTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.emailTB.TextChanged += new System.EventHandler(this.emailTB_TextChanged);
            this.emailTB.Enter += new System.EventHandler(this.emailTB_Enter);
            this.emailTB.Leave += new System.EventHandler(this.emailTB_Leave);
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
            // themeLB
            // 
            this.themeLB.AutoSize = true;
            this.themeLB.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.themeLB.ForeColor = System.Drawing.Color.Black;
            this.themeLB.Location = new System.Drawing.Point(81, 140);
            this.themeLB.Name = "themeLB";
            this.themeLB.Size = new System.Drawing.Size(71, 25);
            this.themeLB.TabIndex = 2;
            this.themeLB.Text = "Theme";
            // 
            // lblSave
            // 
            this.lblSave.AutoSize = true;
            this.lblSave.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(169)))), ((int)(((byte)(119)))));
            this.lblSave.Location = new System.Drawing.Point(539, 444);
            this.lblSave.Name = "lblSave";
            this.lblSave.Size = new System.Drawing.Size(53, 25);
            this.lblSave.TabIndex = 1;
            this.lblSave.Text = "Save";
            this.lblSave.Click += new System.EventHandler(this.lblSave_Click);
            this.lblSave.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblSave_MouseDown);
            this.lblSave.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lblSave_MouseUp);
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
            this.lblDefault.Click += new System.EventHandler(this.lblDefault_Click);
            this.lblDefault.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblDefault_MouseDown);
            this.lblDefault.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lblDefault_MouseUp);
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
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(169)))), ((int)(((byte)(119)))));
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(169)))), ((int)(((byte)(119)))));
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1278, 678);
            this.Name = "Form1";
            this.Text = "Calender - More than just a calendar";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.schedulerDataStorage1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.pnlStatistics.ResumeLayout(false);
            this.pnlStatistics.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.TimeTablePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.schedulerControl1)).EndInit();
            this.SettingPanel.ResumeLayout(false);
            this.SettingPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.theme1PB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.theme2PB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.theme4PB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.theme3PB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.alertOff)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.alertOn)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }


        #endregion
        private System.Windows.Forms.Button[,] DateButton;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.NotifyIcon notifyIcon2;
        private DevExpress.XtraScheduler.SchedulerDataStorage schedulerDataStorage1;
        private DevExpress.XtraEditors.VScrollBar vScrollBar1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem calendarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem timetableToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.Panel TimeTablePanel;
        private DevExpress.XtraScheduler.SchedulerControl schedulerControl1;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel SettingPanel;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.FlowLayoutPanel dayView;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Button addbutton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem statisticsToolStripMenuItem1;
        private System.Windows.Forms.Label YearLabel;
        private System.Windows.Forms.Label PresentMonth;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button prevmonth;
        private System.Windows.Forms.Button nextmonth;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label themeLB;
        private System.Windows.Forms.Label lblSave;
        private System.Windows.Forms.Label lblDefault;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox highChB;
        private System.Windows.Forms.CheckBox mediumChB;
        private System.Windows.Forms.CheckBox normalChB;
        private System.Windows.Forms.TextBox emailTB;
        private System.Windows.Forms.PictureBox alertOff;
        private System.Windows.Forms.PictureBox alertOn;
        private System.Windows.Forms.PictureBox theme3PB;
        private System.Windows.Forms.PictureBox theme4PB;
        private System.Windows.Forms.PictureBox theme1PB;
        private System.Windows.Forms.PictureBox theme2PB;
        private System.Windows.Forms.Panel pnlStatistics;
        private System.Windows.Forms.Label lbSummary;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label sumall;
        private System.Windows.Forms.Label summonth;
        private System.Windows.Forms.Label sumday;
        private System.Windows.Forms.Label lbReports;
        private DevExpress.XtraCharts.ChartControl chartControl1;
        public DevExpress.XtraCharts.Series series1;
        public DevExpress.XtraCharts.XYDiagram xyDiagram1;
        public DevExpress.XtraCharts.SideBySideBarSeriesView sideBySideBarSeriesView1;
        private System.Windows.Forms.ComboBox cbbYearly;
        private System.Windows.Forms.ComboBox cbbMonthly;
        private System.Windows.Forms.Label lbMonthly;
        private System.Windows.Forms.Label lbYearly;
        private System.Windows.Forms.Label notificationStatusLB;
    }
}

