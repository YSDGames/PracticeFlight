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
        timeTxt.text = $"�����ð� \n<b><color=green>{span.Minutes}�� {span.Seconds}��</color></b>";
    }

    public void OnLogin()
    {
        if (string.IsNullOrEmpty(inputID.text))
        {
            Debug.Log("���̵� �Էµ��� ����.");
            return;
        }

        if (string.IsNullOrEmpty(inputPW.text))
        {
            Debug.Log("�н����尡 �Էµ��� ����.");
            return;
        }

        if (inputID.text != id)
        {
            Debug.Log("���̵� �����ϴ�.");
            return;
        }

        if (inputPW.text != pw || inputPW.text.Length < 4)
        {
            Debug.Log("�н����尡 �ٸ��ϴ�.");
            return;
        }
        Debug.Log("�α��� ����!");

        Debug.Log(bool.Parse("false"));
        Debug.Log(bool.Parse("true"));
        Debug.Log(bool.Parse("1"));
    }

    public void OnAutoLogin(Toggle toggle)
    {
        PlayerPrefs.SetString("autoLogin", toggle.isOn.ToString());
    }
}
