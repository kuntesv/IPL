using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using IPLDataModels;

namespace IPLDbContext
{
    public class IplSqlDbContext : DbContext 
    {
        public DbSet<Team> teams { get; set; }
        public DbSet<Coach> Coaches { get; set; }
        public DbSet<Match> Matches { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string IplDb = "Data Source=DESKTOP-IBQA4NC;Initial Catalog=IPLDB; Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False";


            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer(IplDb);
            }
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Coach>().HasData(

                new Coach { 
                 Id = 1,
                 name = "Peter symonds",
                 CreatedDate = new DateTime(2025, 1, 31)
                }, 
                new Coach
                {
                    Id = 2,
                    name = "Paul Walker",
                    CreatedDate = new DateTime(2025, 1, 31)
                }
                );


        }
        


    }
}
