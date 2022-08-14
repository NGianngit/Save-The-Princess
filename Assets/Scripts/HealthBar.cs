using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{
    public TextMeshProUGUI maxHealth;
    public TextMeshProUGUI health;
    public Slider slider;
    public Gradient gradient;
    public Image fill;


    //Set the max value of the healthbar and fill up the healthbar
    public void setMaxHealth(int Health)
    {
        //set max health
        slider.maxValue = Health;
        //fill healthbar
        slider.value = Health;
        maxHealth.text = "/" + Health.ToString() + "Hp";
        health.text = Health.ToString();

        fill.color = gradient.Evaluate(1f);
    }
    //used to change healthbar whenever a change to health occurs
    public void setHealth(int Health)
    {
        //update healthbar value
        slider.value = Health;
        //update health value
        health.text = Health.ToString();
        fill.color= gradient.Evaluate(slider.normalizedValue);
    }
    
}
