using StoreDB_DOMAIN1.Core.Entities;

namespace StoreDB_DOMAIN1.Core.Interfaces
{
    public interface IUserRepository
    {
        Task<User> SignIn(string email, string pwd);
    }
}