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
    public partial class FormAjouterCatégorie : Form
    {
        private UserControl uscat;
        private DB_GestionEntities db;
        public FormAjouterCatégorie(UserControl userCat)
        {
            InitializeComponent();
            db = new DB_GestionEntities();
            this.uscat = userCat;


        }
        public int idselect;
        String testobligatoire1()
        {
            if (nom.Text == "")
            {
                return "nom champ obligatoire";
            }
            return null;
         }

            private void btnAjouter_Click(object sender, EventArgs e)
        {

            if (testobligatoire1() != null)
            {
                MessageBox.Show(testobligatoire1(), "Obligatoire", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            if (lbltitre.Text == "Ajouter Categorie")
            {
                CategorieADO cls = new CategorieADO();
                if (cls.Ajouter_categorie(nom.Text) == true)
                {
                    MessageBox.Show("Categorie Ajouter avec Succé", "Ajouter", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    (uscat as UserCategorie).Actualisation();
                }
                else
                {
                    MessageBox.Show("categorie exist deja ", "Ajouter", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            else
            {
                CategorieADO cls = new CategorieADO();

                DialogResult m = MessageBox.Show("Voulez vous vraiment modifier ce categorie", "Modification", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (m == DialogResult.Yes)
                {
                    cls.Modifier_categorie(idselect, nom.Text);
                    MessageBox.Show("categorie modifier avec sucssé", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    (uscat as UserCategorie).Actualisation();
                }
                else
                {
                    MessageBox.Show("Modification annulé", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            nom.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormAjouterCatégorie_Load(object sender, EventArgs e)
        {

        }
    }

   
    
    }
