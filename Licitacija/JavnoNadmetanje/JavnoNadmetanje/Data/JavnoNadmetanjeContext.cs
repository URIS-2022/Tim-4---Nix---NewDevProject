using JavnoNadmetanje.Enums;
using JavnoNadmetanje.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace JavnoNadmetanje.Data
{
    public class JavnoNadmetanjeContext : DbContext
    {
        public JavnoNadmetanjeContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<JavnoNadmetanjeModel> JavnaNadmetanja { get; set; }

    }
}
