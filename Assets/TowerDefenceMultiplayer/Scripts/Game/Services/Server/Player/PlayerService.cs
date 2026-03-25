using SkyForge.Reactive.Extension;
using System.Collections.Generic;
using SkyForge.Reactive;
using SkyForge.Command;
using Unity.Netcode;
using UnityEngine;
using System.Linq;

namespace TowerDefenceMultiplayer
{
    public class PlayerService : IPlayerService
    {
        public const string PLAYER_MOVE_DIRECTION_UPDATE_SERVER_RPC = nameof(PLAYER_MOVE_DIRECTION_UPDATE_SERVER_RPC);
        public ReactiveCollection<IPlayerServerViewModel> Players { get; private set; }

        private readonly Dictionary<int, IPlayerServerViewModel> _playersMap;
        
        private readonly ICommandProcessor _commandProcessor;
        private readonly NetworkService _networkService;
        public PlayerService(ReactiveCollection<IEntityStateModel> entities, ICommandProcessor commandProcessor, NetworkService networkService)
        {
            _commandProcessor =  commandProcessor;
            _networkService = networkService;
            
            _playersMap = new Dictionary<int, IPlayerServerViewModel>();
            
            
            UpdatePlayers(entities);
            
        }

        public void RegisterNetworkMessageHandlers()
        {
            _networkService.RegisterNamedHandler(PLAYER_MOVE_DIRECTION_UPDATE_SERVER_RPC, OnPlayerMoveDirectionUpdateServerRpc);
        }
        
        public void Dispose()
        {
            _networkService.UnregisterNamedHandler(PLAYER_MOVE_DIRECTION_UPDATE_SERVER_RPC);
        }

        public bool CreatePlayer(ulong clientId, string configId, Vector3 position)
        {
            var createPlayerCommand = new CmdCreatePlayer(clientId, configId, position);
            var result = _commandProcessor.Process(createPlayerCommand);

            return result;
        }

        private void OnPlayerMoveDirectionUpdateServerRpc(ulong clientId, FastBufferReader reader)
        {
            var player = Players.Where(player => player.GetClientId() == clientId).FirstOrDefault();

            if (player is null)
                return;
            
            reader.ReadValueSafe(out Vector2 direction);
            
            player.UpdateMoveDirection(direction.normalized);
        }
        
        private void UpdatePlayers(ReactiveCollection<IEntityStateModel> entities)
        {
            Players = new ReactiveCollection<IPlayerServerViewModel>();
            
            foreach (var entity in entities)
            {
                CreatePlayerViewModel(entity);
            }

            entities.Subscribe(OnEntitiesAdded, OnEntitiesRemoved, OnPlayersClear);
        }

        private void OnPlayersClear()
        {
            Players.Clear();
            _playersMap.Clear();
        }

        private void OnEntitiesRemoved(IEntityStateModel entityStateModel)
        {
            RemovePlayerViewModel(entityStateModel);
        }

        private void OnEntitiesAdded(IEntityStateModel entityStateModel)
        {
            CreatePlayerViewModel(entityStateModel);
        }
        
        private void CreatePlayerViewModel(IEntityStateModel entityStateModel)
        {
            if (entityStateModel.EntityType.Equals(EntityType.Player))
            {
                var playerModel = entityStateModel as IPlayerModel;
                var playerViewModel = new PlayerServerViewModel(playerModel, this);
                Players.Add(playerViewModel);
                _playersMap[entityStateModel.UniqueId] = playerViewModel;
            }
        }

        private void RemovePlayerViewModel(IEntityStateModel entityStateModel)
        {
            if (entityStateModel.EntityType.Equals(EntityType.Player))
            {
                if (_playersMap.TryGetValue(entityStateModel.UniqueId, out var playerViewModelDelete))
                {
                    Players.Remove(playerViewModelDelete);
                    _playersMap.Remove(entityStateModel.UniqueId);
                }
            }
        }
    }
}