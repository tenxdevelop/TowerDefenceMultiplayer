using System.Collections.Generic;
using SkyForge.Input;

namespace TowerDefenceMultiplayer
{
    public class GameInputProvider : BaseInputProvider, IGameInputProvider
    {
        public GameInputProvider(IInputMapper inputMapper) : base(inputMapper)
        {
            
        }

        public IList<IPlayerInput> GetPlayerInputs()
        {
            return GetInputs<IPlayerInput>();
        }
    }
}