using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElevenNote.Data;
using ElevenNote.Data.Entities;
using ElevenNote.Models.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ElevenNote.Services.User
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> RegisterUserAsync(UserRegister model)
        {
            bool emailAvailable = await CheckEmailIsAvailable(model.Email);
            bool usernameAvailable = await CheckUsernameIsAvailable(model.Username);

            if (!emailAvailable || !usernameAvailable)
            {
                return false;
            }

            var entity = new UserEntity() {
                Email = model.Email,
                Username = model.Username,
                DateCreated = DateTime.Now
            };
            
            var passwordHasher = new PasswordHasher<UserEntity>();
            entity.Password = passwordHasher.HashPassword(entity, model.Password);

            _context.Users.Add(entity);
            var numberOfChanges = await _context.SaveChangesAsync();

            return numberOfChanges == 1;
        }

        public async Task<UserDetail> GetUserByIdAsync(int userId)
        {
            var foundUser = await _context.Users.FindAsync(userId);
            if (foundUser is null) {
                return null;
            }
            var userDetail = new UserDetail() {
                Id = foundUser.Id,
                Email = foundUser.Email,
                Username = foundUser.Username,
                FirstName = foundUser.FirstName,
                LastName = foundUser.LastName,
                DateCreated = foundUser.DateCreated
            };
            return userDetail;
        }

        //helper methods
        public async Task<bool> CheckUsernameIsAvailable(string username)
        {
            var foundUser = await _context.Users.FirstOrDefaultAsync(u => u.Username.ToLower() == username.ToLower());

            return (foundUser == null);
        }

        public async Task<bool> CheckEmailIsAvailable(string emailAddress)
        {
            var foundUser = await _context.Users.FirstOrDefaultAsync(user => user.Email == emailAddress);

            return (foundUser == null);
        }
    }
}