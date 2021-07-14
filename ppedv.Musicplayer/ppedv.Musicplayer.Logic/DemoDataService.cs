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
        private IUnitOfWork uow;
        private IDemoDataSource source;

        public DemoDataService(IUnitOfWork uow, IDemoDataSource source)
        {
            this.uow = uow;
            this.source = source;
        }

        public void GenerateDemoData()
        {
            foreach (var item in source.GetDemoSongsWithGenreAndArtists())
            {
                uow.SongsRepository.Add(item);
            }
            uow.Save();
        }
    }
}
