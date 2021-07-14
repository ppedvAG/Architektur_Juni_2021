using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ppedv.Musicplayer.Logic;
using ppedv.Musicplayer.Model;
using ppedv.Musicplayer.Model.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ppedv.Musicplayer.UI.Web.ASP_MVC.Controllers
{
    public class SongsController : Controller
    {
        //Core core = new Core(new Data.EfCore.EfRepository());
        Core core = null;

        public SongsController(IRepository repo)
        {
            core = new Core(repo);
        }

        // GET: SongsController
        public ActionResult Index()
        {
            DateTime dt = new(); //.net 5
            var dt2 = new DateTime(); //.net 3.0

            return View(core.Repository.Query<Song>().ToList());
        }

        // GET: SongsController/Details/5
        public ActionResult Details(int id)
        {

            return View(core.Repository.Query<Song>().FirstOrDefault(x => x.Id == id));
        }

        // GET: SongsController/Create
        public ActionResult Create()
        {
            return View(new Song() { Title = "NEU" });
        }

        // POST: SongsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Song song)
        {
            try
            {
                core.Repository.Add(song);
                core.Repository.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SongsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(core.Repository.Query<Song>().FirstOrDefault(x => x.Id == id));
        }

        // POST: SongsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Song song)
        {
            try
            {
                core.Repository.Update(song);
                core.Repository.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SongsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(core.Repository.Query<Song>().FirstOrDefault(x => x.Id == id));
        }

        // POST: SongsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Song song)
        {
            try
            {
                core.Repository.Delete(song);
                core.Repository.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
