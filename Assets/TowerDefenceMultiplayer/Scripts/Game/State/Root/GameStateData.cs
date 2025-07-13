using System.Collections.Generic;
using System;

namespace TowerDefenceMultiplayer
{
    [Serializable]
    public class GameStateData
    {
        public int globalEntityId;
        
        public List<EntityStateData> entities;
    }
}
