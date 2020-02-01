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


    private Rigidbody2D rb2;

    private void Start()
    {
        rb2 = this.gameObject.GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        float x_movement = Input.GetAxis("Horizontal");

        if (rb2.velocity.magnitude < maxSpeed)
        {
            Vector2 movement = new Vector2(x_movement, 0);
            rb2.AddForce(movement * scale);
        }

    }
}
