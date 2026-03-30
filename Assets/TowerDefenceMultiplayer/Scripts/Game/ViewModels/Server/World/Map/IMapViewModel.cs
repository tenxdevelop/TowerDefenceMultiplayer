using SkyForge.Reactive;
using SkyForge.MVVM;

namespace TowerDefenceMultiplayer
{
    public interface IMapViewModel : IViewModel
    {
        ReactiveCollection<IEntityViewModel> Entities { get; }

        void AttachEntityHasherService(IEntityViewModelHasherService entityHasherService);
        
        void DetachEntityHasherService(IEntityViewModelHasherService entityHasherService);
    }
}