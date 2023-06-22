using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] List<Sprite> center;
    [SerializeField] List<Sprite> right;
    [SerializeField] List<Sprite> left;
    [SerializeField] PlayerBullet bullet;
    [SerializeField] Transform parent;
    [SerializeField] Transform bulletParent;


    public float fireDelayTime;
    public float fireTimer;



    enum Direction
    {
        center,
        left,
        right
    }

    Direction dir = Direction.center;

    public float speed;

    void Awake()
    {
        GetComponent<SpriteAnimation>().SetSprite(center, 0.2f);
        bullet.speed = 5f;
    }



    void Update()
    {
        Move();
        Shoot();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<EnemyBulletA>())
        {
            Destroy(collision.gameObject);
        }

        if (collision.GetComponent<EnemyA>())
        {
            collision.gameObject.GetComponent<EnemyA>().Hit(1);
        }
    }

    void Shoot()
    {
        fireTimer += Time.deltaTime;
        if (fireTimer > fireDelayTime)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                PlayerBullet b = Instantiate(bullet, parent);
                b.name = "pBullet";
                b.transform.SetParent(bulletParent);

                Destroy(b.gameObject, 2f);

                fireTimer = 0;
            }
        }
    }

    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed;
        float y = Input.GetAxisRaw("Vertical") * Time.deltaTime * speed;

        if (x == 0 && dir != Direction.center)
        {
            dir = Direction.center;
            GetComponent<SpriteAnimation>().SetSprite(center, 0.2f);
        }
        else if (x > 0 && dir != Direction.right)
        {
            dir = Direction.right;
            GetComponent<SpriteAnimation>().SetSprite(right, 0.2f);

        }
        else if (x < 0 && dir != Direction.right)
        {
            dir = Direction.left;
            GetComponent<SpriteAnimation>().SetSprite(left, 0.2f);

        }

        float clampX = Mathf.Clamp(transform.position.x + x, -2.5f, 2.5f);
        float clampY = Mathf.Clamp(transform.position.y + y, -4.5f, 4.5f);

        transform.position = new Vector3(clampX, clampY, 0);
    }
}
