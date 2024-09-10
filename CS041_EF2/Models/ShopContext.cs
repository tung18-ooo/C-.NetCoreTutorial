using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS041_EF2.Models
{
    internal class ShopContext : DbContext
    {
        public static readonly ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
        {
            builder.AddFilter(DbLoggerCategory.Query.Name, LogLevel.Information);
            builder.AddConsole();

        });

        public DbSet<Product> products { get; set; }
        public DbSet<Category> categories { get; set; }

        public DbSet<CategoryDetail> categoryDetails { get; set; }

        private const string connect = @"
                Data Source=localhost,1433;
                Initial Catalog=shopdata;
                User ID=SA;Password=password123;
                TrustServerCertificate=true";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(connect);
            optionsBuilder.UseLoggerFactory(loggerFactory);
            //optionsBuilder.UseLazyLoadingProxies();

            Console.WriteLine("OnConfiguring");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            Console.WriteLine("OnModelCreating");
            //Fluent API
            /*
             var entity = modelBuilder.Entity(typeof(Product));
            // entity => Fuent Api - Product
             */

            //var entity =modelBuilder.Entity<Product>();

            /*
            modelBuilder.Entity<Product>(entity =>
            {
                entity => Fuent Api
            });
            */

            modelBuilder.Entity<Product>(entity =>
            {
                //Table mapping
                entity.ToTable("Sanpham"); //ten bang
                //Pk: khoa chinh
                entity.HasKey(p => p.Id);

                //Index, danh' chi muc
                entity.HasIndex(p => p.Price).HasDatabaseName("index-sanpham-price"); //HasDatabaseName: dat ten chi muc

                //relative
                entity.HasOne(p => p.Category)
                .WithMany()             //Category khong co property ~ Sanpham tuong ung voi foreignkey
                .HasForeignKey("CateId") //dat ten Foreingkey
                .OnDelete(DeleteBehavior.Cascade) //khi xoa phan 1 thi phan nhieu se bi xoa di
                //DeleteBehavior.NoActive -- phan 1 bi xoa thi phan nhieu khong anh huong
                //DeleteBehavior.SetNull -- chi tao duoc khi CateId nhan gia tri null
                .HasConstraintName("Khoa_ngoai_Sanpham_Category");

                entity.HasOne(p => p.Category2)
                .WithMany(p => p.Products) // Collect Navigation
                .HasForeignKey("CateId2")
                .OnDelete(DeleteBehavior.NoAction);

                entity.Property(p => p.Name)
                .HasColumnName("title")
                .HasColumnType("nvarchar")
                .HasMaxLength(60)
                .IsRequired(true)
                .HasDefaultValue("Ten san pham mac dinh");
            });

            modelBuilder.Entity<CategoryDetail>(entity =>
            {
                entity.HasOne(d => d.category)
                .WithOne(c => c.categoryDetail)
                .HasForeignKey<CategoryDetail>(c => c.CategoryDetailId);
            });
        }
    }
}
