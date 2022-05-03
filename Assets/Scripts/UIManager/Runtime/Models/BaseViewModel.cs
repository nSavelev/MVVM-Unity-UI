namespace UIManager.Runtime.Models
{
    public abstract class BaseViewModel : IUiModel
    {
        protected IUiManager _uiManager;

        public virtual void Dispose()
        {
        }

        public virtual void InjectUiManager(IUiManager uiManager)
        {
            _uiManager = uiManager;
        }

        public virtual void OnShow()
        {
        }

        public virtual void OnClose()
        {
        }
    }
}