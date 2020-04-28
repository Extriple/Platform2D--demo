using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D RG;
    public float speed;
    public float jumpForce;

    //GroundCheck
    private bool isOnTheGround;
    public Transform checkGroundPoint;
    public LayerMask groundLayer;

    //Double jump
    private bool doubleJump;

    //Wall jump
    public Transform wallCheck;
    private bool isTouchingWall;
    public float wallCheckDisnance;
    private bool isWallSlide;
    public float wallSpeed;
    public float forceInAir;

    void Start()
    {

    }

    void Update()
    {
        //Movement 
        RG.velocity = new Vector2(speed * Input.GetAxis("Horizontal"), RG.velocity.y);

        //Checking wallsliding
        if (isWallSlide)
        {
            if(RG.velocity.y< -wallSpeed)
            {
                RG.velocity = new Vector2(RG.velocity.x, - wallSpeed);
            }
        }

        //CHeck layer
        isOnTheGround = Physics2D.OverlapCircle(checkGroundPoint.position, 0.5f, groundLayer);

        if (isOnTheGround)
        {
            doubleJump = true;
        }

        //Jumping mechanism + double jumping and wall jumping
        if (Input.GetButtonDown("Jump"))
        {
            if (isOnTheGround)
            {
                RG.velocity = new Vector2(RG.velocity.x, jumpForce);
            }
            else if (doubleJump)
            {

                RG.velocity = new Vector2(RG.velocity.x, jumpForce);
                doubleJump = false;

            }
            else if (!isOnTheGround && !isWallSlide && speed != 0)
            {
                Vector2 force = new Vector2(forceInAir * speed, 0);
                RG.AddForce(force);
                if (Mathf.Abs(RG.velocity.x) > speed)
                {
                    RG.velocity = new Vector2(speed * speed, RG.velocity.y);   
                }
            }
            
        }

        //Touch Wall control
        isTouchingWall = Physics2D.Raycast(wallCheck.position, transform.right, wallCheckDisnance, groundLayer);

        CheckWallSlide();


    }
    //Checking wall slide
    private void CheckWallSlide()
    {
        if(isTouchingWall && !isOnTheGround && RG.velocity.y < 0)
        {
            isWallSlide = true;

        }
        else
        {
            isWallSlide = false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(wallCheck.position, new Vector3(wallCheck.position.x + wallCheckDisnance, wallCheck.position.y, wallCheck.position.z));
    }
}
