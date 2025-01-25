using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFX_Manager : MonoBehaviour
{
    [SerializeField]GameObject collectVFX;

    private void OnEnable()
    {
        BallMovement.OnCollected += ExecCollectVFX;
    }

    private void OnDisable()
    {
        BallMovement.OnCollected -= ExecCollectVFX;
    }

    void ExecCollectVFX(GameObject go)
    {
       Instantiate(collectVFX, go.transform.position, go.transform.rotation);
    }
}
