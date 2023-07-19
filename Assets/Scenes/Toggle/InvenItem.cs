using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InvenItem : MonoBehaviour
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
}
