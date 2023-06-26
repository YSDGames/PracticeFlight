using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    [System.Serializable]
    public class BGDate
    {
        public Transform trans;
        public float speed;

    }

    public List<BGDate> bgDatas = new List<BGDate>();

    //public Transform[] trans;

    //void Start()
    //{

    //}

    // Update is called once per frame
    void Update()
    {
        //trans[0].Translate(Vector3.down * Time.deltaTime * 5f);
        //trans[1].Translate(Vector3.down * Time.deltaTime * 3f);
        //trans[2].Translate(Vector3.down * Time.deltaTime * 1f);


        foreach (var item in bgDatas)
        {
            item.trans.Translate(Vector3.down * Time.deltaTime * item.speed);

            if (item.trans.position.y <= -12)
            {
                item.trans.position = Vector3.up * 12;
            }
        }



    }
}
