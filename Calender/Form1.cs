﻿using System;
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

namespace Calender
{
    public partial class Form1 : Form
    {
        string filepath = "data.xml";
        PlanData allPlan = new PlanData();

        public Form1()
        {
            InitializeComponent();
            InitDateMatrix();
            try
            {
                allPlan = (PlanData)DeserializeFromXML(filepath);
            }
            catch
            {
            }
            if(allPlan == null)
            {
                allPlan = new PlanData();
            }
            this.CenterToScreen();
            new_Event = new New_Event(allPlan);
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
            Year.SyncYear();
            int maxDay = Year.GetMaxDaysOfMonth(Year.GetCurrentYear(), month);
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
                        count++;
                    }
                }
            }
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
            new_Event = new New_Event(allPlan);
            new_Event.ShowDialog();
        }        

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
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
    }
}
