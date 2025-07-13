using SkyForge.Reactive.Extention;
using SkyForge.Reactive;
using UnityEngine;

namespace TowerDefenceMultiplayer
{
    public class PlayerModel : IPlayerModel
    {
        public PlayerData OriginState { get; private set; }
        
        public ReactiveProperty<float> HealthPoint { get; private set; }
        public ReactiveProperty<Vector3> Position { get; private set; }
        
        public EntityType EntityType =>  OriginState.entityType;
        
        public int UniqueId =>  OriginState.uniqueId;

        public string ConfigId => OriginState.configId;

        public PlayerModel(PlayerData originState)
        {
            OriginState = originState;
            
            HealthPoint = new ReactiveProperty<float>(originState.healthPoint);
            Position = new ReactiveProperty<Vector3>(originState.position);
            
            HealthPoint.Subscribe(newHealthPoint => originState.healthPoint = newHealthPoint);
            Position.Subscribe(newPosition => originState.position = newPosition);
        }
    }
}