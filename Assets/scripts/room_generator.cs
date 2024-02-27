using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class room_generator : MonoBehaviour
{
    [SerializeField] private generation generation_script;
    [SerializeField] public List<GameObject> different_rooms;
    [SerializeField] private float expansion;
    [SerializeField] private bool all_rooms_connected = false;
    [SerializeField] private float restart_delay;

    public List<GameObject> rooms__;
    void Start()
    {
        //Invoke("build_rooms", delay);
    }
    public void build_room(Vector2 pos, bool destroy)
    {
        int room_number = Random.Range(0, different_rooms.Count);

        GameObject a_room = Instantiate(different_rooms[room_number], pos * expansion, Quaternion.identity);
        rooms__.Add(a_room);
    }
    public void room_termination()
    {
        foreach (GameObject rm in rooms__)
        {
            Destroy(rm);
            rooms__.Remove(rm);
        }
        foreach(Vector2 rm_ in generation_script.room_list)
        {
            generation_script.room_list.Remove(rm_);
        }
        foreach (float dr_ in generation_script.door_list)
        {
            generation_script.door_list.Remove(dr_);
        }
        foreach (float dr__ in generation_script.previous_door_list)
        {
            generation_script.previous_door_list.Remove(dr__);
        }
        //rooms__ = null;
        //generation_script.room_list = null;
        //generation_script.door_list = null;
        generation_script.current_amount_of_rooms = 0;
        generation_script.overflow_check = 0;
        Invoke("restart_", restart_delay);
        //generation_script.room_list.Add(new Vector2(0, 0));
        //generation_script.door_list.Add(0);
    }
    void restart_()
    {
        generation_script.restart();
        GameObject room_uno = Instantiate(different_rooms[0], new Vector2(0, 0), Quaternion.identity);
        rooms__.Add(room_uno);
    }
    private void Update()
    {
      if(generation_script.overflow_check > generation_script.when_is_overflow)
        {
            room_termination();
        }

        if (generation_script.current_amount_of_rooms == generation_script.amount_of_rooms)
        {
            foreach (GameObject room__ in rooms__)
            {
                if (rooms__.IndexOf(room__) <= generation_script.amount_of_rooms - 1 && rooms__.IndexOf(room__) > 0)
                {
                    room__.GetComponent<door_script>().delete_doors(generation_script.door_list[rooms__.IndexOf(room__)], generation_script.previous_door_list[rooms__.IndexOf(room__)]);
                    if (all_rooms_connected == true)
                    {
                        foreach (Vector2 vtwo in generation_script.room_list)
                        {
                            if (vtwo + new Vector2(1, 0) == generation_script.room_list[rooms__.IndexOf(room__) - 1])
                            {
                                room__.GetComponent<door_script>().delete_doors(1, 0);
                            }
                            if (vtwo + new Vector2(-1, 0) == generation_script.room_list[rooms__.IndexOf(room__) - 1])
                            {
                                room__.GetComponent<door_script>().delete_doors(3, 0);
                            }
                            if (vtwo + new Vector2(0, 1) == generation_script.room_list[rooms__.IndexOf(room__) - 1])
                            {
                                room__.GetComponent<door_script>().delete_doors(4, 0);
                            }
                            if (vtwo + new Vector2(0, -1) == generation_script.room_list[rooms__.IndexOf(room__) - 1])
                            {
                                room__.GetComponent<door_script>().delete_doors(2, 0);
                            }
                        }
                    }
                }
                else if(rooms__.IndexOf(room__) <= generation_script.amount_of_rooms - 1)
                {
                    room__.GetComponent<door_script>().delete_doors(generation_script.door_list[rooms__.IndexOf(room__)], generation_script.previous_door_list[rooms__.IndexOf(room__)]);
                }
                else
                {
                    room__.GetComponent<door_script>().delete_doors(0, generation_script.previous_door_list[rooms__.IndexOf(room__)]);
                }
            }
        }
    }
   
}
