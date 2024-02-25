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
   
    public partial class Categorie : Form
    {
        Function Con;
        public Categorie()
        {
            InitializeComponent();
            Con = new Function();
            AfficherCategorie();
        }
        private void AfficherCategorie()
        {
            string Req = "Select * from CategorieTbl";
            ListeCategorie.DataSource = Con.RecupererDonnee(Req);
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AjouterBtn_Click(object sender, EventArgs e)
        {
            if(NomRtb.Text == "" || DescriptionRtb.Text == "")
            {
                MessageBox.Show("veuillez entrer toutes les information");
            }
            else
            {
                try
                {
                    string Nom = NomRtb.Text;
                    string Description = DescriptionRtb.Text;
                    string Req = "insert into CategorieTbl Values ('{0}','{1}')";
                    Req = string.Format(Req, Nom, Description);
                    Con.EnvoyerDonner(Req);
                    AfficherCategorie();
                    MessageBox.Show("Categorie Ajouter");
                    NomRtb.Text = "";
                    DescriptionRtb.Text = "";
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        int Key = 0;
        private void ListeCategorie_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            NomRtb.Text = ListeCategorie.SelectedRows[0].Cells[1].Value.ToString();
            DescriptionRtb.Text = ListeCategorie.SelectedRows[0].Cells[2].Value.ToString();
            if (NomRtb.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(ListeCategorie.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void ModifierBtn_Click(object sender, EventArgs e)
        {
            if (NomRtb.Text == "" || DescriptionRtb.Text == "")
            {
                MessageBox.Show("veuillez entrer toutes les information");
            }
            else
            {
                try
                {
                    string Nom = NomRtb.Text;
                    string Description = DescriptionRtb.Text;
                    string Req = "Update CategorieTbl set CatNom = '{0}', CatDescription = '{1}' where CatId = {2}  ";
                    Req = string.Format(Req, Nom, Description, Key);
                    Con.EnvoyerDonner(Req);
                    AfficherCategorie();
                    MessageBox.Show("Categorie Modifier");
                    NomRtb.Text = "";
                    DescriptionRtb.Text = "";
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void SupprimerBtn_Click(object sender, EventArgs e)
        {
            if (NomRtb.Text == "" || DescriptionRtb.Text == "")
            {
                MessageBox.Show("veuillez entrer toutes les information");
            }
            else
            {
                try
                {
                    string Nom = NomRtb.Text;
                    string Description = DescriptionRtb.Text;
                    string Req = "delete from CategorieTbl  where CatId = {0}  ";
                    Req = string.Format(Req, Nom, Description, Key);
                    Con.EnvoyerDonner(Req);
                    AfficherCategorie();
                    MessageBox.Show("Categorie Modifier");
                    NomRtb.Text = "";
                    DescriptionRtb.Text = "";
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

        private void PictureBox4_Click(object sender, EventArgs e)
        {
            Impresion docmentation = new Impresion();
            docmentation.Show();
            this.Hide();
        }

        private void PictureBox6_Click(object sender, EventArgs e)
        {
            Utilisateur docmentation = new Utilisateur();
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
