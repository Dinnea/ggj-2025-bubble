using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{

    private void Awake()
    {
        
    }
    private void OnEnable()
    {
        BallMovement.OnCollected += ExecOnCollected;
    }

    private void OnDisable()
    {
        BallMovement.OnCollected -= ExecOnCollected;
    }
    void ExecOnCollected(GameObject go)
    {
        if (go == gameObject) Destroy(gameObject);
    }
}
