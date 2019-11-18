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
            this.SuspendLayout();
            // 
            // btnOnlyThisItem
            // 
            this.btnOnlyThisItem.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.btnOnlyThisItem.Location = new System.Drawing.Point(12, 23);
            this.btnOnlyThisItem.Name = "btnOnlyThisItem";
            this.btnOnlyThisItem.Size = new System.Drawing.Size(90, 40);
            this.btnOnlyThisItem.TabIndex = 0;
            this.btnOnlyThisItem.Text = "Only This Item";
            this.btnOnlyThisItem.UseVisualStyleBackColor = true;
            this.btnOnlyThisItem.Click += new System.EventHandler(this.btnYes_Click);
            // 
            // btnThisAndFollowing
            // 
            this.btnThisAndFollowing.DialogResult = System.Windows.Forms.DialogResult.No;
            this.btnThisAndFollowing.Location = new System.Drawing.Point(118, 23);
            this.btnThisAndFollowing.Name = "btnThisAndFollowing";
            this.btnThisAndFollowing.Size = new System.Drawing.Size(152, 40);
            this.btnThisAndFollowing.TabIndex = 1;
            this.btnThisAndFollowing.Text = "This And Following Item";
            this.btnThisAndFollowing.UseVisualStyleBackColor = true;
            this.btnThisAndFollowing.Click += new System.EventHandler(this.btnYes_Click);
            // 
            // btnAll
            // 
            this.btnAll.DialogResult = System.Windows.Forms.DialogResult.Ignore;
            this.btnAll.Location = new System.Drawing.Point(286, 23);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(90, 40);
            this.btnAll.TabIndex = 2;
            this.btnAll.Text = "All Item";
            this.btnAll.UseVisualStyleBackColor = true;
            this.btnAll.Click += new System.EventHandler(this.btnYes_Click);
            // 
            // EditOption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 76);
            this.Controls.Add(this.btnAll);
            this.Controls.Add(this.btnThisAndFollowing);
            this.Controls.Add(this.btnOnlyThisItem);
            this.Name = "EditOption";
            this.Text = "EditOption";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOnlyThisItem;
        private System.Windows.Forms.Button btnThisAndFollowing;
        private System.Windows.Forms.Button btnAll;
    }
}