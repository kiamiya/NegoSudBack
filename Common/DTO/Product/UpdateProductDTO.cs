using Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTO.Product
{
    public class UpdateProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public int Fournisseur { get; set; }
        public int Family { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
    }
}
