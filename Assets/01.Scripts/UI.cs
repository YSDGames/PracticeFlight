using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI : MonoBehaviour
{
    [SerializeField] private TMP_Text txt;

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

}
