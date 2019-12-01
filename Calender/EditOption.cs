using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calender
{
    public partial class EditOption : Form
    {
        public EditOption()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
            btnOnlyThisItem.FlatAppearance.BorderSize = 0;
            btnThisAndFollowing.FlatAppearance.BorderSize = 0;
            btnAll.FlatAppearance.BorderSize = 0;

        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EditOption_Load(object sender, EventArgs e)
        {

        }
    }
}
