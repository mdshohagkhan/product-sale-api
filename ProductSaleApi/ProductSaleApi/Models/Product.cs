using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace ProductSaleApi.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Size { get; set; }
        public string? Picture { get; set; }
        public bool? OnSale { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }=new List<Sale>();
    }

    public class Sale
    {
        public int SaleId { get; set; }
        public DateTime? Date { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; } = null!;
    }
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> op):base(op)
        {
            
        }
        public DbSet<Product> Products { get; set; } = default!;
        public DbSet<Sale> Sales { get; set; } = default!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           Random random = new Random();
            for (int i = 1; i < 5; i++)
            {
                modelBuilder.Entity<Product>().HasData(
                    new Product
                    {
                        ProductId=i,
                        ProductName=$"Product{i}",
                        Price=random.Next(1000, 2000),
                        Size=(int)random.Next(1,5),
                        Picture=i+".jpg",
                        OnSale= i % 2==0
                    });
            }
            for (int i = 1; i < 8; i++)
            { 
            modelBuilder.Entity<Sale>().HasData(
                new Sale 
                { 
                
                SaleId=i,
                Date=DateTime.Now.AddDays(-i* random.Next(400,500)),
                ProductId=(i%5==0?5:1%5),
                Quantity=random.Next(100,200)
                });
            }
        }
    }
}
