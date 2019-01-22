using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{

    public float enemyMaxHealth; 
    float currentHealth;


	void Start ()
    {
        currentHealth = enemyMaxHealth;
	}
	


    public void AddDamage(float damage)
    {
        currentHealth -= damage;

        if(currentHealth == 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
