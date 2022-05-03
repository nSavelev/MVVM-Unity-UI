using UIManager.Runtime.Screen;
using UnityEngine;

namespace UIManager.Runtime.ScreenProviders
{
    public class ChildScreensProvider : MonoBehaviour, IScreensProvider
    {
        public BaseScreen[] GetScreens()
        {
            return GetComponentsInChildren<BaseScreen>(true);
        }
    }
}