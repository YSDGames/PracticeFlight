using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChatManager : MonoBehaviour
{
    [SerializeField] Transform parent;
    [SerializeField] Text chat;
    [SerializeField] Text getchat;
    [SerializeField] TMP_InputField userChat;
    

    [SerializeField] string userName;
    string[] name;
    string[] weapon;

    bool isChating;
    float timer;
    float limit;
    private void Start()
    {
        name = new string[] { "������", "¯ū��", "�ڵ���a", "����¯", "��Ÿ���ּ���", "Rar����", "���̿���ŷ" };
        weapon = new string[] { "�콺", "����", "����ũ", "ǳ��", "�巡���ð���", "�����´��", "�ְ�� ��ɲ��� �ĵ�" };
        isChating = false;
        limit = 1f;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        
        
        if (timer >= limit)
        {
            int rand = Random.Range(4, 7);

            Text ch = Instantiate(chat, parent);
            Text drawingtxt = ch.gameObject.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>();

            ch.text = name[Random.Range(0, name.Length)];
            drawingtxt.text = weapon[Random.Range(0, weapon.Length)] + $" {rand}��";

            if(rand == 4 ) drawingtxt.color = new Color(0, 1, 0, 1);
            else if (rand == 5) drawingtxt.color = new Color(1, 0, 0, 1);
            else if (rand == 6) drawingtxt.color = new Color32(255, 0, 190, 255);

            limit = Random.Range(0.5f, 2);
            timer = 0;
        }
        

        if (Input.GetKeyDown(KeyCode.Return)&&!isChating)
        {
            userChat.ActivateInputField();
        }
    }

    public void GetChat(string str)
    {
        if (userChat.text == string.Empty) return;

        if (Input.GetKeyDown(KeyCode.Return))
        {
            Text ch = Instantiate(getchat, parent);
            ch.text = $"{userName} : ";
            ch.transform.GetChild(0).GetComponent<Text>().text = str;
            userChat.text = string.Empty;
            userChat.ActivateInputField();
        }
    }

    public void OnisChating()
    {
        isChating = true;
    }
    public void OnIsNotChating()
    {
        isChating = false;
    }

}
