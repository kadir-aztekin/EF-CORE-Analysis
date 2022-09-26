// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

Console.WriteLine("Hello, World!");
#region Default Convention
//public class Calısan
//{
//    public int Id { get; set; }
//    public string Adı { get; set; }
//    public Departman Departman { get; set; }

//}
//public class Departman
//{
//    public int Id { get; set; }
//    public string DepartmanAdı { get; set; }
//    public ICollection<Calısan> Calısanlar { get; set; }
//}
//public class ESirketDbContext : DbContext
//{
//    public DbSet<Calısan> Calisanlar { get; set; }
//    public DbSet<Departman> Departmanlar { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//    {
//        optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=ESirketDb;Trusted_Connection=True;");
//    }

//}
#endregion
#region Data Annotions
//public class Calısan
//{
//    public int Id { get; set; }
//    public string Adı { get; set; }
//    public Departman Departman { get; set; }

//}
//public class Departman
//{
//    public int Id { get; set; }
//    [ForeignKey(nameof(Departman))]
//    public int Dıd { get; set; }
//    public string DepartmanAdı { get; set; }
//    public ICollection<Calısan> Calısanlar { get; set; }
//}
//public class ESirketDbContext : DbContext
//{
//    public DbSet<Calısan> Calisanlar { get; set; }
//    public DbSet<Departman> Departmanlar { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//    {
//        optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=ESirketDb;Trusted_Connection=True;");
//    }

//}
#endregion
#region Fluent Apı
public class Calısan
{
    public int Id { get; set; }
    public string Adı { get; set; }
    public Departman Departman { get; set; }

}
public class Departman
{
    public int Id { get; set; }
    public string DepartmanAdı { get; set; }
    public ICollection<Calısan> Calısanlar { get; set; }
}
public class ESirketDbContext : DbContext
{
    public DbSet<Calısan> Calisanlar { get; set; }
    public DbSet<Departman> Departmanlar { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=ESirketDb;Trusted_Connection=True;");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Calısan>()
            .HasOne(c => c.Departman)
            .WithMany(d => d.Calısanlar);
    }

}
#endregion