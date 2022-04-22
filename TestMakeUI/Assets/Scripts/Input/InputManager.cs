using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public bool TabLeftMove()
    {
        return Input.GetKeyDown(KeyCode.Q);
    }

    public bool TabRightMove()
    {
        return Input.GetKeyDown(KeyCode.E);
    }

    public bool LeftDown()
    {
        return Input.GetKeyDown(KeyCode.A);
    }

    public bool RightDown()
    {
        return Input.GetKeyDown(KeyCode.D);
    }

    public bool UpDown()
    {
        return Input.GetKeyDown(KeyCode.W);
    }

    public bool DownDown()
    {
        return Input.GetKeyDown(KeyCode.S);
    }

    public bool SpaceDown()
    {
        return Input.GetKeyDown(KeyCode.Space);
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

}
