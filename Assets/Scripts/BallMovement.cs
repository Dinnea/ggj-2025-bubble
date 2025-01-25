using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float baseForce = 1;
    [SerializeField] float jumpForce = 100;

    [SerializeField] float pillowFriction = 20;

    [SerializeField] float boost = 10;

    float originalDrag;
    float airTime;

    [SerializeField] float airTimeLimit = 1;

    public Action<Vector3> OnDeath;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        originalDrag = rb.angularDrag;
    }

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");


        Vector3 movement = new Vector3(horizontal, 0, vertical);

        rb.AddForce(movement * baseForce);
        //Debug.Log(rb.velocity.magnitude);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        UpdateAirTime();
    }

    void UpdateAirTime()
    {
        if (!IsGrounded()) { airTime += Time.deltaTime; }
        else
        {
            airTime = 0;
        }
    }
    void Jump()
    {
        //Debug.Log(IsGrounded());
        //if (isGrounded) rb.AddForce(new Vector3(0, jumpForce, 0));
        if (IsGrounded()) rb.AddForce(new Vector3(0, jumpForce, 0));
    }

    bool IsGrounded()
    {
        Debug.DrawRay(transform.position, Vector3.down * transform.localScale.x / 2, Color.red);
        return (Physics.Raycast(transform.position, Vector3.down, transform.localScale.x/2));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Pillow"))
        {
            rb.angularDrag = pillowFriction;
        }

        if (collision.collider.CompareTag("Surface"))
        {
            if (airTime > airTimeLimit)
            {
                OnDeath?.Invoke(transform.position);
                Debug.Log("Die");
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Pillow"))
        {
            rb.angularDrag = originalDrag;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Speedy"))
        {
            rb.AddForce(new Vector3 (rb.velocity.x, 0, rb.velocity.z)*boost, ForceMode.Impulse);
        }
    }
}
