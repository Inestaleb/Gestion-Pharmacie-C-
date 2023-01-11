using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace app
{
    public class Connexion
    {
        public bool ConnexionValide(DB_GestionEntities db,String username, String mdp)
        {
            tbllogin login = new tbllogin();
            login.username = username;
            login.mdp = mdp;
            if (db.tbllogins.SingleOrDefault(s => s.username == username && s.mdp == mdp) != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
