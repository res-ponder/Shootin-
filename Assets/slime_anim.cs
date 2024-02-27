using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slime_anim : MonoBehaviour
{
    [SerializeField] Animator anim;
  
    void Start()
    {
        anim.Play("slime bounce");
    }
    private void Update()
    {
        transform.localRotation = Quaternion.identity;
    }
}
