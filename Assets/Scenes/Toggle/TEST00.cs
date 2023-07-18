using UnityEngine;
using UnityEngine.UI;   


public class TEST00 : MonoBehaviour
{
    public Image target;
    public void OnAAA(float value)
    {
        target.color = new Color(1, 1, 1, value);
    }
}
