using Microsoft.EntityFrameworkCore;
using ResqDoc.Models;

namespace resqdoc.Models
{
    public class Context : DbContext
    {

        public Context(DbContextOptions<Context> options)
            : base(options)
        { }

        public DbSet<Ocorrencia> Ocorrencia { get; set; }
        public DbSet<Cobrade> Cobrade { get; set; }
    }
}
