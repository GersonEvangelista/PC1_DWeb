using Microsoft.EntityFrameworkCore;
using StoreDB_DOMAIN1.Core.Entities;
using StoreDB_DOMAIN1.Core.Interfaces;
using StoreDB_DOMAIN1.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreDB_DOMAIN1.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly StoreDbContext _context;

        public UserRepository(StoreDbContext context)
        {
            _context = context;
        }

        public async Task<User> SignIn(string email, string pwd)
        {
            return await _context.User.Where(u => u.Email == email && u.Password == pwd).FirstOrDefaultAsync();
        }

    }
}
