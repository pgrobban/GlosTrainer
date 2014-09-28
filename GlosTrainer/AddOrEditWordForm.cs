using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GlosTrainer
{
    /// <summary>
    /// Represents a form for the user to add or edit a word to the MainWindow word list.
    /// Contains a number of TextBoxes to represent different word forms, accompanied with
    /// Labels for each TextBox and a ComboBox cmbWordClass bound to the WordClass enum as
    /// data source.
    /// The form submits when the user clicks OK (or presses Enter), and cancels when the user
    /// clicks Cancel (or presses the Escape key). There is also a Clear button for the
    /// user the clear the form.
    /// When the user submits, the following validation checks are performed:
    /// - The Swedish dictionary form TextBox cannot be empty
    /// - The English definition TextBox cannot be empty
    /// </summary>
    public partial class AddOrEditWordForm : Form
    {
        /// <summary>
        /// The word the user is currently editing.
        /// </summary>
        public Word SavedWord { get; private set; }

        /// <summary>
        /// Set to true if the user is editing a word, false if creating a new word.
        /// </summary>
        private bool editingMode;

        /// <summary>
        /// Keep the form open if validations fail (i.e. display error messages)
        /// </summary>
        private bool cancelWindowClose = false;

        
        /// <summary>
        /// Creates an AddOrEditWordForm in "add new word mode". All TextBoxes in the form will be empty,
        /// the word class will be set to Noun.
        /// </summary>
        public AddOrEditWordForm() : this(new Word(), false)
        {
        }

        /// <summary>
        /// Creates an AddOrEditWordForm in "edit word mode". All TextBoxes in the form will be given 
        /// text values that are retrieved from the given word. Likewise, cmbWordClass will be set to the word
        /// class of the given word.
        /// </summary>
        /// <param name="editingWord">the word to edit</param>
        public AddOrEditWordForm(Word editingWord) : this(editingWord, true)
        {
        }

        /// <summary>
        /// Internal constructor for common elements of add new word mode and editing mode.
        /// </summary>
        /// <param name="editingWord"></param>
        /// <param name="editingMode"></param>
        private AddOrEditWordForm(Word editingWord, bool editingMode)
        {
            this.SavedWord = editingWord;
            this.editingMode = editingMode;

            this.Text = editingMode ? "Edit word" : "Add new word";

            InitializeComponent();
            this.CenterToScreen();
            cmbWordClass.DataSource = Enum.GetValues(typeof(WordClass.WordClassesEnum));

            // Disable the Swedish dictionary form entry to disable making possible duplicates
            if (editingMode)
                txtSwedishDictionaryForm.Enabled = false;

            this.txtEnglish.Text = editingWord.EnglishDefinition;
            this.cmbWordClass.SelectedIndex = (int)editingWord.WordClass;
            // hack to see if we're adding a new word, then fire the changed selection event to update the default swedish string
            if (editingWord.SwedishDictionaryForm.Equals(string.Empty))
            {
                WordClassChanged(null, null);
            }
            else
            {
                this.txtSwedishDictionaryForm.Text = editingWord.SwedishDictionaryForm;
            }

            // Create textboxes and populate them with data from the editing word
            var textboxes = grpAdvanced.Controls.OfType<TextBox>();
            for (int i = 0; i < textboxes.Count(); i++)
            {
                textboxes.ElementAt(i).Text = editingWord.wordForms[i];
            }
            grpAdvanced.Controls.Add(lblAdvancedHelp);
        }

        /// <summary>
        /// When the cmbWordClass ComboBox has changed its value, call ChangeAdvanceGroupContents
        /// with the WordClassesEnum value matching the new value.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WordClassChanged(object sender, System.EventArgs e)
        {
            int selectedIndex = cmbWordClass.SelectedIndex;
            WordClass.WordClassesEnum wordClassWithSelectedIndex = (WordClass.WordClassesEnum)selectedIndex;
            this.ChangeAdvancedGroupContent(wordClassWithSelectedIndex);
        }

        /// <summary>
        /// Removes all Controls from the Advanced word forms GroupBox and fill it with TextBoxes
        /// and Labels that reflect the WordClass selected in the cmbWordClass.
        /// If enums had properties like in Java...
        /// </summary>
        /// <param name="currentWordClassEnum"></param>
        public void ChangeAdvancedGroupContent(WordClass.WordClassesEnum currentWordClassEnum)
        {
            grpAdvanced.Controls.Clear();
            grpAdvanced.Controls.Add(lblAdvancedHelp);

            WordClass currentWordClass = null;
            switch (currentWordClassEnum)
            {
                case WordClass.WordClassesEnum.Noun:
                    currentWordClass = WordClass.NOUN;
                    break;
                case WordClass.WordClassesEnum.Verb:
                    currentWordClass = WordClass.VERB;
                    break;
                case WordClass.WordClassesEnum.Adjective:
                    currentWordClass = WordClass.ADJECTIVE;
                    break;
                case WordClass.WordClassesEnum.Adverb:
                    currentWordClass = WordClass.ADVERB;
                    break;
                case WordClass.WordClassesEnum.Pronoun:
                    currentWordClass = WordClass.PRONOUN;
                    break;
                case WordClass.WordClassesEnum.Conjunction:
                    currentWordClass = WordClass.CONJUNCTION;
                    break;
                case WordClass.WordClassesEnum.Preposition:
                    currentWordClass = WordClass.PREPOSITUON;
                    break;
                case WordClass.WordClassesEnum.Interjection:
                    currentWordClass = WordClass.INTERJECTION;
                    break;
                case WordClass.WordClassesEnum.Numeral:
                    currentWordClass = WordClass.NUMERAL;
                    break;
                case WordClass.WordClassesEnum.Expression:
                    currentWordClass = WordClass.EXPRESSION;
                    break;
                default:
                    currentWordClass = WordClass.OTHER;
                    break;
            }

            // add a default dictionary help to the word if it exists
            txtSwedishDictionaryForm.Text = currentWordClass.defaultDictionaryForm + " ";
            if (txtSwedishDictionaryForm.Text.Equals(" "))
                txtSwedishDictionaryForm.Text = string.Empty;

            // Start to populated grpAdvanced with TextBoxes and Labels corresponding to the advanced
            // forms of words
            string[] wordForms = currentWordClass.wordFormLabels;
            bool gotWordForms = wordForms.Count() > 0;

            // add some spacing for the help text for dictionary forms, or a text saying that no
            // additional word forms are available for this word class.
            int currentYPos = 50;
         
            if (gotWordForms) 
            {
                Label lblDictionaryFormInfo = new Label();
                lblDictionaryFormInfo.Text = currentWordClass.defaultDictionaryFormInfo;
                grpAdvanced.Controls.Add(lblDictionaryFormInfo);
                lblDictionaryFormInfo.Location = new Point(lblAdvancedHelp.Location.X, currentYPos);
                lblDictionaryFormInfo.AutoSize = true;
                currentYPos += 20;


                foreach (string wordForm in wordForms)
                {
                    Label lbl = new Label();
                    lbl.Text = wordForm + ":";
                    grpAdvanced.Controls.Add(lbl);
                    lbl.Location = new Point(lblAdvancedHelp.Location.X, currentYPos);
                    lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                    lbl.Width = 150;

                    TextBox tb = new TextBox();
                    grpAdvanced.Controls.Add(tb);
                    tb.Location = new Point(txtSwedishDictionaryForm.Location.X, lbl.Location.Y);
                    tb.Size = txtSwedishDictionaryForm.Size;

                    // add some vertical padding
                    currentYPos += lbl.Size.Height + 5;
                }
            }
            else 
            {
                Label infoLabel = new Label();
                infoLabel.Text = "There are no advanced word forms for this word class.";
                grpAdvanced.Controls.Add(infoLabel);
                infoLabel.Location = new Point(lblEnglish.Location.X, currentYPos);
                infoLabel.Width = 300;
            }
        }

        /// <summary>
        /// When the btnClear Button is clicked, invoke the ClearForm() method.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        /// <summary>
        /// Clears the form of any TextBoxes and resets the word class selected to Noun.
        /// </summary>
        private void ClearForm()
        {
            // save swedish dictionary form for editing mode
            string sweDictForm = this.txtSwedishDictionaryForm.Text;

            cmbWordClass.SelectedIndex = 0;
            WordClassChanged(null, null); // temp hack to get the default strings back
            foreach (TextBox tb in this.Controls.OfType<TextBox>())
            {
                tb.Text = string.Empty;
            }

            if (this.editingMode)
                this.txtSwedishDictionaryForm.Text = sweDictForm;
        }

        /// <summary>
        /// When the OK button is clicked, invoke the TrySaveWord() method.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            TrySaveWord();
        }

        /// <summary>
        /// Tries to save the word and close the form if the word is valid. If it is not valif,
        /// an error message dialog will be displayed to the user and the form will not be closed.
        /// A word is valid if:
        /// - the Swedish dictionary form TextBox is not empty
        /// - the Swedish dictionary form does not already exist in the MainWindow word list
        /// - the English difinition TextBox is not empty
        /// </summary>
        public void TrySaveWord()
        {
            string swedishDictionaryForm = txtSwedishDictionaryForm.Text.Trim();
            if (swedishDictionaryForm.Equals(string.Empty))
            {
                MessageBox.Show("The Swedish dictionary form text field is empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.cancelWindowClose = true;
                return;
            }

            string englishDefinition = txtEnglish.Text.Trim();
            if (englishDefinition.Equals(string.Empty))
            {
                MessageBox.Show("The English definition text field is empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.cancelWindowClose = true;
                return;
            }

            // passed the validation, now save the word
            WordClass.WordClassesEnum wordClass = (WordClass.WordClassesEnum)cmbWordClass.SelectedIndex;
            string[] advancedWordForms = GetAdvancedWordFormsArray();
            this.SavedWord = new Word(wordClass, swedishDictionaryForm, englishDefinition, advancedWordForms);
            this.cancelWindowClose = false;
            
        }

        /// <summary>
        /// Retrieves the advanced word forms that the user has entered for this word as an array of strings.
        /// The order of the strings will be the same as they appear in the form.
        /// </summary>
        /// <returns>an array of strings with the advanced word forms</returns>
        public string[] GetAdvancedWordFormsArray() 
        {
            List<string> wordForms = new List<string>();
            foreach (Control c in grpAdvanced.Controls)
            {
                if (c is TextBox)
                {
                    wordForms.Add(c.Text);
                }
            }
            return wordForms.ToArray();
        }

        /// <summary>
        /// Handle window closing events. Cancel the window close if the cancelWindowClose flag is set,
        /// or allow the closing if the user requested a window close (clicking the X button or pressing
        /// the Escape key).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddOrEditWordForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.cancelWindowClose)
                e.Cancel = true;

            if (e.CloseReason == CloseReason.UserClosing)
                e.Cancel = false;
        }

     


    }
}
