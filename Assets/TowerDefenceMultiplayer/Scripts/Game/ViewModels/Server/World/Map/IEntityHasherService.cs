namespace TowerDefenceMultiplayer
{
    public interface IEntityViewModelHasherService
    {
        void OnClearEntities();
        void OnCreateEntityViewModel(IEntityStateModel entityStateModel, IEntityViewModel entityViewModel);
        void OnRemoveEntityViewModel(IEntityStateModel entityStateModel);
    }
}