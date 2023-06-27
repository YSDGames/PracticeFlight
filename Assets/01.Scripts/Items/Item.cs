using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    [SerializeField] private List<Sprite> sprites;
    protected float speed;

    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * speed);
    }

    protected virtual void Init()
    {
        GetComponent<SpriteAnimation>().SetSprite(sprites, 0.1f);
    }
}