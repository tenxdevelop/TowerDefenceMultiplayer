using SkyForge.Reactive;
using SkyForge.Command;
using SkyForge;

namespace TowerDefenceMultiplayer
{
    public static class LobbyRegisterServices
    {
        public static void RegisterServices(DIContainer container, LobbyEnterParams lobbyEnterParams, SingleReactiveProperty<LobbyExitParams> lobbyExitParams)
        {
            //Register commands
            var commandProcessor = new CommandProcessor();
            var gameStateModel = container.Resolve<IGameStateProvider>().ProxyState;
            
            commandProcessor.RegisterCommandHandler(new CmdCreatePlayerHandler(gameStateModel, container.Resolve<IEntityFactoryService>()));
            
            container.RegisterInstance<ICommandProcessor>(commandProcessor);
            
            //Register services
            
            container.RegisterSingleton<IPlayerService>(factory => new PlayerService(gameStateModel.Entities, factory.Resolve<ICommandProcessor>()));
        }
    }
}