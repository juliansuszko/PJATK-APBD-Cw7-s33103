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
        
        modelBuilder.Entity<ComponentTypes>().HasData(
        new ComponentTypes { Id = 1, Abbreviation = "CPU", Name = "Processor" },
        new ComponentTypes { Id = 2, Abbreviation = "GPU", Name = "Graphics Card" },
        new ComponentTypes { Id = 3, Abbreviation = "RAM", Name = "Memory" }
    );

    modelBuilder.Entity<ComponentManufacturers>().HasData(
        new ComponentManufacturers { Id = 1, Abbreviation = "AMD", FullName = "Advanced Micro Devices", FoundationDate = new DateOnly(1969, 5, 1) },
        new ComponentManufacturers { Id = 2, Abbreviation = "NV", FullName = "NVIDIA Corporation", FoundationDate = new DateOnly(1993, 4, 5) },
        new ComponentManufacturers { Id = 3, Abbreviation = "COR", FullName = "Corsair Gaming Inc.", FoundationDate = new DateOnly(1994, 1, 1) }
    );

    modelBuilder.Entity<Components>().HasData(
        new Components { Code = "CPU0000001", Name = "Ryzen 7 7800X3D", Description = "8-core gaming processor", ComponentManufacturersId = 1, ComponentTypesId = 1 },
        new Components { Code = "GPU0000001", Name = "RTX 4080 Super", Description = "High-end gaming graphics card", ComponentManufacturersId = 2, ComponentTypesId = 2 },
        new Components { Code = "RAM0000001", Name = "Corsair Vengeance DDR5 16GB", Description = "DDR5 RAM module 16GB", ComponentManufacturersId = 3, ComponentTypesId = 3 }
    );

    modelBuilder.Entity<PCs>().HasData(
        new PCs { Id = 1, Name = "Gaming Beast X", Weight = 12.5f, Warranty = 36, CreatedAt = new DateTime(2026, 5, 8, 9, 0, 0), Stock = 5 },
        new PCs { Id = 2, Name = "Office Mini Pro", Weight = 4.2f, Warranty = 24, CreatedAt = new DateTime(2026, 4, 15, 13, 30, 0), Stock = 12 },
        new PCs { Id = 3, Name = "Budget Station", Weight = 7.5f, Warranty = 24, CreatedAt = new DateTime(2026, 5, 19, 10, 0, 0), Stock = 3 }
    );

    modelBuilder.Entity<PcComponents>().HasData(
        new PcComponents { PcId = 1, ComponentCode = "CPU0000001", Amount = 1 },
        new PcComponents { PcId = 1, ComponentCode = "GPU0000001", Amount = 1 },
        new PcComponents { PcId = 1, ComponentCode = "RAM0000001", Amount = 2 },
        
        new PcComponents { PcId = 2, ComponentCode = "RAM0000001", Amount = 1 },
        
        new PcComponents { PcId = 3, ComponentCode = "CPU0000001", Amount = 1 },
        new PcComponents { PcId = 3, ComponentCode = "RAM0000001", Amount = 1 }
    );
    }
}