using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Controllers;

namespace Controllers
{
    public class VenteADO
    {
        private DB_GestionEntities db = new DB_GestionEntities();
        private Vente vente;
        private Ligne_Vente lgvent;
        public int idvente;
        public void Ajouter_Vente(DateTime datec, int ID, string totalht, string tva, string totalttc)
        {
            vente = new Vente();
            vente.date = datec;
            vente.CodeClt = ID;
            vente.TOTAL_HT= totalht;
            vente.TOTAL_TTC = tva;
            vente.TVA = totalttc;
            db.Ventes.Add(vente);
            db.SaveChanges();
            idvente = vente.Code_Vente;
        }
        public void Ajouter_Lignevente(int idproduit, string nomp, int qte, string prix, string remise, string total)
        {
            lgvent = new Ligne_Vente();
            lgvent.Code_Vente = idvente;
            lgvent.code_Produit = idproduit;
            lgvent.nom_Produit = nomp;
           lgvent.quantité = qte;
            lgvent.Prix = prix;
            lgvent.Remise = remise;
           lgvent.Total = total;
            db.Ligne_Vente.Add(lgvent);
            db.SaveChanges();

        }
    }
}
