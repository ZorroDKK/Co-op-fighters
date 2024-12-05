using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p2Move : MonoBehaviour
{
    PlayerControls1 control;
    private Vector2 move;
    [Header("Movementsettings")]
    public float moveSpeed = 5f;        // Movement speed of the player
    public float jumpForce = 10f;       // JumpForce applied to the player
    public bool canDoubleJump;
    public int jumps;
    public int jumpToHave = 2;
    [Header("Player Children")]
    public Transform groundCheck;       // Transform that checks for ground
    [Header("Layers")]
    public LayerMask groundLayer;       // Layer mask for ground detection
    [Header("Components")]
    private Rigidbody2D rb;             // Rigidbody of the player
    [Header("Jump Detetection settings")]
    private bool isGrounded;            // Flag to check if the player is on the ground
    private float groundCheckRadius = 0.2f;  // Radius of the ground check

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  // Get the Rigidbody2D component
        jumps = jumpToHave;
    }
    private void Awake()
    {
        control = new PlayerControls1();

        //sets value of the thumpstick when moved
        control.PlayerActions.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
        //set value to 0 when not using thumpstick
        control.PlayerActions.Move.canceled += ctx => move = Vector2.zero;

        //sent southButton inptu when pressed/performed
        control.PlayerActions.Jump.performed += ctx => Jump();
    }
    private void OnEnable()
    {
        control.PlayerActions.Enable();
    }

    private void OnDisable()
    {
        control.PlayerActions.Disable();
    }
    void Update()
    {
        // Check if the player is grounded
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        if (isGrounded)
        {
            jumps = jumpToHave;
        }
        // Get horizontal input
        //float horizontalInput = Input.GetAxis("Horizontal");
        
        rb.velocity = new Vector2(move.x * moveSpeed, rb.velocity.y); // Apply movement

       
    }

    void Jump()
    {
        // Handle jump input
        if (isGrounded || jumps > 0 && canDoubleJump) // "Jump" is mapped to spacebar by default
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse); // Apply jump force
            jumps--;
        }
    }
}
