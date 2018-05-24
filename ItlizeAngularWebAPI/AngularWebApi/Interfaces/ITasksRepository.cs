using AngularWebApi.Models;

namespace AngularWebApi.Interfaces
{
    public interface ITasksRepository : IRepository<Tasks>
    {
        Tasks GetTaskById(int id);
    }
}
