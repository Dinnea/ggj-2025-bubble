using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX_Manager : MonoBehaviour
{
    [SerializeField] AudioSource collectSFX;

    private void OnEnable()
    {
        BallMovement.OnCollected += PlayCollectSFX;
    }
    private void OnDisable()
    {
        BallMovement.OnCollected -= PlayCollectSFX;
    }
    void PlayCollectSFX(GameObject go)
    {
        collectSFX.Play();
    }
}
