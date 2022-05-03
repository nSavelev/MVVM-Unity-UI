using UIManager.Runtime.Screen;

namespace UIManager.Runtime
{
    public interface IScreensProvider
    {
        BaseScreen[] GetScreens();
    }
}