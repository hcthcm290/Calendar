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

            // generate theme color
            Color themeColor = new Color();
            if (Settings1.Default.Theme == 0)
            {
                themeColor = Color.DarkOrange;
            }
            else if (Settings1.Default.Theme == 1)
            {
                themeColor = Color.FromArgb(112, 76, 161);
            }
            else if (Settings1.Default.Theme == 2)
            {
                themeColor = Color.FromArgb(238, 197, 106);
            }
            else if (Settings1.Default.Theme == 3)
            {
                themeColor = Color.FromArgb(78, 169, 119);
            }
            else if (Settings1.Default.Theme == 4)
            {
                themeColor = Color.FromArgb(194, 200, 207);
            }
            this.BackColor = themeColor;
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
