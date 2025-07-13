#if UNITY_EDITOR

using System.Collections.Generic;
using SkyForge.MVVM.Editors;
using SkyForge.Reactive;
using SkyForge.MVVM;
using UnityEditor;
using System.Linq;
using SkyForge;

namespace TowerDefenceMultiplayer.Editor
{
    [CustomEditor(typeof(VMCollectionToNetworkGameObjectCreationBinder))]
    public class VMCollectionToNetworkGameObjectCreationBinderEditor : BinderEditor
    {
        protected override IEnumerable<string> GetPropertyNames()
        {
            var properties = new List<string>() { MVVMConstant.NONE };
            
            return properties.Concat(SkyForgeDefineAssembly.GetPlayerAssembly().GetType(ViewModelTypeFullName.stringValue).GetProperties()
                .Where(property => property.PropertyType.IsGenericType)
                .Where(property => property.PropertyType.GetInterfaces().Where(interfaceProperty => interfaceProperty.IsGenericType).Any(interfaceProperty =>
                        typeof(IObservableCollection<>).IsAssignableFrom(interfaceProperty.GetGenericTypeDefinition())))
                .Where(property => typeof(INetworkViewModel).IsAssignableFrom(property.PropertyType.GenericTypeArguments.First()))
                .Select(property => property.Name)
                .OrderBy(propertyName => propertyName));
            
        }
    }
}

#endif