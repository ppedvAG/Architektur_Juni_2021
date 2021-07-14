using ppedv.Musicplayer.Model.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ppedv.Musicplayer.Logic
{
    public class DemoDataService
    {
        private IRepository repo;
        private IDemoDataSource source;

        public DemoDataService(IRepository repo, IDemoDataSource source)
        {
            this.repo = repo;
            this.source = source;
        }

        public void GenerateDemoData()
        {
            foreach (var item in source.GetDemoSongsWithGenreAndArtists())
            {
                repo.Add(item);
            }
            repo.Save();
        }
    }
}
