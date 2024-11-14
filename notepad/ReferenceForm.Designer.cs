namespace Notepad
{
    partial class ReferenceForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.findAuthor = new System.Windows.Forms.TextBox();
            this.findYear = new System.Windows.Forms.TextBox();
            this.findTitle = new System.Windows.Forms.TextBox();
            this.findPublisher = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(148, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Author";
            // 
            // findAuthor
            // 
            this.findAuthor.Location = new System.Drawing.Point(315, 57);
            this.findAuthor.Name = "findAuthor";
            this.findAuthor.Size = new System.Drawing.Size(265, 31);
            this.findAuthor.TabIndex = 1;
            // 
            // findYear
            // 
            this.findYear.Location = new System.Drawing.Point(315, 109);
            this.findYear.Name = "findYear";
            this.findYear.Size = new System.Drawing.Size(265, 31);
            this.findYear.TabIndex = 2;
            // 
            // findTitle
            // 
            this.findTitle.Location = new System.Drawing.Point(315, 163);
            this.findTitle.Name = "findTitle";
            this.findTitle.Size = new System.Drawing.Size(265, 31);
            this.findTitle.TabIndex = 3;
            // 
            // findPublisher
            // 
            this.findPublisher.Location = new System.Drawing.Point(315, 218);
            this.findPublisher.Name = "findPublisher";
            this.findPublisher.Size = new System.Drawing.Size(265, 31);
            this.findPublisher.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(562, 398);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(106, 40);
            this.button1.TabIndex = 5;
            this.button1.Text = "Next";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.OkBtn_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(674, 398);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 40);
            this.button2.TabIndex = 6;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(148, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 25);
            this.label2.TabIndex = 7;
            this.label2.Text = "Year";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(148, 163);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 25);
            this.label3.TabIndex = 8;
            this.label3.Text = "Title";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(148, 218);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 25);
            this.label4.TabIndex = 9;
            this.label4.Text = "Publisher";
            // 
            // ReferenceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.findPublisher);
            this.Controls.Add(this.findTitle);
            this.Controls.Add(this.findYear);
            this.Controls.Add(this.findAuthor);
            this.Controls.Add(this.label1);
            this.Name = "ReferenceForm";
            this.Text = "reference";
            this.Load += new System.EventHandler(this.ReferenceForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox findAuthor;
        private System.Windows.Forms.TextBox findYear;
        private System.Windows.Forms.TextBox findTitle;
        private System.Windows.Forms.TextBox findPublisher;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}