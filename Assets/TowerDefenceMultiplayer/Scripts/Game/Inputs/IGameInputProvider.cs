using System;
using System.Collections.Generic;

namespace TowerDefenceMultiplayer
{
    public interface IGameInputProvider : IDisposable
    {
        IList<IPlayerInput> GetPlayerInputs();
    }
}