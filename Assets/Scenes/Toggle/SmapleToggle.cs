using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SmapleToggle : MonoBehaviour
{
    [SerializeField] private Toggle[] toggles;
    private Image[] images;
    private Image image;
    void Start()
    {
        image = GetComponent<Image>();

        images = new Image[toggles.Length];
        for (int i = 0; i < toggles.Length; i++)
        {
            images[i] = toggles[i].gameObject.GetComponentInChildren<Image>();
        }
    }

    public void OnToggleChange(Toggle toggle)
    {
        for (int i = 0; i < toggles.Length; i++)
        {
            if (toggles[i] == toggle && toggle.isOn == true)
            {
                Debug.Log(toggles[i].gameObject.name);
                image.color = images[i].color;
            }
        }
    }
}
