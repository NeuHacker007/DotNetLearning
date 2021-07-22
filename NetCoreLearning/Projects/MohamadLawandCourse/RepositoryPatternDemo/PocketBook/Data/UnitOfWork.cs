using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using PocketBook.Core.IConfiguration;
using PocketBook.Core.IRepositories;
using PocketBook.Core.Repositories;

namespace PocketBook.Data
{
    public class UnitOfWork : IUnitOfWork, IAsyncDisposable
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger _logger;


        public IUserRepository userRepository { get; private set; }

        public UnitOfWork(
            ApplicationDbContext context,
            ILoggerFactory logger
        )
        {
            _context = context;
            _logger = logger.CreateLogger("UnitOfWorkLogger");

            userRepository = new UserRepository(_context, _logger);
        }

        public async Task<bool> CompleteAsync()
        {
            return Convert.ToBoolean(await _context.SaveChangesAsync());

        }



        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }
    }
}