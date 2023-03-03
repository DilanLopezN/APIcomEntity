using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiTaskList.Context;
using ApiTaskList.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiTaskList.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class TaskController : ControllerBase
  {
    private readonly OrganizerContext _context;
    public TaskController(OrganizerContext context)
    {
      _context = context;
    }

    //POST 
    [HttpPost]
    public IActionResult Create(Models.Task task)
    {
      _context.Add(task);
      _context.SaveChanges();
      return Ok();

    }

    // UPDATE
    [HttpPut("{Id}")]
    public IActionResult Update(int Id, Models.Task task)
    {
      var taskDb = _context.Tasks.Find(Id);
      if (taskDb == null)
        return NotFound();

      taskDb.Title = task.Title;
      taskDb.Description = task.Description;
      taskDb.Status = task.Status;
      taskDb.Data = task.Data;

      _context.Tasks.Update(taskDb);
      _context.SaveChanges();

      return Ok(taskDb);

    }

    // Delete
    [HttpDelete("{Id}")]
    public IActionResult Delete(int Id)
    {
      var taskDb = _context.Tasks.Find(Id);
      if (taskDb == null)
        return NotFound();

      _context.Tasks.Remove(taskDb);
      _context.SaveChanges();

      return NoContent();
    }

    // Get id
    [HttpGet("{Id}")]
    public IActionResult Get(int Id)
    {
      var tasks = _context.Tasks.Find(Id);
      if (tasks == null)
        return NotFound();

      return Ok(tasks);

    }

    [HttpGet("GetWithTitle")]
    public IActionResult GetTitle(string title)
    {
      var tasks = _context.Tasks.Where(x => x.Title.Contains(title));
      if (tasks == null)
        return NotFound();

      return Ok(tasks);
    }

    // GET STATUS
    [HttpGet("GetWithStatus")]
    public IActionResult GetStatus(int status)
    {
      var tasks = _context.Tasks.Find(status);
      if (status > 1 || status < 0)
        return NotFound("status só pode ser 1 ou 0");

      return Ok(tasks);
    }


    // GET ALL 
    [HttpGet("GetAll")]
    public IActionResult GetAll()
    {
      var tasks = _context.Tasks.ToList();
      return Ok(tasks);

    }

  }
}