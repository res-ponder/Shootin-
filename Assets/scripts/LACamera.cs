using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LACamera : MonoBehaviour
{
    private Transform transform_;
    [SerializeField] private bool not_enemy = false;
    [SerializeField] private Transform player;
    [SerializeField] private Camera current_camera;
    [SerializeField] private float rotational_offset;

    private Vector2 direction;

    void Start()
    {
        if(not_enemy == false)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
        transform_ = this.transform;
    }
    void Update()
    {
        if(not_enemy == false)
        {
            direction = player.position - transform_.position;
        }
        else
        {
            direction = current_camera.ScreenToWorldPoint(Input.mousePosition) - transform_.position;
        }

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        Quaternion rotation = Quaternion.AngleAxis(angle - rotational_offset, Vector3.forward);

        transform.rotation = rotation;
    }
}
