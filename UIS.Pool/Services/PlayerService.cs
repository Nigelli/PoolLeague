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
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository _playerRepository;

        public PlayerService(IPlayerRepository playerRepository)
        {
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
            return _playerRepository.InsertPlayer(name);
        }
    }
}