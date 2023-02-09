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
        public DbSet<Category> categories { get; set; }
        public DbSet<Device> devices { get; set; }
        public DbSet<Property> properties { get; set; }  
        public DbSet<PropertiesValues> PropertiesValues { get; set; }
        public Context(DbContextOptions option) : base(option) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Device>()
                .HasOne(c => c.Category)
                .WithMany(d => d.Devices)
                .HasForeignKey(c=>c.CategoryId)
                .IsRequired().OnDelete(DeleteBehavior.Cascade);
            
            //modelBuilder.Entity<Property>()
            //    .HasMany<Category>(c => c.Categories)
            //    .WithMany(c => c.Properties);
            
            modelBuilder.Entity<PropertiesValues>().
                HasOne(d=>d.Device)
                .WithMany(p=>p.Properties)
                .HasForeignKey(c=>c.DeviceId)
                .IsRequired().OnDelete(DeleteBehavior.Cascade);


        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-HH9RCV9\\SQLEXPRESS;Initial Catalog=TaskDB;Integrated Security=True");
        }
    }
}
