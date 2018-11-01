using Microsoft.EntityFrameworkCore;
using Ngtryout.Models;

namespace Ngtryout.DB
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {

        }

        public DbSet<DatapointEntity> DataList { get; set; }
    }
}
