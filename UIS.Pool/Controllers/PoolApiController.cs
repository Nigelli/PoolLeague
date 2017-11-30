using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Mvc;
using UIS.Pool.Models;
using UIS.Pool.Services;

namespace UIS.Pool.Controllers
{
    [RoutePrefix("data")]
    public class PoolApiController : Controller
    {
        private readonly ISeasonService _seasonService;
        private readonly IPlayerService _playerService;
        private readonly IMatchService _matchService;
        private readonly ILeagueService _leagueService;
        public PoolApiController(
            ISeasonService seasonService, 
            IPlayerService playerService,
            IMatchService matchService,
            ILeagueService leagueService
        )
        {
            _seasonService = seasonService;
            _playerService = playerService;
            _matchService = matchService;
            _leagueService = leagueService;
        }

        #region Season Api Methods

        [AllowAnonymous]
        [Route("seasons/get")]
        [HttpGet]
        public JsonResult GetSeasons()
        {
            var result = _seasonService.GetSeasons();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [Authorize]
        [Route("seasons/add")]
        [HttpPost]
        public JsonResult AddSeason(string description)
        {
            var result = _seasonService.InsertSeason(description);
            return Json(new { data = (result == 1) }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region League Api Methods

        [AllowAnonymous]
        [Route("leagues/get")]
        [HttpPost]
        public JsonResult GetLeaguesBySeasonId(int Id)
        {
            var result = _leagueService.GetLeaguesBySeasonId(Id);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [Authorize]
        [Route("leagues/add")]
        [HttpPost]
        public JsonResult InsertLeague(League league)
        {
            var result = _leagueService.InsertLeague(league);
            return Json(new { data = (result == 1) }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Player Api Methods

        [AllowAnonymous]
        [Route("players/get")]
        [HttpGet]
        public JsonResult GetPlayers()
        {
            var result = _playerService.GetPlayers();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [Authorize]
        [Route("players/add")]
        [HttpPost]
        public JsonResult AddPlayer(string name)
        {
            var result = _playerService.InsertPlayer(name);
            return Json(new { data = (result == 1) }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Result Api Methods

        [AllowAnonymous]
        [Route("mathces/get")]
        [HttpPost]
        public JsonResult GetMatchesByLeagueId(int Id)
        {
            var result = _matchService.GetMatchesByLeagueId(Id);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [Authorize]
        [Route("mathces/add")]
        [HttpPost]
        public JsonResult InsertOrUpdateMatch(Match match)
        {
            var result = _matchService.InsertOrUpdateMatch(match);
            return Json(new { data = (result == 1) }, JsonRequestBehavior.AllowGet);
        }
        #endregion

    }
}
