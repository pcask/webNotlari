using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace EF_CodeFirst.Models.Manager
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Kisi> Kisiler { get; set; }
        public DbSet<Adres> Adresler { get; set; }

        public DatabaseContext()
        {
            Database.SetInitializer(new VeriTabaniOlusturucu());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            // Code-First FluenApi ile Conventions İşlemleri

            // Veri tabanı tarafında tablo isimleri oluşturulurken ingilizce dilince çoğullaştırılır. Bu varsayına davranışı ortadan kaldırmak için;
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();



            // Entity'ler arasındaki ilişkinin belirlenmesi. EF default olarak bu ilişkileri belirler fakat bazı kompleks ilişki durumlarında ne yapıcağını bilemez ve bizim aşağıdaki gibi açık açık ilişkileri belirtmemiz gerekir.
            // Adreslerin kesinlikle bir Kişisi olmak zorunda ( HasRequired ) ve bu Kişinin birden fazla Adresi olabilir ( WithMany ). Adreslerin hangi kişiye ait olduğunu adresler tablosundaki yabancı anahtar ( HasForeignKey ) olarak belirlenen Kisi_Id sütünü ile belirleriz.
            modelBuilder.Entity<Adres>()
                .HasRequired(a => a.Kisi)
                .WithMany(k => k.Adresler)
                .HasForeignKey(a => a.Kisi_Id);


            // Tablo İsimlerini Değiştirme
            modelBuilder.Entity<Kisi>()
                .ToTable("Kisiler");

            modelBuilder.Entity<Adres>()
                .ToTable("Adresler");

            // Primary Key Sütünunu Belirleme
            modelBuilder.Entity<Kisi>()
                .HasKey(k=>k.KisiId);

            modelBuilder.Entity<Adres>()
                .HasKey(a => a.AdresId);

            modelBuilder.Entity<Kisi>()
                .Property(k => k.Ad)
                .IsRequired()
                .IsUnicode(true) // Sql Server tarafında sütünün unicode desteklediği belirtilir. (nchar, nvarchar gibi)
                .HasMaxLength(50);

            modelBuilder.Entity<Kisi>()
                .Property(k => k.Soyad)
                .IsRequired()
                .HasColumnType("nvarchar")
                .HasMaxLength(50);
        }
    }

    public class VeriTabaniOlusturucu: DropCreateDatabaseAlways<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            // Kişiler Ekleniyor
            for (int i = 0; i < 10; i++)
            {
                Kisi kisi = new Kisi();
                kisi.Ad = FakeData.NameData.GetFirstName();
                kisi.Soyad = FakeData.NameData.GetSurname();
                kisi.Yas = FakeData.NumberData.GetNumber(15, 80);

                context.Kisiler.Add(kisi);
            }

            context.SaveChanges();


            // Adresler Ekneniyor.
            List<Kisi> tumKisiler = context.Kisiler.ToList();

            foreach (Kisi kisi in tumKisiler)
            {
                for (int i = 0; i < FakeData.NumberData.GetNumber(1,5); i++)
                {
                    Adres adres = new Adres();
                    adres.AdresTanım = FakeData.PlaceData.GetAddress();

                    kisi.Adresler.Add(adres);
                }
            }

            context.SaveChanges();
        }
    }
}