using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 12.0f;
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private float jumpHeight = 3.0f;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundDistance = 0.4f;
    [SerializeField] private LayerMask groundMask;

    private CharacterController controller;
    private Vector3 velocity;
    private bool isGrounded;
    private bool isMoving;
    private Vector3 lastPosition = new Vector3(0f, 0f, 0f);

    // Start is called before the first frame update
    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    private void Update()
    {
        // Ground check
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        // Resetting the default velocity
        if (isGrounded && velocity.y < 0f)
        {
            velocity.y = -2.0f;
        }

        // Getting the inputs
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // Creating the moving vector
        Vector3 move = transform.right * x + transform.forward * z;

        // Actually moving the player
        controller.Move(move * speed * Time.deltaTime);

        // Check if the player can jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            // Going up
            velocity.y = Mathf.Sqrt(-2.0f * gravity * jumpHeight);
        }

        // Falling down
        velocity.y += gravity * Time.deltaTime;

        // Executing the jump
        controller.Move(velocity * Time.deltaTime);

        if (lastPosition != transform.position && isGrounded == true)
        {
            isMoving = true;
            // for later use
        }
        else
        {
            isMoving = false;
            // for later use
        }
        lastPosition = transform.position;
    }
}
