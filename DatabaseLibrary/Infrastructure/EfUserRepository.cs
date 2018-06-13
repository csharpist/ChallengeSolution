using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using DatabaseLibrary.Abstract;
using DatabaseLibrary.Conrete.Dto;
using DatabaseLibrary.Conrete.Entities;

namespace DatabaseLibrary.Infrastructure
{
    public class EfUserRepository : IUserRepository
    {
        private readonly ChallengeDbContext _context = new ChallengeDbContext();

        public async Task SaveUserAsync(User user)
        {
            var u = await _context.Users.FindAsync(user.Id);
            if (u == null) // new user
            {
                _context.Users.Add(user);
            }
            else // updating existing user
            {
                u.LastName = user.LastName;
                u.FirstName = user.FirstName;
                u.Salary = user.Salary;
                u.Phone = user.Phone;
            }
            await _context.SaveChangesAsync();
        }
        

        public Task<User> GetUserByIdAsync(int id)
        {
            var user = _context.Users.FindAsync(id);
            return user;

        }

        public IQueryable<User> Users => _context.Users;

        public Task DeleteUserAsync(int id)
        {
            var user = _context.Users.Find(id);
            if (user != null)
            {
                _context.Users.Remove(user);
            }
            return _context.SaveChangesAsync();
        }

        public Task InsertManyAsync(IEnumerable<User> users)
        {
            foreach (var user in users)
            {
                _context.Users.Add(user);
            }
            return _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
