using COVID_19Calc;
using System;
using System.Windows.Forms;
using System.Threading;

namespace COVID_19Calc
{
    public partial class Form2 : Form
    {
        Thread th;
        Thread thm;
        public Form2()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
            th = new Thread(Opennewform1);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        private void Opennewform1()
        {
#pragma warning disable CA2000 // Dispose objects before losing scope
            Application.Run(new Form1());
#pragma warning restore CA2000 // Dispose objects before losing scope
        }

        private void Opennewform3()
        {
#pragma warning disable CA2000 // Dispose objects before losing scope
            Application.Run(new Form3());
#pragma warning restore CA2000 // Dispose objects before losing scope
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();
            thm = new Thread(Opennewform3);
            thm.SetApartmentState(ApartmentState.STA);
            thm.Start();
        }
    }
}
