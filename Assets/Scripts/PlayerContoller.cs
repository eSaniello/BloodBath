using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerContoller : MonoBehaviour
{
    public float maxSpeed = 10f;
    public float jumpForce = 4f;
    public float jumpPushForce = 10f;
    bool facingRight = true;
    bool wallJumped = false;
    bool wallJumping = false;

    bool grounded;
    bool touchingWall;
    float checkRadius = 0.2f;
    public Transform groundCheck;
    public Transform wallCheck;
    public LayerMask whatIsGround;

    Rigidbody2D rb;
    bool wallSliding;
    float wallSlideFriction;

    float move = 0;

    public Transform gun;
    public Transform gunTip;
    public ObjectPool pool;
    public float bulletTravelSpeed;

    CircleCollider2D boxCol;
    Animator anim;
    AudioSource _audio;
    public AudioClip jumpSound;
    public AudioClip pewSound;

    void Start()
    {
        boxCol = GetComponent<CircleCollider2D>();
        rb = GetComponent <Rigidbody2D> ();
        anim = GetComponent<Animator>();
        _audio = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        touchingWall = Physics2D.OverlapCircle(wallCheck.position, checkRadius, whatIsGround);

        if (grounded && !wallJumping)
            rb.velocity = new Vector2(move * maxSpeed, rb.velocity.y);

        if (touchingWall && rb.velocity.y < 0)
        {
            wallSliding = true;
            rb.velocity = new Vector2(0 , wallSlideFriction * rb.velocity.y);
        }

        if (wallJumped)
        {
            rb.velocity = new Vector2(jumpPushForce * (facingRight ? -1 : 1), jumpForce);
            wallJumping = true;
            wallJumped = false;
        }

        if (rb.velocity.y < 0)
        {
            wallJumping = false;
        }
        if (grounded)
        {
            wallJumping = false;
        }
        if (rb.velocity.x > 0 && !facingRight)
        {
            Flip();
        }
        else if (rb.velocity.x < 0 && facingRight)
        {
            Flip();
        }
    }

    void Update()
    {
        anim.SetBool("isGrounded", grounded);
        anim.SetFloat("verticalVelocity", rb.velocity.y);
    }

    public void Jump()
    {
        if (grounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            _audio.PlayOneShot(jumpSound);
        }
        else if (touchingWall)
        {
            wallJumped = true;
        }
    }

    void Flip()
    {
        facingRight = !facingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    
    public void Shoot()
    {
        _audio.PlayOneShot(pewSound);

        Vector3 dir = Vector3.zero;

        GameObject Bullet = pool.GetBullet();
        Bullet.transform.localRotation = gun.localRotation;
        Bullet.transform.position = gunTip.position;
        Bullet.SetActive(true);
        if (!facingRight)
        {
            dir.x = -1;

        }
        else if (facingRight)
        {
            dir.x = 1;
        }
        Bullet.GetComponent<Rigidbody2D>().velocity = dir * bulletTravelSpeed;
    }

    public void OnRightButtonDown()
    {
        boxCol.sharedMaterial.friction = 0;
        move = 1;
        anim.SetBool("isWalking", true);
    }
    public void OnRightButtonUp()
    {
        boxCol.sharedMaterial.friction = 1000;
        move = 0;
        anim.SetBool("isWalking", false);
    }
    public void OnLeftButtonDown()
    {
        move = -1;
        boxCol.sharedMaterial.friction = 0;
        anim.SetBool("isWalking", true);
    }
    public void OnLeftButtonUp()
    {
        move = 0;
        boxCol.sharedMaterial.friction = 1000;
        anim.SetBool("isWalking", false);
    }
}