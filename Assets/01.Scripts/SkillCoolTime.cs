using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkillCoolTime : MonoBehaviour
{
    public float maxCoolTime;
    public float coolTime;

    [SerializeField] public Image coolTimeImage;
    [SerializeField] private TMP_Text coolTimeText;

    private void Awake()
    {
        coolTime = maxCoolTime;
    }

    private void Update()
    {
        CoolTimeControl();
    }

    public void OnStart()
    {
        if (coolTime == 0)
        {
            coolTime = maxCoolTime;
            coolTimeImage.gameObject.SetActive(true);
        }
        
    }

    private void CoolTimeControl()
    {
        coolTime -= Time.deltaTime;

        if (coolTime <= 0)
        {
            coolTimeImage.gameObject.SetActive(false);
            coolTime = 0;
        }
        else if (coolTime < 1)
            coolTimeText.text = $"{coolTime:N1}";
        else
            coolTimeText.text = $"{(int)coolTime}";

        coolTimeImage.fillAmount = coolTime / maxCoolTime;
    }
}
