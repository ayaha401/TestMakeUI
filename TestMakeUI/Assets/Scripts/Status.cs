using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StatusMenuState
{
    Non,
    MenuOpen,
    MenuClose,
    WindowOpen,
}
public class Status : MonoBehaviour, IOpenableMenu
{
    [SerializeField] private InputManager _inputManager = null;
    [SerializeField] private GameObject _window = null;
    [SerializeField] private GameObject[] _colorObjs = new GameObject[2];

    private StatusMenuState _currentState = StatusMenuState.MenuClose;
    private int _currentColorObjNum = 0;

    private bool _isOpen = false;

    void Start()
    {
        StatusUIShow(_currentState);
        ShowColorObj();
    }

    void Update()
    {
        if (_currentState == StatusMenuState.MenuClose) return;

        if(_inputManager.UpDown() == true && _currentState == StatusMenuState.MenuOpen)
        {
            _currentColorObjNum = (_currentColorObjNum + 1) % _colorObjs.Length;
            ShowColorObj();
        }

        if (_inputManager.DownDown() == true && _currentState == StatusMenuState.MenuOpen)
        {
            _currentColorObjNum = (_currentColorObjNum - 1 + _colorObjs.Length) % _colorObjs.Length;
            ShowColorObj();
        }

        if(_inputManager.SpaceDown() == true)
        {
            _isOpen = !_isOpen;
            if(_isOpen == true)
            {
                StatusUIShow(StatusMenuState.WindowOpen);
            }
            else
            {
                StatusUIShow(StatusMenuState.MenuOpen);
            }
        }
    }

    void ShowColorObj()
    {
        for (int i = 0; i < _colorObjs.Length; i++)
        {
            if(_currentColorObjNum == i)
            {
                _colorObjs[i].SetActive(true);
            }
            else
            {
                _colorObjs[i].SetActive(false);
            }
        }
    }

    void IOpenableMenu.ShowUI()
    {
        StatusUIShow(StatusMenuState.MenuOpen);
    }

    private void StatusUIShow(StatusMenuState state)
    {
        _currentState = state;

        SetStatusWindow();

        switch (_currentState)
        {
            case StatusMenuState.MenuOpen:
                this.gameObject.SetActive(true);
                break;

            case StatusMenuState.MenuClose:
                this.gameObject.SetActive(false);
                break;

            case StatusMenuState.WindowOpen:
                break;
        }
    }

    void SetStatusWindow()
    {
        StatusWindow statusWindow = _window.GetComponent<StatusWindow>();
        statusWindow.ChangeState(_currentState);
    }
}
