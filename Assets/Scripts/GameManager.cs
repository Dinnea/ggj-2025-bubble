using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    GameManager instance;
    public static bool debug = true;
    public static Action<bool> DebugSwitch;

    private void Awake()
    {
        if(instance == null) instance = this;
        DontDestroyOnLoad(gameObject);
    }
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

    public void LoadGameScene()
    {
        SceneManager.LoadScene(0);
    }
}
