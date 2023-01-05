using EducationApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationApp.Persistence.Context
{
    public class EducationAppContext : DbContext
    {
        public EducationAppContext(DbContextOptions options) : base(options)
        {
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    //base.OnConfiguring(optionsBuilder);
        //    optionsBuilder.UseSqlServer("Server=BYNDR28;Database=myDataBase;User Id=dw;Password=Perkon123456;");
        //}

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
