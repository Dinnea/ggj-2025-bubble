using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class FollowScript : MonoBehaviour
{
    [SerializeField] Transform target; //Purpose of the object
    [SerializeField] float speedY = 2;
    [SerializeField] float speedP = 2;
    public Vector3 offset; //Purpose of the object
    public float distance = 5; //Distance
    private float yaw;
    private float pitch;

    private void Update()
    {
        yaw += speedY * Input.GetAxis("Mouse X");
        pitch -= speedP * Input.GetAxis("Mouse Y");

        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0);
        Vector3 position = rotation * new Vector3(0, 0, -distance) + target.position + offset;

        transform.position = position;
        transform.rotation = rotation;
    }

}
