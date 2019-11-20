namespace Calender
{
    partial class EditOptionS
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
            this.btnThisAndFollowing = new System.Windows.Forms.Button();
            this.btnAllEvent = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnThisAndFollowing
            // 
            this.btnThisAndFollowing.DialogResult = System.Windows.Forms.DialogResult.No;
            this.btnThisAndFollowing.Location = new System.Drawing.Point(17, 13);
            this.btnThisAndFollowing.Name = "btnThisAndFollowing";
            this.btnThisAndFollowing.Size = new System.Drawing.Size(139, 42);
            this.btnThisAndFollowing.TabIndex = 0;
            this.btnThisAndFollowing.Text = "This And Following Item";
            this.btnThisAndFollowing.UseVisualStyleBackColor = true;
            // 
            // btnAllEvent
            // 
            this.btnAllEvent.DialogResult = System.Windows.Forms.DialogResult.Ignore;
            this.btnAllEvent.Location = new System.Drawing.Point(185, 13);
            this.btnAllEvent.Name = "btnAllEvent";
            this.btnAllEvent.Size = new System.Drawing.Size(139, 42);
            this.btnAllEvent.TabIndex = 1;
            this.btnAllEvent.Text = "All Event";
            this.btnAllEvent.UseVisualStyleBackColor = true;
            // 
            // EditOptionS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 68);
            this.Controls.Add(this.btnAllEvent);
            this.Controls.Add(this.btnThisAndFollowing);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "EditOptionS";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnThisAndFollowing;
        private System.Windows.Forms.Button btnAllEvent;
    }
}
