using e_commerce.Models.asbstractClasses;
using e_commerce.Models.implementations;
using e_commerce.Models.interfaces;
using Microsoft.EntityFrameworkCore;

namespace e_commerce.Data.Context
{
    public class ProductContext : DbContext
    {
        public DbSet<AbstractProduct> Products { get; set; }
        public DbSet<Models.implementations.Processor> Processors { get; set; }
        public DbSet<VideoCard> VideoCards { get; set; }
        public ProductContext(DbContextOptions<ProductContext> options) : base(options: options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AbstractProduct>()
                 
              .HasDiscriminator<string>("product_type")
              .HasValue<Models.implementations.Processor>("Processors")
              .HasValue<VideoCard>("VideoCards");

            modelBuilder.Entity<AbstractProduct>()
                .HasKey(p => p.Id);

         

        }

   


    }

}
