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
    public partial class FormLigneVente : Form
    {
        private UserControl userVente;
        private DB_GestionEntities db;
        public FormLigneVente(UserControl user)
        {
            InitializeComponent();
            db = new DB_GestionEntities();
            userVente = user;
        }
        public void Remplir()
        {
            float ht = 0, tv = 0, ttc = 0;
            if (texttva.Text != "")
            {
                tv = float.Parse(texttva.Text);
            }
            dgvCommandeligne.Rows.Clear();
            foreach (var l in Controllers.D_Vente.listev)
            {
                dgvCommandeligne.Rows.Add(l.id, l.nom, l.quantité, l.Prix, l.Remise, l.Total);
                ht = ht + float.Parse(l.Total);
            }
            textht.Text = ht.ToString();
           ttc = (ht + (ht * tv / 100));
            textttc.Text = ttc.ToString();
        }
        public void remplirdgvproduit()
        {
            db = new DB_GestionEntities();
            foreach (var k in db.Produits)
            {
                dgvPro.Rows.Add(k.code_Produit, k.Nom_Produit, k.Quantité_Produit, k.Prix_Produit);
            }
            for (int i = 0; i < dgvPro.Rows.Count; i++)
            {
                if (Convert.ToInt32(dgvPro.Rows[i].Cells[2].Value) == 0)
                {
                    dgvPro.Rows[i].Cells[2].Style.BackColor = Color.Red;
                }
                else
                {
                    dgvPro.Rows[i].Cells[2].Style.BackColor = Color.LightGreen;
                }
            }
            dgvPro.ClearSelection();
        }
        private void textBox4_Enter(object sender, EventArgs e)
        {
            if (textBox4.Text == "Recherche")
            {
                textBox4.Text = "";

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
          Controllers.D_Vente.listev.Clear();
        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            db = new DB_GestionEntities();
            var listrecherche = db.Produits.ToList();
            listrecherche = listrecherche.Where(s => s.Nom_Produit.IndexOf(textBox4.Text, StringComparison.CurrentCultureIgnoreCase) != -1).ToList();
            dgvPro.Rows.Clear();

            foreach (var l in listrecherche)
            {

                dgvPro.Rows.Add(l.code_Produit, l.Nom_Produit, l.Quantité_Produit, l.Prix_Produit);
            }
        }
     

        private void btnClient_Click(object sender, EventArgs e)
        {
            ListesClient lc = new ListesClient();
            lc.ShowDialog();
            idclient=Convert.ToInt32(lc.dgvClient.CurrentRow.Cells[0].Value);
            nom.Text = lc.dgvClient.CurrentRow.Cells[1].Value.ToString();
            pre.Text = lc.dgvClient.CurrentRow.Cells[2].Value.ToString();
            phone.Text = lc.dgvClient.CurrentRow.Cells[3].Value.ToString();
            mail.Text = lc.dgvClient.CurrentRow.Cells[4].Value.ToString();
            adr.Text = lc.dgvClient.CurrentRow.Cells[5].Value.ToString();
            postal.Text = lc.dgvClient.CurrentRow.Cells[6].Value.ToString();
        }
       
        private void modifierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormProduitVente f = new FormProduitVente(this);
            Produit pr = new Produit();
            if (dgvCommandeligne.CurrentRow != null)
            {
                f.group.Text = "Modifier Produit";
                f.lblid.Text = dgvCommandeligne.CurrentRow.Cells[0].Value.ToString();
                f.lblnom.Text = dgvCommandeligne.CurrentRow.Cells[1].Value.ToString();
                int IDP = int.Parse(dgvCommandeligne.CurrentRow.Cells[0].Value.ToString());
                pr = db.Produits.Single(s => s.code_Produit == IDP);
                f.lblstock.Text = pr.Quantité_Produit.ToString();
                f.lblprix.Text = dgvCommandeligne.CurrentRow.Cells[3].Value.ToString();
                f.textqte.Text = dgvCommandeligne.CurrentRow.Cells[2].Value.ToString();
                f.textRemise.Text = dgvCommandeligne.CurrentRow.Cells[4].Value.ToString();
                f.texttotal.Text = dgvCommandeligne.CurrentRow.Cells[5].Value.ToString();
                f.ShowDialog();
            }

        }

        private void supprimerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvCommandeligne.CurrentRow != null)
            {

                DialogResult pr = MessageBox.Show("voulez-vous vraiment Suppression", "Supprimer", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (pr == DialogResult.Yes)
                {
                    int index = Controllers.D_Commande.liste.FindIndex(s => s.id == int.Parse(dgvCommandeligne.CurrentRow.Cells[0].Value.ToString()));
                    Controllers.D_Commande.liste.RemoveAt(index);
                    Remplir();
                    MessageBox.Show("Supprimer avec succés", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    MessageBox.Show("Suppression annulé", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void textTVA_TextChanged(object sender, EventArgs e)
        {
            Remplir();
        }


        public int idclient;
        private void btnAjouter_Click(object sender, EventArgs e)
        {
           
        }

        private void dgvProduit_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvCommandeligne_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvPro_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            FormProduitVente frmp = new FormProduitVente(this);
            if (Convert.ToInt32(dgvPro.CurrentRow.Cells[2].Value) == 0)
            {
                MessageBox.Show("Stock vide", "Stock", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                frmp.lblid.Text = dgvPro.CurrentRow.Cells[0].Value.ToString();
                frmp.lblnom.Text = dgvPro.CurrentRow.Cells[1].Value.ToString();
                frmp.lblstock.Text = dgvPro.CurrentRow.Cells[2].Value.ToString();
                frmp.lblprix.Text = dgvPro.CurrentRow.Cells[3].Value.ToString();
                frmp.texttotal.Text = dgvPro.CurrentRow.Cells[3].Value.ToString();
                frmp.ShowDialog();

            }
        }

        private void texttotalht_TextChanged(object sender, EventArgs e)
        {

        }

        private void FormLigneVente_Load(object sender, EventArgs e)
        {
            remplirdgvproduit();
        }

        private void btnAjouter_Click_1(object sender, EventArgs e)
        {
            VenteADO c = new VenteADO();
            if (dgvCommandeligne.Rows.Count == 0)
            {
                MessageBox.Show("Ajouter des Produit", "Enregistrer", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (nom.Text == "")
                {
                    MessageBox.Show("Ajouter  un client", "Client", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    c.Ajouter_Vente(cmdDate.Value, idclient, textht.Text, texttva.Text, textttc.Text);
                    foreach (var lg in Controllers.D_Vente.listev)
                    {
                        c.Ajouter_Lignevente(lg.id, lg.nom, lg.quantité, lg.Prix, lg.Remise, lg.Total);

                    }
                   (userVente as UserVente).Remplirdata();
                    Controllers.D_Vente.listev.Clear();
                    Close();
                    MessageBox.Show("Commande ajouter avec succes", "Commande", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void texttva_TextChanged_1(object sender, EventArgs e)
        {
            Remplir();
        }

        private void modifierToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FormProduitVente f = new FormProduitVente(this);
            Produit pr = new Produit();
            if (dgvCommandeligne.CurrentRow != null)
            {
                f.group.Text = "Modifier Produit";
                f.lblid.Text = dgvCommandeligne.CurrentRow.Cells[0].Value.ToString();
                f.lblnom.Text = dgvCommandeligne.CurrentRow.Cells[1].Value.ToString();
                int IDP = int.Parse(dgvCommandeligne.CurrentRow.Cells[0].Value.ToString());
                pr = db.Produits.Single(s => s.code_Produit == IDP);
                f.lblstock.Text = pr.Quantité_Produit.ToString();
                f.lblprix.Text = dgvCommandeligne.CurrentRow.Cells[3].Value.ToString();
                f.textqte.Text = dgvCommandeligne.CurrentRow.Cells[2].Value.ToString();
                f.textRemise.Text = dgvCommandeligne.CurrentRow.Cells[4].Value.ToString();
                f.texttotal.Text = dgvCommandeligne.CurrentRow.Cells[5].Value.ToString();
                f.ShowDialog();
            }

        }

        private void supprimerToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (dgvCommandeligne.CurrentRow != null)
            {

                DialogResult pr = MessageBox.Show("voulez-vous vraiment Suppression", "Supprimer", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (pr == DialogResult.Yes)
                {
                    int index = Controllers.D_Vente.listev.FindIndex(s => s.id == int.Parse(dgvCommandeligne.CurrentRow.Cells[0].Value.ToString()));
                    Controllers.D_Vente.listev.RemoveAt(index);
                    Remplir();
                    MessageBox.Show("Supprimer avec succés", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    MessageBox.Show("Suppression annulé", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }
    }
    }


