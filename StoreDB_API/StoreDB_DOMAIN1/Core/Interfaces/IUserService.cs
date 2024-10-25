using StoreDB_DOMAIN1.Core.DTO;

namespace StoreDB_DOMAIN1.Core.Interfaces
{
    public interface IUserService
    {
        Task<UserDTO> SignIn(string email, string pwd);
    }
}