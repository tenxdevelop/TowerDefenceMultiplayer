using System.Collections;
using SkyForge.Extension;

namespace TowerDefenceMultiplayer
{
    public class SceneService : BaseSceneService
    { 
	    public const string GAMEPALY_SCENE = "Gameplay";
	    public const string MAIN_MENU_SCENE = "MainMenu";
		public const string BOOTSTRAP_SCENE = "Bootstrap";
		public const string LOBBY_SCENE = "Lobby";

		public IEnumerator LoadMainMenu(MainMenuEnterParams mainMenuEnterParams)
		{
			yield return LoadScene(BOOTSTRAP_SCENE);
			yield return LoadScene(MAIN_MENU_SCENE, mainMenuEnterParams);
		}

		public IEnumerator LoadGameplay(GameplayEnterParams gameplayEnterParams)
		{
			yield return LoadScene(BOOTSTRAP_SCENE);
			yield return LoadScene(GAMEPALY_SCENE, gameplayEnterParams);
		}

		public IEnumerator LoadLobby(LobbyEnterParams lobbyEnterParams)
		{
			yield return LoadScene(BOOTSTRAP_SCENE);
			yield return LoadScene(LOBBY_SCENE, lobbyEnterParams);
		}
    }
}
