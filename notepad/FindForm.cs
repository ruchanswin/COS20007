using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Notepad
{
    public partial class FindForm : Form
    {
        String findWord;
        public FindForm()
        {
            InitializeComponent();
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            findWord = "";
            this.Close();
        }

        private void OkBtn_Click(object sender, EventArgs e)
        {
            findWord = findText.Text;
            this.Close();
        }
        public String GetFindWord()
        {
            return findWord;
        }
    }
}
