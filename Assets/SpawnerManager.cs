using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    [SerializeField]List<Spawner> spawners;
    [SerializeField] GameObject collectible;
    int collectiblesToSpawn = 1;
    private void Awake()
    {
       spawners = FindObjectsByType<Spawner>(FindObjectsSortMode.None).ToList<Spawner>();
    }

    private void Start()
    {
        for (int i = 0; i < collectiblesToSpawn; i++) 
        {
            int index = Random.Range(0, spawners.Count);
            spawners[index].Spawn(collectible);
        }
    }
}
