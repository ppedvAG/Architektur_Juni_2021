using Bogus;
using ppedv.Musicplayer.Model;
using ppedv.Musicplayer.Model.Contracts;
using System;
using System.Collections.Generic;

namespace ppedv.Musicplayer.DemoData.Bogus
{
    public class BogusDataGenerator : IDemoDataSource
    {
        int seed = 12;
        string lang = "de";

        public IEnumerable<Song> GetDemoSongsWithGenreAndArtists()
        {
            var genreFaker = new Faker<Genre>(lang)
                .UseSeed(seed)
                .RuleFor(x => x.Description, f => f.Music.Genre());

            var artFaker = new Faker<Artist>(lang)
             .UseSeed(seed)
             .RuleFor(x => x.Name, f => f.Name.FullName())
             .RuleFor(x => x.Country, f => f.Address.Country())
             .RuleFor(x => x.City, f => f.Address.City())
             .RuleFor(x => x.BirthDate, f => f.Date.Past(40));

            var artists = artFaker.Generate(100);

            var genres = genreFaker.Generate(10);

            var songFaker = new Faker<Song>(lang)
                .UseSeed(seed)
                .RuleFor(x => x.Title, f => $"{f.Commerce.Color()} {f.Commerce.ProductAdjective()} {f.Commerce.Product()}" )
                .RuleFor(x => x.Length, f => f.Random.Number(100, 1000))
                .RuleFor(x => x.Source, f => f.Lorem.Sentences(3))
                .RuleFor(x => x.Artists, f => new HashSet<Artist>(f.PickRandom(artists, f.Random.Int(1, 4))))
                .RuleFor(x => x.Genre, f => f.PickRandom(genres));

            return songFaker.Generate(100);
        }
    }
}
