// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
Console.WriteLine();
#region Default Convetion
//ESirketDbContext context = new();
//public class Calısan
//{
//    public int Id { get; set; }
//    public string Adı { get; set; }
//    public CalısanAdresi CalısanAdresi { get; set; }

//}
//public class CalısanAdresi
//{
//    public int Id { get; set; }
//    public int CalısanId { get; set; }
//    public string Adres { get; set; }
//    public Calısan Calısan { get; set; }
//}
//public class ESirketDbContext : DbContext
//{
//    public DbSet<Calısan> Calisanlar { get; set; }
//    public DbSet<CalısanAdresi> CalisanAdresleri { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//    {
//        optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=ESirketDb;Trusted_Connection=True;");
//    }
//}
#endregion

#region Data Annatations
//public class Calısan
//{
//    public int Id { get; set; }
//    public string Adı { get; set; }
//    public CalısanAdresi CalısanAdresi { get; set; }

//}
//public class CalısanAdresi
//{
//    [Key,ForeignKey(nameof(Calısan))]
//    public int Id { get; set; }
//    public string Adres { get; set; }
//    public Calısan Calısan { get; set; }
//}
//public class ESirketDbContext : DbContext
//{
//    public DbSet<Calısan> Calisanlar { get; set; }
//    public DbSet<CalısanAdresi> CalisanAdresleri { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//    {
//        optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=ESirketDb;Trusted_Connection=True;");
//    }
//}
#endregion

#region Fluent API
public class Calısan
{
    public int Id { get; set; }
    public string Adı { get; set; }
    public CalısanAdresi CalısanAdresi { get; set; }

}
public class CalısanAdresi
{
    public int Id { get; set; }
    public string Adres { get; set; }
    public Calısan Calısan { get; set; }
}
public class ESirketDbContext : DbContext
{
    public DbSet<Calısan> Calisanlar { get; set; }
    public DbSet<CalısanAdresi> CalisanAdresleri { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=ESirketDb;Trusted_Connection=True;");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CalısanAdresi>().HasKey(c => c.Id);
        modelBuilder.Entity<Calısan>().
            HasOne(c => c.CalısanAdresi).
            WithOne(c=>c.Calısan).HasForeignKey<CalısanAdresi>(c=>c.Id) ;
    }
}
#endregion