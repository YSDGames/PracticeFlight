using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChatManager : MonoBehaviour
{
    [SerializeField] Transform parent;
    [SerializeField] Text chat;
    [SerializeField] Text getchat;


    string[] name;
    string[] weapon;


    private void Start()
    {
        name = new string[]{"������","¯ū��","�ڵ���a","����¯" };
        weapon = new string[] {"�콺","����","����ũ","ǳ��" };
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            Text ch = Instantiate(chat, parent);

            ch.text = name[Random.Range(0,name.Length)];
            ch.gameObject.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = weapon[Random.Range(0, weapon.Length)];

        }
    }

    public void GetChat(string str)
    {
        Text ch = Instantiate(getchat, parent);
        ch.text = "���ѽ� :";
        ch.transform.GetChild(0).GetComponent<Text>().text = str;
    }

}
