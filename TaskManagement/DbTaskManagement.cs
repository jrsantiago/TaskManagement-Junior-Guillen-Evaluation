using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TaskManagement.Models;

namespace TaskManagement
{
    public class DbTaskManagement : DbContext
    {
        public DbTaskManagement() : base("DbTask")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<DbTaskManagement>(null);

            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet <Usuarios> usuarios { get; set; }
        public virtual DbSet <Tareas> tareas { get; set; }

    }
}