using Microsoft.EntityFrameworkCore;
using Simulacro.Controllers;
using Simulacro.Models;

namespace Simulacro.Data
{
    public class BaseContext : DbContext
    {
        public BaseContext(DbContextOptions<BaseContext> options) : base(options)
        {
            
        }
        public DbSet<Companies>Companies { get; set; }
        public DbSet <Sectors> Sectors { get; set; }
     }
}