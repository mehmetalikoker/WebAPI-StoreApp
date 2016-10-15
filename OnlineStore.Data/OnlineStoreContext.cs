using OnlineStore.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Infrastructure;

namespace OnlineStore.Data
{
    public class OnlineStoreContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        public OnlineStoreContext() 
            : base("OnlineStoreDbContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
                .HasRequired(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId);


            // user ile category arasındaki n to n  ilişki.
            // userCategory tablosu yaratıp many to many ilişki yaratacagız.
            modelBuilder.Entity<User>()
                .HasMany(u => u.AllowedCategories)
                .WithMany(c => c.AssignedUsers)
                .Map(mapping =>
                {
                    mapping.MapLeftKey("UserId");
                    mapping.MapRightKey("CategoryId");
                    mapping.ToTable("UserCategory");
                });
        }
    }
}
