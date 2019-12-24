namespace Calender
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
            this.deleteLB = new System.Windows.Forms.Label();
            this.highTT = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.startDateDE.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.startDateDE.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.endDateDE.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.endDateDE.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repeatEndDE.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repeatEndDE.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.None;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.deleteLB);
            this.panel2.Controls.SetChildIndex(this.alertCB, 0);
            this.panel2.Controls.SetChildIndex(this.startDateDE, 0);
            this.panel2.Controls.SetChildIndex(this.endDateDE, 0);
            this.panel2.Controls.SetChildIndex(this.startTimeTP, 0);
            this.panel2.Controls.SetChildIndex(this.endTimeTP, 0);
            this.panel2.Controls.SetChildIndex(this.repeatEndDE, 0);
            this.panel2.Controls.SetChildIndex(this.highLB, 0);
            this.panel2.Controls.SetChildIndex(this.MediumLB, 0);
            this.panel2.Controls.SetChildIndex(this.normalLB, 0);
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
            this.panel2.Controls.SetChildIndex(this.deleteLB, 0);
            // 
            // label9
            // 
            this.label9.Size = new System.Drawing.Size(169, 45);
            this.label9.Text = "Edit event";
            // 
            // startDateDE
            // 
            this.startDateDE.EditValue = new System.DateTime(2019, 12, 17, 16, 42, 43, 0);
            this.startDateDE.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.startDateDE.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.startDateDE.Properties.Appearance.Options.UseFont = true;
            this.startDateDE.Properties.Appearance.Options.UseForeColor = true;
            this.startDateDE.Properties.Appearance.Options.UseTextOptions = true;
            this.startDateDE.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.startDateDE.Properties.DisplayFormat.FormatString = "dd MMMM yyyy";
            this.startDateDE.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.startDateDE.Properties.EditFormat.FormatString = "dd MMMM yyyy";
            this.startDateDE.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.startDateDE.Properties.Mask.EditMask = "dd MMMM yyyy";
            // 
            // endDateDE
            // 
            this.endDateDE.EditValue = new System.DateTime(2019, 12, 17, 16, 42, 43, 0);
            this.endDateDE.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.endDateDE.Properties.Appearance.Options.UseFont = true;
            this.endDateDE.Properties.Appearance.Options.UseTextOptions = true;
            this.endDateDE.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.endDateDE.Properties.DisplayFormat.FormatString = "dd MMMM yyyy";
            this.endDateDE.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.endDateDE.Properties.EditFormat.FormatString = "dd MMMM yyyy";
            this.endDateDE.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.endDateDE.Properties.Mask.EditMask = "dd MMMM yyyy";
            // 
            // repeatEndDE
            // 
            this.repeatEndDE.EditValue = new System.DateTime(2019, 12, 17, 16, 42, 43, 0);
            this.repeatEndDE.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.repeatEndDE.Properties.Appearance.Options.UseFont = true;
            this.repeatEndDE.Properties.Appearance.Options.UseTextOptions = true;
            this.repeatEndDE.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.repeatEndDE.Properties.DisplayFormat.FormatString = "dd MMMM yyyy";
            this.repeatEndDE.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.repeatEndDE.Properties.EditFormat.FormatString = "dd MMMM yyyy";
            this.repeatEndDE.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.repeatEndDE.Properties.Mask.EditMask = "dd MMMM yyyy";
            // 
            // deleteLB
            // 
            this.deleteLB.AutoSize = true;
            this.deleteLB.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.deleteLB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(64)))), ((int)(((byte)(77)))));
            this.deleteLB.Location = new System.Drawing.Point(32, 472);
            this.deleteLB.Name = "deleteLB";
            this.deleteLB.Size = new System.Drawing.Size(60, 21);
            this.deleteLB.TabIndex = 27;
            this.deleteLB.Text = "Delete";
            this.deleteLB.Click += new System.EventHandler(this.deleteLB_Click);
            // 
            // highTT
            // 
            this.highTT.AutomaticDelay = 100;
            this.highTT.ShowAlways = true;
            // 
            // EditEvent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(384, 613);
            this.Name = "EditEvent";
            this.Text = "EditEvent";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.startDateDE.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.startDateDE.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.endDateDE.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.endDateDE.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repeatEndDE.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repeatEndDE.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label deleteLB;
        private System.Windows.Forms.ToolTip highTT;
    }
}