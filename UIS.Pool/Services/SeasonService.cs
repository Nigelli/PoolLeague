using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using UIS.Pool.Models;
using UIS.Pool.Repositories;

namespace UIS.Pool.Services
{
    public class SeasonService: ISeasonService
    {
        private readonly ISeasonRepository _seasonRepository;

        public SeasonService(ISeasonRepository seasonRepository)
        {
            _seasonRepository = seasonRepository;
        }
        public IList<Season> GetSeasons()
        {
            try
            {
                return _seasonRepository.GetSeasons();
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public int InsertSeason(string description)
        {
            return _seasonRepository.InsertSeason(description);
        }
    }
}