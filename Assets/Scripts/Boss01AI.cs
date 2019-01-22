using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss01AI : MonoBehaviour
{
    float bulletTimer;
    public float ShootInterval;
    public Transform bulletSpawnPoint;
    public float BulletTravelSpeed;
    public ObjectPool AIPool;

    public Transform[] positions;
    public float moveINterval;
    float moveTimer;
    int randomSelector;

    public float smoothTime = 0.3f;
    float Xvelocity;

    bool facingRight = false;

    private void Update()
    {
        randomSelector = Random.Range(0, positions.Length);
        Debug.Log(randomSelector);
    }


    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        { 

            bulletTimer += Time.deltaTime;
            moveTimer += Time.deltaTime;

            Vector2 dir = collision.transform.position - transform.position;
            dir.Normalize();

            if (bulletTimer >= ShootInterval)
            {
                GameObject bullet = AIPool.GetBullet();
                bullet.transform.position = bulletSpawnPoint.position;
                bullet.transform.rotation = bulletSpawnPoint.rotation;
                bullet.SetActive(true);
                bullet.GetComponent<Rigidbody2D>().velocity = dir * BulletTravelSpeed;
                bulletTimer = 0;
            }

            if(dir.x > 0 && !facingRight)
            {
                Flip();
            }
            else if(dir.x < 0 && facingRight)
            {
                Flip();
            }

            if(moveTimer >= moveINterval)
            {
                float newPos = Mathf.Lerp(transform.position.x, positions[randomSelector].position.x, smoothTime);
                transform.position = new Vector3(newPos, transform.position.y, transform.position.z);
                moveTimer = 0;
            }
        }
    }
}
