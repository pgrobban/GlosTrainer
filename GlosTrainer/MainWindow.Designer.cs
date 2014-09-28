namespace GlosTrainer
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.btnEditSelectedWord = new System.Windows.Forms.Button();
            this.btnAddWord = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnImportList = new System.Windows.Forms.Button();
            this.btnDeleteSelectedWords = new System.Windows.Forms.Button();
            this.chkExact = new System.Windows.Forms.CheckBox();
            this.chkSearchAllForms = new System.Windows.Forms.CheckBox();
            this.dgvWords = new System.Windows.Forms.DataGridView();
            this.lblWordCount = new System.Windows.Forms.Label();
            this.btnExportList = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWords)).BeginInit();
            this.SuspendLayout();
            // 
            // btnEditSelectedWord
            // 
            this.btnEditSelectedWord.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnEditSelectedWord.Image = global::GlosTrainer.Properties.Resources.Pencil_icon;
            this.btnEditSelectedWord.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnEditSelectedWord.Location = new System.Drawing.Point(153, 3);
            this.btnEditSelectedWord.Name = "btnEditSelectedWord";
            this.btnEditSelectedWord.Size = new System.Drawing.Size(144, 24);
            this.btnEditSelectedWord.TabIndex = 9;
            this.btnEditSelectedWord.Text = "Edit selected word";
            this.btnEditSelectedWord.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEditSelectedWord.UseVisualStyleBackColor = true;
            this.btnEditSelectedWord.Click += new System.EventHandler(this.btnEditSelectedWord_Click);
            // 
            // btnAddWord
            // 
            this.btnAddWord.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddWord.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAddWord.Image = global::GlosTrainer.Properties.Resources.Add_icon;
            this.btnAddWord.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnAddWord.Location = new System.Drawing.Point(3, 3);
            this.btnAddWord.MinimumSize = new System.Drawing.Size(140, 0);
            this.btnAddWord.Name = "btnAddWord";
            this.btnAddWord.Size = new System.Drawing.Size(144, 24);
            this.btnAddWord.TabIndex = 1;
            this.btnAddWord.Text = "Add new word";
            this.btnAddWord.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddWord.UseVisualStyleBackColor = true;
            this.btnAddWord.Click += new System.EventHandler(this.btnAddWord_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 7;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.Controls.Add(this.btnImportList, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnDeleteSelectedWords, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnEditSelectedWord, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnAddWord, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.chkExact, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.chkSearchAllForms, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.dgvWords, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblWordCount, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnExportList, 6, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtSearch, 4, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.MinimumSize = new System.Drawing.Size(140, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(842, 462);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btnImportList
            // 
            this.btnImportList.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnImportList.Image = global::GlosTrainer.Properties.Resources.load_upload_icon;
            this.btnImportList.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnImportList.Location = new System.Drawing.Point(3, 435);
            this.btnImportList.MinimumSize = new System.Drawing.Size(140, 0);
            this.btnImportList.Name = "btnImportList";
            this.btnImportList.Size = new System.Drawing.Size(140, 24);
            this.btnImportList.TabIndex = 15;
            this.btnImportList.Text = "Load list from file";
            this.btnImportList.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnImportList.UseVisualStyleBackColor = true;
            this.btnImportList.Click += new System.EventHandler(this.btnImportList_Click);
            // 
            // btnDeleteSelectedWords
            // 
            this.btnDeleteSelectedWords.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnDeleteSelectedWords.Image = global::GlosTrainer.Properties.Resources.Actions_edit_delete_icon;
            this.btnDeleteSelectedWords.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnDeleteSelectedWords.Location = new System.Drawing.Point(303, 3);
            this.btnDeleteSelectedWords.Name = "btnDeleteSelectedWords";
            this.btnDeleteSelectedWords.Size = new System.Drawing.Size(144, 24);
            this.btnDeleteSelectedWords.TabIndex = 10;
            this.btnDeleteSelectedWords.Text = "Delete selected words";
            this.btnDeleteSelectedWords.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDeleteSelectedWords.UseVisualStyleBackColor = true;
            this.btnDeleteSelectedWords.Click += new System.EventHandler(this.btnDeleteSelectedWords_Click);
            // 
            // chkExact
            // 
            this.chkExact.AutoSize = true;
            this.chkExact.Checked = true;
            this.chkExact.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkExact.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkExact.Location = new System.Drawing.Point(625, 3);
            this.chkExact.Name = "chkExact";
            this.chkExact.Size = new System.Drawing.Size(64, 24);
            this.chkExact.TabIndex = 12;
            this.chkExact.Text = "Exact?";
            this.chkExact.UseVisualStyleBackColor = true;
            // 
            // chkSearchAllForms
            // 
            this.chkSearchAllForms.AutoSize = true;
            this.chkSearchAllForms.Checked = true;
            this.chkSearchAllForms.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSearchAllForms.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkSearchAllForms.Location = new System.Drawing.Point(695, 3);
            this.chkSearchAllForms.Name = "chkSearchAllForms";
            this.chkSearchAllForms.Size = new System.Drawing.Size(144, 24);
            this.chkSearchAllForms.TabIndex = 13;
            this.chkSearchAllForms.Text = "All forms?";
            this.chkSearchAllForms.UseVisualStyleBackColor = true;
            // 
            // dgvWords
            // 
            this.dgvWords.AllowUserToAddRows = false;
            this.dgvWords.AllowUserToDeleteRows = false;
            this.dgvWords.AllowUserToOrderColumns = true;
            this.dgvWords.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvWords.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvWords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableLayoutPanel1.SetColumnSpan(this.dgvWords, 7);
            this.dgvWords.Location = new System.Drawing.Point(3, 33);
            this.dgvWords.Name = "dgvWords";
            this.dgvWords.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvWords.Size = new System.Drawing.Size(836, 396);
            this.dgvWords.TabIndex = 14;
            this.dgvWords.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvWords_CellContentClick);
            this.dgvWords.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvWords_KeyDown);
            // 
            // lblWordCount
            // 
            this.lblWordCount.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.lblWordCount, 3);
            this.lblWordCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblWordCount.Location = new System.Drawing.Point(303, 432);
            this.lblWordCount.Name = "lblWordCount";
            this.lblWordCount.Size = new System.Drawing.Size(316, 30);
            this.lblWordCount.TabIndex = 16;
            this.lblWordCount.Text = "0 items in list";
            this.lblWordCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnExportList
            // 
            this.btnExportList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportList.Enabled = false;
            this.btnExportList.Image = global::GlosTrainer.Properties.Resources.load_download_icon;
            this.btnExportList.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnExportList.Location = new System.Drawing.Point(695, 435);
            this.btnExportList.Name = "btnExportList";
            this.btnExportList.Size = new System.Drawing.Size(144, 23);
            this.btnExportList.TabIndex = 17;
            this.btnExportList.Text = "Save list to file";
            this.btnExportList.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExportList.UseVisualStyleBackColor = true;
            this.btnExportList.Click += new System.EventHandler(this.btnExportList_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(497, 5);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(122, 20);
            this.txtSearch.TabIndex = 11;
            this.txtSearch.Text = "Search list...";
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(842, 462);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(850, 500);
            this.Name = "MainWindow";
            this.Text = "Robban\'s GlosTrainer v.1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.Resize += new System.EventHandler(this.MainWindow_Resize);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWords)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnEditSelectedWord;
        private System.Windows.Forms.Button btnAddWord;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnDeleteSelectedWords;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.CheckBox chkExact;
        private System.Windows.Forms.CheckBox chkSearchAllForms;
        private System.Windows.Forms.DataGridView dgvWords;
        private System.Windows.Forms.Button btnImportList;
        private System.Windows.Forms.Label lblWordCount;
        private System.Windows.Forms.Button btnExportList;

    }
}