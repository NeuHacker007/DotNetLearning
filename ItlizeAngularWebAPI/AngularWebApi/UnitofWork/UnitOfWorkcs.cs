using AngularWebApi.Interfaces;
using AngularWebApi.Models;
using AngularWebApi.Repositories;

namespace AngularWebApi.UnitofWork
{
    public class UnitOfWorkcs
    {
        private readonly ApplicationDbContext _dbContext;
        private ITasksRepository _tasksRepository;

        public UnitOfWorkcs()
        {
            _dbContext = ApplicationDbContext.Create();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
        public ITasksRepository TasksRepository =>
            _tasksRepository ?? (_tasksRepository = new TasksRepository(_dbContext));

    }
}