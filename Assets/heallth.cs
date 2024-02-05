using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heallth : MonoBehaviour
{
    [SerializeField] public float max_health;

    [System.NonSerialized] public float current_health;

    private void Start()
    {
        current_health = max_health;
    }

    public void take_damage(float damage_amount)
    {
        current_health -= damage_amount;
    }

    public void regenerate_health(float regeneration_amount)
    {
        current_health += regeneration_amount;
    }

    private void Update()
    {
        if (current_health > max_health)
        {
            current_health = max_health;
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            take_damage(2);
        }
 
        if (Input.GetKeyDown(KeyCode.R) && current_health < max_health)
        {
            regenerate_health(3);
        }
    }
}
