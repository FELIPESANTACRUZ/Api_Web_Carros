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

        //criando novo objeto carro
        [HttpPost]
        public IActionResult post(Carro carro)
        {
            if (carro != null)
            {
                _context.Carros.Add(carro);
                _context.SaveChanges();
                //OK retorna status 200
                return Ok("Carro adicionado na garagem");
            }
            return BadRequest();
        }

        //deletar registro //receber o id na rota
        [HttpDelete("{id}")]
        public IActionResult Remove(Guid id)
        {
            //retornar o primeiro resultado de id
            var carro = _context.Carros.First(c => c.Id == id);

            if(carro != null)
            {
                _context.Carros.Remove(carro);
                _context.SaveChanges();
                return Ok("Carro Removido!");
            }

            return BadRequest("Carro não existe");
        }

        //editar
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Carro dados)
        {
            var carro = _context.Carros.First(c => c.Id == id);

            if(carro != null)
            {
                //usando operador ternário ,caso esteja vazio mantém se não estiver altera os dados
                carro.Modelo = String.IsNullOrEmpty(dados.Modelo) ? carro.Modelo : dados.Modelo;
                carro.Ano = (dados.Ano <= 0) ? carro.Ano : dados.Ano;
                carro.Marca = String.IsNullOrEmpty(dados.Marca) ? carro.Marca : dados.Marca;
                _context.Carros.Update(carro);
                _context.SaveChanges();
                return Ok(carro);
            }

            return BadRequest("Algo deu errado!");
        }
    }
}
