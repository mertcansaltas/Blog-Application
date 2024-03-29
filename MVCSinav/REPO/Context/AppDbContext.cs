using DATA.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REPO.Context
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Konu> Konular { get; set; }
        public DbSet<Makale> Makaleler { get; set; }
        public DbSet<KullaniciKonu> KullaniciKonular { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet< MakaleKonu> makaleKonular { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<KullaniciKonu>().HasKey(kk => new { kk.UserId, kk.KonuId });
            modelBuilder.Entity<Konu>().HasData(
            new Konu { Id = 1, KonuAdi = "Yazılım Geliştirme" },
new Konu { Id = 2, KonuAdi = "Web Geliştirme" },
new Konu { Id = 3, KonuAdi = "Mobil Uygulama Geliştirme" },
new Konu { Id = 4, KonuAdi = "Oyun Geliştirme" },
new Konu { Id = 5, KonuAdi = "Yapay Zeka" },
new Konu { Id = 6, KonuAdi = "Veritabanı Yönetimi" },
new Konu { Id = 7, KonuAdi = "Ağ Güvenliği" },
new Konu { Id = 8, KonuAdi = "Veri Analizi" },
new Konu { Id = 9, KonuAdi = "Makine Öğrenmesi" },
new Konu { Id = 10, KonuAdi = "Büyük Veri" },
new Konu { Id = 11, KonuAdi = "Bulut Bilişim" },
new Konu { Id = 12, KonuAdi = "Dağıtık Sistemler" },
new Konu { Id = 13, KonuAdi = "Veri Madenciliği" },
new Konu { Id = 14, KonuAdi = "Nesnelerin İnterneti (IoT)" },
new Konu { Id = 15, KonuAdi = "Siber Güvenlik" },
new Konu { Id = 16, KonuAdi = "Web Hizmetleri" },
new Konu { Id = 17, KonuAdi = "Mobil Uygulama Güvenliği" },
new Konu { Id = 18, KonuAdi = "Otomasyon Sistemleri" },
new Konu { Id = 19, KonuAdi = "Paralel Programlama" },
new Konu { Id = 20, KonuAdi = "Oyun Motorları" },
new Konu { Id = 21, KonuAdi = "Yazılım Testi ve Kalite Güvencesi" },
new Konu { Id = 22, KonuAdi = "Docker ve Konteynerleme Teknolojileri" },
new Konu { Id = 23, KonuAdi = "Sanal Gerçeklik ve Artırılmış Gerçeklik" },
new Konu { Id = 24, KonuAdi = "Blokzincir Teknolojisi (Blockchain)" },
new Konu { Id = 25, KonuAdi = "Veri Görselleştirme ve Grafik Tasarımı" }
         );

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-6B51G3S;Database=MVCBlogSayfasi;Trusted_Connection=True;MultipleActiveResultSets=true;Integrated Security=true;TrustServerCertificate=True;");
        }

    }
}
