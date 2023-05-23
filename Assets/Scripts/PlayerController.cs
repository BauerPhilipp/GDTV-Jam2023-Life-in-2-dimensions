using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float jumpingPower;
    [SerializeField] private float moveSpeed;
    [SerializeField] private int maxDoubleJumps = 1;


    private Animator animator;
    private int doubleJumpCount = 0;
    private bool isGrounded;
    private Vector3 moveDir;
    private PlayerControls playerControls;
    private Rigidbody rb;

    private void Awake()
    {
        playerControls = new PlayerControls();
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }
    private void Start()
    {
        playerControls.Movement.Turbo.started += _ => Turbo();        
    }

    private void Update()
    {
        GetPlayerInput();
        PlayerJump();
    }

    private void FixedUpdate()
    {
        PlayerMove();
    }

    private void GetPlayerInput()
    {
        moveDir = playerControls.Movement.Move.ReadValue<Vector2>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.gameObject.CompareTag("Path"))
        {
            isGrounded = true;
            doubleJumpCount = 0;
        }
    }

    private void PlayerMove()
    {
        moveDir.y = 0;
        moveDir.z = 0;
        rb.MovePosition(rb.position + moveDir * (Time.fixedDeltaTime * moveSpeed));
        animator.SetFloat("isMoving", Mathf.RoundToInt(moveDir.x));
    }
    private void PlayerJump()
    {
        if (playerControls.Movement.Jump.triggered && doubleJumpCount < maxDoubleJumps)
        {
            doubleJumpCount++;
            rb.AddForce(Vector3.up * jumpingPower, ForceMode.Impulse);
        }
    }

    private void Turbo()
    {
        Debug.Log("Turbo!!");
    }

    public float GetMoveDirection()
    {
        return Mathf.RoundToInt(moveDir.x);
    }
}
