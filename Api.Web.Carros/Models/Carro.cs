using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Web.Carros.Models
{
    public class Carro
    {
        public Guid Id { get; set; }
        public string Modelo { get; set; }
        public int Ano { get; set; }
        public string Marca { get; set; }
        public string LinkImg { get; set; }

        public Carro()
        {
            //criar Id automaticamente quando instanciar um novo constructor
            Id = Guid.NewGuid();
        }
    }
}
