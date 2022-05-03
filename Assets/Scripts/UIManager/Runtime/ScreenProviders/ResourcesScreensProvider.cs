using UIManager.Runtime.Screen;
using UnityEngine;

namespace UIManager.Runtime.ScreenProviders
{
    public class ResourcesScreensProvider : IScreensProvider
    {
        private string _screensPath;

        public ResourcesScreensProvider(string screensPath)
        {
            _screensPath = screensPath;
        }
        
        public BaseScreen[] GetScreens()
        {
            return Resources.LoadAll<BaseScreen>(_screensPath);
        }
    }
}