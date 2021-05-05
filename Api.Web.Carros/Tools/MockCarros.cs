using Api.Web.Carros.Data;
using Api.Web.Carros.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Web.Carros.Tools
{
    public class MockCarros
    {
        private readonly ApplicationDbContext _context;

        public MockCarros(ApplicationDbContext applicationDbContext)
        {
            //injeção de dependência para usar o Entity
            _context = applicationDbContext;
        }

        public void AddCarrosIniciais()
        {
            List<Carro> Garagem = new List<Carro>
            {
                new Carro { Marca = "Chevrolet", Modelo = "Camaro SS", Ano = 2020, LinkImg = "https://fotos.jornaldocarro.estadao.com.br/wp-content/uploads/2020/06/04145401/Chevrolet-Camaro-azul-frente.jpg"}
            };

            //inserção no banco de dados 
            _context.Carros.AddRange(Garagem);
            _context.SaveChanges();
        }
    }
}
