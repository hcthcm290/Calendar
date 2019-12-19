﻿namespace Calender
{
    partial class EditEvent
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
            this.label17 = new System.Windows.Forms.Label();
            this.highTT = new System.Windows.Forms.ToolTip(this.components);
            this.normalTT = new System.Windows.Forms.ToolTip(this.components);
            this.mediumTT = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.None;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label17);
            this.panel2.Controls.SetChildIndex(this.cbbRepeat, 0);
            this.panel2.Controls.SetChildIndex(this.repeatEndLabel, 0);
            this.panel2.Controls.SetChildIndex(this.repeatLB, 0);
            this.panel2.Controls.SetChildIndex(this.startsLB, 0);
            this.panel2.Controls.SetChildIndex(this.label7, 0);
            this.panel2.Controls.SetChildIndex(this.label2, 0);
            this.panel2.Controls.SetChildIndex(this.endsLB, 0);
            this.panel2.Controls.SetChildIndex(this.label6, 0);
            this.panel2.Controls.SetChildIndex(this.titleTB, 0);
            this.panel2.Controls.SetChildIndex(this.titleLB, 0);
            this.panel2.Controls.SetChildIndex(this.locationLB, 0);
            this.panel2.Controls.SetChildIndex(this.locationTB, 0);
            this.panel2.Controls.SetChildIndex(this.label14, 0);
            this.panel2.Controls.SetChildIndex(this.repeatValueLB, 0);
            this.panel2.Controls.SetChildIndex(this.daysLB, 0);
            this.panel2.Controls.SetChildIndex(this.repeatValueTB, 0);
            this.panel2.Controls.SetChildIndex(this.priorityLB, 0);
            this.panel2.Controls.SetChildIndex(this.alertLB, 0);
            this.panel2.Controls.SetChildIndex(this.notesTB, 0);
            this.panel2.Controls.SetChildIndex(this.applyLB, 0);
            this.panel2.Controls.SetChildIndex(this.cancelLB, 0);
            this.panel2.Controls.SetChildIndex(this.label17, 0);
            // 
            // label9
            // 
            this.label9.Size = new System.Drawing.Size(169, 45);
            this.label9.Text = "Edit event";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(64)))), ((int)(((byte)(77)))));
            this.label17.Location = new System.Drawing.Point(32, 472);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(60, 21);
            this.label17.TabIndex = 27;
            this.label17.Text = "Delete";
            // 
            // highTT
            // 
            this.highTT.AutomaticDelay = 100;
            this.highTT.ShowAlways = true;
            // 
            // normalTT
            // 
            this.normalTT.AutomaticDelay = 100;
            // 
            // mediumTT
            // 
            this.mediumTT.AutomaticDelay = 100;
            // 
            // EditEvent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(361, 613);
            this.Name = "EditEvent";
            this.Text = "EditEvent";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ToolTip highTT;
        private new System.Windows.Forms.ToolTip normalTT;
        private new System.Windows.Forms.ToolTip mediumTT;
    }
}