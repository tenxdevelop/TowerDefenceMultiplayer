using SkyForge.MVVM;
using System;

namespace TowerDefenceMultiplayer
{
    [Serializable]
    public class EntityTypePrefabCreation
    {
        public EntityType EntityType;
        public BaseNetworkView Prefab;
    }
}