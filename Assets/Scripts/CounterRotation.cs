using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterRotation : MonoBehaviour
{
    Camera cam;
    private void Awake()
    {
        cam = Camera.main;
    }
    private void Update()
    {
        transform.rotation = cam.transform.rotation;
        //transform.rotation = Quaternion.Euler(new Vector3( -transform.parent.rotation.x, -transform.parent.rotation.y, -transform.parent.rotation.z));
    }
}
