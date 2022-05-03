using System;
using System.Collections.Generic;
using System.Linq;
using UIManager.Runtime.Models;
using UIManager.Runtime.Screen;
using UnityEngine;

namespace UIManager.Runtime
{
    public class UiManager : MonoBehaviour, IUiManager
    {
        private IEnumerable<BaseScreen> _screens;
        private Dictionary<Type, BaseScreen> _screensMap;
        private Dictionary<Type, (BaseScreen screen, IUiModel model)> _shownScreens = new Dictionary<Type, (BaseScreen, IUiModel model)>();
        private Dictionary<Type, IPersistentUiModel> _persistentModels = new Dictionary<Type, IPersistentUiModel>();

        public void Init(IScreensProvider screensProvider)
        {
            _screens = screensProvider.GetScreens();
            foreach (var screen in _screens)
            {
                screen.gameObject.SetActive(false);
            }
            _screensMap = _screens.ToDictionary(e => e.ModelType, e => e);
        }
        
        public void Init(IEnumerable<IScreensProvider> screensProvider)
        {
            _screens = screensProvider.SelectMany(e=>e.GetScreens()).ToArray();
            foreach (var screen in _screens)
            {
                screen.gameObject.SetActive(false);
            }
            _screensMap = _screens.ToDictionary(e => e.ModelType, e => e);
        }

        public void Show<TModel>() where TModel : BaseViewModel, IPersistentUiModel
        {
            if (_screensMap.TryGetValue(typeof(TModel), out var screen))
            {
                screen.Show();
                _shownScreens.Add(typeof(TModel), (screen, _persistentModels[typeof(TModel)]));
            }
            else
            {
                Debug.LogError($"No screen for {typeof(TModel).FullName}");
            }
        }

        public void Show<TModel>(TModel model) where TModel : BaseViewModel, IOneShotUiModel
        {
            if (_screensMap.TryGetValue(typeof(TModel), out var screen))
            {
                model.InjectUiManager(this);
                screen.Bind(model);
                screen.Show();
                _shownScreens.Add(typeof(TModel), (screen, model));
            }
            else
            {
                Debug.LogError($"No screen for {typeof(TModel).FullName}");
            }
        }

        public void Close<TModel>() where TModel: class, IUiModel
        {
            if (_shownScreens.TryGetValue(typeof(TModel), out var shown))
            {
                shown.screen.Close();
                _shownScreens.Remove(typeof(TModel));
                if (shown.model is IOneShotUiModel)
                {
                    shown.model.Dispose();
                    shown.screen.Dispose();
                }
            }
            else
            {
                Debug.LogWarning($"No screen shown for {typeof(TModel).FullName}");
            }
        }

        public void BindModel<TModel>(TModel model) where TModel : BaseViewModel, IPersistentUiModel
        {
            if (_screensMap.TryGetValue(typeof(TModel), out var screen))
            {
                model.InjectUiManager(this);
                screen.Bind(model);
                _persistentModels.Add(typeof(TModel), model);
            }
            else
            {
                Debug.LogError($"No screen for {typeof(TModel).FullName}");
            }
        }
    }
}