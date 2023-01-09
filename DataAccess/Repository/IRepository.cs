using Common.Model;

namespace DataAccess.Repository
{
    public interface IRepository<Entity>
    {
        void Add(Entity user);
        void Delete(Entity user);
        void Update(Entity user);
        Entity Get(int id);
        List<Entity> GetAll();
    }
}
