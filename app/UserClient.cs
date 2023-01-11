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
    public partial class UserClient : UserControl
    {
        private DB_GestionEntities db;
        private static UserClient userClient;
        public static UserClient Instance
        {
            get
            {
                if (userClient == null)
                {
                    userClient = new UserClient();
                }
                return userClient;
            }
        }
        public UserClient()
        {
            InitializeComponent();
            db = new DB_GestionEntities();
            textRecherche.Enabled =false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormAjouter modif = new FormAjouter(this);
            if (Selectverif() == null)
            {
                for (int i = 0; i < dgvClient.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(dgvClient.Rows[i].Cells[0].Value) == true)
                    {
                        modif.idselect = (int)dgvClient.Rows[i].Cells[1].Value;
                        modif.nom.Text = dgvClient.Rows[i].Cells[2].Value.ToString();
                        modif.pre.Text = dgvClient.Rows[i].Cells[3].Value.ToString();
                        modif.phone.Text = dgvClient.Rows[i].Cells[4].Value.ToString();
                        modif.mail.Text = dgvClient.Rows[i].Cells[5].Value.ToString();
                        modif.adr.Text = dgvClient.Rows[i].Cells[6].Value.ToString();
                        modif.postal.Text = dgvClient.Rows[i].Cells[7].Value.ToString();

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
            dgvClient.Rows.Clear();
            foreach (var s in db.Clients)
            {
                dgvClient.Rows.Add(false, s.CodeClt, s.NomClt, s.PrenomClt, s.telClt, s.emailClt, s.adrClt, s.codepostale);
            }
        }
        public String Selectverif()
        {
            int nombreselectligne = 0;
            for (int i = 0; i < dgvClient.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dgvClient.Rows[i].Cells[0].Value) == true)
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
            FormAjouter ajout = new FormAjouter(this);
            ajout.ShowDialog();
        }

        private void dgvClient_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnsupprimer_Click(object sender, EventArgs e)
        {
            ClientADO CL = new ClientADO();
            int select = 0;
            for (int i = 0; i < dgvClient.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dgvClient.Rows[i].Cells[0].Value) == true)
                {
                    select++;

                }
            }
            if (select == 0)
            {
                MessageBox.Show("aucun client selectionner", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                DialogResult R =
                    MessageBox.Show("voulez vous supprimer ", "Suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (R == DialogResult.Yes)
                {
                    for (int i = 0; i < dgvClient.Rows.Count; i++)
                    {
                        if (Convert.ToBoolean(dgvClient.Rows[i].Cells[0].Value) == true)
                        {
                            CL.Supprimer_client(int.Parse(dgvClient.Rows[i].Cells[1].Value.ToString()));

                        }
                    }
                    Actualisation();
                    MessageBox.Show("Suppresion avec succé", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }else
                {
                    MessageBox.Show("Suppression annulé", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void textBox1_Enter_1(object sender, EventArgs e)
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
       




        private void textRecherche_TextChanged(object sender, EventArgs e)
        {
            db = new DB_GestionEntities();
            var listrecherche = db.Clients.ToList();
            if (textRecherche.Text != "")
            {
                switch(comboRecherche.Text)
                {
                    case "Nom":
                        listrecherche = listrecherche.Where(s => s.NomClt.IndexOf(textRecherche.Text, StringComparison.CurrentCultureIgnoreCase) != -1).ToList();
                        break;
                    case "Prenom":
                        listrecherche = listrecherche.Where(s => s.PrenomClt.IndexOf(textRecherche.Text, StringComparison.CurrentCultureIgnoreCase) != -1).ToList();
                        break;
                    case "Telephone":
                        listrecherche = listrecherche.Where(s => s.telClt.IndexOf(textRecherche.Text, StringComparison.CurrentCultureIgnoreCase) != -1).ToList();
                        break;
                    case "Email":
                        listrecherche = listrecherche.Where(s => s.emailClt.IndexOf(textRecherche.Text, StringComparison.CurrentCultureIgnoreCase) != -1).ToList();
                        break;
                    case "Adresse":
                        listrecherche = listrecherche.Where(s => s.adrClt.IndexOf(textRecherche.Text, StringComparison.CurrentCultureIgnoreCase) != -1).ToList();
                        break;
                    
                }
            }
            dgvClient.Rows.Clear();
            foreach (var l in listrecherche)
            {
                
                dgvClient.Rows.Add(false,l.CodeClt,l.NomClt,l.PrenomClt,l.telClt,l.emailClt,l.adrClt,l.codepostale);
            }
        }


    }
    } 
