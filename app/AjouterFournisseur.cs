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
    public partial class AjouterFournisseur : Form
    {
        private UserControl usf;
        private DB_GestionEntities db;
        public AjouterFournisseur(UserControl userC)
        {
            InitializeComponent();
            db = new DB_GestionEntities();
            this.usf = userC;


        }
        public int idselect;
        String testobligatoire1()
        {
            if (nom.Text == "")
            {
                return "nom champ obligatoire";
            }
            if (adr.Text == "")
            {
                return "email champ obligatoire";
            }
            if (tel.Text == "")
            {
                return "tel champ obligatoire";
            }
            if (ville.Text == "")
            {
                return "ville champ obligatoire";
            }
           
           

            return null;
        }

        private void label1_Click(object sender, EventArgs e)
        {

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

     

        private void FormAjouter_Load(object sender, EventArgs e)
        {

        }

        

        private void btnAjouter_Click_1(object sender, EventArgs e)
        {
            if (testobligatoire1() != null)
            {
                MessageBox.Show(testobligatoire1(), "Obligatoire", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
           if (lbltitre.Text == "Ajouter Fournisseur")
            {
                FournisseurADO four = new FournisseurADO();
                if (four.Ajouter_Four(nom.Text, adr.Text, phone.Text, ville.Text) == true)
                {
                    MessageBox.Show("fourniseur Ajouter avec Succé", "Ajouter", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    (usf as UserFournisseur).Actualisation();
                }
                else
                {
                    MessageBox.Show("Fournisseur exist deja ", "Ajouter", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            else
            {
                FournisseurADO cls = new FournisseurADO();

                DialogResult m = MessageBox.Show("Voulez vous vraiment modifier ce Fournisseur ", "Modification", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (m == DialogResult.Yes)
                {
                    cls.Modifier_Four(idselect, nom.Text, adr.Text, phone.Text, ville.Text);
                    MessageBox.Show("client modifier avec sucssé", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    (usf as UserFournisseur).Actualisation();
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

        private void btnModifier_Click_1(object sender, EventArgs e)
        {
            nom.Text = "";
            adr.Text = "";
            phone.Text = "";

            ville.Text = "";


        }
    }
}
