using System.Collections;
using SkyForge.Extension;
using SkyForge.Reactive;
using UnityEngine;
using SkyForge;

namespace TowerDefenceMultiplayer
{
    public class MainMenuEntryPoint : MonoBehaviour, IEntryPoint
    {
        private SingleReactiveProperty<MainMenuExitParams> _mainMenuExitParams = new();
        private DIContainer _container;
        
        public IEnumerator Initialization(DIContainer parentContainer, SceneEnterParams sceneEnterParams)
        {
            var mainMenuEnterParams = sceneEnterParams as MainMenuEnterParams;
            _container = parentContainer;
            
            MainMenuRegisterServices.RegisterServices(_container, mainMenuEnterParams, _mainMenuExitParams);
            MainMenuRegisterViewModels.RegisterViewModels(_container, mainMenuEnterParams);
            MainMenuRegisterViews.RegisterViews(_container);
            
            Debug.Log("Init main menu");
            yield return null;
        }

        public IObservable<SceneExitParams> Run()
        {
            
            Debug.Log("Start main menu");
            
            return _mainMenuExitParams;
        }
    }
}
