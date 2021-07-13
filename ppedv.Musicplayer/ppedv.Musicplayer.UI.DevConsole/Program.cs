using ppedv.Musicplayer.Logic;
using ppedv.Musicplayer.Model;
using System;

namespace ppedv.Musicplayer.UI.DevConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*** ppedv Musicplayer v0.1 ***");

            //dependency injection mit referenz
            var core = new Core(new Musicplayer.Data.EfCore.EfRepository()); 

            foreach (var a in core.Repository.GetAll<Artist>())
            {
                Console.WriteLine($"{a.Name} {a.City} {a.Country} {a.BirthDate}");
            }

            var aa = core.GetArtistWithMostSongs();

            Console.WriteLine($"Most Songs: {aa.Name}");


            Console.WriteLine("Ende");
            Console.ReadLine();
        }
    }
}
