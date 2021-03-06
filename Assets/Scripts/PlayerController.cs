﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField]
    private int playerNum = 1;

    [SerializeField]
    private float moveScale = 40;

    [SerializeField]
    private float maxSpeed = 10;

    [SerializeField]
    private float jumpScale = 100;

    private Rigidbody2D rb2;

    [SerializeField]
    private LayerMask groundLayer = ~0;

    [SerializeField]
    public float raycastDistance = .5f;

    [SerializeField]
    private AudioClip jumpingSound = null;

    [SerializeField]
    private AudioClip landingSound = null;

    [SerializeField]
    private AudioSource footstepsSource = null;

    [SerializeField]
    private float minXVelocityForSound = .5f;

    [SerializeField]
    private float maxXVelocityForSound = 1.5f;

    [SerializeField, Range(0, 1)]
    private float volume = 1;

    private bool shouldJump = false;

    private SpriteRenderer feet;

    private Animator ani;

    private bool wasGrounded = true;

    public int PlayerNum { get => playerNum; }

    private void Start() {
        rb2 = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        feet = transform.Find("Shoes-Standing").GetComponent<SpriteRenderer>();
    }

    private void Update() {
        bool grounded = IsGrounded();
        if (grounded && Input.GetButtonDown("Jump" + playerNum))
            shouldJump = true;
        footstepsSource.volume = grounded ? Mathf.InverseLerp(minXVelocityForSound, maxXVelocityForSound, Mathf.Abs(rb2.velocity.x)) : 0;
    }

    void FixedUpdate() {
        float x_movement = Input.GetAxis("Horizontal" + playerNum);

        if (rb2.velocity.magnitude < maxSpeed) {
            Vector2 movement = new Vector2(x_movement, 0);
            rb2.AddForce(movement * moveScale);
            feet.flipX = x_movement < 0;

            ani.SetFloat("speed", rb2.velocity.magnitude);
        }

        if (shouldJump) {
            Sound.PlaySound(jumpingSound, volume);
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
            Sound.PlaySound(landingSound, volume);
        return grounded;
    }

}
