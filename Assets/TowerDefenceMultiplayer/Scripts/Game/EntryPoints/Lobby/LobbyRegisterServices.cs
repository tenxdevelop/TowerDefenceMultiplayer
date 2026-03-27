using SkyForge.Reactive;
using SkyForge.Command;
using SkyForge;

namespace TowerDefenceMultiplayer
{
    public static class LobbyRegisterServices
    {
        public static void RegisterServerServices(DIContainer container, LobbyEnterParams lobbyEnterParams, SingleReactiveProperty<LobbyExitParams> lobbyExitParams)
        {
            //Register commands
            var commandProcessor = new CommandProcessor();
            var gameStateModel = container.Resolve<IGameStateProvider>().StateModel;
            
            commandProcessor.RegisterCommandHandler(new CmdCreatePlayerHandler(gameStateModel, container.Resolve<IEntityFactoryService>()));
            commandProcessor.RegisterCommandHandler(new CmdMovePlayerHandler(gameStateModel));
            
            container.RegisterInstance<ICommandProcessor>(commandProcessor);
            
            //Register services
            container.RegisterSingleton<IPlayerService>(factory => new PlayerService(gameStateModel.Entities, 
                factory.Resolve<ICommandProcessor>(), factory.Resolve<NetworkService>()));
        }

        public static void RegisterClientServices(DIContainer container, LobbyEnterParams lobbyEnterParams, SingleReactiveProperty<LobbyExitParams> lobbyExitParams)
        {
            //Register input system
            //TODO: make mapper in PlayerInput make PlayerInput concrete.
            var gameInputProvider = new GameInputProvider(new GameInputMapper());
            
            gameInputProvider.RegisterInput<IPlayerInput, PlayerInput>();
            
            container.RegisterInstance<IGameInputProvider>(gameInputProvider);
            
            //Register services
            container.RegisterSingleton<IPlayerClientService>(factory => new PlayerClientService(factory.Resolve<NetworkService>()));
            
            container.RegisterSingleton<ClientFactoryViewModel>(factory => new ClientFactoryViewModel(factory));
        }
    }
}