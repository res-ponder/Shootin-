using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class rescale_to_screensize : MonoBehaviour
{
    [SerializeField] private float smoothness;
    [SerializeField] private float transition_smoothness;
    [SerializeField] private float zoom;
    [SerializeField] private bool is_backgound = false;
    [SerializeField] private float start_size_x;
    [SerializeField] private float start_size_y;
    [SerializeField] private float offset_size_x;
    [SerializeField] private float offset_size_y;
    [SerializeField] private float min_for_transition = 0.01f;

    private RectTransform RT;
    private Image image;
    private bool zoom_now = false;
    float startAlpha = 1;
    //private float current_zoom;
    private float target_zoom;
    void Start()
    {
        image = GetComponent<Image>();
        RT = GetComponent<RectTransform>();

        if (is_backgound == true)
        {
            RT.sizeDelta = new Vector2(Screen.width, Screen.height);
        }
        else
        {
            RT.sizeDelta = new Vector2(Screen.width * start_size_x, Screen.height * start_size_y);
            RT.localPosition = new Vector2(this.transform.localPosition.x + Screen.width * offset_size_x, this.transform.localPosition.y + Screen.width * offset_size_y);
        }
    }

    private void Update()
    {
        if(is_backgound == true && zoom_now == true)
        {
            RT.localScale = Vector2.Lerp(RT.localScale, new Vector2(target_zoom, target_zoom), smoothness * Time.deltaTime);
            float a = 1;
            a = Mathf.Lerp(startAlpha, 0, transition_smoothness * Time.deltaTime);
            startAlpha = a;
            Debug.Log(a);
            CanvasRenderer canvasRenderer = image.canvasRenderer;
           canvasRenderer.SetAlpha(a);
            if(a < min_for_transition)
            {
                SceneManager.LoadScene("info_screen");
            }
        }
        
    }

    public void on_play()
    {
        zoom_now = true;
        target_zoom = zoom;
        if(is_backgound == false)
        {
            Destroy(this.gameObject);
        }
    }
}
