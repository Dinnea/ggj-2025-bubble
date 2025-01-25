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
        if (followTarget != null) transform.position = followTarget.transform.position + offset;
    }
}
