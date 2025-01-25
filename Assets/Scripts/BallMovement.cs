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
    public static Action<GameObject> OnCollected;

   

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        originalDrag = rb.angularDrag;
    }

    private void Update()
    {
       Movement();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        UpdateAirTime();
    }

    void Movement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");


        Vector3 movement = new(horizontal, 0, vertical);

        if (IsGrounded()) rb.AddForce(movement * baseForce);
        //else Debug.Log("Nope");
    }

    void UpdateAirTime()
    {
        if (!IsGrounded()) { airTime += Time.deltaTime; }
    }
    void Jump()
    {
        //Debug.Log(IsGrounded());
        if (IsGrounded()) rb.AddForce(new Vector3(0, jumpForce, 0));
    }

    bool IsGrounded()
    {
        return (Physics.Raycast(transform.position, Vector3.down, 1f));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Pillow"))
        {
            rb.angularDrag = pillowFriction;
        }

        if (collision.collider.CompareTag("Surface"))
        {
            Debug.Log(airTime);
            if (airTime > airTimeLimit)
            {

                OnDeath?.Invoke(transform.position);
                Debug.Log("Die");
            }
            else airTime = 0;
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

        if (other.CompareTag("Collectible"))
        {
            Debug.Log("contact");
            OnCollected?.Invoke(other.gameObject);
        }
    }
}
