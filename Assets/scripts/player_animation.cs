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
        my_anim.Play("new jeff idle");
    }

    void Update()
    {
        if (mov_script.current_speed_x > min_movement || mov_script.current_speed_x < -min_movement || mov_script.current_speed_y > min_movement || mov_script.current_speed_y < -min_movement)
        {
            if (mov_script.current_speed_x > min_movement || mov_script.current_speed_x < -min_movement)
            {
                    my_anim.Play("new jeff run");
                    my_anim.speed = 1;
                
            }
            else if(mov_script.current_speed_y < -min_movement)
            {
                my_anim.Play("newer down anim");
                my_anim.speed = 1;
            }
            else if (mov_script.current_speed_y > min_movement)
            {
                my_anim.Play("newer jeff up");
                my_anim.speed = 1;
            }
        }
        else
        {
            my_anim.speed = 0;
        }

        if (mov_script.current_speed_x > min_movement)
        {
            this.transform.rotation = Quaternion.Euler(0,0,0);
        }
        if(mov_script.current_speed_x < -min_movement)
        {
            this.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }
}
