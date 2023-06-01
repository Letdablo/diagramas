using Microsoft.EntityFrameworkCore;
using NetCoreSize.Models;

namespace NetCoreSize.Context
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options) { }
        public DbSet<Terminal> Terminales { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<Fabricante> Fabricantes { get; set; }
    }
}
