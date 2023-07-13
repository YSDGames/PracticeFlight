using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class NaverToggle : MonoBehaviour
{
    [SerializeField] private Toggle[] toggles;
    [SerializeField] private Image[] images;



    public void OnChangeView(Toggle select)
    {
        for (int i = 0; i < toggles.Length; i++)
        {
            if (select.isOn == true && toggles[i] == select)
            {
                toggles[i].gameObject.GetComponentsInChildren<Image>(true)[0].gameObject.SetActive(true);
                images[i].color = Color.white;
            }
            else if (select.isOn == false && toggles[i] == select)
            {

                toggles[i].gameObject.GetComponentsInChildren<Image>(true)[0].gameObject.SetActive(false);
                images[i].color = Color.gray;

            }
        }
    }
}
