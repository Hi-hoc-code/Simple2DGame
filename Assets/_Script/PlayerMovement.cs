using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpHeight = 10f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform groundCheck;

    private AudioManager audio;
    private bool isGrounded;
    private Rigidbody2D rb;
    private Animator animator;
    private GameManager gameManager;
    private void Awake()
    {
        audio = FindAnyObjectByType<AudioManager>();
        gameManager = FindAnyObjectByType<GameManager>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.IsGameOver() || gameManager.IsgameWin()) return;
        HandleMovement();
        HandleJump();
        UpdateAnimation();
    }
    private void HandleMovement()
    {
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
        if (moveInput < 0) transform.localScale = new Vector3(-1, 1, 1);
        else if (moveInput > 0) transform.localScale = new Vector3(1, 1, 1);
    }
    private void HandleJump()
    {
        if (Input.GetButtonDown("Jump")&& isGrounded) 
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
            audio.PlayJumpSound();
        }
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
    private void UpdateAnimation()
    {
        bool isRunning = Mathf.Abs(rb.velocity.x) > 0.1f;
        bool isJumping = !isGrounded;
        animator.SetBool("Running", isRunning);
        animator.SetBool("Jumping", isJumping);
    }

}
