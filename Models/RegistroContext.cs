using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RegistroDePontosApi.Models
{
    public class RegistroContext : DbContext
    {
        public RegistroContext(DbContextOptions<RegistroContext> options)
        :base(options)
        {
        }

        public DbSet<RegistroPonto> RegistroPonto{ get; set; } = null!;
    }
}