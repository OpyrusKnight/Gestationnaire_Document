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
    public partial class Inscription : Form
    {
        Function Con;
        public Inscription()
        {
            InitializeComponent();
            Con = new Function();
        }

        private void NextBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (UserName.Text == "" || UserSurNameRtb.Text == "" || UserRecoryRtb.Text == "" || PasswordRtb.Text == "")
                {
                    MessageBox.Show("Completez le formulaire SVP !!!");
                }
                else if (ConfirmationRtb.Text != PasswordRtb.Text)
                {

                    MessageBox.Show("Informqtion Incorect !!!");
                }
                else
                {
                    string Nom = UserName.Text;
                    string pseudo = UserSurNameRtb.Text;
                    string mdp = UserRecoryRtb.Text;
                    string mdp2 = PasswordRtb.Text;
                    string Req = "insert into InscriptionTbl values ('{0}','{1}','{2}','{3}')";
                    Req = string.Format(Req, Nom, pseudo, mdp, mdp2); ;
                    Con.EnvoyerDonner(Req);
                    MessageBox.Show("Utilisateur Ajoutée !!!");
                    Connextion Obj = new Connextion();
                    Obj.Show();
                    this.Hide();
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }

        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ClearRtb_Click(object sender, EventArgs e)
        {
            UserName.Text = "";
            UserSurNameRtb.Text = "";
            UserRecoryRtb.Text = "";
            PasswordRtb.Text = "";
            ConfirmationRtb.Text = "";
            
        }

        private void Retour_Click(object sender, EventArgs e)
        {
            Connextion connextion = new Connextion();
            connextion.Show();
            this.Hide();
        }
    }
}
