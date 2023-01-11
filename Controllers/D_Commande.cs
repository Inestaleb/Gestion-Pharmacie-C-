using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace app.Controllers
{
   public  class D_Commande
    {
        public static List<D_Commande> liste = new List<D_Commande>();
        public int id { get; set; }
        public string nom { get; set; }
        public int quantité { get; set; }
        public string Prix { get; set; }
        public string Remise { get; set; }
        public string Total { get; set; }
    }
}
