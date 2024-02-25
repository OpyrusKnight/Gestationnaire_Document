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
    public partial class Impression2 : Form
    {
        Function con;
        public Impression2()
        {
            InitializeComponent();
            con = new Function();
            remplirCategorie();
            ListerDocument();
        }
        private void remplirCategorie()
        {
            string Req = "select * from CategorieTbl";
            CatCb.DisplayMember = con.RecupererDonnee(Req).Columns["CatNom"].ToString();
            CatCb.ValueMember = con.RecupererDonnee(Req).Columns["CatId"].ToString();
            CatCb.DataSource = con.RecupererDonnee(Req);

        }
        private void ListerDocument()
        {
            try
            {

                string Req = "Select DNom as Nom,CatNom as Categorie,Ddate as Date from DocumentTbl join CategorieTbl on DocumentTbl.Dcat = CategorieTbl.CatId ";
                ListeDocument.DataSource = con.RecupererDonnee(Req);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void AjouterBtn_Click(object sender, EventArgs e)
        {

            try
            {
                if (NomRtb.Text == "" || CatCb.SelectedIndex == -1)
                {
                    MessageBox.Show("veuillez entrer toute les information");
                }
                else
                {
                    DataGridViewRow Ligne = new DataGridViewRow();
                    Ligne.CreateCells(ListeImpression);

                    Ligne.Cells[0].Value = NomRtb.Text;
                    Ligne.Cells[1].Value = CatCb.Text;
                    Ligne.Cells[2].Value = Datetb.Text;
                    ListeImpression.Rows.Add(Ligne);
                    NomRtb.Text = "";

                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
        string Key = "";

        private void ListeDocument_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            NomRtb.Text = ListeDocument.SelectedRows[0].Cells[0].Value.ToString();
            CatCb.SelectedItem = ListeDocument.SelectedRows[0].Cells[1].Value.ToString();
            Datetb.Text = ListeDocument.SelectedRows[0].Cells[2].Value.ToString();
            if (NomRtb.Text == "")
            {
                Key = "";
            }
            else
            {
                Key = ListeDocument.SelectedRows[0].Cells[0].Value.ToString();
            }
        }

        private void ImprimerBtn_Click(object sender, EventArgs e)
        {
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void PrintPreviewDialog1_Load(object sender, EventArgs e)
        {

        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            Accueil docmentation = new Accueil();
            docmentation.Show();
            this.Hide();
        }

        private void PictureBox5_Click(object sender, EventArgs e)
        {
            Connextion docmentation = new Connextion();
            docmentation.Show();
            this.Hide();
        }

        private void PictureBox2_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ListeImpression_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
