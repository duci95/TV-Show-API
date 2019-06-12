using Domain;
using EFDataAccess.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFDataAccess
{
    public class TVShowsContext : DbContext
    {
        public DbSet<Actor> Actors { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Category> Categories { get; set; }        
        public DbSet<Role> Roles { get; set; }
        public DbSet<Show> Shows { get; set; }        
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=ASUS-PC;Initial Catalog=ISDB;Integrated Security=True");
            //optionsBuilder.UseSqlServer(@"Data Source=.\SQLEXPRESS;Initial Catalog=ISDB;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {            
            modelBuilder.ApplyConfiguration(new ActorShowConfiguration());            
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new ActorConfiguration());
            modelBuilder.ApplyConfiguration(new CityConfiguration());
            modelBuilder.ApplyConfiguration(new CommentConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());            
            modelBuilder.ApplyConfiguration(new ShowConfiguration()); 

        }       
    }
}