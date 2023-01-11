using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;
using Controllers;

namespace app
{
    public partial class UserProduit : UserControl
    {

        private DB_GestionEntities db;
        private static UserProduit userProduit;
        public static UserProduit Instance
        {
            get
            {
                if (userProduit == null)
                {
                    userProduit = new UserProduit();
                }
                return userProduit;
            }
        }
        public UserProduit()
        {
            InitializeComponent();
            db = new DB_GestionEntities();
        }
        public void Actualisation()
        {
            db = new DB_GestionEntities();
            Categorie cat = new Categorie();
            dgvProduit.Rows.Clear();
            foreach (var lis in db.Produits)
            {
                cat = db.Categories.SingleOrDefault(s => s.codecateg == lis.codecateg);
                if (cat != null)
                {
                    dgvProduit.Rows.Add(false, lis.code_Produit, lis.Nom_Produit,lis.DCI, lis.Quantité_Produit, lis.Prix_Produit, cat.Nom_Categorie);
                }
            }
            for(int i=0;i<dgvProduit.Rows.Count;i++)
            {

                if(Convert.ToInt32(dgvProduit.Rows[i].Cells[4].Value) == 0)
                {
                    dgvProduit.Rows[i].Cells[3].Style.BackColor = Color.Red;
                }
                else
                {
                    dgvProduit.Rows[i].Cells[3].Style.BackColor = Color.LightGreen;
                }
            }
        }
        private void UserProduit_Load(object sender, EventArgs e)
        {
            Actualisation();

        }
        public String Selectverif()
        {
            int nombreselectligne = 0;
            for (int i = 0; i < dgvProduit.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dgvProduit.Rows[i].Cells[0].Value) == true)
                {
                    nombreselectligne++;
                }
            }
            if (nombreselectligne == 0)
            {
                return "Selectionner le produit qui vous voulez modifier";
            }
            if (nombreselectligne > 1)
            {
                return "Selectionner seulement 1 seule produit pour modifier ";
            }
            return null;
        }

        private void btnajouter_Click(object sender, EventArgs e)
        {
            FormAjouterProduit frmproduit = new FormAjouterProduit(this);
            frmproduit.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormAjouterProduit modif = new FormAjouterProduit(this);
            if (Selectverif() == null)
            {
                for (int i = 0; i < dgvProduit.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(dgvProduit.Rows[i].Cells[0].Value) == true)
                    {
                        modif.idselect = (int)dgvProduit.Rows[i].Cells[1].Value;
                        modif.nom.Text = dgvProduit.Rows[i].Cells[2].Value.ToString();
                        modif.qte.Text = dgvProduit.Rows[i].Cells[3].Value.ToString();
                        modif.prix.Text = dgvProduit.Rows[i].Cells[4].Value.ToString();


                    }
                }
                modif.lbltitre.Text = "Modifier Produit";
                modif.btnModifier.Visible = false;
                modif.ShowDialog();
            }else
            {
                MessageBox.Show(Selectverif(), "Modification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnsupprimer_Click(object sender, EventArgs e)
        {
            ProduitADO cl = new ProduitADO();
            int select = 0;
            for (int i = 0; i < dgvProduit.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dgvProduit.Rows[i].Cells[0].Value) == true)
                {
                    select++;

                }
            }
            if (select == 0)
            {
                MessageBox.Show("aucun produit selectionner", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else 
            {
                DialogResult R =
                    MessageBox.Show("voulez vous supprimer ", "Suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (R == DialogResult.Yes)
                {
                    for (int i = 0; i < dgvProduit.Rows.Count; i++)
                    {
                        if (Convert.ToBoolean(dgvProduit.Rows[i].Cells[0].Value) == true)
                        {
                            cl.Supprimer_Produit(int.Parse(dgvProduit.Rows[i].Cells[1].Value.ToString()));

                        }
                    }
                    Actualisation();
                    MessageBox.Show("Suppresion avec succé", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    MessageBox.Show("Suppression annulé", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void dgvProduit_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            db = new DB_GestionEntities();
            var listrecherche = db.Produits.ToList();
            listrecherche = listrecherche.Where(s => s.Nom_Produit.IndexOf(textBox1.Text, StringComparison.CurrentCultureIgnoreCase) != -1).ToList();
            dgvProduit.Rows.Clear();
            Categorie cat = new Categorie();
            foreach (var l in listrecherche)
            {
                cat = db.Categories.SingleOrDefault(s => s.codecateg == l.codecateg);
                dgvProduit.Rows.Add(false, l.code_Produit, l.Nom_Produit, l.Quantité_Produit, l.Prix_Produit, cat.Nom_Categorie);
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Recherche")
            {
                textBox1.Text = "";

            }
        }
    }
    }

