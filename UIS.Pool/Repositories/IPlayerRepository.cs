using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIS.Pool.Models;

namespace UIS.Pool.Repositories
{
    public interface IPlayerRepository
    {
        IList<Player> GetPlayers();
        int InsertPlayer(string name);
    }
}
