using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public void Spawn (GameObject toSpawn)
    {
        Instantiate(toSpawn, transform.position, transform.rotation);
    }

    private void OnEnable()
    {
        GameManager.DebugSwitch += DebugMode;
    }

    private void OnDisable()
    {
        GameManager.DebugSwitch -= DebugMode;
    }

    void DebugMode(bool debug)
    {
        MeshRenderer renderer = GetComponent<MeshRenderer>();
        renderer.enabled = debug;
    }
}
