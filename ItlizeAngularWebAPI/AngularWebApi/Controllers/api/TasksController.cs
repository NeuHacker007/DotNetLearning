using AngularWebApi.Dtos;
using AngularWebApi.Models;
using AngularWebApi.UnitofWork;
using AutoMapper;
using System;
using System.Linq;
using System.Web.Http;

namespace AngularWebApi.Controllers.api
{
    public class TasksController : ApiController
    {
        private readonly UnitofWork.UnitOfWorkcs _uow;

        public TasksController()
        {
            _uow = new UnitOfWorkcs();
        }
        public IHttpActionResult GetTasks()
        {
            var taskDto = _uow.TasksRepository.GetAll()
                .ToList()
                .Select(Mapper.Map<Tasks, TasksDto>);
            return Ok(taskDto);
        }

        public IHttpActionResult AddTasks(TasksDto tasksDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var tasks = Mapper.Map<TasksDto, Tasks>(tasksDto);
            _uow.TasksRepository.Add(tasks);
            _uow.Save();
            tasksDto.Id = tasks.Id;
            return Created(new Uri(Request.RequestUri + "/" + tasksDto.Id), tasksDto);
        }


        public IHttpActionResult UpdateTasks(int id, TasksDto tasksDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var tasksInDb = _uow.TasksRepository.GetAll().SingleOrDefault(t => t.Id == id);
            if (tasksInDb == null)
            {
                return NotFound();
            }

            Mapper.Map(tasksDto, tasksInDb);

            _uow.Save();
            return Ok();
        }

        public IHttpActionResult DeleteTask(int id)
        {
            var tasksInDb = _uow.TasksRepository.GetAll().SingleOrDefault(t => t.Id == id);
            if (tasksInDb == null)
            {
                return NotFound();
            }
            _uow.TasksRepository.Remove(tasksInDb);
            _uow.Save();
            return Ok();
        }
    }
}
