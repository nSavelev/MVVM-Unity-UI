using System;
using TestUi.Dialog;
using UIManager.Runtime;
using UIManager.Runtime.Models;
using UnityEngine;

namespace TestUi.Main
{
    public class MainScreenModel : BasePersistentModel<MainScreenModel>
    {
        public MainScreenModel()
        {
        }

        public void ShowDialogA()
        {
            _uiManager.Show(new DialogModel("DialogA", new []
            {
                ((string text, Action onClick)) ("OK", ()=>{Debug.Log("OK");}), 
                ((string text, Action onClick)) ("Cancel", ()=>{Debug.Log("Cancel");})
            }));
        }

        public void ShowDialogB()
        {
            _uiManager.Show(new DialogModel("DialogB", new []
            {
                ((string text, Action onClick)) ("OK", ()=>{Debug.Log("OK");}), 
                ((string text, Action onClick)) ("Cancel", ()=>{Debug.Log("Cancel");})
            }));
        }
    }
}
