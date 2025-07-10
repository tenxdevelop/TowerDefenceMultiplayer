using System.Collections;
using SkyForge.Extension;

namespace TowerDefenceMultiplayer
{
    public class SceneService : BaseSceneService
    { 
	    public static string GAMEPALY_SCENE = "Gameplay";
	    public static string MAIN_MENU_SCENE = "MainMenu";
		public static string BOOTSTRAP_SCENE = "Bootstrap";

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
    }
}
