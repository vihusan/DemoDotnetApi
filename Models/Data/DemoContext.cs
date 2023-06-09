using Microsoft.EntityFrameworkCore;

namespace DemoDotnetApi.Models.Data
{
    public class DemoContext :DbContext
    {
        public DemoContext(DbContextOptions<DemoContext> options) : base(options) { }
        public DbSet<Humano> Humanos { get; set; }
    }
}
