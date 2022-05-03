using System.Collections;
using System.Collections.Generic;
using TestUi.Main;
using UIManager.Runtime;
using UIManager.Runtime.ScreenProviders;
using UnityEngine;

public class TestInit : MonoBehaviour
{
    [SerializeField]
    private ChildScreensProvider _screensProvider;
    [SerializeField]
    private UiManager _uiManager;

    void Awake()
    {
        _uiManager.Init(_screensProvider);
        _uiManager.BindModel(new MainScreenModel());
        _uiManager.Show<MainScreenModel>();
    }
}
