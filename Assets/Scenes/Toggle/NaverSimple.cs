using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using TMPro;


public class NaverSimple : MonoBehaviour
{
    [SerializeField] Toggle autoLoginToggle;
    float timer;
    [SerializeField] private Text timeTxt;

    [SerializeField] TMP_InputField inputID;
    [SerializeField] TMP_InputField inputPW;


    string id = "qwer";
    string pw = "1234";
    void Start()
    {
        timer = 150;

        if (PlayerPrefs.HasKey("autoLogin"))
        {
            autoLoginToggle.isOn = bool.Parse(PlayerPrefs.GetString("autoLogin"));
        }
        else
        {
            autoLoginToggle.isOn = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        System.TimeSpan span = System.TimeSpan.FromSeconds(timer);
        timeTxt.text = $"남은시간 \n<b><color=green>{span.Minutes}분 {span.Seconds}초</color></b>";
    }

    public void OnLogin()
    {
        if (string.IsNullOrEmpty(inputID.text))
        {
            Debug.Log("아이디가 입력되지 않음.");
            return;
        }

        if (string.IsNullOrEmpty(inputPW.text))
        {
            Debug.Log("패스워드가 입력되지 않음.");
            return;
        }

        if (inputID.text != id)
        {
            Debug.Log("아이디가 없습니다.");
            return;
        }

        if (inputPW.text != pw || inputPW.text.Length < 4)
        {
            Debug.Log("패스워드가 다릅니다.");
            return;
        }
        Debug.Log("로그인 성공!");

        Debug.Log(bool.Parse("false"));
        Debug.Log(bool.Parse("true"));
        Debug.Log(bool.Parse("1"));
    }

    public void OnAutoLogin(Toggle toggle)
    {
        PlayerPrefs.SetString("autoLogin", toggle.isOn.ToString());
    }
}
