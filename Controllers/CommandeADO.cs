using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace app
{
  public   class CommandeADO
    {
        private DB_GestionEntities db= new DB_GestionEntities();
        private Commande cmd;
        private ligne_Commande lgcmd;
       public int idcmd;
        public void Ajouter_Commande(DateTime datec, int id, string totalht,string tva,string totalttc)
        {
            cmd = new Commande();
            cmd.date_commande = datec;
           
            cmd.ID_F = id;
            cmd.Total_HT = totalht;
            cmd.TVA = tva;
            cmd.Total_TTC = totalttc;
            db.Commandes.Add(cmd);
            db.SaveChanges();
            idcmd = cmd.code_cde;
        }
        public void Ajouter_LigneCommande(int idproduit, string nomp,int qte,string prix, string remise,string total)
        {
            lgcmd = new ligne_Commande();
            lgcmd.code_cde = idcmd;
            lgcmd.code_Produit = idproduit;
            lgcmd.nom_Produit = nomp;
            lgcmd.quantité = qte;
            lgcmd.Prix = prix;
            lgcmd.Remise = remise;
            lgcmd.Total = total;
            db.ligne_Commande.Add(lgcmd);
            db.SaveChanges();

        }
    }
}
