using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private int playerNum;
    [SerializeField]
    private float scale;
    [SerializeField]
    private float maxSpeed;

    [SerializeField]
    private float jumpScale;

    private Rigidbody2D rb2;
    private bool isOnGround = false;
    //TODO Fix this later
//    [SerializeField]
//    private LayerMask groundLayer;


    private void Start()
    {
        rb2 = this.gameObject.GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        float x_movement = Input.GetAxis("Horizontal"+playerNum);
        
        if (rb2.velocity.magnitude < maxSpeed)
        {
            Vector2 movement = new Vector2(x_movement, 0);
            rb2.AddForce(movement * scale);
        }
        if (Input.GetButtonDown("Jump" + playerNum))
        {
            if (isOnGround)
            {
                isOnGround = false;
                Vector2 jumpForce = new Vector2(0, jumpScale * 10);
                rb2.AddForce(jumpForce);
            }
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (CollisionIsWithGround(collision))
        {
            isOnGround = true;
            print(isOnGround);
        }

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if(!CollisionIsWithGround(collision))
        {
            isOnGround = false;
            print(isOnGround);
        }
    }

    private bool CollisionIsWithGround(Collision2D collision)
    {
        bool is_with_ground = false;
        foreach (ContactPoint2D c in collision.contacts)
        {
            Vector2 colDirVector = c.point + rb2.position;
                                     if(colDirVector .y <0)
            {
                is_with_ground = true;
            }
        }

        return is_with_ground;
    }


    public bool IsGrounded()
    {
        /*Todo Fix Raycasting solution
                        Vector2 position = transform.position;
                Vector2 direction = Vector2.down;
                float distance = 1.0f;

                Debug.DrawRay(position, direction, Color.green);
                RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, groundLayer);
                if (hit.collider != null)
                {
                    return true;
                }

                return false;*/




        return true;
    }
}
