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
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository _playerRepository;

        public PlayerService(IPlayerRepository playerRepository)
        {
            Assertions.IsNullOrDefault(playerRepository, "IPlayerRepository cannot be null.");

            _playerRepository = playerRepository;
        }
        public IList<Player> GetPlayers()
        {
            try
            {
                return _playerRepository.GetPlayers();
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public int InsertPlayer(string name)
        {
            try
            {
                Assertions.IsNullEmptyOrWhitespace(name, "name cannot be null or whitespace.");
                return _playerRepository.InsertPlayer(name);
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