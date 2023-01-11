using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using Model;
using Controllers;

namespace app
{
    public partial class UserCommande : UserControl
    {
        private DB_GestionEntities db;
        private static UserCommande userCommande;
        public static UserCommande Instance
        {
            get
            {
                if (userCommande == null)
                {
                    userCommande = new UserCommande();
                }
                return userCommande;
            }
        }
        public UserCommande()
        {
            InitializeComponent();
            db = new DB_GestionEntities();
        }
        public void Remplirdata()
        {
            dgvcmd.Rows.Clear();
         
            Fournisseur fr = new Fournisseur();
            
            string nom;
            foreach (var m in db.Commandes)
            {
                //nomprenom client
              
                fr = db.Fournisseurs.Single(s => s.ID_F == m.ID_F);
                nom = fr.Nom_F;
                dgvcmd.Rows.Add(m.code_cde, m.date_commande,nom ,m.Total_HT,m.TVA,m.Total_TTC);

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnajouter_Click(object sender, EventArgs e)
        {
            FormLigneCommande FRM = new FormLigneCommande(this);
            FRM.ShowDialog();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void UserCommande_Load(object sender, EventArgs e)
        {
            Remplirdata();
        }

        private void btnRecherche_Click(object sender, EventArgs e)
        {
            var listecmd = db.Commandes.ToList();
            if (dgvcmd.Rows.Count != 0)
            {

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormImper frm = new FormImper();
            try
            {
                //comande selectionner
                int id = Convert.ToInt32(dgvcmd.CurrentRow.Cells[0].Value);
                var commande = db.Commandes.Single(s => s.code_cde == id);
                //client
                
                // fournisseur
                var fournisseur = db.Fournisseurs.Single(s => s.ID_F == commande.ID_F);

                //detail cmd
                var listecmd = db.ligne_Commande.Where(s => s.code_cde == id).ToList();
                //ajouter liste dans data source Rapport
                frm.affiche.LocalReport.ReportEmbeddedResource = "app.ReportCommande.rdlc";
                frm.affiche.LocalReport.DataSources.Add(new ReportDataSource("DataCommande", listecmd));
                //info de client
             
                //info de fourniseur
                ReportParameter nomf = new ReportParameter("Nom_F", fournisseur.Nom_F );
                ReportParameter adressef= new ReportParameter("Adresse_F", fournisseur.Adresse_F);
                ReportParameter telEPHONE = new ReportParameter("Telephone_F", fournisseur.Telephone_F);
                ReportParameter VILLE = new ReportParameter("Ville_F",fournisseur.Ville_F);
              
                //info commande
                ReportParameter idcmd = new ReportParameter("NCommande", commande.code_cde.ToString());
                ReportParameter DateCmd = new ReportParameter("Date", commande.date_commande.ToString());
                //ajout totalht tva totalttc
                ReportParameter totalht = new ReportParameter("totalht", commande.Total_HT);
                ReportParameter tva = new ReportParameter("tva", commande.TVA);
                ReportParameter totalttc = new ReportParameter("totalttc", commande.Total_TTC);
                //enregistrer
                frm.affiche.LocalReport.SetParameters(new ReportParameter[] { nomf,adressef,telEPHONE,VILLE ,idcmd, DateCmd, totalht, tva, totalttc }) ;
                frm.affiche.RefreshReport();
                frm.ShowDialog();




            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


    }
}
