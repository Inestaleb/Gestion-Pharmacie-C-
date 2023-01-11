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
    public partial class FormProduitCommande : Form
    {
        public Form frm;
        public FormProduitCommande(Form frmd)
        {
            InitializeComponent();
            frm = frmd;
        }
       

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textqte_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar)  && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void textRemise_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void textqte_TextChanged(object sender, EventArgs e)
        {
            if (textqte.Text != "")
            {
                int qte = int.Parse(textqte.Text);
                int prix = int.Parse(lblprix.Text);
                if(int.Parse(textqte.Text)>int.Parse(lblstock.Text))
                {
                    MessageBox.Show("il ya " + int.Parse(lblstock.Text) + "dans stock", "STOCK",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textqte.Text = "";
                    texttotal.Text = lblprix.Text;
                }
                else
                {
                    texttotal.Text = (qte * prix).ToString();
                }
               
            }else
            {
                texttotal.Text = lblprix.Text;
            }
        }

        private void textRemise_TextChanged(object sender, EventArgs e)
        {
            if(textRemise.Text!="")
            {
                int qte;
                if(textqte.Text!="")
                {
                    qte = int.Parse(textqte.Text);
                }else
                {
                    qte = 1;
                }
                
                int prix = int.Parse(lblprix.Text);
                int total = qte * prix;
                int remise= int.Parse(textRemise.Text);
                texttotal.Text = (total - (total * remise / 100)).ToString();

            }else
            {
                int qte;
                if (textqte.Text != "")
                {
                    qte = int.Parse(textqte.Text);
                }
                else
                {
                    qte = 1;
                }
                int prix = int.Parse(lblprix.Text);
                texttotal.Text= (qte * prix).ToString();
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            int qte;
            int Re;
            if (textqte.Text != "")
            {
                qte = int.Parse(textqte.Text);
            }
            else
            {
                qte = 1;
            }
            if (textRemise.Text != "")
            {
                Re= int.Parse(textRemise.Text);
            }
            else
            {
                Re = 0;
            }

            Controllers.D_Commande d = new Controllers.D_Commande
            {
                id = int.Parse(lblid.Text),
                nom = lblnom.Text,
                quantité = qte,
                Prix = lblprix.Text,
                Remise = Re.ToString(),
                Total=texttotal.Text,


            };
            if (group.Text == "Vendre Produit")
            {
                if (Controllers.D_Commande.liste.SingleOrDefault(s =>s.id == d.id) != null)
                {
                    MessageBox.Show("Produit deja exist dans commande", "Produit", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    Controllers.D_Commande.liste.Add(d);
                }
            }else
            {
                DialogResult pr = MessageBox.Show("voulez-vous vraiment modifier", "Modification", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(pr==DialogResult.Yes)
                {
                    int index = Controllers.D_Commande.liste.FindIndex(s => s.id == int.Parse(lblid.Text));
                    Controllers.D_Commande.liste[index] = d;
                    MessageBox.Show("Modification succes", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    Close();
                }else
                {
                    MessageBox.Show("Modification annulé", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            (frm as FormLigneCommande).Remplir();
        }

        private void FormProduitCommande_Load(object sender, EventArgs e)
        {

        }

        private void group_Enter(object sender, EventArgs e)
        {

        }
    }
}
