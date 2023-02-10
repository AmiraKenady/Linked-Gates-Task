using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
    public class Context: DbContext
    {
        public DbSet<Category> category { get; set; }
        public DbSet<Device> device { get; set; }
        public DbSet<Property> property { get; set; }  
        public DbSet<PropertiesValues> PropertiesValues { get; set; }
        public Context(DbContextOptions option) : base(option) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Device>()
                .HasOne(c => c.Category)
                .WithMany(d => d.Devices)
                .HasForeignKey(c=>c.CategoryId)
                .IsRequired().OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Property>()
                .HasMany<Category>(c => c.Categories)
                .WithMany(c => c.Properties);

            modelBuilder.Entity<Property>()
                .HasMany<Device>(c => c.Devices)
                .WithMany(c => c.Property)
                .UsingEntity<PropertiesValues>()
                .HasKey(k => new { k.PropertyId, k.DeviceId });


        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            
        }
    }
}
