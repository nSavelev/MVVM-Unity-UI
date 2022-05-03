namespace UIManager.Runtime.Models
{
    public class BasePersistentModel<TModel> : BaseViewModel, IPersistentUiModel where TModel:BaseViewModel
    {
        public void Close()
        {
            _uiManager.Close<TModel>();
        }
    }
}