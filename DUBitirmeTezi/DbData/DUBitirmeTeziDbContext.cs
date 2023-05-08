using Microsoft.EntityFrameworkCore;
using DUBitirmeTezi.Models.Akademik;
using DUBitirmeTezi.Models.Universitemiz;
using DUBitirmeTezi.Models;
using DUBitirmeTezi.Models.Anasayfa;
using System.Collections.Generic;
using System.Linq;
using System;

namespace DUBitirmeTezi.DbData
{
    public class DUBitirmeTeziDbContext : DbContext
    {
        public DUBitirmeTeziDbContext(DbContextOptions<DUBitirmeTeziDbContext> options) : base(options)
        {
            this.Database.EnsureCreated();
        }

        //public DbSet<ModelAdı> Veritabanına Eklenecek Tablonun Adı { get; set; }

        //Models/Akademik
        public DbSet<Enstitu> Enstitus { get; set; }
        public DbSet<EnstituDetay> EnstituDetays { get; set; }
        public DbSet<Fakulte> Fakultes { get; set; }
        public DbSet<FakulteDetay> FakulteDetays { get; set; }
        public DbSet<MeslekYuksekokulu> MeslekYuksekokulus { get; set; }
        public DbSet<MeslekYuksekokulDetay> MeslekYuksekokulDetays { get; set; }
        public DbSet<Yuksekokul> Yuksekokuls { get; set; }
        public DbSet<YuksekokulDetay> YuksekokulDetays { get; set; }

        //Models/Universitemiz
        public DbSet<FotografGalerisi> FotografGalerisis { get; set; }
        public DbSet<Yonetim> Yonetims { get; set; }
        public DbSet<YonetimDetay> YonetimDetays { get; set; }

        //Anasayfadaki proje sayıları 
        public DbSet<ProjeSayilari> ProjeSayilaris { get; set; }

        public DbSet<Duyurular> Duyurulars { get; set; }

        public DbSet<YetkiliGirisi> YetkiliGirisis { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProjeSayilari>().HasData(
                new ProjeSayilari
                {
                    Id = 1 ,
                    Baslik = "KENTİMİZ VE SANAYİ ELELE ÜRETEN ÜNİVERSİTE" ,
                    Aciklama = "Sanayi ve iş dünyası ile üniversiteyi ortak akıl, ortak hedef ve ortak başarı ilkeleri doğrultusunda ortak projelerle biraraya getirerek üniversitenin ve sanayinin gelişmesine katkıda bulunmaktır.",
                    Fakulte = "14",
                    Enstitu = "4",
                    Yuksekokul = "14",
                    MeslekYuksekokulu = "17",
                    LisansProgrami = "66",
                    LisansutsuProgrami = "71",
                    UygulamaArastirmaMerkezi = "21",
                    Koordinatorluk = "7" ,
                    TubitakProjesi = "77", 
                    BapProjesi = "500" , 
                    SponsorluProje = "5",
                    Patent = "300"
                });

            modelBuilder.Entity<YetkiliGirisi>().HasData(
                new YetkiliGirisi
                {
                    Id = 1 ,
                    Ad = "Melih",
                    Soyad = "Dinçer",
                    KullaniciAdi="MelihDincer",
                    Sifre="melih",
                    Mail = "melihdincer@gmail.com",
                    Telefon = "05311048276",
                    DahiliTelefon = "1234",
                    KullanicininEklendigiTarih = Convert.ToDateTime("01-10-2021"),
                    AktifMi = true
                });

            modelBuilder.Entity<YetkiliGirisi>().HasData(
                new YetkiliGirisi
                {
                    Id = 2,
                    Ad = "admin",
                    Soyad = "admin",
                    KullaniciAdi = "admin",
                    Mail = "admin@gmail.com",
                    Sifre = "admin",
                    Telefon = "05055055555",
                    DahiliTelefon = "1234",
                    KullanicininEklendigiTarih = Convert.ToDateTime("01-10-2021"),
                    AktifMi = true
                });
        }
    }
}