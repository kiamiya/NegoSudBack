using System.ComponentModel.DataAnnotations.Schema;

namespace Common.Model
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public int FournisseurId { get; set; }
        public Fournisseur Fournisseur { get; set; }
        public int FamilyId { get; set; }
        public Family Family { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
    }
}
