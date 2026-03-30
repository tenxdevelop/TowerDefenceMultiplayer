using SkyForge.Command;
using UnityEngine;

namespace TowerDefenceMultiplayer
{
    public class CmdCreatePlayer : ICommand
    {
        public readonly ulong ClientId;
        public readonly string ConfigId;
        public readonly Vector3 Position;

        public CmdCreatePlayer(ulong clientId, string configId, Vector3 position)
        {
            ClientId = clientId;
            ConfigId = configId;
            Position = position;
        }
    }
}