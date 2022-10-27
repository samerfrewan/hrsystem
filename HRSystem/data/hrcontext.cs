using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using HRSystem.Models;

namespace HRSystem.data
{
    public class hrcontext:IdentityDbContext<Applicationuser>
    {
        IConfiguration config;
        public hrcontext(IConfiguration _config)
        {

            config = _config;
        
        }
        public DbSet<employee> employees { set; get; }
        public DbSet<department> departments { set; get; }
        public DbSet<country> countries { set; get; }
        public DbSet<city> cities { set; get; }

       
protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(config.GetConnectionString("x"));


            base.OnConfiguring(optionsBuilder);


        }
    }
}
