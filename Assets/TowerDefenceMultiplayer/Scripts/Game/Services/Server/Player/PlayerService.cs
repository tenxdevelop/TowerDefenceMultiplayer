using SkyForge.Reactive.Extension;
using System.Collections.Generic;
using SkyForge.Reactive;
using SkyForge.Command;
using UnityEngine;

namespace TowerDefenceMultiplayer
{
    public class PlayerService : IPlayerService
    {
        public ReactiveCollection<IPlayerServerViewModel> Players { get; private set; }

        private readonly Dictionary<int, IPlayerServerViewModel> _playersMap;
        
        private ICommandProcessor _commandProcessor;
        
        public PlayerService(ReactiveCollection<IEntityStateModel> entities, ICommandProcessor commandProcessor)
        {
            _commandProcessor =  commandProcessor;
            
            _playersMap = new Dictionary<int, IPlayerServerViewModel>();
            
            UpdatePlayers(entities);
        }

        public void Dispose()
        {
            
        }

        public bool CreatePlayer(ulong clientId, string configId, Vector3 position)
        {
            var createPlayerCommand = new CmdCreatePlayer(clientId, configId, position);
            var result = _commandProcessor.Process(createPlayerCommand);

            return result;
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