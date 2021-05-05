using Api.Web.Carros.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Web.Carros.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> context): base(context)
        {
            
        }


        //Mapear objeto carro
        public DbSet<Carro> Carros { get; set; }

    }
}
