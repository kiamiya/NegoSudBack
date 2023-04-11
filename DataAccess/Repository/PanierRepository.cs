using Common.Model;
using DataAccess.dbContext;

namespace DataAccess.Repository
{
    public class PanierRepository : IRepository<Family>
    {
        private NegoSudDBContext _context;

        public PanierRepository(NegoSudDBContext context)
        {
            _context = context;
        }
        public void Add(Panier user)
        {
            _context.Paniers.Add(user);
        }

        public void Delete(Panier user)
        {
            _context.Paniers.Remove(user);
        }

        public Panier Get(int id)
        {
            return _context.Paniers.First(usr => usr.Id == id);
        }
        
        public List<Panier> GetAll()
        {
            return _context.Paniers.ToList();
        }

        public void Update(Panier user)
        {
            _context.Paniers.Update(user);
        }
    }
}