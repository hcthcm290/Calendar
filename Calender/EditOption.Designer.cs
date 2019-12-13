namespace Calender
{
    partial class EditOption
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
            this.btnOnlyThisItem = new System.Windows.Forms.Button();
            this.btnThisAndFollowing = new System.Windows.Forms.Button();
            this.btnAll = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnOnlyThisItem
            // 
            this.btnOnlyThisItem.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.btnOnlyThisItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOnlyThisItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOnlyThisItem.ForeColor = System.Drawing.SystemColors.Window;
            this.btnOnlyThisItem.Location = new System.Drawing.Point(10, 10);
            this.btnOnlyThisItem.Margin = new System.Windows.Forms.Padding(4);
            this.btnOnlyThisItem.Name = "btnOnlyThisItem";
            this.btnOnlyThisItem.Size = new System.Drawing.Size(250, 50);
            this.btnOnlyThisItem.TabIndex = 0;
            this.btnOnlyThisItem.Text = "For this event";
            this.btnOnlyThisItem.UseVisualStyleBackColor = true;
            this.btnOnlyThisItem.Click += new System.EventHandler(this.btnYes_Click);
            // 
            // btnThisAndFollowing
            // 
            this.btnThisAndFollowing.DialogResult = System.Windows.Forms.DialogResult.No;
            this.btnThisAndFollowing.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThisAndFollowing.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnThisAndFollowing.ForeColor = System.Drawing.SystemColors.Window;
            this.btnThisAndFollowing.Location = new System.Drawing.Point(10, 70);
            this.btnThisAndFollowing.Margin = new System.Windows.Forms.Padding(4);
            this.btnThisAndFollowing.Name = "btnThisAndFollowing";
            this.btnThisAndFollowing.Size = new System.Drawing.Size(250, 50);
            this.btnThisAndFollowing.TabIndex = 1;
            this.btnThisAndFollowing.Text = "For future events";
            this.btnThisAndFollowing.UseVisualStyleBackColor = true;
            this.btnThisAndFollowing.Click += new System.EventHandler(this.btnYes_Click);
            // 
            // btnAll
            // 
            this.btnAll.DialogResult = System.Windows.Forms.DialogResult.Ignore;
            this.btnAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAll.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnAll.ForeColor = System.Drawing.SystemColors.Window;
            this.btnAll.Location = new System.Drawing.Point(10, 130);
            this.btnAll.Margin = new System.Windows.Forms.Padding(4);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(250, 50);
            this.btnAll.TabIndex = 2;
            this.btnAll.Text = "For all events";
            this.btnAll.UseVisualStyleBackColor = true;
            this.btnAll.Click += new System.EventHandler(this.btnYes_Click);
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Ignore;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.button1.ForeColor = System.Drawing.SystemColors.Window;
            this.button1.Location = new System.Drawing.Point(10, 188);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(250, 50);
            this.button1.TabIndex = 3;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // EditOption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(270, 250);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnAll);
            this.Controls.Add(this.btnThisAndFollowing);
            this.Controls.Add(this.btnOnlyThisItem);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "EditOption";
            this.Text = "EditOption";
            this.Load += new System.EventHandler(this.EditOption_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOnlyThisItem;
        private System.Windows.Forms.Button btnThisAndFollowing;
        private System.Windows.Forms.Button btnAll;
        private System.Windows.Forms.Button button1;
    }
}