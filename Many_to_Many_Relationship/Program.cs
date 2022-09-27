// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

Console.WriteLine("Hello, World!");

#region Default Convention
//class Kitap
//{
//    public int Id { get; set; }
//    public string KitapAdı { get; set; }
//    public ICollection<Yazar> Yazarlar { get; set; }
//}
//class Yazar
//{
//    public int Id { get; set; }
//    public string YazarAdi { get; set; }
//    public ICollection<Kitap> Kitaplar { get; set; }

//}
//class EkitapDbContext : DbContext
//{
//    public DbSet<Kitap> Kitaplar { get; set; }
//    public DbSet<Yazar> Yazarlar { get; set; }
//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//    {
//        optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=EkitapDb;Trusted_Connection=True;");
//    }
//}
#endregion
#region Data Annatations
class Kitap
{
    public int Id { get; set; }
    public string KitapAdı { get; set; }
    public ICollection<KitapYazar> Yazarlar { get; set; }
}
class KitapYazar
{
    [Key]
    public int KitapId { get; set; }
    public int YazarId { get; set; }
    public Kitap Kitap { get; set; }
    public Yazar Yazar { get; set; }

}
class Yazar
{
    public int Id { get; set; }
    public string YazarAdi { get; set; }
    public ICollection<KitapYazar> Kitaplar { get; set; }


}
class EkitapDbContext : DbContext
{
    public DbSet<Kitap> Kitaplar { get; set; }
    public DbSet<Yazar> Yazarlar { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=EkitapDb;Trusted_Connection=True;");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<KitapYazar>()
            .HasKey(ky => new { ky.KitapId, ky.YazarId });
    }
}
#endregion