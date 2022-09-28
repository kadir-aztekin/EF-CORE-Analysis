// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;

BackingFieldContext context = new();
var person = await context.Persons.FindAsync(1);
//Person person2 = new()
//{
//    Name = "Person 101",
//    Department = "Departmamnt 100"
//};
//await context.Persons.AddAsync(person2);
//await context.SaveChangesAsync();
Console.ReadLine();
#region Backing Fields
//class Person
//{
//    public int Id { get; set; }
//    public string name;
//    public string Name { get => name.Substring(0,3); set=>name=value.Substring(0,3); }
//    public string Department { get; set; }
//}
#endregion
#region BackingField Attributes
//class Person
//{
//    public int Id { get; set; }

//    public string name;
//    [BackingField(nameof(name))]
//    public string Name { get; set; }
//    public string Department { get; set; }
//}
#endregion
#region Field And Property Access
//EF sorgulama surecegınde entity içerisindeki prop yada field kullanıp kullanmayacagını davranısını bizlere belirtir.
#endregion

#region Field-Only Properties
//Entitylerde değerleri almak için property'ler yerine metotların kullanıldığı veya belirli alanların hiç gösterilmemesi gerektiği durumlarda(örneğin primary key kolonu) kullanabilir.
class Person
{
    public int Id { get; set; }
    public string name;
    public string Department { get; set; }

    public string GetName()
        => name;
    public string SetName(string value)
        => this.name = value;
}
#endregion

class BackingFieldContext : DbContext
{
    public DbSet<Person> Persons { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=DenemeDb;Trusted_Connection=True;");

        //Field : Veri erişim süreçlerinde sadece field'ların kullanılmasını söyler. Eğer field'ın kullanılamayacağı durum söz konusu olursa bir exception fırlatır.
        //FieldDuringConstruction : Veri erişim süreçlerinde ilgili entityden bir nesne oluşturulma sürecinde field'ların kullanılmasını söyler.,
        //Property : Veri erişim sürecinde sadece propertynin kullanılmasını söyler. Eğer property'nin kullanılamayacağı durum söz konusuysa (read-only, write-only) bir exception fırlatır.
        //PreferField,
        //PreferFieldDuringConstruction,
        //PreferProperty
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>()
         .Property(nameof(Person.name));
    }
}