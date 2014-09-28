using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace GlosTrainer
{
    /// <summary>
    /// Represents a word/phrase entry in a dictionary. Each word has a
    /// Swedish dictionary form, an English definition, and a number of
    /// word forms (conjugated verbs, definitive and plural forms of nouns etc.)
    /// These word forms are stored in the wordForms array of strings.. For word forms
    /// that do not have alternate forms, wordForms is empty. 
    /// Ideally we would like to map the array to the WordClass enum somehow, but without 
    /// properties on enums, the only way we can achieve this is to subclass the Word
    /// class once for each word class, currently not a viable option.
    /// The class implements the INotifyPropertyChanged so we can use Words to bind
    /// to SortableBindingLists for use in MainWindow.
    /// </summary>
    [Serializable()]
    public class Word : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        private WordClass.WordClassesEnum _wordClass;
        /// <summary>
        /// Gets or sets the word class for this word. When setting the value,
        /// the OnPropertyChanged event will be called.
        /// </summary>
        public WordClass.WordClassesEnum WordClass 
        {
            get { return _wordClass; }
            set 
            {
                _wordClass = value;
                OnPropertyChanged("WordClass");
            } 
        }

  
        private string _swedishDictionaryForm;
        /// <summary>
        /// Gets or sets the Swedish dictionary form for this word. When setting the value,
        /// the OnPropertyChanged event will be called.
        /// </summary>
        public string SwedishDictionaryForm 
        {
            get { return _swedishDictionaryForm; }
            set 
            {
                _swedishDictionaryForm = value;
                OnPropertyChanged("SwedishDictionaryForm");
            }
        }

        private string _englishDefinition;
        /// <summary>
        /// Gets or sets the English definition for this word. When setting the value,
        /// the OnPropertyChanged event will be called.
        /// </summary>
        public string EnglishDefinition 
        {
            get { return _englishDefinition;  }
            set 
            {
                _englishDefinition = value;
                OnPropertyChanged("EnglishDefinition");
            } 
        }

        private string[] _wordForms;
        /// <summary>
        /// Gets or sets the array of alternative word forms for this word. When setting 
        /// the value to a new reference, the OnPropertyChanged event will be called.
        /// </summary>
        public string[] wordForms 
        {
            get { return _wordForms; }
            set
            {
                _wordForms = value;
                OnPropertyChanged("WordForms");
            }
        }

        /// <summary>
        /// Creates a new "blank" Word. The word class is set to Noun,
        /// the Swedish dictionary form and English definition forms are set
        /// to empty strings, and the wordForm is set to an empty (10-length) array.
        /// </summary>
        // TODO: setting the length of array to 0 will cause a crash in AddOrEditWordForm
        public Word() : this(0, string.Empty, string.Empty, new string[10]) 
        { 
        }

        /// <summary>
        /// Creates a word with the given word class, Swedish dcitionary form, English definition,
        /// and an optional number of alternative forms.
        /// </summary>
        /// <param name="wordClass">the word class of the word</param>
        /// <param name="swedishDictionaryForm">the Swedish Dcitionary form of the word</param>
        /// <param name="englishDefinition">the English definition of the word</param>
        /// <param name="wordForms">an array of alternative word forms</param>
        public Word(WordClass.WordClassesEnum wordClass, string swedishDictionaryForm, string englishDefinition, params string[] wordForms) 
        {
            this.WordClass = wordClass;
            this.SwedishDictionaryForm = swedishDictionaryForm;
            this.EnglishDefinition = englishDefinition;
            this.wordForms = wordForms;
        }

        /// <summary>
        /// Notify the handler when properties have been changed
        /// </summary>
        /// <param name="name"></param>
        protected void OnPropertyChanged(string name) 
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
