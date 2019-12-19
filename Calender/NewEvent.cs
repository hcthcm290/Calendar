using System;
using System.Drawing;
using System.Windows.Forms;
using ClockPicker;

namespace Calender
{
    public partial class New_Event : Form
    {
        public PlanData thisPlan;
        protected TimeSpan timeSpan; // timespan between starttime and endtime
        PriorityEnum priority;
        bool notification;
        
        public New_Event()
        {
            InitializeComponent();
            Init();
            this.Refresh();
        }
        public New_Event(PlanData planData)
        {
            InitializeComponent();
            Init();
            thisPlan = planData;
            this.StartPosition = FormStartPosition.CenterParent;
        }
        public New_Event(PlanData planData, DateTime focusedDate)
        {
            InitializeComponent();
            Init();
            thisPlan = planData;
            this.StartPosition = FormStartPosition.CenterParent;
            startDateDE.DateTime = focusedDate;
            endDateDE.DateTime = focusedDate;
            string sad = startTimeTP.Text;
            this.titleTB.Focus();
            timeSpan = new TimeSpan(1, 0, 0);
            startTimeTP.Value = DateTime.Now;
            endTimeTP.Value = DateTime.Now + timeSpan;
            highTT.SetToolTip(highLB, "High");
            normalTT.SetToolTip(normalLB, "Normal");
            mediumTT.SetToolTip(MediumLB, "Medium");

            repeatEndDE.DateTime = focusedDate;
        }

