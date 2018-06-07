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

        [HttpGet]
        public IHttpActionResult GetTasks()
        {
            var taskDto = _uow.TasksRepository.GetAll()
                .ToList()
                .Select(Mapper.Map<Tasks, TasksDto>);
            return Ok(taskDto);
        }

        [HttpGet]
        public IHttpActionResult GetTaskById(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var tasks = _uow.TasksRepository.GetTaskById(id);



            return Ok(Mapper.Map<Tasks, TasksDto>(tasks));

        }
        [HttpPost]
        public IHttpActionResult AddTasks([FromBody] TasksDto tasksDto)
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

        [HttpPut]
        public IHttpActionResult UpdateTasks([FromUri] int id, [FromBody] TasksDto tasksDto)
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

        [HttpDelete]
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
