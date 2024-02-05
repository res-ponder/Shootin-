using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_shooting : MonoBehaviour
{
    [SerializeField] private float firerate;
    [SerializeField] private float damage;
    [SerializeField] private float radius;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform shooting_point;
    [SerializeField] private Transform gun_holder;
    private Transform target;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        InvokeRepeating("shoot", 0, firerate);
    }
    void shoot()
    {
        if (Vector2.Distance(transform.position, target.position) < radius)
        {
            Instantiate(bullet, shooting_point.position, gun_holder.rotation);
        }
    }
}
