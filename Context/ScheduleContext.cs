using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using APIsComCsharp.Entities;
namespace APIsComCsharp.Context
{
  public class ScheduleContext : DbContext
  {
    public ScheduleContext(DbContextOptions<ScheduleContext> options) : base(options)

    {

    }

    public DbSet<Contact> Contacts { get; set; }


  }
}