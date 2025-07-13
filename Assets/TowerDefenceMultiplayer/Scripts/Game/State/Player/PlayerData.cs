using System;

namespace TowerDefenceMultiplayer
{
    [Serializable]
    public class PlayerData : EntityStateData
    {
        public ulong clientId;
        public float healthPoint;
    }
}