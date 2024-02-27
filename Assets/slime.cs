using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slime : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float damage;
    void Start()
    {
    }
    private void Update()
    {
        Transform childTransform = transform.GetChild(0); // Assuming the child is the first child

        childTransform.rotation = Quaternion.identity;

        transform.Translate(new Vector2(0, speed) * Time.deltaTime, Space.Self);
    }
}
