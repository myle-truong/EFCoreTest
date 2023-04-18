using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class EFCoreTestContext: DbContext
    {
        public static IConfigurationRoot configuration;
        public DbSet<Land> Landen { get; set; }
        public DbSet<Stad> Steden { get; set; }
        public DbSet<Taal> Talen { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                .AddJsonFile("appsettings.json", false)
                .Build();

            var connectionString =
            configuration.GetConnectionString("EFCoreTest");
            if (connectionString != null)
            {
                optionsBuilder.UseSqlServer(connectionString,
                options => options.MaxBatchSize(150)).UseLazyLoadingProxies();
            }

            optionsBuilder.LogTo(Console.WriteLine);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Land
            modelBuilder.Entity<Land>().ToTable("Landen");
            modelBuilder.Entity<Land>().HasKey(l => l.LandCode);
            modelBuilder.Entity<Land>().Property(l => l.LandCode)
                .IsRequired()
                .HasMaxLength(2);
            modelBuilder.Entity<Land>().Property(l => l.LandCode)
                .HasMaxLength(3);
            modelBuilder.Entity<Land>().Property(l => l.Naam)
                .IsRequired()
                .HasMaxLength(50);
            modelBuilder.Entity<Land>()
                .HasIndex(l => l.LandCode)
                .IsUnique();

            //Stad
            modelBuilder.Entity<Stad>().ToTable("Steden");
            modelBuilder.Entity<Stad>().HasKey(s => s.StadNr);
            modelBuilder.Entity<Stad>().Property(s => s.StadNr)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Stad>().Property(s => s.Naam)
                .IsRequired()
                .HasMaxLength(50);
            modelBuilder.Entity<Stad>().Property(s => s.LandCode)
                .IsRequired()
                .HasMaxLength(2);
            modelBuilder.Entity<Stad>()
                .HasOne(s => s.Land)
                .WithMany(l => l.Steden)
                .HasForeignKey(s => s.LandCode);

            //Taal
            modelBuilder.Entity<Taal>().ToTable("Talen");
            modelBuilder.Entity<Taal>().HasKey(t => t.TaalCode);
            modelBuilder.Entity<Taal>().Property(t => t.TaalCode)
                .IsRequired()
                .HasMaxLength(2);
            modelBuilder.Entity<Taal>().Property(t => t.Naam)
                .IsRequired()
                .HasMaxLength(50);


            modelBuilder.Entity<Land>().HasData(
             new Land { LandCode = "BEL", Naam = "België" },
             new Land { LandCode = "DEU", Naam = "Duitsland" },
             new Land { LandCode = "FRA", Naam = "Frankrijk" },
             new Land { LandCode = "LUX", Naam = "Luxemburg" },
             new Land { LandCode = "NLD", Naam = "Nederland" });

            modelBuilder.Entity<Stad>().HasData(
                new Stad { StadNr = 1, Naam = "Brussel", LandCode = "BEL" },
                new Stad { StadNr = 2, Naam = "Antwerpen", LandCode = "BEL" },
                new Stad { StadNr = 3, Naam = "Luik", LandCode = "BEL" },
                new Stad { StadNr = 4, Naam = "Amsterdam", LandCode = "NLD" },
                new Stad { StadNr = 5, Naam = "Den Haag", LandCode = "NLD" },
                new Stad { StadNr = 6, Naam = "Rotterdam", LandCode = "NLD" },
                new Stad { StadNr = 7, Naam = "Berlijn", LandCode = "DEU" },
                new Stad { StadNr = 8, Naam = "Hamburg", LandCode = "DEU" },
                new Stad { StadNr = 9, Naam = "München", LandCode = "DEU" },
                new Stad { StadNr = 10, Naam = "Luxemburg", LandCode = "LUX" },
                new Stad { StadNr = 11, Naam = "Parijs", LandCode = "FRA" },
                new Stad { StadNr = 12, Naam = "Marseille", LandCode = "FRA" },
                new Stad { StadNr = 13, Naam = "Lyon", LandCode = "FRA" });

            modelBuilder.Entity<Taal>().HasData(
                new Taal { TaalCode = "de", Naam = "Duits" },
                new Taal { TaalCode = "fr", Naam = "Frans" },
                new Taal { TaalCode = "lb", Naam = "Luxemburgs" },
                new Taal { TaalCode = "nl", Naam = "Nederlands" });

            modelBuilder.Entity<Land>()
                .HasMany(p => p.Talen)
                .WithMany(p => p.Landen)
                .UsingEntity(j => j.HasData(
                    new { LandenLandCode = "BEL", TalenTaalCode = "de" },
                    new { LandenLandCode = "BEL", TalenTaalCode = "fr" },
                    new { LandenLandCode = "BEL", TalenTaalCode = "nl" },
                    new { LandenLandCode = "DEU", TalenTaalCode = "de" },
                    new { LandenLandCode = "FRA", TalenTaalCode = "fr" },
                    new { LandenLandCode = "LUX", TalenTaalCode = "de" },
                    new { LandenLandCode = "LUX", TalenTaalCode = "fr" },
                    new { LandenLandCode = "LUX", TalenTaalCode = "lb" },
                    new { LandenLandCode = "NLD", TalenTaalCode = "nl" })
                );
        }
    }
}
