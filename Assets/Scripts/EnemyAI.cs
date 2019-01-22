using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    Rigidbody2D rb;

    RaycastHit2D GroundCheckRay;
    public Transform GroundCheckRayOrigin;
    float GroundCheckRayLength = .5f;

    bool WallCheck;
    public Transform WallCheckOrigin;

    public LayerMask groundLayer;

    public float EnemyMoveSpeed = 3f;


    public float RageSpeed;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        //Collision checking
        GroundCheckRay = Physics2D.Raycast(GroundCheckRayOrigin.position, Vector3.down, GroundCheckRayLength, groundLayer);
        WallCheck = Physics2D.OverlapCircle(WallCheckOrigin.position, .25f, groundLayer);

        //move  
        rb.velocity = new Vector2(EnemyMoveSpeed, rb.velocity.y);

        if (WallCheck)
        {
            FlipDirection();
        }
        if (!GroundCheckRay)
        {
            FlipDirection();
        }
    }

    void FlipDirection()
    {
        float speed = EnemyMoveSpeed;
        speed *= -1;
        EnemyMoveSpeed = speed;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector3 dir = (collision.transform.position - transform.position);
            Vector3 normal = dir.normalized;
            EnemyMoveSpeed = normal.normalized.x * RageSpeed;
            if (EnemyMoveSpeed > 0 && transform.localScale.x < 0)
            {
                FlipDirection();
            }
            else if (EnemyMoveSpeed < 0 && transform.localScale.x > 0)
            {
                FlipDirection();
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector3 dir = (collision.transform.position - transform.position);
            Vector3 normal = dir.normalized;
            EnemyMoveSpeed = normal.normalized.x * RageSpeed;
            if (EnemyMoveSpeed > 0 && transform.localScale.x < 0)
            {
                FlipDirection();
            }
            else if (EnemyMoveSpeed < 0 && transform.localScale.x > 0)
            {
                FlipDirection();
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector3 dir = (collision.transform.position - transform.position);
            Vector3 normal = dir.normalized;
            EnemyMoveSpeed = normal.normalized.x * 3;
            if (EnemyMoveSpeed > 0 && transform.localScale.x < 0)
            {
                FlipDirection();
            }
            else if (EnemyMoveSpeed < 0 && transform.localScale.x > 0)
            {
                FlipDirection();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<playerHealth>().AddDamage(10f);
        }
    }
}
