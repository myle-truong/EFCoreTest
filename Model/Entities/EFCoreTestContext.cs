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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)//Đây là phương thức OnConfiguring trong lớp kế thừa DbContext của Entity Framework Core. Phương thức này được gọi bởi Entity Framework khi tạo đối tượng DbContext đầu tiên.
        {
            configuration = new ConfigurationBuilder()//Trong phương thức này, chúng ta đang định cấu hình DbContext bằng cách sử dụng đối tượng DbContextOptionsBuilder
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                .AddJsonFile("appsettings.json", false)//Đầu tiên, chúng ta sử dụng đối tượng ConfigurationBuilder để tạo một đối tượng configuration. ConfigurationBuilder được sử dụng để tải và đọc các tệp cấu hình, trong trường hợp này là appsettings.json, từ thư mục gốc của ứng dụng.
                .Build();

            var connectionString =
            configuration.GetConnectionString("EFCoreTest");//Sau đó, chúng ta sử dụng GetConnectionString của đối tượng configuration để lấy chuỗi kết nối từ tệp cấu hình. Trong trường hợp này, tên chuỗi kết nối được sử dụng là "EFCoreTest".
            if (connectionString != null)
            {
                optionsBuilder.UseSqlServer(connectionString,//Nếu chuỗi kết nối không phải là null, chúng ta cấu hình optionsBuilder để sử dụng SQL Server và thiết lập kích thước lô tối đa là 150. Chúng ta cũng kích hoạt chức năng tải lười (lazy-loading) thông qua phương thức UseLazyLoadingProxies.
                options => options.MaxBatchSize(150)).UseLazyLoadingProxies();
            }

            //optionsBuilder.LogTo(Console.WriteLine);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)//Đoạn mã này được gọi trong phương thức OnModelCreating của một lớp kế thừa từ DbContext trong Entity Framework Core, và được gọi khi cơ sở dữ liệu được khởi tạo.
        {
            /* Ở đây, đoạn mã đang được sử dụng để cấu hình các mô hình dữ liệu Land, Stad, và Taal (tạm dịch là Đất nước, Thành phố, và Ngôn ngữ), bao gồm: 
            - Thiết lập các bảng trong cơ sở dữ liệu tương ứng với các mô hình dữ liệu (Land, Stad, Taal) 
            bằng cách sử dụng phương thức .ToTable("...").

            - Đặt khóa chính (primary key) cho các bảng tương ứng bằng cách sử dụng phương thức .HasKey(...), 
            với các thuộc tính được sử dụng làm khóa chính.

            - Thiết lập các thuộc tính cho các cột trong các bảng tương ứng bằng cách sử dụng phương thức .Property(...), 
            bao gồm đặt giá trị bắt buộc (.IsRequired()) và độ dài tối đa cho các thuộc tính chuỗi (.HasMaxLength(...)).

            - Đặt các quan hệ giữa các bảng tương ứng bằng cách sử dụng các phương thức như
            .HasOne(...), .WithMany(...), và .HasForeignKey(...), để thiết lập quan hệ 
            giữa Stad và Land, và quan hệ giữa Land và Taal.

            - Đặt dữ liệu mẫu (seed data) cho các bảng Land, Stad, và Taal bằng cách sử dụng phương thức .HasData(...), 
            với các giá trị được cung cấp là các đối tượng của các mô hình dữ liệu tương ứng.
            */

            //Land
            modelBuilder.Entity<Land>().ToTable("Landen");
            modelBuilder.Entity<Land>().HasKey(l => l.LandCode);
            modelBuilder.Entity<Land>().Property(l => l.LandCode)
                .IsRequired()
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
                .HasMaxLength(3); 
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

            /*
             Thiết lập quan hệ nhiều-nhiều (many-to-many) giữa Land và Taal thông qua bảng trung gian (joining table) 
            bằng cách sử dụng phương thức .HasMany(...).WithMany(...).UsingEntity(...), và đặt dữ liệu mẫu cho bảng trung gian này 
            bằng cách sử dụng phương thức .HasData(...), với các giá trị được cung cấp là các đối tượng tương ứng 
            với quan hệ nhiều-nhiều giữa Land
             */
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
