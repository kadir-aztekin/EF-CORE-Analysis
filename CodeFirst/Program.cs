// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;


//MİGRATİON CODE 
//ECommerceDbContext context = new();
//context.Database.Migrate();
Console.WriteLine();
public class ECommerceDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Customer> Customers { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=ECommerDb;Trusted_Connection=True;");
    }
}
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Quantity { get; set; }
    public float Price { get; set; }
}
public class Customer
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}