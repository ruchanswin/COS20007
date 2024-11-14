using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Notepad
{
    public partial class ReferenceForm : Form
    {
        String author;
        String year;
        String title;
        String publisher;

        public ReferenceForm()
        {
            InitializeComponent();
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            author = "";
            year = "";
            title = "";
            publisher = "";
            this.Close();
        }

        private void OkBtn_Click(object sender, EventArgs e)
        {
            author = findAuthor.Text;
            year = findYear.Text;
            title = findTitle.Text;
            publisher = findPublisher.Text;
            this.Close();
        }

        public String GetReference()
        {
            string reference = $"{author} ({year}). {title}. {publisher}.";
            return reference;
        }

        private void ReferenceForm_Load(object sender, EventArgs e)
        {

        }
    }
}
