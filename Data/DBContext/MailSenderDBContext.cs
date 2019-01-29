using System;
using Microsoft.EntityFrameworkCore;
using Model.Models;

namespace Data.DBContext
{
    public class MailSenderDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //useMssql(optionsBuilder);
            useMysql(optionsBuilder);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public void useMssql(DbContextOptionsBuilder optionsBuilder)
        {
            //todo: get on this appsettings.json
            string cn = "";

            optionsBuilder.UseSqlServer(cn);
        }

        public void useMysql(DbContextOptionsBuilder optionsBuilder)
        {
            string cn = "";

            optionsBuilder.UseMySql(cn);
        }
        
        public DbSet<MailFrom> MailFroms { get; set; }
        public DbSet<MailFrom> MailTos { get; set; }
        public DbSet<MailFrom> SystemUsers { get; set; }
    }
}
