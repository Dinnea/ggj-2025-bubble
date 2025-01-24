using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class FollowScript : MonoBehaviour
{
    [SerializeField] GameObject followTarget;
    [SerializeField] Vector3 offset;

    private void Update()
    {
        transform.position = followTarget.transform.position + offset;
    }
}
