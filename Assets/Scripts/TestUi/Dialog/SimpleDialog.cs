using UIManager.Runtime.Screen;
using UnityEngine;
using UnityEngine.UI;

namespace TestUi.Dialog
{
    public class SimpleDialog : AbstractScreen<DialogModel>
    {
        [SerializeField]
        protected DialogButton[] _buttons;
        [SerializeField]
        protected Button[] _close;
        [SerializeField]
        protected Text _message;

        protected override void OnBind(DialogModel model)
        {
            foreach (var close in _close)
            {
                close.onClick.AddListener(()=>
                {
                    model.Close();
                });
            }
            _message.text = model.MessageText;
            for (int i = 0; i < _buttons.Length; i++)
            {
                if (model.Buttons.Length > i)
                {
                    _buttons[i].gameObject.SetActive(true);
                    var index = i;
                    _buttons[i].Init(model.Buttons[i].text, ()=>
                    {
                        model.Buttons[index].onClick?.Invoke();
                        model.Close();
                    });
                }
                else
                {
                    _buttons[i].gameObject.SetActive(false);
                }
            }
        }

        public override void Dispose()
        {
            Debug.Log($"Disposing {name}");
            foreach (var btn in _buttons)
            {
                btn.Dispose();
            }

            foreach (var close in _close)
            {
                close.onClick.RemoveAllListeners();
            }
        }
    }
}
