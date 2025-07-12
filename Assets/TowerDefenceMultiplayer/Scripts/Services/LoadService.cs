using SkyForge.MVVM;
using UnityEngine;

namespace TowerDefenceMultiplayer
{
    public class LoadService : System.IDisposable
    {
        public static string PREFAB_NETWORK_MANAGER = "Prefabs/Network/NetworkManager";
        
        public static string PREFAB_UI_UIROOT = "Prefabs/UI/UIRoot";
        public static string PREFAB_UI_STATIC_UIROOT_MAIN_MENU = "Prefabs/UI/MainMenu/StaticUIRootMainMenu";
        public static string PREFAB_UI_UIROOT_MAIN_MENU = "Prefabs/UI/MainMenu/UIRootMainMenu";
        
        public T LoadPrefab<T>(string prefabPath) where T : Object
        {
            var prefab = Resources.Load<T>(prefabPath);
            
            if (prefab is null)
            {
                Debug.LogError($"Failed to load prefab: {prefabPath}");
                throw new System.MethodAccessException("Failed to load prefab");
            }
            
            return prefab;
        }

        public T CreateGameObject<T>(T prefab, Transform parent = null) where T : Object
        {
            var newGameObject = Object.Instantiate(prefab, parent);
            return newGameObject;
        }

        public T CreateView<T>(T prefab, IViewModel viewModel, Transform parent = null) where T : View
        {
            var view = Object.Instantiate(prefab, parent);
            view.Bind(viewModel);
            
            return view;
        }
        
        public void Dispose()
        {
            
        }
    }
}