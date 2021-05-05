using Api.Web.Carros.Data;
using Api.Web.Carros.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Web.Carros.Controllers
{
    //dizendo que é uma controller de API ao prjeto
    [ApiController]

    [Route("[Controller]")]

    //class CarrosController herda de ControllerBase
    public class CarrosController : ControllerBase
    {
        private ApplicationDbContext _context;

        public CarrosController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Carro> Get()
        {
            //praticamente um comando "select * from Carros"
            return _context.Carros;
        }
    }
}
