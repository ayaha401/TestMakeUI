using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum MenuKinds
{
    Map,
    Status,
    Option,
    Exit,
}

public class Menu : MonoBehaviour
{
    [SerializeField] private InputManager _inputManager = null;

    [SerializeField] private GameObject[] _menuObj = new GameObject[4];

    private int _currentNum = 0;

    private MenuKinds _currentTabKind = MenuKinds.Map;
    private int _kindsMaxNum = 0;

    void Start()
    {
        _kindsMaxNum = _menuObj.Length;
    }

    void Update()
    {
        if (_inputManager.LeftDown() == true)
        {
            int currentTabNum = ((int)_currentTabKind - 1 + _kindsMaxNum) % _kindsMaxNum;
            _currentTabKind = (MenuKinds)Enum.ToObject(typeof(MenuKinds), currentTabNum);
        }

        if (_inputManager.RightDown() == true)
        {
            int currentTabNum = ((int)_currentTabKind + 1) % _kindsMaxNum;
            _currentTabKind = (MenuKinds)Enum.ToObject(typeof(MenuKinds), currentTabNum);
        }

        switch (_currentTabKind)
        {
            case MenuKinds.Map:
                Debug.Log("Map");
                break;
            case MenuKinds.Status:
                Debug.Log("Status");
                break;
            case MenuKinds.Option:
                Debug.Log("Option");
                break;
            case MenuKinds.Exit:
                Debug.Log("Exit");
                break;
        }
    }
}
