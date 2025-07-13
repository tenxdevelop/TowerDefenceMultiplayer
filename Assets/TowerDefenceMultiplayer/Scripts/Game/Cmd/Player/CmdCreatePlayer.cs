using SkyForge.Command;
using UnityEngine;

namespace TowerDefenceMultiplayer
{
    public class CmdCreatePlayer : ICommand
    {
        public readonly string ConfigId;
        public readonly Vector3 Position;

        public CmdCreatePlayer(string configId, Vector3 position)
        {
            ConfigId = configId;
            Position = position;
        }
    }
}