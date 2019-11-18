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
            this.SuspendLayout();
            // 
            // startTime
            // 
            this.startTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startTime.Location = new System.Drawing.Point(13, 8);
            this.startTime.Name = "startTime";
            this.startTime.Size = new System.Drawing.Size(100, 23);
            this.startTime.TabIndex = 0;
            this.startTime.Text = "StartTime";
            this.startTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // title
            // 
            this.title.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.Location = new System.Drawing.Point(119, 8);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(243, 23);
            this.title.TabIndex = 1;
            this.title.Text = "Title";
            // 
            // endTime
            // 
            this.endTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.endTime.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.endTime.Location = new System.Drawing.Point(14, 29);
            this.endTime.Name = "endTime";
            this.endTime.Size = new System.Drawing.Size(96, 23);
            this.endTime.TabIndex = 2;
            this.endTime.Text = "EndTime";
            this.endTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // location
            // 
            this.location.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.location.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.location.Location = new System.Drawing.Point(121, 31);
            this.location.Name = "location";
            this.location.Size = new System.Drawing.Size(242, 23);
            this.location.TabIndex = 3;
            this.location.Text = "Location";
            // 
            // edit
            // 
            this.edit.Location = new System.Drawing.Point(382, 7);
            this.edit.Name = "edit";
            this.edit.Size = new System.Drawing.Size(52, 47);
            this.edit.TabIndex = 4;
            this.edit.Text = "Edit";
            this.edit.UseVisualStyleBackColor = true;
            this.edit.Click += new System.EventHandler(this.edit_Click);
            // 
            // Item
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.edit);
            this.Controls.Add(this.location);
            this.Controls.Add(this.endTime);
            this.Controls.Add(this.title);
            this.Controls.Add(this.startTime);
            this.Name = "Item";
            this.Size = new System.Drawing.Size(448, 65);
            this.Load += new System.EventHandler(this.Item_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label startTime;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Label endTime;
        private System.Windows.Forms.Label location;
        private System.Windows.Forms.Button edit;
    }
}
