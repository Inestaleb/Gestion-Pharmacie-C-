using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;


namespace app
{
    public class ClientADO
    {
        private DB_GestionEntities db = new DB_GestionEntities();
        private Client cl;
        public bool Ajouter_client(string nom, string prenom, string tel, string email, string adr, int postal)
        {
          cl = new Client();

            cl.NomClt = nom;
            cl.PrenomClt = prenom;
            cl.telClt = tel;
            cl.emailClt = email;
            cl.adrClt = adr;
            cl.codepostale = postal;
            if (db.Clients.SingleOrDefault(s => s.NomClt == nom && s.PrenomClt == prenom) == null)
            {
                db.Clients.Add(cl);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }
        public void Modifier_client(int id, string nom, string prenom, string telephone, string email, string adresse, int postal)
        {
            cl = new Client();
            cl =db.Clients.SingleOrDefault( s => s.CodeClt == id);
            if (cl != null)
            {
                cl.NomClt = nom;
                cl.PrenomClt = prenom;
                cl.telClt = telephone;
                cl.emailClt = email;
                cl.adrClt = adresse;
                cl.codepostale = postal;
                db.SaveChanges();

            }
        }
        public void Supprimer_client(int id)
        {
            cl = new Client();
            cl = db.Clients.SingleOrDefault(s => s.CodeClt == id);
            if (cl != null)
            {
                db.Clients.Remove(cl);
                db.SaveChanges();
            }


        }
    }
}

