using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Mvc;
using log4net;
using UIS.Pool.Models;
using UIS.Pool.Services;
using UIS.Pool.Utilities;

namespace UIS.Pool.Controllers
{
    [RoutePrefix("data")]
    public class PoolApiController : Controller
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(PoolApiController));

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
            Assertions.IsNullOrDefault(seasonService, "ISeasonService cannot be null");
            Assertions.IsNullOrDefault(seasonService, "IPlayerService cannot be null");
            Assertions.IsNullOrDefault(seasonService, "IMatchService cannot be null");
            Assertions.IsNullOrDefault(seasonService, "ILeagueService cannot be null");

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
            try
            {
                var result = _seasonService.GetSeasons();
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                logger.Error("Failure to retrieve Seasons from service", ex);
                throw;
            }
        }

        [Authorize]
        [Route("seasons/add")]
        [HttpPost]
        public JsonResult AddSeason(string description)
        {
            try
            {
                var result = _seasonService.InsertSeason(description);
                return Json(new { data = (result == 1) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                logger.Error($"Failure adding Season: [{description}].", ex);
                throw;
            }
        }
        #endregion

        #region League Api Methods

        [AllowAnonymous]
        [Route("leagues/get")]
        [HttpPost]
        public JsonResult GetLeaguesBySeasonId(int Id)
        {
            try
            {
                var result = _leagueService.GetLeaguesBySeasonId(Id);
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                logger.Error("Failure getting Leagues from service", ex);
                throw;
            }
            
        }

        [Authorize]
        [Route("leagues/add")]
        [HttpPost]
        public JsonResult InsertLeague(League league)
        {
            try
            {
                var result = _leagueService.InsertLeague(league);
                return Json(new { data = (result == 1) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                logger.Error($"Failure adding league.", ex);
                throw;
            }
        }

        [Authorize]
        [Route("leagues/addPlayer")]
        [HttpPost]
        public JsonResult InsertPlayerIntoLeague(int PlayerId, int LeagueId)
        {
            try
            {
                var result = _leagueService.InsertPlayerIntoLeague(PlayerId, LeagueId);
                return Json(new { data = (result == 1) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                logger.Error("Failure adding player to league", ex);
                throw;
            }
        }
        #endregion

        #region Player Api Methods

        [AllowAnonymous]
        [Route("players/get")]
        [HttpGet]
        public JsonResult GetPlayers()
        {
            try
            {
                var result = _playerService.GetPlayers();
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                logger.Error("Failure to Players from service.", ex);
                throw;
            }
        }

        [Authorize]
        [Route("players/add")]
        [HttpPost]
        public JsonResult AddPlayer(string name)
        {
            try
            {
                var result = _playerService.InsertPlayer(name);
                return Json(new { data = (result == 1) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                logger.Error($"Failure adding Player: [{name}].");
                throw;
            }
        }
        #endregion

        #region Matches Api Methods

        [AllowAnonymous]
        [Route("matches/get")]
        [HttpPost]
        public JsonResult GetMatchesByLeagueId(int Id)
        {
            try
            {
                var result = _matchService.GetMatchesByLeagueId(Id);
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                logger.Error("Failure getting Matches from service", ex);
                throw;
            }
        }

        [Authorize]
        [Route("matches/add")]
        [HttpPost]
        public JsonResult InsertOrUpdateMatch(Match match)
        {
            try
            {
                var result = _matchService.InsertOrUpdateMatch(match);
                return Json(new { data = (result == 1) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                logger.Error("Error inserting/updating Match", ex);
                throw;
            }
        }

        [Authorize]
        [Route("matches/generate")]
        [HttpPost]
        public JsonResult GenerateMatchesByLeagueId(int LeagueId)
        {
            try
            {
                var matches = _matchService.GenerateMatches(LeagueId);
                var result = _matchService.InsertMatches(matches);
                return Json(new { data = (result == 1) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                logger.Error("Failure generating Matches", ex);
                throw;
            }
        }
        #endregion

    }
}
