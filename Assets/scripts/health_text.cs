using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class health_text : MonoBehaviour
{
    [SerializeField] private Text text;
    [SerializeField] private heallth health_script;
    [SerializeField] private bool current_health = false;

    void Update()
    {
        if(current_health == true)
        {
            text.text = "" + health_script.current_health;
        }
        else
        {
            text.text = "/" + health_script.max_health;
        }
     
    }
}
