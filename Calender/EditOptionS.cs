using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calender
{
    public partial class EditOptionS : Form
    {
        public EditOptionS()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;

            btnThisAndFollowing.FlatAppearance.BorderSize = 0;
            btnThisAndFollowing.FlatAppearance.MouseOverBackColor = Color.Transparent;

            btnAll.FlatAppearance.BorderSize = 0;
            btnAll.FlatAppearance.MouseOverBackColor = Color.Transparent;

            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatAppearance.MouseOverBackColor = Color.Transparent;
            this.Focus();
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EditOption_Load(object sender, EventArgs e)
        {

        }

        private void btnThisAndFollowing_MouseEnter(object sender, EventArgs e)
        {
            btnThisAndFollowing.FlatAppearance.BorderSize = 1;
            btnAll.FlatAppearance.BorderSize = 0;
            btnCancel.FlatAppearance.BorderSize = 0;
        }

        private void btnOnlyThisItem_MouseEnter(object sender, EventArgs e)
        {
            btnThisAndFollowing.FlatAppearance.BorderSize = 0;
            btnAll.FlatAppearance.BorderSize = 0;
            btnCancel.FlatAppearance.BorderSize = 0;
        }

        private void btnAll_MouseEnter(object sender, EventArgs e)
        {
            btnThisAndFollowing.FlatAppearance.BorderSize = 0;
            btnAll.FlatAppearance.BorderSize = 1;
            btnCancel.FlatAppearance.BorderSize = 0;
        }

        private void btnCancel_MouseEnter(object sender, EventArgs e)
        {
            btnThisAndFollowing.FlatAppearance.BorderSize = 0;
            btnAll.FlatAppearance.BorderSize = 0;
            btnCancel.FlatAppearance.BorderSize = 1;
        }
    }
}
