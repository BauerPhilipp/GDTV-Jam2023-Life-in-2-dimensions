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
    public float MoveSpeed { get { return moveSpeed; } set {  moveSpeed = value; } }
    public int MaxDoubleJumps { get { return maxDoubleJumps; } set { maxDoubleJumps = value; } }



    private Animator animator;
    [SerializeField] private int doubleJumpCount = 0;
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
        if (other.collider.gameObject.CompareTag("Path") || other.collider.gameObject.CompareTag("PathWithBoni"))
        {
            isGrounded = true;
            Debug.Log("Collission!" + other.gameObject.name);
            doubleJumpCount = 0;
        }
        if (other.collider.gameObject.CompareTag("Path"))
        {

        }
        if (other.collider.gameObject.CompareTag("PathWithBoni"))
        {
            PathBoni pathBoni = other.collider.gameObject.GetComponent<PathBoni>();
            DimensionManager.Instance.ActivateBoni(this, pathBoni);
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

    public float GetMoveDirection()
    {
        return Mathf.RoundToInt(moveDir.x);
    }

}
