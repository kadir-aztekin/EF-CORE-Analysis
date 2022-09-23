// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, World!");
ETicaretContext context = new ETicaretContext();
Urun urun = new Urun();
urun.Fiyat = 100;
urun.UrunAdi = "A";
Urun urun1 = new Urun();
urun1.Fiyat = 100;
urun1.UrunAdi = "B";
Urun urun3 = new Urun();
urun3.Fiyat = 100;
urun3.UrunAdi = "C";
await context.AddRangeAsync(urun, urun1, urun3);
//await context.AddAsync(urun);
await context.SaveChangesAsync();
public class ETicaretContext : DbContext
{
    public DbSet<Urun> Urunler { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=ECommerDb;Trusted_Connection=True;");
    }
}
public class Urun
{
    public int Id { get; set; }
    public string UrunAdi { get; set; }
    public float Fiyat { get; set; }
}