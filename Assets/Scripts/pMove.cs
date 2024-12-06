using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pMove : MonoBehaviour
{
    PlayerControls control;
    private Vector2 move;
    [Header("Movementsettings")] 
    public float setWalkSpeed = 10;
    public float moveSpeed = 5f;        // Movement speed of the player
    public float jumpForce = 10f;       // JumpForce applied to the player
    public bool canDoubleJump;
    public int jumps;
    public int jumpToHave = 2;
    public bool isToTheRight = true;
    public bool isMoving;
    [Header("Player Children")]
    public Transform groundCheck;       // Transform that checks for ground
    [Header("Layers")]
    public LayerMask groundLayer;       // Layer mask for ground detection
    [Header("Components")]
    private Rigidbody2D rb;             // Rigidbody of the player
    public SpriteRenderer sr;
    public Animator anim;
    [Header("Jump Detetection settings")]
    private bool isGrounded;            // Flag to check if the player is on the ground
    private float groundCheckRadius = 0.2f;  // Radius of the ground check
    [Header("SpellAttackSlot")] 
    public Transform spellSpawm;
    public GameObject spell;
    public float spellDamage;
    public float spellSpeed;
    

    void Start()
    {
        moveSpeed = setWalkSpeed;
        rb = GetComponent<Rigidbody2D>();  // Get the Rigidbody2D component
        //sr = GetComponent<SpriteRenderer>(); // Get the spriteRenderer component
        //anim = GetComponent<Animator>(); // get the animator component
        jumps = jumpToHave;
    }
    private void Awake()
    {
        control = new PlayerControls();

        //sets value of the thumpsticks when moved
        control.PlayerActions.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
        //set value to 0 when not using thumpsticks
        control.PlayerActions.Move.canceled += ctx => move = Vector2.zero;

        //sent southButton inptut when pressed/performed
        control.PlayerActions.Jump.performed += ctx => Jump();
        //spell attack input when pressed/performed
        control.PlayerActions.SpellAttack.performed += ctx => SpellAttack();
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

        if (rb.velocity.x != 0)
        {
            anim.SetBool("isWalking", true);
            isMoving = true;
        }
        else if (rb.velocity.x == 0)
        {
            anim.SetBool("isWalking", false);
            isMoving = false;
        }
        

        if (move.x > 0 && !isToTheRight) //moveing right but facing left
        {
            sr.flipX = false;
            isToTheRight = true;
        }
        else if (move.x < 0 && isToTheRight) // moving left but facing right
        {
            sr.flipX = true;
            isToTheRight = false;
        }
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

    void SpellAttack()
    {
        anim.SetTrigger("SpellAttack");
    }

    public void spellSpawning()
    {
        Instantiate(spell, spellSpawm.position, Quaternion.identity);
    }
}
