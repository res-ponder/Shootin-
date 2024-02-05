using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow : MonoBehaviour
{
    [SerializeField] private float smoothness;
    [SerializeField] private Transform player;
    [SerializeField] private Transform camera_;

    private Vector2 current_position;
    private Vector2 target_position;

    void Update()
    {
        target_position.x = player.position.x;
        target_position.y = player.position.y;

        current_position = Vector2.Lerp(current_position, target_position, 1/smoothness * Time.deltaTime);

        camera_.position = current_position;
    }
}
