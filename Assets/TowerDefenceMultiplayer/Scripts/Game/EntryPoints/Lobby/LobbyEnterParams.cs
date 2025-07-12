using SkyForge.Extension;

namespace TowerDefenceMultiplayer
{
    public class LobbyEnterParams : SceneEnterParams
    {
        public string LobbyCode { get; }
        public string ServerName { get; }
        public string Country { get; }
        
        public int CountPlayer { get; }

        public bool IsHost { get; }

        public LobbyEnterParams(string lobbyCode, string serverName, string country, int countPlayer,  bool isHost)
        {
            LobbyCode = lobbyCode;
            ServerName = serverName;
            Country = country;
            CountPlayer = countPlayer;
            IsHost = isHost;
        }
    }
}