using PocketBook.Models;
using PocketBook.Core.IRepositories;
using System.Threading.Tasks;
using System;
using PocketBook.Data;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace PocketBook.Core.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(
            ApplicationDbContext context,
            ILogger logger
        ) : base(context, logger)
        {

        }
        public async Task<string> GetFirstNameAndLastName(Guid id)
        {
            try
            {
                var user = await dbSet.FindAsync(id);
                var name = $"{user.FirstName}, {user.LastName}";
                return name;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} GetFirstNameAndLastName method error", typeof(UserRepository));
                return string.Empty;
            }
        }

        public override async Task<IEnumerable<User>> All()
        {
            try
            {
                return await dbSet.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} All method error", typeof(UserRepository));

                return new List<User>();
            }
        }

        public override async Task<bool> Upsert(User entity)
        {

            try
            {
                var user = await dbSet.Where(x => x.Id == entity.Id).FirstOrDefaultAsync();

                if (user == null)
                {
                    return await Add(entity);
                }

                user.FirstName = entity.FirstName;
                user.LastName = entity.LastName;
                user.Email = entity.Email;

                return true;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Upsert method error", typeof(UserRepository));
                return false;
            }
        }

        public override async Task<bool> Delete(Guid id)
        {
            try
            {
                var user = await dbSet.Where(x => x.Id == id).FirstOrDefaultAsync();
                if (user != null)
                {
                    dbSet.Remove(user);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} delete method error", typeof(UserRepository));
                return false;
            }
        }
    }
}