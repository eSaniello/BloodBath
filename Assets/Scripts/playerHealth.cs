using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerHealth : MonoBehaviour
{
    public float maxHealth;
    float currentHealth; 

	public Slider healthSlider;
	bool damaged = false;
	Color damageColor = new Color(0f , 0f , 0f , 1f);
	float colorSmooth = 5;
    

	void Start ()
    {
        currentHealth = maxHealth;

		healthSlider.maxValue = maxHealth;
		healthSlider.value = maxHealth;
        
	}

	public void AddDamage(float damage)
    {
        if (currentHealth <= 0)
        {
            return;
        }
        currentHealth -= damage;
		healthSlider.value = currentHealth;
		damaged = true;
        

        if(currentHealth <= 0)
        {
            MakeDead();
        }
    }

    void MakeDead()
    {
        Destroy(gameObject);
    }
}
