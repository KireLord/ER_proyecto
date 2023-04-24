using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ER_proyecto.Models;

namespace ER_proyecto.Data
{
    public class ER_proyectoContext : DbContext
    {
        public ER_proyectoContext (DbContextOptions<ER_proyectoContext> options)
            : base(options)
        {
        }

        public DbSet<ER_proyecto.Models.ER_Tabla> ER_Tabla { get; set; } = default!;
    }
}
