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
            // todo: types must not be hard coded 
            //modelBuilder.Entity<User>()
            //    .ToTable("Users")
            //    .HasDiscriminator<string>("UserType")
            //    .HasValue<Seller>("Seller")
            //    .HasValue<Customer>("Customer");
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
        
        public DbSet<MailInfo> MailInfos { get; set; }
    }
}
