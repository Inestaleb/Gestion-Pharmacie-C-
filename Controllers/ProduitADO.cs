using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
namespace app
{
  public  class ProduitADO
    {
        private DB_GestionEntities db = new DB_GestionEntities();
        private Produit pr;
        public bool Ajouter_Produit(string nom,String DCI ,int quantité, int prix, int codecategorie )
        {
          
            
                Produit pr = new Produit();

                pr.Nom_Produit = nom;
                  pr.DCI = DCI;
                pr.Quantité_Produit = quantité;
                pr.Prix_Produit = prix;
                pr.codecateg = codecategorie;

                if (db.Produits.SingleOrDefault(s => s.Nom_Produit == nom) == null)
                {
                    db.Produits.Add(pr);
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            
        }
        public void Modifier_Produit(int id, string nom,string DCI, int quantité, int prix, int categorie)
        {
            pr = new Produit();
            pr = db.Produits.SingleOrDefault(s => s.code_Produit == id);
            if (pr != null)
            {
                pr.Nom_Produit = nom;
                pr.DCI = DCI;
                pr.Quantité_Produit = quantité;
                pr.Prix_Produit = prix;
                pr.codecateg = categorie;
                db.SaveChanges();

            }
        }
        public void Supprimer_Produit(int id)
        {
            pr = new Produit();
            pr = db.Produits.SingleOrDefault(s => s.code_Produit == id);
            if (pr != null)
            {
                db.Produits.Remove(pr);
                db.SaveChanges();
            }


        }
    }
}
