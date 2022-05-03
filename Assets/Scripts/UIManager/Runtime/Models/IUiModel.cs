using System;

namespace UIManager.Runtime.Models
{
    public interface IUiModel : IDisposable
    {
        void InjectUiManager(IUiManager uiManager);
        void OnShow();
        void OnClose();
    }
}