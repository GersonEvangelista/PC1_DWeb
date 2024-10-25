using StoreDB_DOMAIN1.Core.Entities;
using StoreDB_DOMAIN1.Core.Settings;

namespace StoreDB_DOMAIN1.Core.Interfaces
{
    public interface IJWTService
    {
        JWTSettings _settings { get; }

        string GenerateJWToken(User user);
    }
}