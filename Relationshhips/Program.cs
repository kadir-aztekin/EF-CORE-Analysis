// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, World!");
//Principal Entity(Asıl Entity)
//Kendi başına var olan tablo

//Dependent Entity (Bağımlı Entity)
//Başka tabloya bağlı olan tablo

//Navigation Property Nedir?
//İlişkisel tablolar arasındakı fiziksel erişimi classlar arasında sağlar
public class Calısan
{
    public int Id { get; set; }
    public string CalısanAdı { get; set; }
    public int DepartmanId { get; set; }
    public Departman Departmanlar { get; set; }
}
public class Departman
{
    public int Id { get; set; }
    public string DepartmanAdı { get; set; }
    public ICollection<Calısan> Calısanlar { get; set; }
}