using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using AngularWebApi.Interfaces;
using AngularWebApi.Models;

namespace AngularWebApi.Repositories
{
    public class TasksRepository:GenericRepository<Tasks>,ITasksRepository
    {
        private ApplicationDbContext _dbContext;
        public TasksRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}