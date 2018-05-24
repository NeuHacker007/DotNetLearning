using AngularWebApi.Interfaces;
using AngularWebApi.Models;
using System.Linq;

namespace AngularWebApi.Repositories
{
    public class TasksRepository : GenericRepository<Tasks>, ITasksRepository
    {
        private ApplicationDbContext _dbContext;
        public TasksRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public Tasks GetTaskById(int id)
        {
            return _dbContext.Tasks.SingleOrDefault(t => t.Id == id);
        }
    }
}