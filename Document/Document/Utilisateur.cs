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
    public partial class Utilisateur : Form
    {
        Function Con;
        public Utilisateur()
        {
            InitializeComponent();
            Con = new Function();
            AfficherUtilisateur();
        }
       
        private void AfficherUtilisateur()
        {
            string Req = "Select * from UtilisateurTbl";
            ListeUtilisateur.DataSource = Con.RecupererDonnee(Req);
        }

        private void AjouterBtn_Click(object sender, EventArgs e)
        {
            if (NomRtb.Text == ""|| MatRtb.Text == "" || AddresseRtb.Text == "" ||TelRtb.Text ==""|| MpassRtb.Text =="")
            {
                MessageBox.Show("veuillez entrer toutes les information");
            }
            else
            {
                try
                {
                    string Matricule = MatRtb.Text;
                    string Nom = NomRtb.Text;
                    string Address = AddresseRtb.Text;
                    string Tel = TelRtb.Text;
                    string Mpass = MpassRtb.Text;
                    string Req = "insert into UtilisateurTbl Values ('{0}','{1}','{2}','{3}','{4}')";
                    Req = string.Format(Req, Matricule, Nom, Address, Tel, Mpass);
                    Con.EnvoyerDonner(Req);
                    AfficherUtilisateur();
                    MessageBox.Show("Utilisateur AJouter");
                    MatRtb.Text = "";
                    NomRtb.Text = "";
                    AddresseRtb.Text = "";
                    TelRtb.Text = "";
                    MpassRtb.Text = "";
                }
                catch(Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        int Key = 0;
        private void ListeUtilisateur_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            NomRtb.Text = ListeUtilisateur.SelectedRows[0].Cells[2].Value.ToString();
            MatRtb.Text = ListeUtilisateur.SelectedRows[0].Cells[1].Value.ToString();
            AddresseRtb.Text = ListeUtilisateur.SelectedRows[0].Cells[3].Value.ToString();
            TelRtb.Text = ListeUtilisateur.SelectedRows[0].Cells[4].Value.ToString();
            MpassRtb.Text = ListeUtilisateur.SelectedRows[0].Cells[5].Value.ToString();
            if (NomRtb.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(ListeUtilisateur.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void ModifierBtn_Click(object sender, EventArgs e)
        {
            if (NomRtb.Text == "" || MatRtb.Text == "" || AddresseRtb.Text == "" || TelRtb.Text == "" || MpassRtb.Text == "")
            {
                MessageBox.Show("veuillez entrer toutes les information");
            }
            else
            {
                try
                {
                    string Matricule = MatRtb.Text;
                    string Nom = NomRtb.Text;
                    string Address = AddresseRtb.Text;
                    string Tel = TelRtb.Text;
                    string Mpass = MpassRtb.Text;
                    string Req = "update  UtilisateurTbl set UtiMat = '{0}',UtiNom ='{1}',UtiAddresse = '{2}',UtiTelephone = '{3}',UtiMpasse = '{4}' where UTILId = {5} ";
                    Req = string.Format(Req, Matricule, Nom, Address, Tel, Mpass, Key);
                    Con.EnvoyerDonner(Req);
                    AfficherUtilisateur();
                    MessageBox.Show("Utilisateur Modifier");
                    MatRtb.Text = "";
                    NomRtb.Text = "";
                    AddresseRtb.Text = "";
                    TelRtb.Text = "";
                    MpassRtb.Text = "";
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void SupprimerBtn_Click(object sender, EventArgs e)
        {
            if (NomRtb.Text == "" || MatRtb.Text == "" || AddresseRtb.Text == "" || TelRtb.Text == "" || MpassRtb.Text == "")
            {
                MessageBox.Show("veuillez entrer toutes les information");
            }
            else
            {
                try
                {
                    string Matricule = MatRtb.Text;
                    string Nom = NomRtb.Text;
                    string Address = AddresseRtb.Text;
                    string Tel = TelRtb.Text;
                    string Mpass = MpassRtb.Text;
                    string Req = "delete from UtilisateurTbl  where UTILId = {0} ";
                    Req = string.Format(Req, Key);
                    Con.EnvoyerDonner(Req);
                    AfficherUtilisateur();
                    MessageBox.Show("Utilisateur Supprimer");
                    MatRtb.Text = "";
                    NomRtb.Text = "";
                    AddresseRtb.Text = "";
                    TelRtb.Text = "";
                    MpassRtb.Text = "";
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            Accueil docmentation = new Accueil();
            docmentation.Show();
            this.Hide();
        }

        private void PictureBox3_Click(object sender, EventArgs e)
        {
            Docmentation docmentation = new Docmentation();
            docmentation.Show();
            this.Hide();
        }

        private void PictureBox7_Click(object sender, EventArgs e)
        {
            Categorie docmentation = new Categorie();
            docmentation.Show();
            this.Hide();
        }

        private void PictureBox4_Click(object sender, EventArgs e)
        {
            Impresion docmentation = new Impresion();
            docmentation.Show();
            this.Hide();
        }

        private void PictureBox5_Click(object sender, EventArgs e)
        {
            Connextion docmentation = new Connextion();
            docmentation.Show();
            this.Hide();
        }

        private void PictureBox8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
