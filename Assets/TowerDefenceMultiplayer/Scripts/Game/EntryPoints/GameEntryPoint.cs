using UnityEngine.SceneManagement;
using System.Collections;
using SkyForge.Extension;
using UnityEngine;
using SkyForge;

namespace TowerDefenceMultiplayer
{
    public class GameEntryPoint
    {
        private static GameEntryPoint _instance;

        private DIContainer _rootContainer;
        private Coroutines _coroutine;
        
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void Start()
        {
            Application.targetFrameRate = 120;

            if (_instance != null)
            {
                Debug.LogError("Game is already running");
                return;
            }

            _instance = new GameEntryPoint();
            _instance.Run();
        }

        public void Run()
        {
            _rootContainer = new DIContainer();
            
            RegisterGameServices.RegisterServices(_rootContainer);
            RegisterGameViewModels.RegisterViewModels(_rootContainer);
            BindViews(_rootContainer);
            
            var sceneService = _rootContainer.Resolve<SceneService>();
            sceneService.LoadSceneEvent += OnLoadScene;
            
            _coroutine = new Coroutines();
            _rootContainer.RegisterInstance(_coroutine);

            var defaultSceneEnterParams = new MainMenuEnterParams();
            _coroutine.StartCoroutine(sceneService.LoadMainMenu(defaultSceneEnterParams));
        }

        private void OnLoadScene(Scene scene, LoadSceneMode loadSceneMode, SceneEnterParams sceneEnterParams)
        {
            var sceneName = scene.name;

            if (sceneName.Equals(SceneService.BOOTSTRAP_SCENE))
            {
                LoadBootstrap();
            } 
            else if (sceneName.Equals(SceneService.MAIN_MENU_SCENE))
            {
                _coroutine.StartCoroutine(LoadMainMenu());
            }
            else if (sceneName.Equals(SceneService.GAMEPALY_SCENE))
            {
                _coroutine.StartCoroutine(LoadGameplay());
            }
        }

        private void LoadBootstrap()
        {
            var uIRootViewModel = _rootContainer.Resolve<IUIRootViewModel>();

            uIRootViewModel.ShowLoadingScreen();
        }

        private IEnumerator LoadMainMenu()
        {
            var mainMenuContainer = new DIContainer(_rootContainer);
            
            yield return null;
            
            var uIRootViewModel = _rootContainer.Resolve<IUIRootViewModel>();
            uIRootViewModel.HideLoadingScreen();
        }

        private IEnumerator LoadGameplay()
        {
            var gameplayContainer = new DIContainer(_rootContainer);
            
            yield return null;
            
            var uIRootViewModel = _rootContainer.Resolve<IUIRootViewModel>();
            uIRootViewModel.HideLoadingScreen();
        }

        private void BindViews(DIContainer container)
        {
            var loadService = container.Resolve<LoadService>();
            
            var uIRootPrefab = loadService.LoadPrefab<UIRootView>(LoadService.PREFAB_UI_UIROOT);
            var uIRootViewModel = container.Resolve<IUIRootViewModel>();
            
            var uIRootView = loadService.CreateView(uIRootPrefab, uIRootViewModel);
            Object.DontDestroyOnLoad(uIRootView);
        }
    }    
}


