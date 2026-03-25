using SkyForge;

namespace TowerDefenceMultiplayer
{
    public static class LobbyRegisterNetworkHandlers
    {
        public static void RegisterServerNetworkMessageHandlers(DIContainer container)
        {
            var playerService = container.Resolve<IPlayerService>();
            playerService.RegisterNetworkMessageHandlers();
        }
    }
}