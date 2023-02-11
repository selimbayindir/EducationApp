using EducationApp.Domain.Entities;
using EducationApp.Domain.Entities.Common;
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


        //Gelen Kayıt isteklerinde Eğer kayıt ise CreatedDate Eğer güncelleme ise UpdatedDate alanının doldurululmasını istiyoruz.
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)//default parememtre Repositoryde nasıl kullanndıysan o şekide ekle override save..
        {
            //Change Tracker:Entityler üğzerinde yapılan değişiklikleri ya da yeni eklenen verileri yakalanmasını sağlar.Update Operasyonlarında Track Edilen verileri yakalayıp elde etmemizi sağlar.
          var datas=ChangeTracker
                .Entries<BaseEntity>();
            foreach (var item in datas)
            {
                var _ = item.State switch   //disscard yapılanması geri dönüş gelmesin
                {
                    EntityState.Added=>item.Entity.CreatedDate=DateTime.UtcNow,
                    EntityState.Modified=> item.Entity.UpdatedDate = DateTime.UtcNow
                };
            }
                //Entries :Sürece giren <Bunu> yakala
                
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
