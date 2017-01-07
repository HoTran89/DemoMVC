﻿using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using TestMVC.Entity;

namespace TestMVC.DAL
{
    public class UserContext : DbContext
    {
        public UserContext() : base("UserContext")
        {
        }

        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}