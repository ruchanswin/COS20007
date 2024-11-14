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
    public partial class ReplaceForm : Form
    {
        public String findWord;
        public String replaceWord;
        public ReplaceForm()
        {
            InitializeComponent();
        }

        private void ReplaceBtn_Click(object sender, EventArgs e)
        {
            findWord = findText.Text;
            replaceWord = replaceText.Text;
            this.Close();
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            findWord = "";
            replaceWord = "";
            this.Close();
        }

        private void ReplaceForm_Load(object sender, EventArgs e)
        {

        }
    }
}
