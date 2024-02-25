using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Document
{
    public partial class Impresion : Form
    {
        Function con; 
        public Impresion()
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
            }catch(Exception Ex)
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
          string  Key = "";
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
        string  name, Categorie, Date;

        private void PrintDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawString("========== EMPLOYEE SUMARY=========", new Font("Century Gothic", 20, FontStyle.Bold), Brushes.Red, new Point(180));
            foreach (DataGridViewRow row in ListeImpression.Rows)
            {
                name = "" + row.Cells["Column1"].Value;
                Categorie = "" + row.Cells["Column2"].Value;
                Date = "" + row.Cells["Column3"].Value;


                e.Graphics.DrawString("Nom : " + name, new Font("Century Gothic", 16, FontStyle.Regular), Brushes.Black, new Point(10, 80));
                e.Graphics.DrawString("Categorie : " + Categorie, new Font("Century Gothic", 16, FontStyle.Regular), Brushes.Black, new Point(10, 100));
                e.Graphics.DrawString("Date : " + Date, new Font("Century Gothic", 16, FontStyle.Regular), Brushes.Black, new Point(10, 120));

            }
           
            e.Graphics.DrawString("========== EMPiSoft=========", new Font("Century Gothic", 20, FontStyle.Bold), Brushes.Red, new Point(180, 160));
            ListeImpression.Rows.Clear();
            ListeImpression.Refresh();
        }

        private void PrintPreviewDialog1_Load(object sender, EventArgs e)
        {
          
        }

        private void PictureBox8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
