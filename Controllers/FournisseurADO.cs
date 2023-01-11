using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
namespace Controllers
{
   public class FournisseurADO
    {

        private DB_GestionEntities db = new DB_GestionEntities();
        private Fournisseur  four;
        public bool Ajouter_Four(string nom, string Adresse, string tel, string ville)
        {
            four = new Fournisseur();

            four.Nom_F = nom;
           four.Adresse_F = Adresse;
           four.Telephone_F= tel;
            four.Ville_F = ville;
            
            if (db.Fournisseurs.SingleOrDefault(s => s.Nom_F == nom) == null)
            {
                db.Fournisseurs.Add(four);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }
        public void Modifier_Four(int id, string nom, string Adresse, string tel, string ville)
        {
            four = new Fournisseur();
            four= db.Fournisseurs.SingleOrDefault(s => s.ID_F == id);
            if (four != null)
            {
                four.Nom_F = nom;
                four.Adresse_F = Adresse;
                four.Telephone_F = tel;
                four.Ville_F = ville;
                db.SaveChanges();

            }
        }
        public void Supprimer_Four(int id)
        {
            four = new Fournisseur();
            four = db.Fournisseurs.SingleOrDefault(s => s.ID_F == id);
            if(four != null)
                {
                db.Fournisseurs.Remove(four);
                db.SaveChanges();
                  }


        }
    }
}

