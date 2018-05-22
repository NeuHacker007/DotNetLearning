using AngularWebApi.Interfaces;
using AngularWebApi.Models;
using AngularWebApi.Repositories;

namespace AngularWebApi.UnitofWork
{
    public class UnitOfWorkcs
    {
        private ApplicationDbContext _dbContext;
        private ITasksRepository _tasksRepository;

        public UnitOfWorkcs()
        {
            _dbContext = new ApplicationDbContext();
        }

        public ITasksRepository TasksRepository =>
            _tasksRepository ?? (_tasksRepository = new TasksRepository(_dbContext));

    }
}