using UnityEngine;
using System;

namespace TowerDefenceMultiplayer
{
    [Serializable]
    public class EntityStateData
    {
        public int uniqueId;
        public string configId;
        public EntityType entityType;
        public Vector3 position;
    }
}
