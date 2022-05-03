using UIManager.Runtime.Screen;
using UnityEngine;
using UnityEngine.UI;

namespace TestUi.Main
{
    public class MainScreen : AbstractScreen<MainScreenModel>
    {
        [SerializeField]
        protected Button _btnA;
        [SerializeField]
        protected Button _btnB;
        
        protected override void OnBind(MainScreenModel model)
        {
            _btnA.onClick.AddListener(model.ShowDialogA);
            _btnB.onClick.AddListener(model.ShowDialogB);
        }
    }
}
