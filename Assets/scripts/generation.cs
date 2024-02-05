using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generation : MonoBehaviour
{
    public List<Vector2> room_list;
    public List<float> door_list;
    public List<float> previous_door_list;
    [SerializeField] public float amount_of_rooms;
    [SerializeField] public Vector2 first_room_pos;
    [SerializeField] float time_step;
    [SerializeField] public float when_is_overflow;
    [SerializeField] float overflow_time_step;
    [SerializeField] room_generator rg_script;

    private Vector2 current_room_pos = new Vector2(0,0);
    [System.NonSerialized] public float current_amount_of_rooms = 0;
    [System.NonSerialized] public float overflow_check = 0;
    private void Update()
    {
       
    }
    void Start()
    {
        rg_script.build_room(new Vector2(0, 0), false);
        previous_door_list.Add(0);
        generate_room_number();
    }
   void generate_room_number()
    {
        float random_number = Random.Range(0, 4);

        if(random_number == 0)
        {
            add_number(new Vector2(current_room_pos.x + 1, current_room_pos.y), 3);
        }
        if (random_number == 1)
        {
            add_number(new Vector2(current_room_pos.x - 1, current_room_pos.y), 1);
        }
        if (random_number == 2)
        {
            add_number(new Vector2(current_room_pos.x, current_room_pos.y + 1), 2);
        }
        if (random_number == 3)
        {
            add_number(new Vector2(current_room_pos.x, current_room_pos.y - 1), 4);
        }
    }
    void add_number(Vector2 v_two, float door_nm)
    {
       if(room_list.Contains(v_two) || v_two == first_room_pos)
        {
            Invoke("generate_room_number", overflow_time_step);
            overflow_check += 1;
            if(overflow_check > when_is_overflow)
            {
                rg_script.room_termination();
                Debug.Log("Termination");
            }
        }
       else
        {
            room_list.Add(v_two);
            current_room_pos = v_two;
            current_amount_of_rooms += 1;
            if (current_amount_of_rooms < amount_of_rooms)
            {
                Invoke("generate_room_number", time_step);
            }
            create_door_number(door_nm);
            rg_script.build_room(v_two, false);
        }       
    }
    void create_door_number(float door)
    {
        door_list.Add(door);
        previous_door_list.Add(door);
    }
    public void restart()
    {
        Debug.Log("restart");
        current_room_pos = new Vector2(0, 0);
        previous_door_list.Add(0);
        //door_list.Add(0);
        Invoke("generate_room_number", 0.1f);
    }
}
