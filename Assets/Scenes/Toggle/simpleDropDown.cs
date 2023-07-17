using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class simpleDropDown : MonoBehaviour
{
    [SerializeField] TMP_Dropdown dropDown;

    int abc;
    void Start()
    {
        dropDown.value = 0;
        dropDown.ClearOptions();

        string[] str = { "S class", "A class", "B class", "C class", "D class", "F class" };

        List<TMP_Dropdown.OptionData> od = new List<TMP_Dropdown.OptionData>();

        for (int i = 0; i < str.Length; i++)
        {
            TMP_Dropdown.OptionData data = new TMP_Dropdown.OptionData();
            data.text = str[i];
            od.Add(data);
        }

        dropDown.options = od;
        
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void OnvalueChange(int abc)
    {
        this.abc = abc;
        Debug.Log(abc);
    }
}
