using Microsoft.EntityFrameworkCore;

namespace PTE_Test_Helper.Models
{
    public class PTE_Test_HelperContext : DbContext
    {
        public PTE_Test_HelperContext(DbContextOptions<PTE_Test_HelperContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<RO> RO { get; set; }
    }
}
