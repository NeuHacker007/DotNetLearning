using PocketBook.Models;
using System.Threading.Tasks;
using System;
namespace PocketBook.Core.IRepositories
{
    public interface IUserRepository : IGenericRepository<User>
    {

        Task<string> GetFirstNameAndLastName(Guid id);

    }
}