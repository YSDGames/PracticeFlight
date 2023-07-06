using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialBullet : MonoBehaviour
{
    bool isStart = false;

    private void Update()
    {
        transform.position += Vector3.up * Time.deltaTime * 10f;
        
        if(transform.position.y > Camera.main.orthographicSize + 0.2f)
        {
            OnHinde();
        }
    } 
    public void OnShow()
    {
        gameObject.SetActive(true);
        Vector2 pos = transform.localPosition;
        pos.y = -(Camera.main.orthographicSize+0.2f);
        transform.localPosition = pos;
        isStart = true;
    }

    public void OnHinde()
    {
        isStart = false;
        gameObject.SetActive(false);
    }
}
