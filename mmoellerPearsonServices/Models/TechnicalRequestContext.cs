using Microsoft.EntityFrameworkCore;

namespace mmoellerPearsonServices.Models
{
    public class TechnicalRequestContext : DbContext
    {
        public TechnicalRequestContext(DbContextOptions<TechnicalRequestContext> options)
         : base(options) 
        { 
        }
        public DbSet<TechnicalRequestForm> TechinalRequestForms { get; set; } = null!;
    }
}