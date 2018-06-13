using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using DatabaseLibrary.Abstract;
using DatabaseLibrary.Conrete.Dto;
using DatabaseLibrary.Conrete.Entities;

namespace DatabaseLibrary.Mock
{
    public class MockUserRepository : IUserRepository
    {
        private static readonly IList<User> _users = new List<User>();

        static MockUserRepository()
        {
            _users.Add(new User
            {
                FirstName = "Eugene",
                LastName = "Denisov",
                Salary = 12000M,
                Phone = "+7 918 123 45 56"
            });
        }

        public Task SaveUserAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void SaveUser(User user)
        {
            if (_users.All(_ => _.Id != user.Id))
            {
                user.Id = _users.Select(_ => _.Id).DefaultIfEmpty(0).Max() + 1;
                _users.Add(user);
            }
            else
            {
                var u = _users.Single(_ => _.Id == user.Id);
                u.FirstName = user.FirstName;
                u.LastName = user.LastName;
                u.Salary = user.Salary;
                u.Phone = user.Phone;
            }
        }

        public User GetUserById(int id)
        {
            return _users.Single(_ => _.Id == id);
        }

        public IQueryable<User> Users => _users.AsQueryable();
        public void DeleteUser(int id)
        {
            var user = _users.Single(_ => _.Id == id);
            _users.Remove(user);
        }

        public Task DeleteUserAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task InsertManyAsync(IEnumerable<User> users)
        {
            foreach (var user in users)
            {
                _users.Add(user);
            }
            
        }

        public void Dispose()
        {
        }
    }
}
