using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ppedv.Musicplayer.Logic;
using ppedv.Musicplayer.Model;
using ppedv.Musicplayer.Model.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ppedv.Musicplayer.UI.Web.API.Controllers
{
    public class SongDTO
    {
        public string Title { get; set; }
        public int Length { get; set; }
    }


    [Route("api/[controller]")]
    [ApiController]
    public class SongController : ControllerBase
    {
        Core core = null;

        MapperConfiguration mapperConfiguration;

        public SongController(IUnitOfWork uow)
        {
            core = new Core(uow);
            mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Song, SongDTO>()
                    .ForMember(x => x.Title, dto => dto.MapFrom(x => x.Title))
                    .ReverseMap();
            });
        }

        // GET: api/<SongController>
        [HttpGet]
        public IEnumerable<SongDTO> Get()
        {
            //mapping by hand
            //foreach (var s in core.UnitOfWork.SongsRepository.Query().ToList())
            //{
            //    yield return new SongApi() { Title = s.Title, Length = s.Length };
            //}
            var mapper = mapperConfiguration.CreateMapper();
            foreach (var s in core.UnitOfWork.SongsRepository.Query().ToList())
            {
                yield return mapper.Map<SongDTO>(s);
            }
        }

        // GET api/<SongController>/5
        [HttpGet("{id}")]
        public SongDTO Get(int id)
        {
            var mapper = mapperConfiguration.CreateMapper();
            return mapper.Map<SongDTO>(core.UnitOfWork.SongsRepository.Query().FirstOrDefault(x => x.Id == id));
        }

        // POST api/<SongController>
        [HttpPost]
        public void Post([FromBody] SongDTO value)
        {
            var mapper = mapperConfiguration.CreateMapper();
            core.UnitOfWork.SongsRepository.Add(mapper.Map<Song>(value));
            core.UnitOfWork.Save();
        }

        // PUT api/<SongController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] SongDTO value)
        {
            var mapper = mapperConfiguration.CreateMapper();
            core.UnitOfWork.SongsRepository.Update(mapper.Map<Song>(value));
            core.UnitOfWork.Save();
        }

        // DELETE api/<SongController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            
            core.UnitOfWork.SongsRepository.Delete(core.UnitOfWork.SongsRepository.GetById(id));
            core.UnitOfWork.Save();
        }
    }
}
