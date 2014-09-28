using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlosTrainer
{
    /// <summary>
    /// Represents a word class from the perspective of the program. Ideally you
    /// only have to bother with the WordClassEnum - we would like to map this enum
    /// to some properties like in Java's full-fledged enum classes, but we can't 
    /// in C# so I created static members of this class instead.
    /// A word class has an array of strings that tell the program which word forms 
    /// words in this word class have to display as labels in AddOrEditWordForm,
    /// as well as hints for setting the default value of the Swedish definition form
    /// to hint for the user.
    /// </summary>
    public class WordClass
    {

        public enum WordClassesEnum 
        { 
            Noun,
            Verb,
            Adjective,
            Adverb,
            Pronoun,
            Numeral,
            Conjunction,
            Interjection,
            Preposition,
            Expression,
            Other,
        }

        private string[] _wordFormLabels;
        public string[] wordFormLabels 
        {
            get { return _wordFormLabels; } 
        }

        private string _defaultDictionaryForm;
        public string defaultDictionaryForm 
        {
            get { return _defaultDictionaryForm; } 
        }

        private string _defaultDictionaryFormInfo;
        public string defaultDictionaryFormInfo
        {
            get { return _defaultDictionaryFormInfo; }
        }


        private WordClass(string[] wordFormLabels, string defaultDictionaryForm, string defaultDictionaryFormInfo) 
        {
            this._wordFormLabels = wordFormLabels;
            this._defaultDictionaryForm = defaultDictionaryForm;
            this._defaultDictionaryFormInfo = defaultDictionaryFormInfo;
        }

        private static string[] nounFormLabels = new string[] { "Definite singular", "Indefinite plural", "Definite plural", };
        private static string[] verbFormLabels = new string[] { "Present tense", "Past tense", "Supinum (perfect tense)", "Imperative", "Passive" };
        private static string[] adjectiveFormLabels = new string[] { "ett-form", "Defnitive && plural form", "Comparative", "Superlative", "Superlative definitive" };
        private static string[] pronounFormLabels = new string[] { "Object form", "Posessive form" };


        public static WordClass NOUN = new WordClass(nounFormLabels, "en/ett", "The dictionary form of a noun is the indefinite singular of the noun.");
        public static WordClass VERB = new WordClass(verbFormLabels, "att", "The dictionary form of a verb is the att-form of the verb.");
        public static WordClass ADJECTIVE = new WordClass(adjectiveFormLabels, "", "The dictionary form of an adjective is its en-word form.");
        public static WordClass ADVERB = new WordClass(new string[] { }, "", "");
        public static WordClass PRONOUN = new WordClass(pronounFormLabels, "", "Not all pronouns have object or posessive forms.");
        public static WordClass NUMERAL = new WordClass(new string[] { "Ordinal" }, "", "The dictionary form of a numeral is its cardinal form.");
        public static WordClass CONJUNCTION = new WordClass(new string[] { }, "", "");
        public static WordClass INTERJECTION = new WordClass(new string[] { }, "", "");
        public static WordClass PREPOSITUON = new WordClass(new string[] { }, "", "");
        public static WordClass EXPRESSION = new WordClass(new string[] { "Literal meaning" }, "", "Here you can add a proverb, expression, figure of speech, metaphors and so on.");
        public static WordClass OTHER = new WordClass(new string[] { }, "", "");


    }

  
}
