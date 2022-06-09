using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Showsatron.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Showsatron.Models.Platform> Platforms { get; set; }
        public DbSet <Showsatron.Models.Genre> Genres { get; set; }
        public DbSet <Showsatron.Models.AccountInfo> AccountInfos { get; set; }

    }
}
