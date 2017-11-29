﻿using System;
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
        public PoolApiController(ISeasonService seasonService)
        {
            _seasonService = seasonService;
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
        #endregion

        #region Player Api Methods
        #endregion

        #region Result Api Methods
        #endregion

    }
}