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
    public partial class UserFournisseur : UserControl
    {
        private DB_GestionEntities db;
        private static UserFournisseur userFournisseur;
        public static UserFournisseur Instance
        {
            get
            {
                if (userFournisseur == null)
                {
                    userFournisseur = new UserFournisseur();
                }
                return userFournisseur;
            }
        }
        public UserFournisseur()
        {
            InitializeComponent();
            db = new DB_GestionEntities();
            textRecherche.Enabled = false;
        }
        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textRecherche.Text == "Recherche")
            {
                textRecherche.Text = "";
                textRecherche.ForeColor = Color.Black;
            }
        }
        public void Actualisation()
        {
            db = new DB_GestionEntities();
            dgvFournisseur.Rows.Clear();
            foreach (var s in db.Fournisseurs)
            {
                dgvFournisseur.Rows.Add(false, s.ID_F,s.Nom_F,s.Adresse_F,s.Telephone_F,s.Ville_F);
            }
        }
        public String Selectverif()
        {
            int nombreselectligne = 0;
            for (int i = 0; i < dgvFournisseur.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dgvFournisseur.Rows[i].Cells[0].Value) == true)
                {
                    nombreselectligne++;
                }
            }
            if (nombreselectligne == 0)
            {
                return "Selectionner le client qui vous voulez modifier";
            }
            if (nombreselectligne > 1)
            {
                return "Selectionner seulement 1 seule client pour modifier ";
            }
            return null;
        }
        private void UserClient_Load(object sender, EventArgs e)
        {

            Actualisation();
        }


        private void btnajouter_Click(object sender, EventArgs e)
        {
            AjouterFournisseur a= new AjouterFournisseur(this);
            a.ShowDialog();
        }

        private void btnsupprimer_Click(object sender, EventArgs e)
        {
            FournisseurADO CL = new FournisseurADO();
            int select = 0;
            for (int i = 0; i < dgvFournisseur.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dgvFournisseur.Rows[i].Cells[0].Value) == true)
                {
                    select++;

                }
            }
            if (select == 0)
            {
                MessageBox.Show("aucun  fournisseur selectionner", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                DialogResult R =
                    MessageBox.Show("voulez vous supprimer ", "Suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (R == DialogResult.Yes)
                {
                    for (int i = 0; i < dgvFournisseur.Rows.Count; i++)
                    {
                        if (Convert.ToBoolean(dgvFournisseur.Rows[i].Cells[0].Value) == true)
                        {
                            CL.Supprimer_Four(int.Parse(dgvFournisseur.Rows[i].Cells[1].Value.ToString()));

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

        private void button3_Click(object sender, EventArgs e)
        {
           AjouterFournisseur modif = new AjouterFournisseur(this);
            if (Selectverif() == null)
            {
                for (int i = 0; i < dgvFournisseur.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(dgvFournisseur.Rows[i].Cells[0].Value) == true)
                    {
                        modif.idselect = (int)dgvFournisseur.Rows[i].Cells[1].Value;
                        modif.nom.Text = dgvFournisseur.Rows[i].Cells[2].Value.ToString();
                        modif.adr.Text = dgvFournisseur.Rows[i].Cells[3].Value.ToString();
                        modif.phone.Text = dgvFournisseur.Rows[i].Cells[4].Value.ToString();
                        modif.ville.Text = dgvFournisseur.Rows[i].Cells[5].Value.ToString();
           

                    }
                }
                modif.lbltitre.Text = "Modifier Client";
                modif.btnModifier.Visible = false;
                modif.ShowDialog();

            }
            else
            {
                MessageBox.Show(Selectverif(), "Modification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void UserFournisseur_Load(object sender, EventArgs e)
        {
            Actualisation();
        }

        private void textRecherche_TextChanged(object sender, EventArgs e)
        {
            db = new DB_GestionEntities();
            var listrecherche = db.Fournisseurs.ToList();
            if (textRecherche.Text != "")
            {
                switch (comboRecherche.Text)
                {
                    case "Nom":
                        listrecherche = listrecherche.Where(s => s.Nom_F.IndexOf(textRecherche.Text, StringComparison.CurrentCultureIgnoreCase) != -1).ToList();
                        break;
                    case "Adresse":
                        listrecherche = listrecherche.Where(s => s.Adresse_F.IndexOf(textRecherche.Text, StringComparison.CurrentCultureIgnoreCase) != -1).ToList();
                        break;
                    case "Telephone":
                        listrecherche = listrecherche.Where(s => s.Telephone_F.IndexOf(textRecherche.Text, StringComparison.CurrentCultureIgnoreCase) != -1).ToList();
                        break;
                    case "Ville":
                        listrecherche = listrecherche.Where(s => s.Ville_F.IndexOf(textRecherche.Text, StringComparison.CurrentCultureIgnoreCase) != -1).ToList();
                        break;
                  

                }
            }
            dgvFournisseur.Rows.Clear();
            foreach (var l in listrecherche)
            {

                dgvFournisseur.Rows.Add(false,l.ID_F,l.Nom_F,l.Adresse_F,l.Telephone_F,l.Ville_F );
            }
        }

        private void textRecherche_Enter(object sender, EventArgs e)
        {
            if (textRecherche.Text == "Recherche")
            {
                textRecherche.Text = "";

            }
        }

        private void comboRecherche_SelectedIndexChanged(object sender, EventArgs e)
        {
            textRecherche.Enabled = true;
            textRecherche.Text = "";
        }
    }
}
