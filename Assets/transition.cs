using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class transition : MonoBehaviour
{
    [SerializeField] private float transition_time;

    private Image image;
    private float startAlpha = 0;
    private bool start = false;

    void unstart()
    {
        start = false;
    }
    private void Start()
    {
        image = GetComponent<Image>();
        start = true;
        Invoke("unstart", 10f);
        RectTransform RT = GetComponent<RectTransform>();
        RT.sizeDelta = new Vector2(Screen.width, Screen.height);
    }
    private void Update()
    {
        float a = 0;
        a = Mathf.Lerp(startAlpha, 1, transition_time * Time.deltaTime);
        startAlpha = a;
        Debug.Log(a);
        CanvasRenderer canvasRenderer = image.canvasRenderer;
        canvasRenderer.SetAlpha(a);
    }
}
