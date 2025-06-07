using Microsoft.EntityFrameworkCore;
using System;
using TrabajoPraactico_Programación3.Models;

namespace TrabajoPraactico_Programación3.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {

        }

        public DbSet<Gastos> Gastos { get; set; }
    }
}
