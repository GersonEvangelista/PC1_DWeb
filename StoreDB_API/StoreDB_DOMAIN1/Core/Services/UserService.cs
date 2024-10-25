using StoreDB_DOMAIN1.Core.DTO;
using StoreDB_DOMAIN1.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreDB_DOMAIN1.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IJWTService _jwtService;
        public UserService(IUserRepository userRepository, IJWTService jwtService)
        {
            _userRepository = userRepository;
            _jwtService = jwtService;
        }

        public async Task<UserDTO> SignIn(string email, string pwd)
        {
            var user = await _userRepository.SignIn(email, pwd);
            if (user == null) return null;

            var token = _jwtService.GenerateJWToken(user);
            var sendEmail = false;
            var userDTO = new UserDTO()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Password = user.Password,
                Token = token,
                IsEmailSent = sendEmail
            };
            return userDTO;
        }
    }
}
