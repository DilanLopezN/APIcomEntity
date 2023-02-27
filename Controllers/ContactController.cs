using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIsComCsharp.Context;
using APIsComCsharp.Entities;
using Microsoft.AspNetCore.Mvc;

namespace APIsComCsharp.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class ContactController : ControllerBase
  {

    private readonly ScheduleContext _context;
    public ContactController(ScheduleContext context)
    {
      _context = context;

    }

    [HttpPost]
    public IActionResult Create(Contact contact)
    {
      _context.Add(contact);
      _context.SaveChanges();
      return Ok(contact);

    }
  }
}