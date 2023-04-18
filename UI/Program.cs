using Microsoft.EntityFrameworkCore;
using Model.Entities;

using var context = new EFCoreTestContext();
var query = from land in context.Landen
            orderby land.Naam
            select land;
Console.WriteLine("Landen");
Console.WriteLine("------");
foreach (var land in query)
{
    Console.WriteLine($"{land.LandCode}: {land.Naam}");
}
Console.WriteLine("Geef een landcode in");
var landcode = Console.ReadLine();
var landKeuze = context.Landen.Find(landcode);
if (landKeuze == null)
{
    Console.WriteLine("Geef een correcte landcode in");
}
else
{
    var queryLand = from land in context.Landen.Include("Talen").Include("Steden")
                    where land == landKeuze
                    select land;
    foreach (var land in queryLand)
    {
        Console.WriteLine("Steden");
        foreach (var stad in land.Steden)
        {
            Console.WriteLine($"\t{stad.Naam}");
        }
        Console.WriteLine("Talen");
        foreach (var taal in land.Talen)
        {
            Console.WriteLine($"\t{taal.Naam}");
        }
    }
    Console.WriteLine("Geef een nieuwe stad in");
    context.Steden.Add(new Stad { Naam = Console.ReadLine(), Land = landKeuze });
    context.SaveChanges();
}