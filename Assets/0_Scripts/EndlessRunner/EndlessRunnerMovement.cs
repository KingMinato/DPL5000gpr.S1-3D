using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessRunnerMovement : MonoBehaviour
{
    private Rigidbody rb;

    private float xPositionLeft = -3f;
    private float xPositionMiddle = 0f;
    private float xPositionRight = 3f;
    private float jumpForce = 6f;

    [SerializeField] private bool grounded = true;
    [SerializeField] private float playerHeight = 2f;
    [SerializeField] private LayerMask groundLayers;

    [SerializeField] private int laneIndex = 1; // 0 = left, 1 = middle, 2 = right

    [SerializeField] private float speed = 200f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, speed);
    }

    private void Update()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.3f, groundLayers);

        if (Input.GetKeyDown(KeyCode.A))
        {
            if (laneIndex > 0)
            {
                laneIndex--;
                ChangeLane();
            }
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            if (laneIndex < 2)
            {
                laneIndex++;
                ChangeLane();
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            Jump();
        }
    }

    private void ChangeLane()
    {
        if (laneIndex == 0)
            transform.position = new Vector3(xPositionLeft, transform.position.y, transform.position.z);
        else if (laneIndex == 1)
            transform.position = new Vector3(xPositionMiddle, transform.position.y, transform.position.z);
        else if (laneIndex == 2)
            transform.position = new Vector3(xPositionRight, transform.position.y, transform.position.z);
    }

    private void Jump()
    {
        rb.velocity += Vector3.up * jumpForce;
    }
}
