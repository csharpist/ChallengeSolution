using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseLibrary.Conrete.Dto;
using DatabaseLibrary.Conrete.Entities;

namespace DatabaseLibrary.Abstract
{
    public interface IUserRepository : IDisposable
    {
        Task SaveUserAsync(User user);
        Task<User> GetUserByIdAsync(int id);
        IQueryable<User> Users { get; }
        Task DeleteUserAsync(int id);
        Task InsertManyAsync(IEnumerable<User> users);
    }
}
