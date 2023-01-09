using Common.Model;

namespace DataAccess.Repository
{
    public interface IUserRepository : IRepository<User>
    {
        bool Login(string email, string pass);
        User Get(string email);
    }
}
