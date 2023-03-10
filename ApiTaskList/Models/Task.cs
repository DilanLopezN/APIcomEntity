using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTaskList.Models
{
  public class Task
  {
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime Data { get; set; }
    public TaskStatus Status { get; set; }
  }
}