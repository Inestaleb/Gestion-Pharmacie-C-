//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Ligne_Vente
    {
        public int code_Produit { get; set; }
        public int Code_Vente { get; set; }
        public int quantité { get; set; }
        public int id_ligvente { get; set; }
        public string nom_Produit { get; set; }
        public string Prix { get; set; }
        public string Remise { get; set; }
        public string Total { get; set; }
    
        public virtual Produit Produit { get; set; }
        public virtual Vente Vente { get; set; }
    }
}
