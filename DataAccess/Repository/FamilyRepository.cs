using Common.Model;
using DataAccess.dbContext;

namespace DataAccess.Repository
{
    public class FamilyRepository : IRepository<Family>
    {
        private NegoSudDBContext _context;

        public FamilyRepository(NegoSudDBContext context)
        {
            _context = context;
        }
        public void Add(Family user)
        {
            _context.Families.Add(user);
        }

        public void Delete(Family user)
        {
            _context.Families.Remove(user);
        }

        public Family Get(int id)
        {
            return _context.Families.First(usr => usr.Id == id);
        }

        public List<Family> GetAll()
        {
            return _context.Families.ToList();
        }

        public void Update(Family user)
        {
            _context.Families.Update(user);
        }
    }
}
