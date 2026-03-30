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
        
        //clientId, playerServerViewModel
        private readonly Dictionary<ulong, IPlayerServerViewModel> _playersMap;
        
        private readonly ICommandProcessor _commandProcessor;
        private readonly NetworkService _networkService;
        
        public PlayerService(ICommandProcessor commandProcessor, NetworkService networkService)
        {
            _commandProcessor =  commandProcessor;
            _networkService = networkService;
            
            _playersMap = new Dictionary<ulong, IPlayerServerViewModel>();
        }

        public void MovePlayer(int entityId, Vector2 direction, float deltaTime)
        {
            var movePlayerCommand = new CmdMovePlayer(entityId, direction, deltaTime);
            _commandProcessor.Process(movePlayerCommand);
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
            if (_playersMap.TryGetValue(clientId, out var playerViewModel))
            {
                reader.ReadValueSafe(out Vector2 direction);
                playerViewModel.UpdateMoveDirection(direction.normalized);
            }
        }

        public void OnClearEntities()
        {
            _playersMap.Clear();
        }

        public void OnCreateEntityViewModel(IEntityStateModel entityStateModel, IEntityViewModel entityViewModel)
        {
            if (entityStateModel.EntityType.Equals(EntityType.Player))
            {
                var playerStateModel = entityStateModel as IPlayerModel;

                if (playerStateModel is null)
                {
                    Debug.LogError("create player view model, but entity state model is not player model");
                    return;
                }

                var playerViewModel = entityViewModel as IPlayerServerViewModel;
                _playersMap[playerStateModel.ClientId]  = playerViewModel;
            }
        }

        public void OnRemoveEntityViewModel(IEntityStateModel entityStateModel)
        {
            if (entityStateModel.EntityType.Equals(EntityType.Player))
            {
                var playerStateModel = entityStateModel as IPlayerModel;

                if (playerStateModel is null)
                    return;
                
                _playersMap.Remove(playerStateModel.ClientId);
            }
        }
    }
}