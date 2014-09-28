using System;
using System.Windows.Forms;
using System.Drawing;

namespace GlosTrainer
{
    partial class AddOrEditWordForm
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
            this.grpBasicInfo = new System.Windows.Forms.GroupBox();
            this.txtEnglish = new System.Windows.Forms.TextBox();
            this.txtSwedishDictionaryForm = new System.Windows.Forms.TextBox();
            this.lblEnglish = new System.Windows.Forms.Label();
            this.lblWordClass = new System.Windows.Forms.Label();
            this.cmbWordClass = new System.Windows.Forms.ComboBox();
            this.lblSwedishDictionaryForm = new System.Windows.Forms.Label();
            this.grpAdvanced = new System.Windows.Forms.GroupBox();
            this.lblAdvancedHelp = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.grpBasicInfo.SuspendLayout();
            this.grpAdvanced.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpBasicInfo
            // 
            this.grpBasicInfo.Controls.Add(this.txtEnglish);
            this.grpBasicInfo.Controls.Add(this.txtSwedishDictionaryForm);
            this.grpBasicInfo.Controls.Add(this.lblEnglish);
            this.grpBasicInfo.Controls.Add(this.lblWordClass);
            this.grpBasicInfo.Controls.Add(this.cmbWordClass);
            this.grpBasicInfo.Controls.Add(this.lblSwedishDictionaryForm);
            this.grpBasicInfo.Location = new System.Drawing.Point(12, 12);
            this.grpBasicInfo.Name = "grpBasicInfo";
            this.grpBasicInfo.Size = new System.Drawing.Size(383, 100);
            this.grpBasicInfo.TabIndex = 0;
            this.grpBasicInfo.TabStop = false;
            this.grpBasicInfo.Text = "Basic word info (required)";
            // 
            // txtEnglish
            // 
            this.txtEnglish.Location = new System.Drawing.Point(160, 71);
            this.txtEnglish.Name = "txtEnglish";
            this.txtEnglish.Size = new System.Drawing.Size(217, 20);
            this.txtEnglish.TabIndex = 3;
            // 
            // txtSwedishDictionaryForm
            // 
            this.txtSwedishDictionaryForm.Location = new System.Drawing.Point(160, 45);
            this.txtSwedishDictionaryForm.Name = "txtSwedishDictionaryForm";
            this.txtSwedishDictionaryForm.Size = new System.Drawing.Size(217, 20);
            this.txtSwedishDictionaryForm.TabIndex = 1;
            // 
            // lblEnglish
            // 
            this.lblEnglish.AutoSize = true;
            this.lblEnglish.Location = new System.Drawing.Point(6, 74);
            this.lblEnglish.Name = "lblEnglish";
            this.lblEnglish.Size = new System.Drawing.Size(89, 13);
            this.lblEnglish.TabIndex = 2;
            this.lblEnglish.Text = "English definition:";
            // 
            // lblWordClass
            // 
            this.lblWordClass.AutoSize = true;
            this.lblWordClass.Location = new System.Drawing.Point(6, 21);
            this.lblWordClass.Name = "lblWordClass";
            this.lblWordClass.Size = new System.Drawing.Size(63, 13);
            this.lblWordClass.TabIndex = 4;
            this.lblWordClass.Text = "Word class:";
            // 
            // cmbWordClass
            // 
            this.cmbWordClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWordClass.Location = new System.Drawing.Point(160, 13);
            this.cmbWordClass.Name = "cmbWordClass";
            this.cmbWordClass.Size = new System.Drawing.Size(217, 21);
            this.cmbWordClass.TabIndex = 5;
            this.cmbWordClass.SelectedIndexChanged += new System.EventHandler(this.WordClassChanged);
            // 
            // lblSwedishDictionaryForm
            // 
            this.lblSwedishDictionaryForm.AutoSize = true;
            this.lblSwedishDictionaryForm.Location = new System.Drawing.Point(6, 48);
            this.lblSwedishDictionaryForm.Name = "lblSwedishDictionaryForm";
            this.lblSwedishDictionaryForm.Size = new System.Drawing.Size(121, 13);
            this.lblSwedishDictionaryForm.TabIndex = 0;
            this.lblSwedishDictionaryForm.Text = "Swedish dictionary form:";
            // 
            // grpAdvanced
            // 
            this.grpAdvanced.Controls.Add(this.lblAdvancedHelp);
            this.grpAdvanced.Location = new System.Drawing.Point(12, 118);
            this.grpAdvanced.Name = "grpAdvanced";
            this.grpAdvanced.Size = new System.Drawing.Size(383, 221);
            this.grpAdvanced.TabIndex = 1;
            this.grpAdvanced.TabStop = false;
            this.grpAdvanced.Text = "Advanced word forms";
            // 
            // lblAdvancedHelp
            // 
            this.lblAdvancedHelp.Location = new System.Drawing.Point(6, 16);
            this.lblAdvancedHelp.Name = "lblAdvancedHelp";
            this.lblAdvancedHelp.Size = new System.Drawing.Size(371, 28);
            this.lblAdvancedHelp.TabIndex = 0;
            this.lblAdvancedHelp.Text = "Fill in as many forms of the word as you have learned, then edit this word when y" +
    "ou have learned more.";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(12, 422);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(172, 422);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(320, 422);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // AddOrEditWordForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(407, 457);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.grpAdvanced);
            this.Controls.Add(this.grpBasicInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AddOrEditWordForm";
            this.Text = "Add or edit word";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddOrEditWordForm_FormClosing);
            this.grpBasicInfo.ResumeLayout(false);
            this.grpBasicInfo.PerformLayout();
            this.grpAdvanced.ResumeLayout(false);
            this.ResumeLayout(false);

        }




        #endregion

        private System.Windows.Forms.GroupBox grpBasicInfo;
        private System.Windows.Forms.ComboBox cmbWordClass;
        private System.Windows.Forms.Label lblWordClass;
        private System.Windows.Forms.TextBox txtEnglish;
        private System.Windows.Forms.Label lblEnglish;
        private System.Windows.Forms.TextBox txtSwedishDictionaryForm;
        private System.Windows.Forms.Label lblSwedishDictionaryForm;
        private System.Windows.Forms.GroupBox grpAdvanced;
        private Label lblAdvancedHelp;
        private Button btnCancel;
        private Button btnClear;
        private Button btnOK;

    }
}