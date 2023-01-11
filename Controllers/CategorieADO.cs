using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace app
{
    public class CategorieADO
    {

        private DB_GestionEntities db = new DB_GestionEntities();
        private Categorie Cat;
        public bool Ajouter_categorie(string nom)
        {
           Cat = new Categorie();

            Cat.Nom_Categorie = nom;
           
            if (db.Categories.SingleOrDefault(s => s.Nom_Categorie== nom ) == null)
            {
                db.Categories.Add(Cat);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }
        public void Modifier_categorie(int id, string nom)
        {
            Cat = new Categorie();
            Cat = db.Categories.SingleOrDefault(s => s.codecateg == id);
            if (Cat != null)
            {
               Cat.Nom_Categorie = nom;
              
                db.SaveChanges();

            }
        }
        public void Supprimer_categorie(int id)
        {
            Cat = new Categorie();
            Cat = db.Categories.SingleOrDefault(s => s.codecateg == id);
            if (Cat != null)
            {
                db.Categories.Remove(Cat);
                db.SaveChanges();
            }


        }
    }
}
