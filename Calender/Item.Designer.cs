namespace Calender
{
    partial class Item
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.startTime = new System.Windows.Forms.Label();
            this.title = new System.Windows.Forms.Label();
            this.endTime = new System.Windows.Forms.Label();
            this.location = new System.Windows.Forms.Label();
            this.edit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // startTime
            // 
            this.startTime.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.startTime.Location = new System.Drawing.Point(59, 10);
            this.startTime.Name = "startTime";
            this.startTime.Size = new System.Drawing.Size(100, 23);
            this.startTime.TabIndex = 0;
            this.startTime.Text = "00:00";
            this.startTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // title
            // 
            this.title.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.title.Location = new System.Drawing.Point(131, 10);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(205, 23);
            this.title.TabIndex = 1;
            this.title.Text = "Title";
            // 
            // endTime
            // 
            this.endTime.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.endTime.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.endTime.Location = new System.Drawing.Point(59, 31);
            this.endTime.Name = "endTime";
            this.endTime.Size = new System.Drawing.Size(96, 23);
            this.endTime.TabIndex = 2;
            this.endTime.Text = "End";
            this.endTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // location
            // 
            this.location.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.location.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.location.Location = new System.Drawing.Point(131, 31);
            this.location.Name = "location";
            this.location.Size = new System.Drawing.Size(204, 23);
            this.location.TabIndex = 3;
            this.location.Text = "Location";
            // 
            // edit
            // 
            this.edit.Location = new System.Drawing.Point(438, 7);
            this.edit.Name = "edit";
            this.edit.Size = new System.Drawing.Size(52, 47);
            this.edit.TabIndex = 4;
            this.edit.Text = "Edit";
            this.edit.UseVisualStyleBackColor = true;
            this.edit.Click += new System.EventHandler(this.edit_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Segoe UI Light", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label1.Location = new System.Drawing.Point(117, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 39);
            this.label1.TabIndex = 5;
            this.label1.Text = "|";
            // 
            // Item
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.edit);
            this.Controls.Add(this.location);
            this.Controls.Add(this.endTime);
            this.Controls.Add(this.title);
            this.Controls.Add(this.startTime);
            this.Name = "Item";
            this.Size = new System.Drawing.Size(506, 65);
            this.Load += new System.EventHandler(this.Item_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Item_Paint);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label startTime;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Label endTime;
        private System.Windows.Forms.Label location;
        private System.Windows.Forms.Button edit;
        private System.Windows.Forms.Label label1;
    }
}
