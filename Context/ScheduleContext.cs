using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIsComCsharp.Entities;
using Microsoft.EntityFrameworkCore;

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
