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
    public partial class Connextion : Form
    {
        Function Con;
        public Connextion()
        {
            InitializeComponent();
            Con = new Function();
        }
        public static int UserId;
        public static string UserName;
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        
        private void ConnexionBtn_Click(object sender, EventArgs e)
        {
            
if (string.IsNullOrEmpty(UserRtb.Text) || string.IsNullOrEmpty(PassWordRtb.Text))
            {
                MessageBox.Show("Veuillez remplir toutes les informations");
            }
            else if (UserRtb.Text == "Admin" && PassWordRtb.Text == "Admin")
            {
                Accueil obj = new Accueil();
                obj.Show();
                this.Hide();
            }
            else
            {
                string req = "SELECT * FROM UtilisateurTbl WHERE UtiMat = '{0}' AND UtiMpasse = '{1}'";
                req = string.Format(req, UserRtb.Text, PassWordRtb.Text);
                DataTable dt = Con.RecupererDonnee(req);

                string req2 = "SELECT * FROM InscriptionTbl WHERE UserName = '{0}' AND UserPassword = '{1}'";
                req2 = string.Format(req2, UserRtb.Text, PassWordRtb.Text);
                DataTable dt2 = Con.RecupererDonnee(req2);

                if (dt.Rows.Count == 0 && dt2.Rows.Count == 0)
                {
                    MessageBox.Show("Utilisateur inexistant");
                }
                else if (dt.Rows.Count > 0)
                {
                    Impression2 obj = new Impression2();
                    obj.Show();
                    this.Hide();
                }
                else if (dt2.Rows.Count > 0)
                {
                    Accueil obj = new Accueil();
                    obj.Show();
                    this.Hide();
                }
            }
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void GunaLinkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Inscription inscription = new Inscription();
            inscription.Show();
            this.Hide();
        }

        private void PassWordRtb_TextChanged(object sender, EventArgs e)
        {
            PassWordRtb.PasswordChar = '*';
        }
    }
}
