using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Document
{
    public partial class Chargement : Form
    {
        public Chargement()
        {
            InitializeComponent();
        }
        int Starpointer = -6;
        private void Timer1_Tick(object sender, EventArgs e)
        {
            Starpointer += 6;
            MyprogressBar.Value = Starpointer;
            if (MyprogressBar.Value == 100)
            {
                timer1.Stop();
                this.Hide();
                Connextion obj = new Connextion();
                obj.Show();
            }
        }

        private void Chargement_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
