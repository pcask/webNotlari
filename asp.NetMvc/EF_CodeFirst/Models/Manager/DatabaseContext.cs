using System;
using System.Collections.Generic;
using System.Data.Entity;
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

            // Tablo İsimlerini Değiştirme
            modelBuilder.Entity<Kisi>().ToTable("KisilerTablosu");
            modelBuilder.Entity<Adres>().ToTable("Adresler");

            // Primary Key Sütünunu Belirleme
            modelBuilder.Entity<Kisi>().HasKey<int>(s => s.Id);
            modelBuilder.Entity<Kisi>().HasKey<int>(s => s.Id);


        }
    }

    public class VeriTabaniOlusturucu: CreateDatabaseIfNotExists<DatabaseContext>
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