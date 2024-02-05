using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float smooth;
    [SerializeField] private Rigidbody2D rigidbdy;

    [System.NonSerialized] public float current_speed_x;
    [System.NonSerialized] public float current_speed_y;
    private bool pressing_w = false;
    private bool pressing_s = false;
    private bool pressing_a = false;
    private bool pressing_d = false;
    private float target_speed_x;
    private float target_speed_y;
    private float tilted_speed;
    private bool pressing_ws = false;
    private bool pressing_ad = false;
    private bool colliding = false;


    private void Start()
    {
        InvokeRepeating("calculate_tilted_speed", 0, 1);
    }
    void Update()
    {
        transform.Translate(new Vector2(current_speed_x, current_speed_y) * speed * Time.deltaTime, Space.World);

        //rigidbdy.velocity = new Vector2(current_speed_x, current_speed_y);

        Inputs();

        current_speed_y = Mathf.Lerp(current_speed_y, target_speed_y, 1/smooth * Time.deltaTime);
        current_speed_x = Mathf.Lerp(current_speed_x, target_speed_x, 1/smooth * Time.deltaTime);

        if (pressing_w == true && pressing_s == true)
        {
            target_speed_y = 0;
        }
        else if (pressing_w && pressing_ad) {
            target_speed_y = tilted_speed;
        }
        else if(pressing_s && pressing_ad) {
            target_speed_y = -tilted_speed;
        }
        else if (pressing_w == true) {
            target_speed_y = speed;
        }
        else if (pressing_s == true) {
            target_speed_y = -speed;
        }
        else {
            target_speed_y = 0;
        }

        if (pressing_a == true && pressing_d == true)
        {
            target_speed_x = 0;
        }
        else if (pressing_d && pressing_ws)
        {
            target_speed_x = tilted_speed;
        }
        else if (pressing_a && pressing_ws)
        {
            target_speed_x = -tilted_speed;
        }
        else if (pressing_d == true)
        {
            target_speed_x = speed;
        }
        else if (pressing_a == true)
        {
            target_speed_x = -speed;
        }
        else
        {
            target_speed_x = 0;
        }
    }
    private void Inputs()
    {
        if (Input.GetKey(KeyCode.W))
        {
            pressing_w = true;
        }
        else
        {
            pressing_w = false;
        }
        if (Input.GetKey(KeyCode.S))
        {
            pressing_s = true;
        }
        else
        {
            pressing_s = false;
        }
        if (Input.GetKey(KeyCode.A))
        {
            pressing_a = true;
        }
        else
        {
            pressing_a = false;
        }
        if (Input.GetKey(KeyCode.D))
        {
            pressing_d = true;
        }
        else
        {
            pressing_d = false;
        }

        if(pressing_w && pressing_s)
        {
            pressing_ws = false;
        }
       else if(pressing_w || pressing_s)
        {
            pressing_ws = true;
        }
        else
        {
            pressing_ws = false;
        }

        if (pressing_a && pressing_d)
        {
            pressing_ad = false;
        }
        else if (pressing_a || pressing_d)
        {
            pressing_ad = true;
        }
        else
        {
            pressing_ad = false;
        }
    }
    private void calculate_tilted_speed()
    {
        tilted_speed = speed / Mathf.Sqrt(2);
    }
}
