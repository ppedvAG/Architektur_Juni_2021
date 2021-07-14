using Autofac;
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

            #region dependency injection mit referenz
            //var core = new Core(new Musicplayer.Data.EfCore.EfRepository()); 
            #endregion

            #region dependency injection ohne Referenz auf ppedv.Musicplayer.Data.EfCore, per reflection
            //var efRepoPath = $@"C:\Users\Fred\source\repos\Architektur_Juni_2021\ppedv.Musicplayer\ppedv.Musicplayer.Data.EfCore\bin\Debug\net5.0\ppedv.Musicplayer.Data.EfCore.dll";
            //var ass = Assembly.LoadFrom(efRepoPath);
            //var typeMitRepo = ass.GetTypes().FirstOrDefault(x => x.GetInterfaces().Contains(typeof(IRepository)));
            //IRepository repo = (IRepository)Activator.CreateInstance(typeMitRepo);
            //var core = new Core(repo);
            #endregion

            #region AutoFac als DI Framework ohne Referenz auf ppedv.Musicplayer.Data.EfCore
            //var efRepoPath = $@"C:\Users\Fred\source\repos\Architektur_Juni_2021\ppedv.Musicplayer\ppedv.Musicplayer.Data.EfCore\bin\Debug\net5.0\ppedv.Musicplayer.Data.EfCore.dll";
            //var ass = Assembly.LoadFrom(efRepoPath);
            //var builder = new ContainerBuilder();
            //builder.RegisterAssemblyTypes(ass).Where(t => t.Name.EndsWith("Repository")).AsImplementedInterfaces();
            //var container = builder.Build();

            //var core = new Core(container.Resolve<IRepository>());
            #endregion

            #region AutoFac als DI Framework mit Referenz auf ppedv.Musicplayer.Data.EfCore
            var builder = new ContainerBuilder();
            builder.RegisterType<Musicplayer.Data.EfCore.EfRepository>().AsImplementedInterfaces();
            var container = builder.Build();

            var core = new Core(container.Resolve<IRepository>());
            #endregion


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
