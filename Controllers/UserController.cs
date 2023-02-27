using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace APIsComCsharp.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class UserController : ControllerBase
  {

    [HttpGet("ObterDataHoraAtual")]
    public IActionResult ObterDataHora()
    {
      var obj = new
      {
        Data = DateTime.Now.ToLongDateString(),
        Hora = DateTime.Now.ToShortTimeString()
      };

      return Ok(obj);
    }
  }
}