using SkyForge.Reactive.Extention;
using SkyForge.Reactive;

namespace TowerDefenceMultiplayer
{
    public class PlayerPrefsGameStateProvider : IGameStateProvider
    {
        private const string GAME_STATE_KEY = nameof(GAME_STATE_KEY);
        public GameStateModel ProxyState { get; private set; }
        
        
        public PlayerPrefsGameStateProvider(IEntityFactoryService entityFactoryService)
        {
            var gameStateData = new GameStateData();
            
            ProxyState = new GameStateModel(gameStateData, entityFactoryService);
        }
        
        public void Dispose()
        {
            
        }

        public IObservable<bool> SaveState()
        {
            return Observable.Return(true);
        }

        public IObservable<bool> ResetState()
        {
            
            return Observable.Return(true);
        }

        public IObservable<GameStateModel> LoadState()
        {
            return Observable.Return(ProxyState);
        }

        
    }
}