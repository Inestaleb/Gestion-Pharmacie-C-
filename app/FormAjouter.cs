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
    public partial class FormAjouter : Form
    {
        private UserControl usclient;
        private DB_GestionEntities db;
        public FormAjouter(UserControl userC)
        {
            InitializeComponent();
            db = new DB_GestionEntities();
            this.usclient = userC;
           

        }
        public int idselect;
        String testobligatoire1()
        {
            if (nom.Text == "")
            {
                return "nom champ obligatoire";
            }
            if (prenom.Text == "")
            {
                return "prenom champ obligatoire";
            }
            if (tel.Text == "")
            {
                return "tel champ obligatoire";
            }
            if (email.Text == "")
            {
                return "email champ obligatoire";
            }
            if (adr.Text == "")
            {
                return "email champ obligatoire";
            }
            if (postal.Text == "")
            {
                return "email champ obligatoire";
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

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            if (testobligatoire1() != null)
            {
                MessageBox.Show(testobligatoire1(), "Obligatoire", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            if (lbltitre.Text == "Ajouter Client")
            {
               ClientADO cls = new ClientADO();
                if (cls.Ajouter_client(nom.Text,  pre.Text,  phone.Text,  mail.Text, adr.Text, int.Parse(postal.Text)) == true)
                {
                    MessageBox.Show("Client Ajouter avec Succé", "Ajouter", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    (usclient as UserClient).Actualisation();
                }
                else
                {
                    MessageBox.Show("Client exist deja ", "Ajouter", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            else
            {
                ClientADO cls = new ClientADO();

                DialogResult m = MessageBox.Show("Voulez vous vraiment modifier ce client ", "Modification", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (m == DialogResult.Yes)
                {
                    cls.Modifier_client(idselect, nom.Text, pre.Text, phone.Text,mail.Text, adr.Text, int.Parse(postal.Text));
                    MessageBox.Show("client modifier avec sucssé", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    (usclient as UserClient).Actualisation();
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
                 pre.Text = "";
                phone.Text = "";
                
              mail.Text = "";
               adr.Text = "";
               postal.Text = "";
        }

        private void FormAjouter_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
