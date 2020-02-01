using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    [SerializeField]
    private int playerNum = 1;
    [SerializeField]
    private float scale = 1;
    [SerializeField]
    private float maxSpeed = 1;

    [SerializeField]
    private float jumpScale = 1;

    private Rigidbody2D rb2;

    [SerializeField]
    private LayerMask groundLayer = ~0;

    [SerializeField]
    private float raycastDistance = .5f;

    private bool shouldJump = false;

    private void Start() {
        rb2 = this.gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update() {
        if (Input.GetButtonDown("Jump" + playerNum) && IsGrounded())
            shouldJump = true;
    }

    void FixedUpdate() {
        float x_movement = Input.GetAxis("Horizontal" + playerNum);

        if (rb2.velocity.magnitude < maxSpeed) {
            Vector2 movement = new Vector2(x_movement, 0);
            rb2.AddForce(movement * scale);
        }

        if (shouldJump) {
            shouldJump = false;
            Vector2 jumpForce = new Vector2(0, jumpScale * 10);
            rb2.AddForce(jumpForce);
        }

    }


    public bool IsGrounded() {
        Vector2 position = transform.position;
        Vector2 direction = Vector2.down;
        float distance = raycastDistance;

        RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, groundLayer);
        Debug.DrawRay(position, direction * (hit ? hit.distance : distance), hit ? Color.green : Color.red);
        if (hit.collider != null) {
            return true;
        }
        return false;
    }
}
