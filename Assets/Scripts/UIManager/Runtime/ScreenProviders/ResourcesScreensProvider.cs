using System.Linq;
using UIManager.Runtime.Screen;
using UnityEngine;

namespace UIManager.Runtime.ScreenProviders
{
    public class ResourcesScreensProvider : IScreensProvider
    {
        private string _screensPath;
        private Transform _parent;

        public ResourcesScreensProvider(string screensPath, Transform parent)
        {
            _parent = parent;
            _screensPath = screensPath;
        }
        
        public BaseScreen[] GetScreens()
        {
            return Resources.LoadAll<BaseScreen>(_screensPath).Select(e=>Object.Instantiate(e, _parent)).ToArray();
        }
    }
}