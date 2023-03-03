using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ApiTaskList.Models;

namespace ApiTaskList.Context
{
  public class OrganizerContext : DbContext
  {
    public OrganizerContext(DbContextOptions<OrganizerContext> options) : base(options)
    {

    }
    public DbSet<Models.Task> Tasks { get; set; }
  }
}