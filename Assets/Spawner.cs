using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public void Spawn (GameObject toSpawn)
    {
        Instantiate(toSpawn, transform.position, transform.rotation);
    }
}
