using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpf_mvvm_test.Models;

namespace wpf_mvvm_test.DB
{
    #region static class for in memory
    //public static class Database
    //{
    //    public static List<User> DBUsers = new List<User>();

    //    static Database()
    //    {
    //        DBUsers.Add(new User()
    //        {
    //            Id = 1,
    //            Email = "zolghadrisahin@ymail.com",
    //            Name = "shahin",
    //            Password = "123456"
    //        });
    //        DBUsers.Add(new User()
    //        {
    //            Id = 2,
    //            Email = "strange@gmail.com",
    //            Name = "something",
    //            Password = "123456"
    //        });
    //    }

    //}
    #endregion

    public class AppDBContext:DbContext
    {
        public AppDBContext()
        {
            
        }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-DL0I6I3\\SHZSQLEXPRESSDB;Initial Catalog=MVVMTEST;Integrated Security=True;Connect Timeout=30;Encrypt=False;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new UserConfig());
        }
    }
}
