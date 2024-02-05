using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_animation : MonoBehaviour
{
    [SerializeField] private Animator my_anim;
    [SerializeField] private movement mov_script;
    [SerializeField] private float min_movement;

    void Start()
    {
        my_anim.Play("hero_idle");
    }

    void Update()
    {
        if(mov_script.current_speed_x > min_movement || mov_script.current_speed_x < -min_movement || mov_script.current_speed_y > min_movement || mov_script.current_speed_y < -min_movement)
        {
            my_anim.Play("movement");
        }
        else
        {
            my_anim.Play("hero_idle");
        }

        if(mov_script.current_speed_x > min_movement)
        {
            this.transform.rotation = Quaternion.Euler(0,0,0);
        }
        if(mov_script.current_speed_x < -min_movement)
        {
            this.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }
}
