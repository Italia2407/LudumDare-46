using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private BoxCollider2D bc2D;

    public AudioSource audio;

    public float jumpForce = 6.0f;
    public float speed = 4.0f;
    public LayerMask mask;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        bc2D = GetComponent<BoxCollider2D>();

        rb2D.freezeRotation = true;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb2D.AddForce(new Vector2(0.0f, jumpForce), ForceMode2D.Impulse);
            audio.Play();
        }
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal") * speed;
        rb2D.velocity = new Vector2(horizontal * Time.fixedDeltaTime * 100, rb2D.velocity.y);
    }

    public bool IsGrounded()
    {
        float skinDepth = 0.1f;
        float raycastDistance = 0.4f;

        float leftEdge = bc2D.bounds.center.x - bc2D.bounds.extents.x;
        float rightEdge = bc2D.bounds.center.x + bc2D.bounds.extents.x;
        float bottomEdge = bc2D.bounds.center.y - bc2D.bounds.extents.y;

        Vector2 bottomLeftVertex = new Vector2(leftEdge, bottomEdge);
        bottomLeftVertex += new Vector2(skinDepth, skinDepth);
        Vector2 bottomRightVertex = new Vector2(rightEdge, bottomEdge);
        bottomRightVertex += new Vector2(-skinDepth, skinDepth);

        RaycastHit2D hitL = Physics2D.Raycast(bottomLeftVertex, Vector2.down, raycastDistance, mask);
        RaycastHit2D hitR = Physics2D.Raycast(bottomRightVertex, Vector2.down, raycastDistance, mask);

        if (hitL.collider != null)
        {
            Debug.Log("Left side hit something!");
            if (hitL.collider.tag == "Ground")
                return true;
        }
        if (hitR.collider != null)
        {
            Debug.Log("Right side hit something!");
            if (hitR.collider.tag == "Ground")
                return true;
        }

        return false;
    }
}
