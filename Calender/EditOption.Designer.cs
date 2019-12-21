﻿namespace Calender
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnOnlyThisItem
            // 
            this.btnOnlyThisItem.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.btnOnlyThisItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOnlyThisItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOnlyThisItem.ForeColor = System.Drawing.SystemColors.Window;
            this.btnOnlyThisItem.Location = new System.Drawing.Point(8, 7);
            this.btnOnlyThisItem.Name = "btnOnlyThisItem";
            this.btnOnlyThisItem.Size = new System.Drawing.Size(188, 41);
            this.btnOnlyThisItem.TabIndex = 1;
            this.btnOnlyThisItem.Text = "For this event";
            this.btnOnlyThisItem.UseVisualStyleBackColor = true;
            this.btnOnlyThisItem.Click += new System.EventHandler(this.btnYes_Click);
            this.btnOnlyThisItem.MouseEnter += new System.EventHandler(this.btnOnlyThisItem_MouseEnter);
            // 
            // btnThisAndFollowing
            // 
            this.btnThisAndFollowing.DialogResult = System.Windows.Forms.DialogResult.No;
            this.btnThisAndFollowing.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThisAndFollowing.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnThisAndFollowing.ForeColor = System.Drawing.SystemColors.Window;
            this.btnThisAndFollowing.Location = new System.Drawing.Point(8, 57);
            this.btnThisAndFollowing.Name = "btnThisAndFollowing";
            this.btnThisAndFollowing.Size = new System.Drawing.Size(188, 41);
            this.btnThisAndFollowing.TabIndex = 1;
            this.btnThisAndFollowing.Text = "For future events";
            this.btnThisAndFollowing.UseVisualStyleBackColor = true;
            this.btnThisAndFollowing.Click += new System.EventHandler(this.btnYes_Click);
            this.btnThisAndFollowing.MouseEnter += new System.EventHandler(this.btnThisAndFollowing_MouseEnter);
            // 
            // btnAll
            // 
            this.btnAll.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAll.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnAll.ForeColor = System.Drawing.SystemColors.Window;
            this.btnAll.Location = new System.Drawing.Point(8, 106);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(188, 41);
            this.btnAll.TabIndex = 1;
            this.btnAll.Text = "For all events";
            this.btnAll.UseVisualStyleBackColor = true;
            this.btnAll.Click += new System.EventHandler(this.btnYes_Click);
            this.btnAll.MouseEnter += new System.EventHandler(this.btnAll_MouseEnter);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnCancel.ForeColor = System.Drawing.SystemColors.Window;
            this.btnCancel.Location = new System.Drawing.Point(8, 153);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(188, 41);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.MouseEnter += new System.EventHandler(this.btnCancel_MouseEnter);
            // 
            // EditOption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(202, 203);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAll);
            this.Controls.Add(this.btnThisAndFollowing);
            this.Controls.Add(this.btnOnlyThisItem);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "EditOption";
            this.Text = "EditOption";
            this.Load += new System.EventHandler(this.EditOption_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOnlyThisItem;
        private System.Windows.Forms.Button btnThisAndFollowing;
        private System.Windows.Forms.Button btnAll;
        private System.Windows.Forms.Button btnCancel;
    }
}