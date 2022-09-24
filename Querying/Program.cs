// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;


ETicaretContext context = new ETicaretContext();

//await Querying(context);

static async Task Querying(ETicaretContext context)
{

    //METHOD SYTANXs
    var urunler = await context.Urunler.ToListAsync();

    //QUERY SYTANX
    var urunler2 = await (from urun in context.Urunler
                          select urun).ToListAsync();
    var urunler3 = from urun in context.Urunler
                   select urun;
    foreach (Urun x in urunler3) /* foreach IENURUMBLA OLUR*/
    {
        Console.WriteLine(x.UrunAdi);
    }
    //IQueryable:Sorguya karşılık gelir , Sorgunun excetue edilmemiş halidir
    //IENUREMBLA:Sorguyu execute edilmiş halidir.
}

//await WHEREORDERBYTHENBY(context);

static async Task WHEREORDERBYTHENBY(ETicaretContext context)
{
    //Where
    var urunler2 = await context.Urunler.Where(u => u.Id > 2).ToListAsync();
    var urunler3 = await context.Urunler.Where(u => u.UrunAdi.StartsWith("a")).ToListAsync();

    //OrderBY
    var urunler4 = await context.Urunler.Where(u => u.Id > 2 || u.UrunAdi.EndsWith("r")).OrderBy(u => u.Id).ToListAsync();

    //thenby 
    var urunler5 = await context.Urunler.Where(u => u.Id > 2 || u.UrunAdi.EndsWith("r")).OrderBy(u => u.Id).ThenBy(u => u.Fiyat).ThenBy(u => u.Id)
    .ToListAsync();

    //SingleAsync
    var urun6 = await context.Urunler.SingleAsync(u => u.Id == 1);
    Console.WriteLine(urun6.UrunAdi);

    //Firstdefaultasync
    var urun7 = context.Urunler.FirstOrDefault(u => u.Id == 2);
    Console.WriteLine(urun7.UrunAdi);

    //FindAsync
    var urun8 = context.Urunler.Find(4);

    //Single VEYA SINGLEORDEFAULT DA TEK BİR EŞLESEN VERI YOKSA EXCEPTİON FIRLATIR
    //FAKAT FIRST VEYA FIRSTORDEFUALT DA KENDISINDEN SONRAKI VERİYİ GETİRİR 
    //FİND FONK WHERE,LİNQ KULLANMADAN DİREK PİRAMERY KEY ALANINDA SORGU YAPAR
}

//await PrivateMethods(context);

static async Task PrivateMethods(ETicaretContext context)
{
    //countAsync
    var urun9 = await context.Urunler.CountAsync();
    Console.WriteLine(urun9);

    //LongCountAsync
    var urun10 = await context.Urunler.LongCountAsync(u => u.Fiyat > 10);
    Console.WriteLine(urun10);

    //AnyAsync Boolen turunde değer dondurur
    var urun11 = await context.Urunler.AnyAsync(u => u.Fiyat > 10);
    Console.WriteLine(urun11);

    //max-min async
    var fiyat = await context.Urunler.MaxAsync(u => u.Fiyat);
    Console.WriteLine(fiyat);
    var fiyat2 = await context.Urunler.MinAsync(u => u.Fiyat);
    Console.WriteLine(fiyat2);

    //Distinct sorguda tekrar eden kayıt varsa tekilleştirir
    var tekrar = await context.Urunler.Distinct().ToListAsync();

    //sum

    var toplam = await context.Urunler.SumAsync(u => u.Fiyat);
    Console.WriteLine(toplam);
    //average

    var ortalama = await context.Urunler.AverageAsync(u => u.Fiyat);
    Console.WriteLine(ortalama);


    var datas = context.Urunler.GroupBy(ı => ı.Fiyat).Select(group=>new { Count=group.Count(),Fiyat=group.Key}).ToList();
    Console.WriteLine(datas.Count);
}










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