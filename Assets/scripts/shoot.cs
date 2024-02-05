using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private float mag_size;
    [SerializeField] private float reload_time;
    [SerializeField] private float fire_rate;
    [SerializeField] private bool full_auto = false;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform shooting_point;
    [SerializeField] private Transform gun_holder;

    private Transform transform_;
    private bool reloading = false;
    private bool time_to_shoot;
    private float current_mag;

    void Start()
    {
        current_mag = mag_size;
        time_to_shoot = true;
    }
    void Update()
    {
        if(full_auto == false)
        {
            if (Input.GetMouseButtonDown(0) && time_to_shoot == true && current_mag > 0 && reloading == false)
            {
                shoot_();
                time_to_shoot = false;
                Invoke("between_shoot", fire_rate);
            }
        }
        else if(full_auto == true)
        {
            if (Input.GetMouseButton(0) && time_to_shoot == true && current_mag > 0 && reloading == false)
            {
                shoot_();
                time_to_shoot = false;
                Invoke("between_shoot", fire_rate);
            }
        }
      
        if(Input.GetKeyDown(KeyCode.R) || Input.GetMouseButtonDown(0) && current_mag == 0)
        {
            Invoke("reload", reload_time);
            reloading = true;
        }
    }
    private void shoot_()
    {
        Instantiate(bullet, shooting_point.position, this.transform.rotation);
        current_mag = current_mag - 1;
    }
    private void between_shoot()
    {
        time_to_shoot = true;
    }
    private void reload()
    {
        current_mag = mag_size;
        reloading = false;
    }
}
