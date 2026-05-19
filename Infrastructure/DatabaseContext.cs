using Microsoft.EntityFrameworkCore;
using PJATK_APBD_Cw7_s33103.Models;

namespace PJATK_APBD_Cw7_s33103.Infrastructure;

public class DatabaseContext(DbContextOptions opt) : DbContext(opt)
{
    public DbSet<PCs> Pcs { get; set; }
    public DbSet<PcComponents> PcComponents { get; set; }
    public DbSet<ComponentTypes> ComponentTypes { get; set; }
    public DbSet<Components> Components { get; set; }
    public DbSet<ComponentManufacturers> ComponentManufacturers { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}