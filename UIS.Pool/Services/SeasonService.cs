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
using UIS.Pool.Utilities;

namespace UIS.Pool.Services
{
    public class SeasonService: ISeasonService
    {
        private readonly ISeasonRepository _seasonRepository;

        public SeasonService(ISeasonRepository seasonRepository)
        {
            Assertions.IsNullOrDefault(seasonRepository, "ISeasonRepository cannot be null.");

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
            try
            {
                Assertions.IsNullEmptyOrWhitespace(description, "description cannot be null or whitespace.");
                return _seasonRepository.InsertSeason(description);
            }
            catch (ArgumentException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}