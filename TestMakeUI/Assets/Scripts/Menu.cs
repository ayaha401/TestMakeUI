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

    private MenuKinds _currentTabKind = MenuKinds.Status;
    private int _kindsMaxNum = 0;

    void Start()
    {
        _kindsMaxNum = _menuObj.Length;
        ShowUI(_currentTabKind);
    }

    void Update()
    {
        if (_inputManager.TabLeftMove() == true)
        {
            int currentTabNum = ((int)_currentTabKind - 1 + _kindsMaxNum) % _kindsMaxNum;
            _currentTabKind = (MenuKinds)Enum.ToObject(typeof(MenuKinds), currentTabNum);
            ShowUI(_currentTabKind);
        }

        if (_inputManager.TabRightMove() == true)
        {
            int currentTabNum = ((int)_currentTabKind + 1) % _kindsMaxNum;
            _currentTabKind = (MenuKinds)Enum.ToObject(typeof(MenuKinds), currentTabNum);
            ShowUI(_currentTabKind);
        }
    }

    void ShowUI(MenuKinds kind)
    {
        for(int i = 0; i < _kindsMaxNum; i++)
        {
            if(i == (int)kind)
            {
                if(_menuObj[i].GetComponent<IOpenableMenu>() != null)
                {
                    IOpenableMenu openableMenu = _menuObj[i].GetComponent<IOpenableMenu>();
                    openableMenu.ShowUI();
                }
            }
            else
            {
                _menuObj[i].gameObject.SetActive(false);
            }
        }
    }

    public MenuKinds SendCurrentTabKind()
    {
        return _currentTabKind;
    }
}
