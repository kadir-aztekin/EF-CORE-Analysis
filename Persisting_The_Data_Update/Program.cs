// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;


Console.WriteLine();

ETicaretContext context= new ETicaretContext();
Urun urun= await context.Urunler.FirstOrDefaultAsync(u => u.Id == 3);
Console.WriteLine(context.Entry(urun).State);
urun.UrunAdi = "kadir";
urun.Fiyat = 9989889;


context.Urunler.Update(urun);
Console.WriteLine(context.Entry(urun).State);
await context.SaveChangesAsync();
Console.WriteLine(context.Entry(urun).State);

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