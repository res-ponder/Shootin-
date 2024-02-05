using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidbody_;
    [SerializeField] private float speed;
  
    void Update()
    {
        transform.Translate(new Vector2(0, speed) * Time.deltaTime, Space.Self);
    }
}
