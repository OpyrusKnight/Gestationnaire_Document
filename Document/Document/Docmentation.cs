using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Document
{
    public partial class Docmentation : Form
    {
        Function Con;
        public Docmentation()
        {
            InitializeComponent();
            Con = new Function();
            remplirCategorie();
            ListerDocument();
            
        }
        private void remplirCategorie()
        {
            string Req = "select * from CategorieTbl";
            CategorieCb.DisplayMember = Con.RecupererDonnee(Req).Columns["CatNom"].ToString();
            CategorieCb.ValueMember = Con.RecupererDonnee(Req).Columns["CatId"].ToString();
            CategorieCb.DataSource = Con.RecupererDonnee(Req);
            TrieCb.DisplayMember = Con.RecupererDonnee(Req).Columns["CatNom"].ToString();
            TrieCb.ValueMember = Con.RecupererDonnee(Req).Columns["CatId"].ToString();
            TrieCb.DataSource = Con.RecupererDonnee(Req);
        }
        private void ListerDocument()
        {
            string Req = "Select * from DocumentTbl";
            ListeDocument.DataSource = Con.RecupererDonnee(Req);
        }

        private void Filtrage()
        {
            string Req = "Select * from DocumentTbl where Dcat = {0}";
            int Cat = Convert.ToInt32(TrieCb.SelectedValue.ToString());
            Req = string.Format(Req, Cat);
            ListeDocument.DataSource = Con.RecupererDonnee(Req);
        }
        private void AjouterBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (NomRtb.Text == "" || MatRtb.Text == "" || CategorieCb.SelectedIndex == -1)
                {
                    MessageBox.Show("veuillez entrer toute les information");
                }
                else
                {
                    string Nom = NomRtb.Text;
                    string Matricule = MatRtb.Text;
                    int Cat = Convert.ToInt32(CategorieCb.SelectedValue.ToString());
                    string Date = ExpDate.Value.ToString();
                    string Req = "insert into DocumentTbl Values('{0}','{1}','{2}','{3}')";
                    Req = string.Format(Req, Matricule, Nom,  Cat, Date);
                    Con.EnvoyerDonner(Req);
                    ListerDocument();
                    MessageBox.Show("Categorie Ajouter");
                    NomRtb.Text = "";
                    MatRtb.Text = "";
                }
            }catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
        int Key = 0;
        private void ModifierBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (NomRtb.Text == "" || MatRtb.Text == "" || CategorieCb.SelectedIndex == -1)
                {
                    MessageBox.Show("veuillez entrer toute les information");
                }
                else
                {
                    string Nom = NomRtb.Text;
                    string Matricule = MatRtb.Text;
                    int Cat = Convert.ToInt32(CategorieCb.SelectedValue.ToString());
                    string Date = ExpDate.Value.ToString();
                    string Req = "update  DocumentTbl set DMat = '{0}',DNom = '{1}', Dcat = '{2}',Ddate = '{3}' where DId = {4}";
                    Req = string.Format(Req, Matricule, Nom, Cat, Date,Key);
                    Con.EnvoyerDonner(Req);
                    ListerDocument();
                    MessageBox.Show("Categorie Modifier");
                    NomRtb.Text = "";
                    MatRtb.Text = "";
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void ListeDocument_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            NomRtb.Text = ListeDocument.SelectedRows[0].Cells[2].Value.ToString();
            MatRtb.Text = ListeDocument.SelectedRows[0].Cells[1].Value.ToString();
            if (NomRtb.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(ListeDocument.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void SupprimerBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (NomRtb.Text == "" || MatRtb.Text == "" || CategorieCb.SelectedIndex == -1)
                {
                    MessageBox.Show("veuillez entrer toute les information");
                }
                else
                {
                    string Nom = NomRtb.Text;
                    string Matricule = MatRtb.Text;
                    int Cat = Convert.ToInt32(CategorieCb.SelectedValue.ToString());
                    string Date = ExpDate.Value.ToString();
                    string Req = "delete from DocumentTbl  where DId = {0}";
                    Req = string.Format(Req, Key);
                    Con.EnvoyerDonner(Req);
                    ListerDocument();
                    MessageBox.Show("Categorie Modifier");
                    NomRtb.Text = "";
                    MatRtb.Text = "";
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void ImporteBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true; // Permettre la sélection multiple de fichiers
            openFileDialog.Filter = "Fichiers texte (*.txt)|*.txt|Fichiers PDF (*.pdf)|*.pdf|Fichiers Excel (*.xls;*.xlsx)|*.xls;*.xlsx|Tous les fichiers (*.*)|*.*"; // Filtre pour les types de fichiers à importer

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string destinationFolder = @"C:\Users\Frank\Documents\cours\"; // Spécifiez le dossier de destination souhaité dans votre application

                foreach (string fileName in openFileDialog.FileNames)
                {
                    string destinationPath = Path.Combine(destinationFolder, Path.GetFileName(fileName));

                    try
                    {
                        File.Copy(fileName, destinationPath);
                        // Le fichier a été copié avec succès

                        // Ajouter le nom du fichier au TextBox NomRtb
                        NomRtb.AppendText(Path.GetFileName(fileName) + Environment.NewLine);
                    }
                    catch (Exception ex)
                    {
                        // Gérer les erreurs de copie de fichier
                        MessageBox.Show($"Une erreur s'est produite lors de la copie du fichier : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                // Afficher un message de réussite lorsque tous les fichiers sont importés
                MessageBox.Show("Les fichiers ont été importés avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            }

        }

        private void TrieBtn_Click(object sender, EventArgs e)
        {
            ListerDocument();
        }

        private void CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void TrieCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            Filtrage();
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            Accueil docmentation = new Accueil();
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
