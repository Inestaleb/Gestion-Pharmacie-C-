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
    public partial class UserVente : UserControl
    {
        private DB_GestionEntities db;
        private static UserVente userVente;
        public static UserVente Instance
        {
            get
            {
                if (userVente == null)
                {
                    userVente = new UserVente();
                }
                return userVente;
            }
        }
       
        public UserVente()
        {
            InitializeComponent();
            db = new DB_GestionEntities();
        }
        public void Remplirdata()
        {
            dgvcmd.Rows.Clear();

            Client fr = new Client();

            string nompr;
            foreach (var m in db.Ventes)
            {
                //nomprenom client

                fr = db.Clients.Single(s => s.CodeClt == m.CodeClt);
                nompr = fr.NomClt +""+fr.PrenomClt;
                dgvcmd.Rows.Add(m.Code_Vente, m.date, nompr, m.TOTAL_HT, m.TVA, m.TOTAL_TTC);

            }
        }

        private void UserVente_Load(object sender, EventArgs e)
        {
            Remplirdata();
        }
        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void btnajouter_Click(object sender, EventArgs e)
        {
            FormLigneVente FRM = new FormLigneVente(this);
            FRM.ShowDialog();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            FormImper frm = new FormImper();
            try
            {
                //comande selectionner
                int id = Convert.ToInt32(dgvcmd.CurrentRow.Cells[0].Value);
                var vente = db.Ventes.Single(s => s.Code_Vente == id);
                //client
                var ClientCommande = db.Clients.Single(s => s.CodeClt == vente.CodeClt);
                //detail cmd
                var listevente = db.Ligne_Vente.Where(s => s.Code_Vente == id).ToList();
                //ajouter liste dans data source Rapport
                frm.affiche.LocalReport.ReportEmbeddedResource = "app.ReportVente.rdlc";
                frm.affiche.LocalReport.DataSources.Add(new ReportDataSource("DataVente", listevente));
                //info de client
                ReportParameter nomprenom = new ReportParameter("NomPrenomClient", ClientCommande.NomClt + " " + ClientCommande.PrenomClt);
                ReportParameter adresse = new ReportParameter("AdresseC", ClientCommande.adrClt);
                ReportParameter tel = new ReportParameter("TelephoneC", ClientCommande.telClt);
                ReportParameter email = new ReportParameter("EmailC", ClientCommande.emailClt);
                ReportParameter codep = new ReportParameter("CodeP", ClientCommande.codepostale.ToString());
                //info commande
                ReportParameter idcmd = new ReportParameter("NCommande", vente.Code_Vente.ToString());
                ReportParameter DateCmd = new ReportParameter("Date", vente.date.ToString());
                //ajout totalht tva totalttc
                ReportParameter totalht = new ReportParameter("totalht", vente.TOTAL_HT);
                ReportParameter tva = new ReportParameter("tva", vente.TVA);
                ReportParameter totalttc = new ReportParameter("totalttc", vente.TOTAL_TTC);
                //enregistrer
                frm.affiche.LocalReport.SetParameters(new ReportParameter[] { nomprenom, adresse, tel, email, codep, idcmd, DateCmd, totalht, tva, totalttc });
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

