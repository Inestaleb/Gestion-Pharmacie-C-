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

namespace app
{
    public partial class FournisseurCommande : Form
    {
        private DB_GestionEntities db;
        public FournisseurCommande()
        {
            InitializeComponent();
            db = new DB_GestionEntities();
        }


        private void dgvFournisseur_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Close();
        }

        private void FournisseurCommande_Load(object sender, EventArgs e)
        {
            foreach (var s in db.Fournisseurs)
            {
                dgvFournisseur.Rows.Add(s.ID_F,s.Nom_F,s.Adresse_F,s.Telephone_F,s.Ville_F);
            }
        }
    }
}
