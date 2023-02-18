using Microsoft.EntityFrameworkCore;
using Ugovor.Models;

namespace Ugovor.Data
{
    public class UgovorDbContext : DbContext
    {
        public UgovorDbContext(DbContextOptions<UgovorDbContext> opt) : base(opt)
        {

        }

        public DbSet<UgovorModel> Ugovori { get; set; }


    }
}
