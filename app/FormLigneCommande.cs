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
    public partial class FormLigneCommande : Form
    {
        private UserControl usercommande;
        private DB_GestionEntities db;
        public FormLigneCommande(UserControl user)
        {
            InitializeComponent();
            db = new DB_GestionEntities();
            usercommande = user;
        }
       
        //remplir datagridwiew commande par liste
        public void Remplir()
        {
            float totalht = 0, tva = 0, totalttc = 0; ;
            if(tvatext.Text!="")
            {
                tva= float.Parse(tvatext.Text);
            }
            dgvDetailCommande.Rows.Clear();
           foreach( var l in  Controllers.D_Commande.liste)
            {
                dgvDetailCommande.Rows.Add(l.id, l.nom, l.quantité, l.Prix, l.Remise, l.Total);
                totalht = totalht + float.Parse(l.Total);
            }
            Totalht.Text = totalht.ToString();
            totalttc = (totalht + (totalht * tva / 100));
           Totalttc.Text = totalttc.ToString();
        }
        //remplir dgvproduit
        public void remplirdgvproduit()
        {
            db = new DB_GestionEntities();
            foreach(var k in db.Produits)
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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void FormLigneCommande_Load(object sender, EventArgs e)
        {
            remplirdgvproduit();

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void email_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void mail_TextChanged(object sender, EventArgs e)
        {

        }

        private void adr_TextChanged(object sender, EventArgs e)
        {

        }

        private void postal_TextChanged(object sender, EventArgs e)
        {

        }

        private void tel_Click(object sender, EventArgs e)
        {

        }

      

        private void textBox4_Enter(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
            Controllers.D_Commande.liste.Clear();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void btnClient_Click(object sender, EventArgs e)
        {
        }

     

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void dgvCommandeligne_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void modifierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormProduitCommande f = new FormProduitCommande(this);
            Produit pr = new Produit();
            if(dgvDetailCommande.CurrentRow!=null)
            {
                f.group.Text = "Modifier Produit";
                f.lblid.Text = dgvDetailCommande.CurrentRow.Cells[0].Value.ToString();
                f.lblnom.Text = dgvDetailCommande.CurrentRow.Cells[1].Value.ToString();
                int IDP = int.Parse(dgvDetailCommande.CurrentRow.Cells[0].Value.ToString());
                pr= db.Produits.Single(s => s.code_Produit ==IDP );
                f.lblstock.Text= pr.Quantité_Produit.ToString();
                f.lblprix.Text = dgvDetailCommande.CurrentRow.Cells[3].Value.ToString();
                f.textqte.Text = dgvDetailCommande.CurrentRow.Cells[2].Value.ToString();
                f.textRemise.Text = dgvDetailCommande.CurrentRow.Cells[4].Value.ToString();
                f.texttotal.Text = dgvDetailCommande.CurrentRow.Cells[5].Value.ToString();
                f.ShowDialog();
            }

        }

        private void supprimerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvDetailCommande.CurrentRow != null)
            {

                DialogResult pr = MessageBox.Show("voulez-vous vraiment Suppression", "Supprimer", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (pr == DialogResult.Yes)
                {
                    int index = Controllers.D_Commande.liste.FindIndex(s => s.id == int.Parse(dgvDetailCommande.CurrentRow.Cells[0].Value.ToString()));
                    Controllers.D_Commande.liste.RemoveAt(index);
                    Remplir();
                    MessageBox.Show("Supprimer avec succés", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }else
                {
                    MessageBox.Show("Suppression annulé", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void textTVA_TextChanged(object sender, EventArgs e)
        {
            Remplir();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void texttotalht_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textTTC_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
        public int idclient;
        public int id;
       

       

        private void Fournisseur_Enter(object sender, EventArgs e)
        {

        }

        private void dgvPro_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvPro_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            FormProduitCommande frmp = new FormProduitCommande(this);
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

        private void Ajoutbtn_Click_1(object sender, EventArgs e)
        {
            CommandeADO c = new CommandeADO();
            if (dgvDetailCommande.Rows.Count == 0)
            {
                MessageBox.Show("Ajouter des Produit", "Enregistrer", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                if (nomf.Text == "")
                {
                    MessageBox.Show("Ajouter  un Fournisseur", "Fournisseur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    c.Ajouter_Commande(cmdDate.Value, id, Totalht.Text, tvatext.Text, Totalttc.Text);
                    foreach (var lg in Controllers.D_Commande.liste)
                    {
                        c.Ajouter_LigneCommande(lg.id, lg.nom, lg.quantité, lg.Prix, lg.Remise, lg.Total);

                    }
                    (usercommande as UserCommande).Remplirdata();
                    Controllers.D_Commande.liste.Clear();
                    Close();
                    MessageBox.Show("Commande ajouter avec succes", "Commande", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                }
            }

        }

        private void btnaffiche_Click(object sender, EventArgs e)
        {
            FournisseurCommande c = new FournisseurCommande();
            c.ShowDialog();
            id = Convert.ToInt32(c.dgvFournisseur.CurrentRow.Cells[0].Value);
            nomf.Text = c.dgvFournisseur.CurrentRow.Cells[1].Value.ToString();
            adressee.Text = c.dgvFournisseur.CurrentRow.Cells[2].Value.ToString();
            telf.Text = c.dgvFournisseur.CurrentRow.Cells[3].Value.ToString();
            textville.Text = c.dgvFournisseur.CurrentRow.Cells[4].Value.ToString();
        }

        private void textRecherche_TextChanged(object sender, EventArgs e)
        {
            db = new DB_GestionEntities();
            var listrecherche = db.Produits.ToList();
            listrecherche = listrecherche.Where(s => s.Nom_Produit.IndexOf(textBox4.Text, StringComparison.CurrentCultureIgnoreCase) != -1).ToList();
            dgvProduit.Rows.Clear();

            foreach (var l in listrecherche)
            {

                dgvProduit.Rows.Add(l.code_Produit, l.Nom_Produit, l.Quantité_Produit, l.Prix_Produit);
            }
        }

        private void textRecherche_Enter(object sender, EventArgs e)
        {

            if (textBox4.Text == "Recherche")
            {
                textBox4.Text = "";

            }
        }

        private void modifierToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FormProduitCommande f = new FormProduitCommande(this);
            Produit pr = new Produit();
            if (dgvDetailCommande.CurrentRow != null)
            {
                f.group.Text = "Modifier Produit";
                f.lblid.Text = dgvDetailCommande.CurrentRow.Cells[0].Value.ToString();
                f.lblnom.Text = dgvDetailCommande.CurrentRow.Cells[1].Value.ToString();
                int IDP = int.Parse(dgvDetailCommande.CurrentRow.Cells[0].Value.ToString());
                pr = db.Produits.Single(s => s.code_Produit == IDP);
                f.lblstock.Text = pr.Quantité_Produit.ToString();
                f.lblprix.Text = dgvDetailCommande.CurrentRow.Cells[3].Value.ToString();
                f.textqte.Text = dgvDetailCommande.CurrentRow.Cells[2].Value.ToString();
                f.textRemise.Text = dgvDetailCommande.CurrentRow.Cells[4].Value.ToString();
                f.texttotal.Text = dgvDetailCommande.CurrentRow.Cells[5].Value.ToString();
                f.ShowDialog();
            }
        }

        private void supprimerToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            {
                if (dgvDetailCommande.CurrentRow != null)
                {

                    DialogResult pr = MessageBox.Show("voulez-vous vraiment Suppression", "Supprimer", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (pr == DialogResult.Yes)
                    {
                        int index = Controllers.D_Commande.liste.FindIndex(s => s.id == int.Parse(dgvDetailCommande.CurrentRow.Cells[0].Value.ToString()));
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
        }
    }
    }
