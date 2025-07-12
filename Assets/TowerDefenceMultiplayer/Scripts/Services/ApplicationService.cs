using System;
using UnityEditor;
using UnityEngine;

namespace TowerDefenceMultiplayer
{
    public class ApplicationService : IDisposable
    {
        public void Dispose()
        {
             
        }

        public void CloseGame()
        {
#if DEBUG
            EditorApplication.ExitPlaymode();
#else
            Application.Quit();            
#endif
        }
    }
}