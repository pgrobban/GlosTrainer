using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GlosTrainer
{
    /// <summary>
    /// GlosTrainer is a small application for learners of Swedish to write word lists in.
    /// It has a main window (a Form) that allows searching and sorting the list, as well
    /// as importing and epxorting lists to XML files. There is also another form,
    /// AddOrEditForm, which allows the user to add new words or edit words as they learn
    /// new word forms.
    /// </summary>
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWindow());
        }
    }
}
