using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurvivalStats : MonoBehaviour
{
    [Header("Hunger")]
    public float maxHunger = 100;
    public float hungerDrainRate = 1;
    public Transform hungerBar;
    
    [Header("Thirst")]
    public float maxThirst = 100;
    public float thirstDrainRate = 1.5f;
    public Transform thirstBar;
    
    [Header("Health")]
    public float maxHealth = 100;
    public float damageWhenStarving = 5;
    public float damageWhenDehydrated = 8;
    public Transform healthBar;
    
    private float hunger;
    private float thirst;
    private float health;
    
    
    void Start()
    {
        hunger = maxHunger;
        thirst = maxThirst;
        health = maxHealth;
    }

   
    void Update()
    {
        //drain over time
        hunger -= Time.deltaTime * hungerDrainRate;
        thirst -= Time.deltaTime * thirstDrainRate;
        
        hunger = Mathf.Clamp(hunger, 0, maxHunger);
        thirst = Mathf.Clamp(thirst, 0, maxThirst);

        if (hunger <= 0)
        {
            health -= damageWhenStarving * Time.deltaTime;
        }

        if (thirst <= 0)
        {
            health -= damageWhenDehydrated * Time.deltaTime;
        }
        health = Mathf.Clamp(health, 0, maxHealth);
        
        
        hungerBar.localScale = new Vector3(hunger/maxHunger, 1, 1);
        thirstBar.localScale = new Vector3(thirst/maxThirst, 1, 1);
        healthBar.localScale = new Vector3(health/maxHealth, 1, 1);
    }

    public void Eat(float amount)
    {
        hunger += amount;
        hunger = Mathf.Clamp(hunger, 0, maxHunger);
    }

    public void Drink(float amount)
    {
        thirst += amount;
        thirst = Mathf.Clamp(thirst, 0, maxThirst);
    }
}
