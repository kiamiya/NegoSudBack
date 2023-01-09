using Common.Model;
using DataAccess.dbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class ProductRepository : IRepository<Product>
    {
        private NegoSudDBContext _context;

        public ProductRepository(NegoSudDBContext context)
        {
            _context = context;
        }
        public void Add(Product user)
        {
            _context.Products.Add(user);
        }

        public void Delete(Product user)
        {
            _context.Products.Remove(user);
        }

        public Product Get(int id)
        {
            return _context.Products.First(usr => usr.Id == id);
        }

        public List<Product> GetAll()
        {
            return _context.Products.ToList();
        }

        public void Update(Product user)
        {
            _context.Products.Update(user);
        }
    }
}
