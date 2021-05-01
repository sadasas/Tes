using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 movement;
    public float speed;
    private bool grounded;
    private float distoGround;
    public LayerMask ground;
    public float jumpForce;
    public float lerp;

    private void Awake()
    {
        distoGround = GetComponent<Collider>().bounds.extents.y;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public bool Grounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, distoGround + 0.1f, ground);
    }

    private void Update()
    {
        movement = new Vector3(0, 0, Input.GetAxis("Horizontal"));
        movement.Normalize();
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Grounded())
            {
                rb.AddForce(transform.up * jumpForce);
            }
        }

        rb.MovePosition(transform.position + movement * speed * Time.deltaTime);
        if (movement.magnitude > 0.1)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(movement), lerp);
        }
    }
}