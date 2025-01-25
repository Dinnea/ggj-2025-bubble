using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool debug = true;
    public static Action<bool> DebugSwitch;
    void SwitchDebug()
    {
        debug = !debug;
        DebugSwitch?.Invoke(debug);
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.LeftShift))
        {
            if(Input.GetKeyDown(KeyCode.Q)) SwitchDebug();
        }
        
    }
}
