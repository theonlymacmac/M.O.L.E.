using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour{

    public Animator animator;

    private float horizontal;
    private float speed = 8f;
    private float jumpingPower = 16f;
    private bool isFacingRight = true;

    private bool isWallSliding;
    private float wallSlidingSpeed = 2f;

    private bool isWallJumping;
    private float wallJumpingDirection;
    private float wallJumpingTime = 0.2f;
    private float wallJumpingCounter;
    private float wallJumpingDuration = 0.4f;
    private Vector2 wallJumpingPower = new Vector2(8f, 16f);

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheckF;
    [SerializeField] private Transform groundCheckB;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform wallCheckF;
    [SerializeField] private Transform wallCheckB;
    [SerializeField] private LayerMask wallLayer;

    private void Update(){

        animator.SetFloat("Speed", horizontal);

        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && (IsGroundedF() || IsGroundedB())){
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f){
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        WallSlide();
        WallJump();


        // if (!isWallJumping){
        //     Flip();
        // }
    }

    private void FixedUpdate(){
        if (!isWallJumping){
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        }
    }

    private bool IsGroundedF(){
        return Physics2D.OverlapCircle(groundCheckF.position, 0.2f, groundLayer);
    }

    private bool IsGroundedB(){
        return Physics2D.OverlapCircle(groundCheckB.position, 0.2f, groundLayer);
    }

    private bool IsWalledF(){
        return Physics2D.OverlapCircle(wallCheckF.position, 0.2f, wallLayer);
    }

    private bool IsWalledB(){
        return Physics2D.OverlapCircle(wallCheckB.position, 0.2f, wallLayer);
    }

    private void WallSlide(){
        if ((IsWalledF() || IsWalledB()) && (!IsGroundedF() || !IsGroundedB()) && horizontal != 0f){ ///////////////////
            isWallSliding = true;
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -wallSlidingSpeed, float.MaxValue));
        }
        else{
            isWallSliding = false;
        }
    }

    private void WallJump(){
        if (isWallSliding){
            isWallJumping = false;
            wallJumpingDirection = transform.localScale.x;
            wallJumpingCounter = wallJumpingTime;

            CancelInvoke(nameof(StopWallJumping));
        }
        else{
            wallJumpingCounter -= Time.deltaTime;
        }

        if (Input.GetButtonDown("Jump") && wallJumpingCounter > 0f){
            isWallJumping = true;
            rb.velocity = new Vector2(wallJumpingDirection * wallJumpingPower.x, wallJumpingPower.y);
            wallJumpingCounter = 0f;

            if (transform.localScale.x != wallJumpingDirection){
                isFacingRight = !isFacingRight;
                Vector3 localScale = transform.localScale;
                localScale.x *= -1f;
                transform.localScale = localScale;
            }

            Invoke(nameof(StopWallJumping), wallJumpingDuration);
        }
    }

    private void StopWallJumping(){
        isWallJumping = false;
    }

    private void Flip(){
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f){
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}