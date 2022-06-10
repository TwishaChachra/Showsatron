using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Showsatron.Models;
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
        public DbSet<Platform> Platforms { get; set; }
        public DbSet <Genre> Genres { get; set; }
        public DbSet <AccountInfo> AccountInfos { get; set; }

    }
}
