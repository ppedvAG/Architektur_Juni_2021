using ppedv.Musicplayer.Logic;
using ppedv.Musicplayer.Model;
using ppedv.Musicplayer.Model.Contracts;
using System;
using System.Linq;
using System.Reflection;

namespace ppedv.Musicplayer.UI.DevConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*** ppedv Musicplayer v0.1 ***");

            //dependency injection mit referenz
            //var core = new Core(new Musicplayer.Data.EfCore.EfRepository()); 

            //dependency injection ohne Referenz, per reflection
            var efRepoPath = $@"C:\Users\Fred\source\repos\Architektur_Juni_2021\ppedv.Musicplayer\ppedv.Musicplayer.Data.EfCore\bin\Debug\net5.0\ppedv.Musicplayer.Data.EfCore.dll";
            var ass = Assembly.LoadFrom(efRepoPath);
            var typeMitRepo = ass.GetTypes().FirstOrDefault(x => x.GetInterfaces().Contains(typeof(IRepository)));
            IRepository repo = (IRepository)Activator.CreateInstance(typeMitRepo);
            var core = new Core(repo);

            //todo DI Framework


            foreach (var a in core.Repository.Query<Artist>().Where(x => x.Name.Contains("a")).OrderBy(x => x.BirthDate).ToList())
            {
                Console.WriteLine($"{a.Name} {a.City} {a.Country} {a.BirthDate}");
                Console.WriteLine($"\t{string.Join(", ", a.Songs.Select(x => x.Title))}");
            }

            var aa = core.GetArtistWithMostSongs();

            Console.WriteLine($"Most Songs: {aa?.Name}");


            Console.WriteLine("Ende");
            Console.ReadLine();
        }
    }
}
