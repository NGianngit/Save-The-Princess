using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Testdmg : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    Animator animator;

    public HealthBar healthBar;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;
        healthBar.setMaxHealth(maxHealth);
    }

    private void OnCollisionEnter(Collision collision)
    {
        

        if (collision.gameObject.tag == "PlayerSword")
        {
            TakeDamage(15);
        }

        if (collision.gameObject.tag == "Arrow")
        {
            Destroy(collision.gameObject);
            TakeDamage(10);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.setHealth(currentHealth);
        if (currentHealth <= 0)
        {
            
            Destroy(gameObject);
        }
    }
}
