using COVID_19Calc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COVID_19Calc
{
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
#pragma warning disable CA2000 // Dispose objects before losing scope
            Application.Run(new Form2());
#pragma warning restore CA2000 // Dispose objects before losing scope
        }
    }
}
