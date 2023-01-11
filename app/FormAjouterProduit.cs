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
    public partial class FormAjouterProduit : Form
    {
        private UserControl usproduit;
        private DB_GestionEntities db;
        public FormAjouterProduit(UserControl userP)
        {
            InitializeComponent();
            db = new DB_GestionEntities();
            this.usproduit = userP;
            categ.DataSource = db.Categories.ToList();
            categ.DisplayMember = "Nom_Categorie";
            categ.ValueMember = "codecateg";

        }
        public int idselect;
        String testobligatoire1()
        {
            if (categ.Text == "")
            {
                return "nom champ obligatoire";
            }
            if (nom.Text == "")
            {
                return "prenom champ obligatoire";
            }
            if (dci.Text == "")
            {
                return "prenom champ obligatoire";
            }
            if (qte.Text == "")
            {
                return "tel champ obligatoire";
            }
            if (prix.Text == "")
            {
                return "email champ obligatoire";
            }

            return null;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void prenom_TextChanged(object sender, EventArgs e)
        {

        }

        private void FormAjouterProduit_Load(object sender, EventArgs e)
        {

        }

        private void qte_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar < 48 || e.KeyChar > 57)
            {
                e.Handled = true;
            }
            if (e.KeyChar == 8)
            {
                e.Handled = false;
            }
        }

        private void prix_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar < 48 || e.KeyChar > 57)
            {
                e.Handled = true;
            }
            if (e.KeyChar == 8)
            {
                e.Handled = false;
            }
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            if (testobligatoire1() != null)
            {
                MessageBox.Show(testobligatoire1(), "Obligatoire", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
             if (lbltitre.Text == "Ajouter Produit")
            {
                ProduitADO cls = new ProduitADO();
                if (cls.Ajouter_Produit( nom.Text,dci.Text ,int.Parse(qte.Text), int.Parse(prix.Text), Convert.ToInt32(categ.SelectedValue)) == true)
                {
                    MessageBox.Show("Produit Ajouter avec Succé", "Ajouter", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    (usproduit as UserProduit).Actualisation();
                }
                else
                {
                    MessageBox.Show("Produit exist deja ", "Ajouter", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            else
            {
                ProduitADO cls = new ProduitADO();

                DialogResult m = MessageBox.Show("Voulez vous vraiment modifier ce produit ", "Modification", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (m == DialogResult.Yes)
                {
                    cls.Modifier_Produit(idselect ,nom.Text,dci.Text ,int.Parse(qte.Text), int.Parse(prix.Text), Convert.ToInt32(categ.SelectedValue));
                    MessageBox.Show("produit modifier avec sucssé", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    (usproduit as UserProduit).Actualisation();
                }
                else
                {
                    MessageBox.Show("Modification annulé", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            nom.Text = "";
            dci.Text = "";
            qte.Text = "";
            prix.Text = "";
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
