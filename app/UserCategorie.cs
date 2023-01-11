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
    public partial class UserCategorie : UserControl
    {
        private DB_GestionEntities db;
        private static UserCategorie userCategorie;
        public static UserCategorie Instance
        {
            get
            {
                if (userCategorie == null)
                {
                    userCategorie = new UserCategorie();
                }
                return userCategorie;
            }
        }
        public UserCategorie()
        {
            InitializeComponent();
            db = new DB_GestionEntities();
        }
        public void Actualisation()
        {
            db = new DB_GestionEntities();
            dgvCategorie.Rows.Clear();
            foreach (var s in db.Categories)
            {
                dgvCategorie.Rows.Add(false, s.codecateg, s.Nom_Categorie);
            }
        }
        private void UserCategorie_Load(object sender, EventArgs e)
        {
            Actualisation();
        }
        public String Selectverif()
        {
            int nombreselectligne = 0;
            for (int i = 0; i < dgvCategorie.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dgvCategorie.Rows[i].Cells[0].Value) == true)
                {
                    nombreselectligne++;
                }
            }
            if (nombreselectligne == 0)
            {
                return "Selectionner le categorie qui vous voulez modifier";
            }
            if (nombreselectligne > 1)
            {
                return "Selectionner seulement 1 seule categorie pour modifier ";
            }
            return null;
        }

        private void btnajouter_Click(object sender, EventArgs e)
        {

            FormAjouterCatégorie ajout = new FormAjouterCatégorie(this);
            ajout.ShowDialog();
        }

        private void btnsupprimer_Click(object sender, EventArgs e)
        {

            CategorieADO CL = new CategorieADO();
            int select = 0;
            for (int i = 0; i < dgvCategorie.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dgvCategorie.Rows[i].Cells[0].Value) == true)
                {
                    select++;

                }
            }
            if (select == 0)
            {
                MessageBox.Show("aucun Categorie selectionner", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                DialogResult R =
                    MessageBox.Show("voulez vous Categorie", "Suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (R == DialogResult.Yes)
                {
                    for (int i = 0; i < dgvCategorie.Rows.Count; i++)
                    {
                        if (Convert.ToBoolean(dgvCategorie.Rows[i].Cells[0].Value) == true)
                        {
                            CL.Supprimer_categorie(int.Parse(dgvCategorie.Rows[i].Cells[1].Value.ToString()));

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
            FormAjouterCatégorie modif = new FormAjouterCatégorie(this);
            if (Selectverif() == null)
            {
                for (int i = 0; i < dgvCategorie.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(dgvCategorie.Rows[i].Cells[0].Value) == true)
                    {
                        modif.idselect = (int)dgvCategorie.Rows[i].Cells[1].Value;
                        modif.nom.Text = dgvCategorie.Rows[i].Cells[2].Value.ToString();
                 

                    }
                }
                modif.lbltitre.Text = "Modifier Categorie";
                modif.btnModifier.Visible = false;
                modif.ShowDialog();

            }
            else
            {
                MessageBox.Show(Selectverif(), "Modification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            db = new DB_GestionEntities();
            var listrecherche = db.Categories.ToList();
            listrecherche = listrecherche.Where(s => s.Nom_Categorie.IndexOf(textBox1.Text, StringComparison.CurrentCultureIgnoreCase) != -1).ToList();
            dgvCategorie.Rows.Clear();
            Categorie cat = new Categorie();
            foreach (var l in listrecherche)
            {
                cat = db.Categories.SingleOrDefault(s => s.codecateg == l.codecateg);
                dgvCategorie.Rows.Add(false, l.codecateg, l.Nom_Categorie);
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

    

