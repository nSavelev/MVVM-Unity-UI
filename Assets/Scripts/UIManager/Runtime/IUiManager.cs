using UIManager.Runtime.Models;

namespace UIManager.Runtime
{
    public interface IUiManager
    {
        void Init(IScreensProvider screensProvider);
        void Show<TModel>() where TModel: BaseViewModel, IPersistentUiModel;
        void Show<TModel>(TModel model) where TModel : BaseViewModel, IOneShotUiModel;
        void Close<TModel>() where TModel: class, IUiModel;
        void BindModel<TModel>(TModel model) where TModel : BaseViewModel, IPersistentUiModel;
    }
}