        void Init()
        {
            this.cbbRepeat.Items.Add("No repeat");
            this.cbbRepeat.Items.Add("Every day");
            this.cbbRepeat.Items.Add("Every week");
            this.cbbRepeat.Items.Add("Every month");
            this.cbbRepeat.Items.Add("Every year");
            this.cbbRepeat.Items.Add("Custom");
            this.cbbRepeat.SelectedIndex = 0;

            this.alertCB.Items.Add("1 hour before");
            this.alertCB.Items.Add("30 mins before");
            this.alertCB.Items.Add("15 mins before");
            this.alertCB.Items.Add("At time of event");
            this.alertCB.SelectedIndex = 3;


        }
        private void New_Event_Load(object sender, EventArgs e)
        {

        }
        private void Silent_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
        private void Day_KeyDown(object sender, KeyEventArgs e)
        {
            ComboBox cb = (ComboBox)(sender);
            if (e.KeyCode == Keys.Enter)
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
                e.Handled = true;
                e.SuppressKeyPress = true;
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

                e.Handled = true;
                e.SuppressKeyPress = true;
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
            if (tb.Text.ToLower() == tb.Name)
            {
                tb.Text = "";
            }
        }
        private void TB_Leave(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text == "")
            {
                tb.Text = tb.Name.Substring(0, 1).ToUpper() + tb.Name.Substring(1);
            }
        }
        private void Repeat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbRepeat.SelectedIndex == 0) // if no repeat
            {
                this.repeatValueLB.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Strikeout))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.repeatValueLB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(200)))), ((int)(((byte)(207)))));
                this.daysLB.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Strikeout))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.daysLB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(200)))), ((int)(((byte)(207)))));
                this.repeatEndLabel.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Strikeout))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.repeatEndLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(200)))), ((int)(((byte)(207)))));

                repeatEndDE.Visible = false;

                repeatValueTB.Visible = false;
            }
            else if (cbbRepeat.SelectedIndex == 5) // if custom repeat
            {
                this.repeatValueLB.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.repeatValueLB.ForeColor = SystemColors.ControlText;
                this.daysLB.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.daysLB.ForeColor = SystemColors.ControlText;
                this.repeatEndLabel.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.repeatEndLabel.ForeColor = SystemColors.ControlText;

                repeatValueTB.Visible = true;
                repeatValueTB.BringToFront();
                repeatValueTB.Focus();

                repeatEndDE.Visible = true;
                return;
                //edit this
            }
            else
            {
                this.repeatValueLB.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Strikeout))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.repeatValueLB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(200)))), ((int)(((byte)(207)))));
                this.daysLB.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Strikeout))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.daysLB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(200)))), ((int)(((byte)(207)))));
                this.repeatEndLabel.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.repeatEndLabel.ForeColor = SystemColors.ControlText;

                repeatValueTB.Visible = false;
                priorityLB.Focus();

                repeatEndDE.Visible = true;
                //edit this
            }

            titleLB.Focus();
        }
        public bool CheckLegitDate(int year, int month, int day)
        {
            if (day > Year.GetMaxDaysOfMonth(year, month))
            {
                return false;
            }
            return true;
        }
        public virtual void SaveButton_Click(object sender, EventArgs e)
        {
            TimeSpan alertTimeSpane = new TimeSpan();
            if(alertCB.SelectedIndex == 0)
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

            GroupPlanItem newGroup = new GroupPlanItem();
            
            DateTime start = new DateTime(startDateDE.DateTime.Year, startDateDE.DateTime.Month, startDateDE.DateTime.Day, 
                                          startTimeTP.Value.Hour, startTimeTP.Value.Minute, 0);


            DateTime end = new DateTime(endDateDE.DateTime.Year, endDateDE.DateTime.Month, endDateDE.DateTime.Day,
                                        endTimeTP.Value.Hour, endTimeTP.Value.Minute, 0);


            if (end <= start)
            {
                MessageBox.Show("End Day must after Start Day");
                return;
            }

            string title = titleTB.Text;
            if(titleTB.ForeColor != SystemColors.ControlText)
            {
                title = "";
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

            ////////////////////////////////////////////////////////////////
            ///
            // FOR NO REPEAT //
            if (cbbRepeat.SelectedIndex == 0)
            {
                newGroup.repeatKind = 0;
                newGroup.Insert(new PlanItem(title, note, start, end, (int)priority, start - alertTimeSpane, location, notification));
                thisPlan.Insert(newGroup);
                this.Close();
                return;
            }
           
            DateTime repeatEnd = new DateTime(repeatEndDE.DateTime.Year, repeatEndDE.DateTime.Month, repeatEndDE.DateTime.Day, 23, 59, 59);

            if (repeatEnd < end)
            {
                MessageBox.Show("The end for Repeat end must after the end of event");
                return;
            }

            newGroup.repeatEnd = repeatEnd;

            
            if (cbbRepeat.SelectedIndex == 1) // repeat daily
            {
                newGroup.repeatKind = 1;
                while (true)
                {
                    start = start.AddDays(1);
                    end = end.AddDays(1);
                    newGroup.Insert(new PlanItem(title, note, start, end, (int)priority, start - alertTimeSpane, location, notification));

                    if (start > repeatEnd)
                    {
                        thisPlan.Insert(newGroup);
                        this.Close();
                        return;
                    }
                }
            }
            else if (cbbRepeat.SelectedIndex == 2) // repeat weekly
            {
                newGroup.repeatKind = 2;
                while (true)
                {
                    start = start.AddDays(7);
                    end = end.AddDays(7);
                    newGroup.Insert(new PlanItem(title, note, start, end, (int)priority, start - alertTimeSpane, location, notification));

                    if (start > repeatEnd)
                    {
                        thisPlan.Insert(newGroup);
                        this.Close();
                        return;
                    }
                }
            }
            /*
            else if (cbbRepeat.SelectedIndex == 3) // repeat monthly
            {
                newGroup.repeatKind = 3;

                TimeSpan timeSpan = end - start;
                while (true)
                {
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
            
            else if (cbbRepeat.Text.ToString() == "A Year")
            {
                newGroup.repeatKind = 4;

                TimeSpan timeSpan = end - start;
                while (true)
                {
                    do
                    {
                        Date.AddMonth(tYear_Start, tMonth_Start, out tYear_Start, out tMonth_Start, 12);
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
                newGroup.repeatKind = 5;
                newGroup.repeatValue = Convert.ToInt32(repeatValue.Text);

                while (true)
                {
                    start = start.AddDays(Convert.ToInt32(repeatValue.Text));
                    end = end.AddDays(Convert.ToInt32(repeatValue.Text));

                    if (start > repeatEnd)
                    {
                        thisPlan.Insert(newGroup);
                        this.Close();
                        return;
                    }
                }
                
            }
            */
        }

        /*
        private void Day_Start_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            Day_End.SelectedIndex = cb.SelectedIndex;
        }

        private void Month_Start_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            Month_End.SelectedIndex = cb.SelectedIndex;
        }

        private void Year_Start_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            Year_End.SelectedIndex = cb.SelectedIndex;
        }

        private void Day_Start_TextChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            Day_End.Text = cb.Text;
        }

        private void Month_Start_TextChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            Month_End.Text = cb.Text;
        }

        private void Year_Start_TextChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            Year_End.Text = cb.Text;
        }

        private void RepeatEndLabel_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void Minute_Start_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
        */
        private void Minute_End_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Hour_Start_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void New_Event_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            e.Graphics.FillEllipse(new SolidBrush(Color.FromArgb(202, 64, 77)), new RectangleF(304, 345, 22, 22));
            e.Graphics.FillEllipse(new SolidBrush(Color.FromArgb(238, 196, 106)), new RectangleF(251, 345, 22, 22));
            e.Graphics.FillEllipse(new SolidBrush(Color.FromArgb(68, 75, 83)), new RectangleF(198, 345, 22, 22));
            e.Graphics.DrawRectangle(new Pen(new SolidBrush(Color.FromArgb(180,0,0,0)), 5), new Rectangle(0, 0, this.Width, this.Height));
        }

        private void Day_End_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void New_Event_MouseDown(object sender, MouseEventArgs e)
        {
            priorityLB.Focus();
        }

        private void dateEdit1_Click(object sender, EventArgs e)
        {

        }

        private void dateEdit1_Click_1(object sender, EventArgs e)
        {
            startDateDE.ShowPopup();
        }

        private void dateEdit2_Click(object sender, EventArgs e)
        {
            endDateDE.ShowPopup();
        }

        private void dateEdit1_EditValueChanged(object sender, EventArgs e)
        {
            priorityLB.Focus();
        }

        private void dateEdit2_EditValueChanged(object sender, EventArgs e)
        {
            priorityLB.Focus();
        }

        private void timePicker1_Leave(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void New_Event_Shown(object sender, EventArgs e)
        {
            titleLB.Focus();
        }

        private void titleTB_Click(object sender, EventArgs e)
        {
            if (titleTB.ForeColor == Color.FromArgb(194, 200, 207))
            {
                titleTB.Text = "";
                titleTB.ForeColor = SystemColors.ControlText;
            }
        }

        private void titleTB_Leave(object sender, EventArgs e)
        {
            if(titleTB.Text == "")
            {
                titleTB.ForeColor = Color.FromArgb(194,200,207);
                titleTB.Text = "Title goes here";
            }
        }

        private void locationTB_Click(object sender, EventArgs e)
        {
            if (locationTB.ForeColor == Color.FromArgb(194, 200, 207))
            {
                locationTB.Text = "";
                locationTB.ForeColor = SystemColors.ControlText;
            }
        }

        private void locationTB_Leave(object sender, EventArgs e)
        {
            if (locationTB.Text == "")
            {
                locationTB.ForeColor = Color.FromArgb(194, 200, 207);
                locationTB.Text = "Location goes here";
            }
        }

        private void notesTB_Click(object sender, EventArgs e)
        {
            if (notesTB.ForeColor == Color.FromArgb(194, 200, 207))
            {
                notesTB.Text = "";
                notesTB.ForeColor = SystemColors.ControlText;
            }
        }

        private void notesTB_Leave(object sender, EventArgs e)
        {
            if (notesTB.Text == "")
            {
                notesTB.ForeColor = Color.FromArgb(194, 200, 207);
                notesTB.Text = "Location goes here";
            }
        }
        
        private void startTimeTP_ValueChanged(object sender, ValueChangedEventArgs<DateTime> e)
        {
            endTimeTP.Value = startTimeTP.Value + timeSpan;
        }

        private void endTimeTP_ValueChanged(object sender, ValueChangedEventArgs<DateTime> e)
        {
            timeSpan = endTimeTP.Value - startTimeTP.Value;
        }

        private void repeatEndDE_Click(object sender, EventArgs e)
        {
            repeatEndDE.ShowPopup();
        }

        private void repeatEndDE_EditValueChanged(object sender, EventArgs e)
        {
            priorityLB.Focus();
        }

        private void alertCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            priorityLB.Focus();
        }

        private void alertOff_Click(object sender, EventArgs e)
        {
            this.alertOff.Visible = false;
            this.alertOn.Visible = true;

            this.alertLB.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.alertLB.ForeColor = SystemColors.ControlText;

            this.alertCB.Visible = true;
        }

        private void alertOn_Click(object sender, EventArgs e)
        {
            this.alertOff.Visible = true;
            this.alertOn.Visible = false;

            this.alertLB.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Strikeout))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.alertLB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(200)))), ((int)(((byte)(207)))));
            
            this.alertCB.Visible = false;
        }
    }
}
