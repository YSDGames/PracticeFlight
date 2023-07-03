using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI : MonoBehaviour
{
    [SerializeField] private TMP_Text txt;
    [SerializeField] private Image hpImage;
    [SerializeField] private TMP_Text hpText;

    [SerializeField] private Image mpImage;
    [SerializeField] private TMP_Text mpText;



    float curHp = 100f;
    float maxHp = 100f;
    float curMp = 100f;
    float maxMp = 100f;



    public static UI instance;
    int score;

    public int SetScore
    {
        get
        {
            return score;
        }
        set
        {
            score = value;
            txt.text = $"Score : {score}";
        }
    }

    private void Start()
    {
        instance = this;
        txt.fontSize = 70;
        txt.alignment = TextAlignmentOptions.Left | TextAlignmentOptions.Center;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            curHp += Random.Range(5, 11);
            curMp += Random.Range(5, 11);
        }
        if (Input.GetKeyDown(KeyCode.F2))
        {
            curHp -= Random.Range(5, 11);
            curMp -= Random.Range(5, 11);
        }

        curHp = Mathf.Clamp(curHp, 0, maxHp);
        curMp = Mathf.Clamp(curMp, 0, maxMp);

        hpImage.fillAmount = curHp / maxHp;
        mpImage.fillAmount = curMp / maxMp;

        //hpText.text = $"{100 * hpImage.fillAmount:N0}%";
        //mpText.text = $"{100 * mpImage.fillAmount:N0}%";

        hpText.text = $"{curHp}/{maxHp}";
        mpText.text = $"{curMp}/{maxMp}";
    }
}
