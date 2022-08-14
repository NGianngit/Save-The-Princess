using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInteraction : MonoBehaviour
{
    public Switch changeScene;
    public SwitchCeller celler;
    public int maxHealth;
    public int currentHealth;
    public HealthBar healthBar;
    public GameObject deathScreen;
    public static int keys;
    public GameObject Lock;
    public TextMeshProUGUI keysCollected;
    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.setMaxHealth(maxHealth);
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "switch")
        {
            changeScene.Interact();
            
        }

        if (collision.gameObject.tag == "celler")
        {
            celler.Interact();
            keys = 0;
        }


        if (collision.gameObject.tag == "keys")
        {
            Destroy(collision.gameObject);
            keys++;
        }
        

        if (collision.gameObject.tag == "EnemyArrow")
        {
            Destroy(collision.gameObject);
            TakeDamage(10);
        }

        if (collision.gameObject.tag == "EnemySword")
        {
            TakeDamage(25);
        }

        if (collision.gameObject.tag == "EnemyAxe")
        {
            TakeDamage(15);
        }

        if (collision.gameObject.tag == "door")
        {
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Bandage")
        {
            Destroy(collision.gameObject);
            HealDamage(50);
        }
    }

    private void Update()
    {
        keysCollected.text = keys.ToString();
        if (keys >= 2)
        {
            Destroy(Lock);
        }
    }

    public void HealDamage(int damage)
    {
        currentHealth += damage;
        if (currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
        }
        healthBar.setHealth(currentHealth);

    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.setHealth(currentHealth);
        if (currentHealth <= 0)
        {

            Destroy(gameObject);
            deathScreen.SetActive(true);
        }
    }

}
