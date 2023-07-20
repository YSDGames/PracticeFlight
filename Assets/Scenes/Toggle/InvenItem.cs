using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InvenItem : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] Image icon;
    [SerializeField] TMPro.TMP_Text enchanTxt;
    [SerializeField] GameObject equipTxt;

    public ItemData data;
    public void SetData(ItemData data)
    {
        this.data = data;

        icon.sprite = data.sprite;
        enchanTxt.text = data.enchan.ToString();
        equipTxt.SetActive(data.isEquip);
       
    }
    public void SetSprite(Sprite sprite)
    {
        icon.sprite = sprite;
    }

    public void OnClick()
    {
        Debug.Log(data.index);
    }


    Vector3 pos;
    public void OnBeginDrag(PointerEventData eventData)
    {
        pos = transform.position;
    }
    public void OnDrag(PointerEventData eventData)
    {
        GetComponent<RectTransform>().anchoredPosition += eventData.delta;
    }

    public void OnEndDrag(PointerEventData eventData)
    {

    }
}
