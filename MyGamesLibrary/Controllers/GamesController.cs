using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using MyGamesLibrary.Models;
using MyGamesLibrary.Repository;

namespace MyGamesLibrary.Controllers
{
    [Authorize]
    public class GamesController : Controller
    {
        IPlayedRepo playedrepo;
        IWantedRepo wantedRepo;
        IFavouriteRepo favrepo;
        public GamesController(IPlayedRepo playedrepo, IWantedRepo wantedRepo, IFavouriteRepo favrepo)
        {
            this.playedrepo = playedrepo;
            this.wantedRepo = wantedRepo;
            this.favrepo = favrepo;
        }

        public IActionResult PLayed()
        {
            List<Played> played = playedrepo.GetAll();
            return View("PLayed", played); 
        }
        public IActionResult WantsToPlay()
        {
            List<WantsToPlay> wantstoplaye = wantedRepo.GetAll();
            return View("WantsToPlay", wantstoplaye);
        }


        public IActionResult AddPlayed()
        {
            return View("AddPlayed");
        }
        public IActionResult AddWantsToPlay()
        {
            return View("AddWantsToPlay");
        }


        public IActionResult SaveAdd(Played played)
        {
            if(ModelState.IsValid == true)
            {
                playedrepo.Add(played);
                playedrepo.Save();

                return RedirectToAction("Played");
            }

            return View("AddPlayed", played);
        }

        public IActionResult SaveAdd2(WantsToPlay wantstoplay)
        {
            if (ModelState.IsValid == true)
            {
                wantedRepo.Add(wantstoplay);
                wantedRepo.Save();

                return RedirectToAction("WantsToPlay");
            }

            return View("AddWantsToPlay", wantstoplay);
        }


        public IActionResult EditPlayed(string Name)
        {
            Played game = playedrepo.GetByName(Name);
            return View("EditPlayed", game);
        }

        public IActionResult SaveEdit(Played newgame)
        {
            if (ModelState.IsValid == true)
            {
                var oldgame = playedrepo.GetByName(newgame.Name);

                oldgame.Name = newgame.Name;
                oldgame.GameType = newgame.GameType;
                oldgame.Size = newgame.Size;
                oldgame.Company = newgame.Company;
                oldgame.LikeIt = newgame.LikeIt;
                oldgame.Status = newgame.Status;

                playedrepo.Save();

                return RedirectToAction("played");
            }

            return View("EditPlayed", newgame);
        }

        public IActionResult EditWanted(string Name)
        {
            WantsToPlay game = wantedRepo.GetByName(Name);
            return View("EditWanted", game);
        }

        public IActionResult SaveEdit2(WantsToPlay newgame)
        {
            if (ModelState.IsValid == true)
            {
                var oldgame = wantedRepo.GetByName(newgame.Name);

                oldgame.Name = newgame.Name;
                oldgame.GameType = newgame.GameType;
                oldgame.Size = newgame.Size;
                oldgame.Company = newgame.Company;
                oldgame.Status = newgame.Status;

                wantedRepo.Save();

                return RedirectToAction("WantsToPlay");
            }

            return View("EditWanted", newgame);
        }


        public IActionResult Search(string searchname)
        {
            AppDbContext context = new AppDbContext();
            if (searchname != null)
            {
                List<Played> result = context.playedGames.Where(x => x.Name.StartsWith(searchname)).ToList();
                return PartialView("_Search", result);
            }
            return RedirectToAction("PLayed");
        }

        public IActionResult Search2(string searchname)
        {
            AppDbContext context = new AppDbContext();
            if (searchname != null)
            {
                List<WantsToPlay> result = context.wantsToPlayGames.Where(x => x.Name.StartsWith(searchname)).ToList();
                return View("Search2", result);
            }
            return RedirectToAction("WantsToPlay");
        }


        public IActionResult AddFav(string Name)
        {
            Played game = playedrepo.GetByName(Name);
            Favourite fav = new Favourite();
            fav.Name = game.Name;
            fav.GameType = game.GameType;
            fav.Company = game.Company;
            fav.Size = game.Size;
            fav.LikeIt = game.LikeIt;
            fav.Status = game.Status;

            if (favrepo.Check(fav))
            {
                return RedirectToAction("Played");
            }

            favrepo.Add(fav);
            favrepo.Save();
            return RedirectToAction("Played");
        }
        public IActionResult showfav()
        {
            List<Favourite> fav = favrepo.GetAll();
            return View("showfav", fav);
        }

        public IActionResult DeletePlayed(string Name)
        {
            playedrepo.Delete(Name);
            playedrepo.Save();
            return RedirectToAction("showfav");
        }
        public IActionResult DeleteWanted(string Name)
        {
            wantedRepo.Delete(Name);
            wantedRepo.Save();
            return RedirectToAction("showfav");
        }
        public IActionResult DeleteFav(string Name)
        {
            favrepo.Delete(Name);
            favrepo.Save();
            return RedirectToAction("showfav");
        }
    }
}
