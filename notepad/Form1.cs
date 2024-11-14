using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Notepad
{
    public partial class Form1 : Form
    {
        public String currentFile;
        readonly List<string> undoList;
        readonly List<string> redoList;
        int textSizeValue;

        public Form1()
        {
            InitializeComponent();
            currentFile = null;
            undoList = new List<string>();
            redoList = new List<string>();
            undoList.Add("");
            undoToolStripMenuItem.Enabled = false;
            redoToolStripMenuItem.Enabled = false;
            textSizeValue = 12;
        }

        private void ApplyStyle(FontStyle style)
        {
            if (richTextBox1.SelectionLength > 0)
            {
                var selectedText = richTextBox1.SelectedText;
                var currentFont = richTextBox1.SelectionFont;
                if (currentFont == null) return;

                var newFontStyle = currentFont.Style ^ style;
                richTextBox1.SelectionFont = new Font(currentFont.FontFamily, currentFont.Size, newFontStyle);

                undoList.Add(richTextBox1.Text);
                undoToolStripMenuItem.Enabled = true;
                redoList.Clear();
                redoToolStripMenuItem.Enabled = false;
            }
        }


        private void OpenFile()
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = "c:\\",
                Filter = "Rich Text Format (*.rtf)|*.rtf|All files (*.*)|*.*",
                FilterIndex = 1,
                RestoreDirectory = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                currentFile = openFileDialog1.FileName;
                string fileExtension = Path.GetExtension(currentFile).ToLower();
                if (fileExtension == ".rtf")
                {
                    richTextBox1.LoadFile(currentFile, RichTextBoxStreamType.RichText);
                }
                else
                {
                    richTextBox1.LoadFile(currentFile, RichTextBoxStreamType.PlainText);
                }
                saveToolStripMenuItem.Enabled = true;
                printToolStripMenuItem.Enabled = true;
                Text = currentFile + " - Notepad";
            }
        }


        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        private void OpenBtn_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        private void SaveFileAs()
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog
            {
                InitialDirectory = "c:\\",
                Filter = "Rich Text Format (*.rtf)|*.rtf|All files (*.*)|*.*",
                FilterIndex = 1,
                RestoreDirectory = true
            };

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                currentFile = saveFileDialog1.FileName;
                Text = currentFile + " - Notepad";
                SaveFile();
            }
            saveToolStripMenuItem.Enabled = true;
            printToolStripMenuItem.Enabled = true;
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileAs();
        }

        private void SaveFile()
        {
            if (!string.IsNullOrEmpty(currentFile))
            {
                string fileExtension = Path.GetExtension(currentFile).ToLower();
                if (fileExtension == ".rtf")
                {
                    richTextBox1.SaveFile(currentFile, RichTextBoxStreamType.RichText);
                }
                else
                {
                    richTextBox1.SaveFile(currentFile, RichTextBoxStreamType.PlainText);
                }
            }
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFile();
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            SaveFile();
        }

        private void NewFile()
        {
            DialogResult result = MessageBox.Show("Do you want to save changes to the current file?", "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                if (currentFile != null)
                    SaveFile();
                else
                    SaveFileAs();
            }
            else if (result == DialogResult.Cancel)
            {
                return;
            }
            richTextBox1.Text = "";
            saveToolStripMenuItem.Enabled = false;
            printToolStripMenuItem.Enabled = false;
            currentFile = null;
        }

        private void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewFile();
        }

        private void NewBtn_Click(object sender, EventArgs e)
        {
            NewFile();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you really want to exit?\n All the current changes will be lost", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
            else if (result == DialogResult.No)
            {
                return;
            }
        }

        private void RichTextBox1_TextChanged(object sender, EventArgs e)
        {
            int numOfLines = richTextBox1.Lines.Length;
            linesLabel.Text = numOfLines.ToString();
            lengthLabel.Text = richTextBox1.Text.Length.ToString();
            undoToolStripMenuItem.Enabled = true;
            undoList.Add(richTextBox1.Text);
            printToolStripMenuItem.Enabled = true;
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
            
        }

        private void CutBtn_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void CopyBtn_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void Pastebtn_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void Delete()
        {
            richTextBox1.Text = richTextBox1.Text.Remove(richTextBox1.SelectionStart, richTextBox1.SelectionLength);
        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Delete();
        }

        private void Deletebtn_Click(object sender, EventArgs e)
        {
            Delete();
        }

        private void Find()
        {
            FindForm f1 = new FindForm();
            f1.ShowDialog();
            if (f1.GetFindWord() != "")
            {

                int index = 0;
                while (index != -1 && index < richTextBox1.Text.Length)
                {
                    index = richTextBox1.Text.IndexOf(f1.GetFindWord(), index);
                    if (index != -1)
                    {
                        richTextBox1.Select(index, f1.GetFindWord().Length);
                        index++;
                    }
                }
                MessageBox.Show("The finding is complete.", "End");
            }
            else
            {
                DialogResult result = MessageBox.Show("Do you want to proceed the action?", "End", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    f1.ShowDialog();
                    if (f1.GetFindWord() != "")
                    {

                        int index = 0;
                        while (index != -1 && index < richTextBox1.Text.Length)
                        {
                            index = richTextBox1.Text.IndexOf(f1.GetFindWord(), index);
                            if (index != -1)
                            {
                                richTextBox1.Select(index, f1.GetFindWord().Length);
                                index++;
                            }
                        }
                        MessageBox.Show("The finding is complete.", "End");
                    }
                }
                else if (result == DialogResult.No)
                {
                    f1.Close();
                }
            }
        }

        private void Reference()
        {
            ReferenceForm reference = new ReferenceForm();
            reference.ShowDialog();
            if (reference.GetReference() != " (). . .")
            {
                richTextBox1.Text += reference.GetReference();
                MessageBox.Show("The reference is created.", "Complete");
            }
            else
            {
                DialogResult result = MessageBox.Show("Do you want to proceed the action?", "End", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    reference.ShowDialog();
                    if (reference.GetReference() != " (). . .")
                    {
                        richTextBox1.Text += reference.GetReference();
                        MessageBox.Show("The reference is created.", "Complete");
                    }
                }
                else if (result == DialogResult.No)
                {
                    reference.Close();
                }
            }
        }

        private void ReferenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reference();
        }
        private void ReferenceBtn_Click(object sender, EventArgs e)
        {
            Reference();
        }


        private void FindToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Find();
        }
        private void FindBtn_Click(object sender, EventArgs e)
        {
            Find();
        }

        private void Replace()
        {
            ReplaceForm r1 = new ReplaceForm();
            r1.ShowDialog();
            String findWord = r1.findWord;
            String replaceWord = r1.replaceWord;
            if (findWord != "")
            {
                richTextBox1.Text = richTextBox1.Text.Replace(findWord, replaceWord);
                MessageBox.Show("The change is complete.", "Done", MessageBoxButtons.OK);
            }
            else
            {
                DialogResult result = MessageBox.Show("Do you want to proceed the action?", "End", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    r1.ShowDialog();
                    if (findWord != "")
                    {
                        richTextBox1.Text = richTextBox1.Text.Replace(findWord, replaceWord);
                        MessageBox.Show("The change is complete.", "Done", MessageBoxButtons.OK);
                    }
                }
                else if (result == DialogResult.No)
                {
                    r1.Close();
                }
            }
        }

        private void ReplaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Replace();
        }

        private void ReplaceBtn_Click(object sender, EventArgs e)
        {
            Replace();
        }


        private void MyUndo()
        {
            redoList.Add(richTextBox1.Text);
            redoToolStripMenuItem.Enabled = true;
    
            richTextBox1.Text = (String)undoList[undoList.Count - 1];
            undoList.RemoveAt(undoList.Count - 1);
   

            if (undoList.Count == 1)
            {
                undoToolStripMenuItem.Enabled = false;
            }
        }

        private void UndoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyUndo();
        }

        private void Undo_Click(object sender, EventArgs e)
        {
            MyUndo();
        }

        private void MyRedo()
        {
            richTextBox1.Text = (String)redoList[redoList.Count - 1];
            redoList.RemoveAt(redoList.Count-1);
            if (redoList.Count == 0)
            {
                redoToolStripMenuItem.Enabled = false;
            }

        }

        private void RedoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyRedo();
        }

        private void RedoBtn_Click(object sender, EventArgs e)
        {
            MyRedo();
        }

        private void GoTo()
        {
            
        }

        private void GoToToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GoTo();
        }

        private void GoToBtn_Click(object sender, EventArgs e)
        {
            GoTo();
        }

        private void SelectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();

        }

        private void SelectAllBtn_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void TimeDate()
        {
            richTextBox1.Text = DateTime.Now.ToString("hh:mm:ss tt dd-MM-yyyy");
        }

        private void TimeDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TimeDate();

        }

        private void TimeDateBtn_Click(object sender, EventArgs e)
        {
            TimeDate();
        }

        private void PrintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintDialog printDlg = new PrintDialog();
            PrintDocument printDoc = new PrintDocument
            {
                DocumentName = currentFile
            };
            printDlg.Document = printDoc;
            printDlg.AllowSelection = true;
            printDlg.AllowSomePages = true;

            if (printDlg.ShowDialog() == DialogResult.OK)
                printDoc.Print();
        }

        private void ToolStripComboBox1_Click(object sender, EventArgs e)
        {


        }

        private void FontBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            richTextBox1.Font = new Font(fontBox.SelectedItem.ToString(), textSizeValue);
        }

        private void ToolStripComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            textSizeValue = int.Parse(sizeBox.SelectedItem.ToString());
            richTextBox1.Font = new Font(fontBox.SelectedItem.ToString(), textSizeValue);
        }

        private void FontToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void UnderlineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ApplyStyle(FontStyle.Underline);
        }

        private void UnderLineBtn_Click(object sender, EventArgs e)
        {
            ApplyStyle(FontStyle.Underline);
        }

        private void BoldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ApplyStyle(FontStyle.Bold);
        }

        private void BoldBtn_Click(object sender, EventArgs e)
        {
            ApplyStyle(FontStyle.Bold);
        }

        private void ItalicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ApplyStyle(FontStyle.Italic);
        }

        private void ItalicBtn_Click(object sender, EventArgs e)
        {
            ApplyStyle(FontStyle.Italic);
        }

        private void ImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InsertImage();
        }


        private void InsertImage()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                InitialDirectory = "c:\\",
                Filter = "Image Files|*.bmp;*.jpg;*.jpeg;*.png;*.gif",
                FilterIndex = 1,
                RestoreDirectory = true
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Image img = Image.FromFile(openFileDialog.FileName);
                    Clipboard.SetImage(img);
                    richTextBox1.Paste();
                    Clipboard.Clear();

                    undoList.Add(richTextBox1.Rtf);
                    undoToolStripMenuItem.Enabled = true;
                    redoList.Clear();
                    redoToolStripMenuItem.Enabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while inserting the image: " + ex.Message);
                }
            }
        }

        private void SetAlignment(HorizontalAlignment alignment)
        {
            richTextBox1.SelectionAlignment = alignment;

            undoList.Add(richTextBox1.Rtf);
            undoToolStripMenuItem.Enabled = true;
            redoList.Clear();
            redoToolStripMenuItem.Enabled = false;
        }

        private void LeftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetAlignment(HorizontalAlignment.Left);
        }

        private void RightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetAlignment(HorizontalAlignment.Right);
        }

        private void CenterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetAlignment(HorizontalAlignment.Center);
        }

        private void TableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InsertTable();
        }

        private void InsertTable()
        {
            using (Form TableForm = new Form())
            {
                TableForm.Width = 250;
                TableForm.Height = 150;
                TableForm.Text = "Table";

                Label rowsLabel = new Label() { Left = 10, Top = 10, Text = "Rows" };
                Label columnsLabel = new Label() { Left = 10, Top = 40, Text = "Columns" };
                TextBox rowsTextBox = new TextBox() { Left = 120, Top = 10, Width = 100 };
                TextBox columnsTextBox = new TextBox() { Left = 120, Top = 40, Width = 100 };
                Button confirmation = new Button() { Text = "OK", Left = 120, Width = 50, Top = 70, DialogResult = DialogResult.OK };
                Button confirmation1 = new Button() { Text = "Cancel", Left = 170, Width = 50, Top = 70, DialogResult = DialogResult.Cancel };

                confirmation.Click += (sender, e) => { TableForm.Close(); };

                TableForm.Controls.Add(rowsLabel);
                TableForm.Controls.Add(columnsLabel);
                TableForm.Controls.Add(rowsTextBox);
                TableForm.Controls.Add(columnsTextBox);
                TableForm.Controls.Add(confirmation);
                TableForm.Controls.Add(confirmation1);  
                TableForm.AcceptButton = confirmation;
                TableForm.CancelButton = confirmation1;

                if (TableForm.ShowDialog() == DialogResult.OK)
                {
                    if (int.TryParse(rowsTextBox.Text, out int rows) && int.TryParse(columnsTextBox.Text, out int columns))
                    {
                        string rtfTable = GenerateTable(rows, columns);
                        richTextBox1.SelectedRtf = rtfTable;

                        undoList.Add(richTextBox1.Rtf);
                        undoToolStripMenuItem.Enabled = true;
                        redoList.Clear();
                        redoToolStripMenuItem.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("The input for rows and columns is not valid.");
                    }
                }
            }
        }

        private string GenerateTable(int rows, int columns)
        {
            StringBuilder rtfTable = new StringBuilder();
            rtfTable.Append(@"{\rtf1\trowd");

            int cellWidth = 1000;
            int cellHeight = 200;
            for (int c = 0; c < columns; c++)
            {
                rtfTable.Append(@"\cellx" + (cellWidth * (c + 1)));
            }
            for (int r = 0; r < rows; r++)
            {
                rtfTable.Append(@"\trrh" + cellHeight); 
                for (int c = 0; c < columns; c++)
                {
                    rtfTable.Append(@"\intbl \cell");
                }
                rtfTable.Append(@"\row");
            }
            rtfTable.Append(@"}");

            return rtfTable.ToString();
        }

        private void ChangeTextColor(Color color)
        {
            richTextBox1.SelectionColor = color;

            undoList.Add(richTextBox1.Rtf);
            undoToolStripMenuItem.Enabled = true;
            redoList.Clear();
            redoToolStripMenuItem.Enabled = false;
        }

        private void OrangeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeTextColor(Color.Orange);
        }

        private void RedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeTextColor(Color.Red);
        }

        private void WhiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeTextColor(Color.White);
        }

        private void BlackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeTextColor(Color.Black);
        }

        private void BlueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeTextColor(Color.Blue);
        }

        private void YellowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeTextColor(Color.Yellow);
        }

        private void PinkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeTextColor(Color.Pink);
        }

        private void PurpleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeTextColor(Color.Purple);
        }

        private void GreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeTextColor(Color.Green);
        }

        private void GrayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeTextColor(Color.Gray);
        }

        private void BrownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeTextColor(Color.Brown);
        }
    }
}
