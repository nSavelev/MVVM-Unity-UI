namespace UIManager.Runtime.Models
{
    public abstract class BaseOneShotModel<TModel> : BaseViewModel, IOneShotUiModel where TModel:BaseViewModel
    {
        public void Close()
        {
            _uiManager.Close<TModel>();
        }
    }
}