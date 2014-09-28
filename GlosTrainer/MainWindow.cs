using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace GlosTrainer
{
    /// <summary>
    /// The main window of the applicaiton. This is a GUI consisting of:
    /// - Buttons for adding, editing and deleting words, as well as importing and exporting
    /// lists from/to file. These variables have names prefixed by btn.
    /// - A DataGridView named dgvWords which shows the words in the word list for the user
    /// in a table-like manner. dgvWords is bound to a a SortableBindingList (variable wordList)
    /// for retrieval and update of words. The table shows the following columns for the user:
    /// Swedish dictionary form, English definition and word class.
    /// - A label lblWordCount showing the number of words currently in the word list.
    /// - A Textbox txtSearch which allows users to search for words. The search will be
    /// performed after the user has pressed enter and will be displayed as highlighted rows
    /// in the DataGridView. The search results can be narrrowed down using the two checkboxes
    /// below.
    /// - Two Checkboxes, chkExact and chkSearchAllForms to refine search results: if chkExact
    /// is checked, only exact word matches will be counted; if chkSearchAllForms is checked,
    /// the search will consider all alternative word forms.
    /// 
    /// TODO: Add a sort glyph to dgvWords to hint for the user that the columns are sortable
    /// </summary>
    public partial class MainWindow : Form
    {
        /// <summary>
        /// The word list bound to the dgvWordList DataGridView to store, retrieve and delete
        /// words. It is sortable, so words in the list will be sorted when the user clicks on
        /// the column headers of the DataGridView.
        /// </summary>
        // TODO: fix so we won't need to send this to AddOrEditWordForm
        private SortableBindingList<Word> wordList = new SortableBindingList<Word>();

        public MainWindow()
        {
            InitializeComponent();
            this.CenterToScreen();

            // Create a placeholder toggle for the saarch box.
            txtSearch.GotFocus += this.RemoveText;
            txtSearch.LostFocus += this.AddText;

            dgvWords.AutoGenerateColumns = false;
            dgvWords.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            /*
             * Manually create the DataGridView columns. This is for three reasons:
             * - We need to bind the table with the respective property values of Words
             * - Set the columns to ReadOnly since we want to open the edit window to reveal
             * all word forms when the user clicks on the row
             * - Set the width of the column so that the Swedish dictionary form and
             * English definition columns are wider than the Word class column
             */
            // Swedish dictionary form column
            DataGridViewTextBoxColumn colSwedish = new DataGridViewTextBoxColumn()
            {
                Name = "SwedishDictionaryForm",
                HeaderText = "Swedish dictionary form",
                DataPropertyName = "SwedishDictionaryForm",
                ReadOnly = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                Width = (int)(dgvWords.Width * 0.4),
            };
            dgvWords.Columns.Add(colSwedish);
            // English definition column
            DataGridViewTextBoxColumn colEnglish = new DataGridViewTextBoxColumn()
            {
                Name = "EnglishDefinition",
                HeaderText = "English definition",
                DataPropertyName = "EnglishDefinition",
                ReadOnly = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                Width = (int)(dgvWords.Width * 0.4),
            };
            dgvWords.Columns.Add(colEnglish);
            // Word class column
            DataGridViewTextBoxColumn colWordClass = new DataGridViewTextBoxColumn()
            {
                Name = "WordClass",
                HeaderText = "Word class",
                DataPropertyName = "WordClass",
                SortMode = DataGridViewColumnSortMode.Automatic,
                ReadOnly = true,
            };
            dgvWords.Columns.Add(colWordClass);
            // bind the SortableBindingList as DataSource to the DataGridView
            dgvWords.DataSource = wordList;
        }

        /// <summary>
        /// Removes the placeholder text from the txtSearch TextBox. For use when the TextBox got focus.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveText(object sender, EventArgs e)
        {
            this.txtSearch.Text = string.Empty;
            this.txtSearch.Font = new System.Drawing.Font(txtSearch.Font, System.Drawing.FontStyle.Regular);
        }

        /// <summary>
        /// Adds the placeholder text to the txtSearch TextBox. For use when the TextBox regained focus.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddText(object sender, EventArgs e)
        {
            if (this.txtSearch.Text.Equals(string.Empty))
            {
                this.txtSearch.Text = "Search list...";
                this.txtSearch.Font = new System.Drawing.Font(txtSearch.Font, System.Drawing.FontStyle.Italic);
            }
        }


        /// <summary>
        /// Handles click events for the cells. Currently this listens for double click events
        /// and opens the Edit word form for the Word at the clicked row. 
        /// Click events for the header row are handled in dgvWords_CellMouseDown.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvWords_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // if clicked on column header, we will sort the columns instead
            if (e.RowIndex == -1)
                return;

            int updateIndex = e.RowIndex;
            Word selectedWord = wordList[updateIndex];
            EditWord(selectedWord);
        }

        /// <summary>
        /// When the Add new word button is clicked, call the AddNewWord method.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddWord_Click(object sender, EventArgs e)
        {
            AddNewWord();
        }

        /// <summary>
        /// Displays the Add new word Form and waiting for the user to finish filling 
        /// out the form or cancel it. If the user has finished filling out the form,
        /// add the word to the bound word list of the DataGridView.
        /// </summary>
        public void AddNewWord()
        {
            dgvWords.ClearSelection();
            AddOrEditWordForm form = new AddOrEditWordForm();
            form.Text = "Add new word";

            DialogResult newWordResult = form.ShowDialog();
            if (newWordResult == DialogResult.OK)
            {
                wordList.Add(form.SavedWord);
                this.UpdateWordCountLabel();
                dgvWords.Focus();
            }
            this.btnExportList.Enabled = true;
        }

        /// <summary>
        /// Shows an Edit word Form for a given Word. This is a variant of the AddOrEditForm Form
        /// with the title text changed and the form pre-filled in with the previous entries
        /// for this Word. When the user has finished filling out the form, the properties
        /// of the Word will be given the new values from the respective TextBox values.
        /// </summary>
        /// <param name="selectedWord"></param>
        public void EditWord(Word selectedWord)
        {
            AddOrEditWordForm form = new AddOrEditWordForm(selectedWord);
            form.Text = "Edit word";

            DialogResult newWordResult = form.ShowDialog();
            // If the user finished filling out the form, overwrite the properties of the word
            if (newWordResult == DialogResult.OK)
            {
                Word savedWord = form.SavedWord;
                selectedWord.SwedishDictionaryForm = savedWord.SwedishDictionaryForm;
                selectedWord.EnglishDefinition = savedWord.EnglishDefinition;
                selectedWord.WordClass = savedWord.WordClass;
                selectedWord.wordForms = savedWord.wordForms;
                dgvWords.Focus();
            }
        }

        /// <summary>
        /// Updates the lblWordCount Label to reflect the new number of words in the
        /// wordList list.
        /// </summary>
        public void UpdateWordCountLabel()
        {
            if (wordList.Count() == 1)
                lblWordCount.Text = "1 word in list";
            else
                lblWordCount.Text = wordList.Count() + " words in list";
        }

        /// <summary>
        /// Calls the DeleteSelectedWords() method.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteSelectedWords_Click(object sender, EventArgs e)
        {
            DeleteSelectedWords();
        }

        /// <summary>
        /// Asks the user for confirmation and if affirmative, deletes the selected
        /// rows in the dgvWords table. Does nothing if the user hasn't selected
        /// any rows.
        /// </summary>
        public void DeleteSelectedWords()
        {
            DataGridViewSelectedRowCollection selectedRows = dgvWords.SelectedRows;

            if (selectedRows.Count == 0)
                return;

            DialogResult confirmDeletionResult = MessageBox.Show("Are you sure you want to delete " + selectedRows.Count + " word(s)?", "Delete words", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirmDeletionResult == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in selectedRows)
                {
                    wordList.RemoveAt(row.Index);
                }
                UpdateWordCountLabel();

                if (this.wordList.Count() == 0)
                {
                    btnExportList.Enabled = false;
                }
            }

        }

        /// <summary>
        /// Handles key events for the Form:
        /// - Pressing Enter will open an Edit word Form if the user has selected one row
        /// - Pressing the Delete key will ask the user for confirmation on deleting the word
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvWords_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    e.Handled = true;
                    if (dgvWords.SelectedRows.Count == 1)
                    {
                        int updateIndex = dgvWords.SelectedRows[0].Index;
                        Word selectedWord = wordList[updateIndex];
                        EditWord(selectedWord);
                    }
                    else
                    {
                        MessageBox.Show("Please select only one row to edit a word.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    break;
                case Keys.Delete:
                    DeleteSelectedWords();
                    break;
            }
        }

        /// <summary>
        /// Handles clicks on the Edit word button. Calls EditWord with the Word on the selected
        /// row, or shows an error message if 0 or more than one row are selected.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEditSelectedWord_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection selectedRows = dgvWords.SelectedRows;
            if (selectedRows.Count == 0)
            {
                MessageBox.Show("No word selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (selectedRows.Count > 1)
            {
                MessageBox.Show("Select only one word.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Word wordToEdit = this.wordList[selectedRows[0].Index];
                EditWord(wordToEdit);
            }
        }

        /// <summary>
        /// Handles key events for the txtSearch TextBox. When the user pressed the Enter key,
        /// call the SearchAndDisplayResults method with the entered text as a search string.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchAndDisplayResults(txtSearch.Text, chkExact.Checked, chkSearchAllForms.Checked);
            }
        }

        /// <summary>
        /// Performs a search in the wordList List on the given search string and options for exact search
        /// and search in all words. Results will be shown as selected rows in the DataGridView dgvWords.
        /// By default, the Swedish dictionary form and English definition properties are considered for the result.
        /// If exactSearch is set to truem words must be matched in the list as
        /// returned by the .Equals() method on the strings. If set to false, words will match if they are
        /// returned true by the .Contains() method on the string.
        /// If searchAllWordForms is set to true, any of the word forms are also considered in the result.
        /// </summary>
        /// <param name="searchValue">the search string</param>
        /// <param name="exactSearch">if the search needs to match exactly></param>
        /// <param name="searchAllWordForms">if all word forms should be considered</param>
        /// TODO: nicer?
        public void SearchAndDisplayResults(string searchValue, bool exactSearch, bool searchAllWordForms)
        {
            dgvWords.ClearSelection();
            foreach (DataGridViewRow row in dgvWords.Rows)
            {
                Word wordAtRow = wordList[row.Index];
                if (exactSearch)
                {
                    if (wordAtRow.SwedishDictionaryForm.Equals(searchValue) || wordAtRow.EnglishDefinition.Equals(searchValue))
                    {
                        row.Selected = true;
                    }
                }
                else
                {
                    if (wordAtRow.SwedishDictionaryForm.Contains(searchValue) || wordAtRow.EnglishDefinition.Contains(searchValue))
                    {
                        row.Selected = true;
                    }
                }

                if (searchAllWordForms)
                {
                    if (exactSearch)
                    {
                        foreach (string wordform in wordAtRow.wordForms)
                        {
                            if (wordform.Equals(searchValue))
                            {
                                row.Selected = true;
                            }
                        }
                    }
                    else
                    {
                        foreach (string wordform in wordAtRow.wordForms)
                        {
                            if (wordform.Contains(searchValue))
                            {
                                row.Selected = true;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// When the btnExportList button is clicked, call the TrySaveList method.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExportList_Click(object sender, EventArgs e)
        {
            TrySaveList();
        }

        /// <summary>
        /// Asks the user for a location to save the word list as an XML file. Will display
        /// an error if an exception occurred, or do nothing if the user cancelled the action.
        /// </summary>
        public void TrySaveList()
        {
            SaveFileDialog sd = new SaveFileDialog();
            sd.FileName = "mylist.xml";
            Stream stream;

            if (sd.ShowDialog() == DialogResult.OK)
            {
                if ((stream = sd.OpenFile()) != null)
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(SortableBindingList<Word>));
                    serializer.Serialize(stream, wordList);
                    stream.Close();
                }
            }
        }

        /// <summary>
        /// When the btnImportList button is clicked, call the TryImportList() method.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnImportList_Click(object sender, EventArgs e)
        {
            TryImportList();
        }

        /// <summary>
        /// Open an OpenFileDialog and ask the user for an XML file to import from and set as
        /// data source for the DataGridView. Will show an error message to the user if an 
        /// exception occurred, or do nothing if the user closed the dialog.
        /// </summary>
        public void TryImportList()
        {
            OpenFileDialog of = new OpenFileDialog();
            Stream stream;

            if (of.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((stream = of.OpenFile()) != null)
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(SortableBindingList<Word>));
                        wordList = (SortableBindingList<Word>)serializer.Deserialize(stream);
                        dgvWords.DataSource = wordList;
                        stream.Close();

                        btnExportList.Enabled = true;
                        dgvWords.Focus();
                        this.UpdateWordCountLabel();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("There was an error reading from the file: " + ex.Message);
                }

            }
        }

        /// <summary>
        /// As the user resizes the window, try to resize the columns appropriately. Currently 
        /// they match the initial proportions (40+40+20%)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainWindow_Resize(object sender, EventArgs e)
        {
            // resize columns
            dgvWords.Columns["SwedishDictionaryForm"].Width = (int)(0.4 * this.Width);
            dgvWords.Columns["EnglishDefinition"].Width = (int)(0.4 * this.Width);
        }

        /// <summary>
        /// Ask the user for confirmation to close.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you really want to close GloseTrainer? All your unsaved words will be lost.", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

    }
}
