using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss01AIBullet : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<playerHealth>().AddDamage(15f);
        }
        gameObject.SetActive(false);
    }
}
