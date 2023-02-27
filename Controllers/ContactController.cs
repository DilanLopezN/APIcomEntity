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
      return CreatedAtAction(nameof(GetName), new { id = contact.Id }, contact);

    }

    [HttpGet("{id}")]
    public IActionResult GetId(int id)
    {
      var contact = _context.Contacts.Find(id);
      if (contact == null)
        return NotFound();


      return Ok(contact);
    }

    [HttpGet("GetNames")]
    public IActionResult GetName(string name)
    {
      var contacts = _context.Contacts.Where(x => x.Name.Contains(name));
      return Ok(contacts);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Contact contact)
    {
      var contactDb = _context.Contacts.Find(id);
      if (contactDb == null)
        return NotFound();

      contactDb.Name = contact.Name;
      contactDb.Phone = contact.Phone;
      contactDb.IsActive = contact.IsActive;

      _context.Contacts.Update(contactDb);
      _context.SaveChanges();

      return Ok(contactDb);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
      var contactDb = _context.Contacts.Find(id);
      if (contactDb == null)
        return NotFound();

      _context.Contacts.Remove(contactDb);
      _context.SaveChanges();
      return NoContent();

    }
  }
}