﻿namespace Notepad
{
    partial class ReplaceForm
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
            this.find = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.findText = new System.Windows.Forms.TextBox();
            this.replaceText = new System.Windows.Forms.TextBox();
            this.replaceBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // find
            // 
            this.find.AutoSize = true;
            this.find.Location = new System.Drawing.Point(26, 25);
            this.find.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.find.Name = "find";
            this.find.Size = new System.Drawing.Size(54, 25);
            this.find.TabIndex = 0;
            this.find.Text = "Find";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 85);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Replace with";
            // 
            // findText
            // 
            this.findText.Location = new System.Drawing.Point(310, 25);
            this.findText.Margin = new System.Windows.Forms.Padding(6);
            this.findText.Name = "findText";
            this.findText.Size = new System.Drawing.Size(230, 31);
            this.findText.TabIndex = 2;
            // 
            // replaceText
            // 
            this.replaceText.Location = new System.Drawing.Point(310, 85);
            this.replaceText.Margin = new System.Windows.Forms.Padding(6);
            this.replaceText.Name = "replaceText";
            this.replaceText.Size = new System.Drawing.Size(230, 31);
            this.replaceText.TabIndex = 3;
            // 
            // replaceBtn
            // 
            this.replaceBtn.Location = new System.Drawing.Point(196, 135);
            this.replaceBtn.Margin = new System.Windows.Forms.Padding(6);
            this.replaceBtn.Name = "replaceBtn";
            this.replaceBtn.Size = new System.Drawing.Size(150, 44);
            this.replaceBtn.TabIndex = 4;
            this.replaceBtn.Text = "Replace";
            this.replaceBtn.UseVisualStyleBackColor = true;
            this.replaceBtn.Click += new System.EventHandler(this.ReplaceBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(394, 133);
            this.cancelBtn.Margin = new System.Windows.Forms.Padding(6);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(150, 44);
            this.cancelBtn.TabIndex = 5;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // ReplaceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 200);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.replaceBtn);
            this.Controls.Add(this.replaceText);
            this.Controls.Add(this.findText);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.find);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "ReplaceForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "replaceForm";
            this.Load += new System.EventHandler(this.ReplaceForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label find;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox findText;
        private System.Windows.Forms.TextBox replaceText;
        private System.Windows.Forms.Button replaceBtn;
        private System.Windows.Forms.Button cancelBtn;
    }
}