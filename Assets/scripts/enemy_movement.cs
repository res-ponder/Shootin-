using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_movement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float smoothness;
    [SerializeField] private float change_time;

    private float target_x;
    private float target_y;
    private float current_x;
    private float current_y;

    private void Start()
    {
        InvokeRepeating("random_direction", 0, change_time);
    }
    void random_direction()
    {
        float random_number = Random.Range(0, 4);

        if (random_number == 0)
        {
            target_x = 1;
        }
        else if (random_number == 1)
        {
            target_x = -1;
        }
        else
        {
            target_x = 0;
        }
        
        if (random_number == 2)
        {
            target_y = 1;
        }
        else if (random_number == 3)
        {
            target_y = -1;
        }
        else
        {
            target_y = 0;
        }
    }

    void Update()
    {
        transform.Translate(new Vector2(current_x, current_y) * speed * Time.deltaTime, Space.World);

        current_x = Mathf.Lerp(current_x, target_x, 1 / smoothness);
        current_y = Mathf.Lerp(current_y, target_y, 1 / smoothness);
    }
}
