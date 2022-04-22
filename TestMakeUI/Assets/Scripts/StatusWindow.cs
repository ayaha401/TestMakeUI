using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusWindow : MonoBehaviour
{
    [SerializeField] private InputManager _inputManager = null;

    private StatusMenuState _currentState = StatusMenuState.Non;
    [SerializeField] private GameObject[] _colorObjs = new GameObject[2];

    private int _currentColorObjNum = 0;

    void Start()
    {
        ShowUI();
        ShowColorObj();
    }

    void Update()
    {
        if (_currentState != StatusMenuState.WindowOpen) return;

        if (_inputManager.UpDown() == true)
        {
            _currentColorObjNum = (_currentColorObjNum + 1) % _colorObjs.Length;
            ShowColorObj();
        }

        if (_inputManager.DownDown() == true)
        {
            _currentColorObjNum = (_currentColorObjNum - 1 + _colorObjs.Length) % _colorObjs.Length;
            ShowColorObj();
        }
    }

    void ShowColorObj()
    {
        for (int i = 0; i < _colorObjs.Length; i++)
        {
            if (_currentColorObjNum == i)
            {
                _colorObjs[i].SetActive(true);
            }
            else
            {
                _colorObjs[i].SetActive(false);
            }
        }
    }

    public void ChangeState(StatusMenuState kind)
    {
        _currentState = kind;
        ShowUI();
    }

    void ShowUI()
    {
        switch (_currentState)
        {
            case StatusMenuState.WindowOpen:
                gameObject.SetActive(true);
                break;

            default:
                gameObject.SetActive(false);
                break;
        }
    }
}
