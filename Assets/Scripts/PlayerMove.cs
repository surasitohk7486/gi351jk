using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float walkSpeed;
    private float moveInput;
    public bool isGrounded;
    private Rigidbody2D rb;
    public LayerMask groundMask;

    public PhysicsMaterial2D bounceMat, norMat;
    public bool canJump = true;
    public float jumpValue = 0.0f;

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private SpriteRenderer spriteRenderer;

    private static int IsPlayerRunAnimatorHash = Animator.StringToHash("IsPlayerRun");

    private static int IsPlayerJumpAnimatorHash = Animator.StringToHash("IsPlayerJump");

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");

        if(jumpValue == 0.0f && isGrounded)
        {
            rb.velocity = new Vector2(moveInput * walkSpeed, rb.velocity.y);
        }
        rb.velocity = new Vector2 (moveInput * walkSpeed, rb.velocity.y);

        isGrounded = Physics2D.OverlapBox(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 0.5f), new Vector2(0.9f,0.4f), 0f,groundMask);

        if(!isGrounded)
        {
            rb.sharedMaterial = bounceMat;
        }
        else
        {
            rb.sharedMaterial = norMat;
        }
        if (Input.GetKey("space") && isGrounded && canJump)
        {
            jumpValue += 0.25f;
            animator.SetBool(IsPlayerJumpAnimatorHash, !isGrounded);
        }

        if(Input.GetKeyDown("space") && isGrounded && canJump) 
        {
            rb.velocity = new Vector2(0.0f,rb.velocity.y);

        }

        if (jumpValue >= 20f && isGrounded)
        { 
            float tempx = moveInput * walkSpeed;
            float tempy = jumpValue;
            rb.velocity = new Vector2(tempx, tempy);
            Invoke("ResetJump", 0.2f);
        }

        if (Input.GetKeyUp("space"))
        {
            if(isGrounded)
            {
                rb.velocity = new Vector2(moveInput * walkSpeed, jumpValue);
                jumpValue = 0.0f;
            }
            canJump = true;
        }

        spriteRenderer.flipX = moveInput < 0;

        animator.SetBool(IsPlayerRunAnimatorHash, Mathf.Abs(moveInput) > 0);
        
    }

    void ResetJump()
    {
        canJump = false;
        jumpValue = 0.0f;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawCube(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 0.5f), new Vector2(0.9f, 0.2f));
    }
}
