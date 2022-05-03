using System;
using UIManager.Runtime.Models;

namespace TestUi.Dialog
{
    public class DialogModel : BaseOneShotModel<DialogModel>
    {
        public DialogModel(string message, (string text, Action onClick)[] buttons)
        {
            MessageText = message;
            Buttons = buttons;
        }

        public (string text, Action onClick)[] Buttons { get; }

        public string MessageText { get; }
    }
}
