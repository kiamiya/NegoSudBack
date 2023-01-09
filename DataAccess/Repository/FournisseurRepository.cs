using Common.Model;
using DataAccess.dbContext;

namespace DataAccess.Repository
{
    public class FournisseurRepository : IRepository<Fournisseur>
    {
        private NegoSudDBContext _context;

        public FournisseurRepository(NegoSudDBContext context)
        {
            _context = context;
        }
        public void Add(Fournisseur user)
        {
            _context.Fournisseurs.Add(user);
        }

        public void Delete(Fournisseur user)
        {
            _context.Fournisseurs.Remove(user);
        }

        public Fournisseur Get(int id)
        {
            return _context.Fournisseurs.First(usr => usr.Id == id);
        }

        public List<Fournisseur> GetAll()
        {
            return _context.Fournisseurs.ToList();
        }

        public void Update(Fournisseur user)
        {
            _context.Fournisseurs.Update(user);
        }
    }
}
