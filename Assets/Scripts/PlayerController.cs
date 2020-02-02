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

    [SerializeField]
    private AudioClip jumpingSound = null;

    [SerializeField]
    private AudioClip landingSound = null;

    [SerializeField]
    private AudioSource footstepsSource = null;

    [SerializeField]
    private float footstepInterval = .5f;

    [SerializeField]
    private float minXVelocityForSound = .5f;

    [SerializeField]
    private float maxXVelocityForSound = 1.5f;

    private bool shouldJump = false;

    private Animator ani;

    private bool wasGrounded = true;

    private void Start() {
        rb2 = this.gameObject.GetComponent<Rigidbody2D>();
        ani = this.gameObject.GetComponent<Animator>();
    }

    private void Update() {
        bool grounded = IsGrounded();
        if (grounded && Input.GetButtonDown("Jump" + playerNum))
            shouldJump = true;
        if (grounded)
            footstepsSource.volume = Mathf.InverseLerp(minXVelocityForSound, maxXVelocityForSound, Mathf.Abs(rb2.velocity.x));
    }

    void FixedUpdate() {
        float x_movement = Input.GetAxis("Horizontal" + playerNum);

        if (rb2.velocity.magnitude < maxSpeed) {
            Vector2 movement = new Vector2(x_movement, 0);
            rb2.AddForce(movement * scale);
            ani.SetBool("Left", x_movement > 0);

            ani.SetBool("moving", x_movement != 0);
        }

        if (shouldJump) {
            AudioSource.PlayClipAtPoint(jumpingSound, Vector3.zero);
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
        bool grounded = hit.collider != null;
        ani.SetBool("jumping", !grounded);
        wasGrounded = grounded;
        if (!wasGrounded && grounded)
            AudioSource.PlayClipAtPoint(landingSound, Vector3.zero);
        return grounded;
    }

}
