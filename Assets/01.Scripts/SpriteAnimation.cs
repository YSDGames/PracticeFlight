using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;

public class SpriteAnimation : MonoBehaviour
{
    public static SpriteAnimation instance; 

    private List<Sprite> sprites = new List<Sprite>();
    private List<Sprite> sprites1 = new List<Sprite>();


    private SpriteRenderer sr;

    private float spriteDelayTime;
    private float sprtieDelayTime1;
    private float delayTime = 0f;

    private int spriteAnimationIndex = 0;

    private UnityAction action;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (sprites.Count == 0)
            return;

        delayTime += Time.deltaTime;
        if (delayTime > spriteDelayTime)
        {
            delayTime = 0;
            if (sprites1.Count != 0)
            {
                sr.sprite = sprites1[spriteAnimationIndex];
                spriteAnimationIndex++;

                if (spriteAnimationIndex > sprites1.Count - 1)
                {
                    spriteAnimationIndex = 0;
                    sprites1.Clear();
                }

            }
            else
            {
                sr.sprite = sprites[spriteAnimationIndex];
                spriteAnimationIndex++;

                if (spriteAnimationIndex > sprites.Count - 1)
                {
                    if (action != null)
                    {
                        sprites.Clear();
                        action();
                        action = null;
                    }
                    else
                    {
                        spriteAnimationIndex = 0;
                    }
                }
            }
            
        }
    }

    public void SetSprite(List<Sprite> argSprites, float delayTime)
    {
        this.delayTime = float.MaxValue;
        spriteAnimationIndex = 0;
        sprites = argSprites.ToList<Sprite>();
        spriteDelayTime = delayTime;
    }

    public void SetSprite(List<Sprite> argSprites, float delayTime, UnityAction action)
    {
        this.delayTime = float.MaxValue;
        spriteAnimationIndex = 0;
        sprites = argSprites.ToList<Sprite>();
        spriteDelayTime = delayTime;
        this.action = action;
    }

    public void SetSprite(List<Sprite> argSprites, List<Sprite> argSprites1, float delayTime , float delayTime1)
    {
        this.delayTime = float.MaxValue;
        spriteAnimationIndex = 0;
        sprites = argSprites.ToList<Sprite>();
        sprites1 = argSprites1.GetRange(0, argSprites1.Count);
        sprtieDelayTime1 = delayTime1;
        spriteDelayTime = delayTime;
    }
}
