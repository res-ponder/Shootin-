using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door_script : MonoBehaviour
{
    [SerializeField] private GameObject door_one;
    [SerializeField] private GameObject door_two;
    [SerializeField] private GameObject door_three;
    [SerializeField] private GameObject door_four;

    [SerializeField] private GameObject hall_one;
    [SerializeField] private GameObject hall_two;
    [SerializeField] private GameObject hall_three;
    [SerializeField] private GameObject hall_four;

    public void delete_doors(float door_number, float door_number_two)
    {
        if (door_number == 1|| door_number_two == 3)
        {
            Destroy(door_one);
            Destroy(hall_one);
        }

        if (door_number == 2 || door_number_two == 4)
        {
            Destroy(door_two);
            Destroy(hall_two);
        }

        if (door_number == 3 || door_number_two == 1)
        {
            Destroy(door_three);
            Destroy(hall_three);
        }

        if (door_number == 4 || door_number_two == 2)
        {
            Destroy(door_four);
            Destroy(hall_four);
        }

    }
}
