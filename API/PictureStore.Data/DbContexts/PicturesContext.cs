using Microsoft.EntityFrameworkCore;
using PictureStore.Data.Entities;

namespace PictureStore.Data.DbContexts;

public class PicturesContext : DbContext
{
    public PicturesContext(DbContextOptions<PicturesContext> options): base(options) { }

    public DbSet<Picture> Pictures { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Picture>()
            .HasIndex(p => p.Name)
            .IsUnique();
    }
}
