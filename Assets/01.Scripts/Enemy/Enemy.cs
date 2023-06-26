using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Progress;

public struct EnemyData
{
    public float speed;
    public float hp;
    public float dmg;

}

public abstract class Enemy : MonoBehaviour
{
    Item[] items;
    protected EnemyData data = new EnemyData();

    [SerializeField] protected List<Sprite> normalSP;
    [SerializeField] protected List<Sprite> hitSP;
    [SerializeField] protected List<Sprite> explosionSP;
    protected SpriteAnimation sa;

    Transform shootposition;

    [SerializeField] protected EnemyBulletA bullet;
    [SerializeField] protected Transform firePos;
    [SerializeField] GameObject bulletParent;

    Player p;

    List<EnemyBulletA> bulletss = new List<EnemyBulletA>();


    float fireTimer;
    public float fireDelayTime = 1f;

    public virtual void Init()
    {
        sa = GetComponent<SpriteAnimation>();
        shootposition = transform.GetChild(0);

        items = Resources.LoadAll<Item>("Item");

    }

    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * data.speed);
        Shoot();

        if (p == null)
        {
            p = FindObjectOfType<Player>();
            return;
        }
        else if (firePos != null)
        {
            Vector2 vec = transform.position - p.transform.position;
            float angle = Mathf.Atan2(vec.y, vec.x) * Mathf.Rad2Deg;
            firePos.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        }

        if (transform.position.y < -5.5f)
        {
            DestoryBullet();
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.GetComponent<PlayerBullet>())
        {
            Destroy(collision.gameObject);
            Hit(collision.GetComponent<PlayerBullet>().power);

        }
    }

    //내가 구현해놓을게 쓸라면쓰고 수정할라면 수정하고
    public void Hit(float dmg)
    {
        sa.SetSprite(normalSP, hitSP, 0.2f, 0.05f);
        data.hp -= dmg;

        if (data.hp <= 0)
        {
            Dead();
        }
    }

    public void DestoryBullet()
    {

        //if (bulletss.Count > 0)
        //{
        //    foreach (var item in bulletss)
        //    {
        //        Debug.Log("zz");
        //        Destroy(item.gameObject);
        //    }
        //}
        if (bulletss != null)
            for (int i = bulletss.Count - 1; i >= 0; i--)
            {
                if (bulletss[i] != null)
                {
                    Destroy(bulletss[i].gameObject);
                    
                }
                //bulletss.RemoveAt(i);
                break;
            }

    }

    public void Dead()
    {

        Destroy(GetComponent<Rigidbody2D>());
        GetComponent<CircleCollider2D>().enabled = false;


        sa.SetSprite(explosionSP, 0.1f,
            () =>
            {
                int rand = Random.Range(1, 101);

                string spawnStr = rand < 60 ? "Coin" : rand < 80 ? "Power" : "Boom";

                //아이템생성
                for (int i = 0; i < items.Length; i++)
                {
                    if (items[i].name == spawnStr)
                    {
                        Instantiate(items[i], transform.position, Quaternion.identity);
                        break;
                    }
                }

                //파괴
                Destroy(gameObject);
            }
            );


        Destroy(GetComponent<Rigidbody2D>());
        GetComponent<CircleCollider2D>().enabled = false;

        sa.SetSprite(explosionSP, 0.1f, () => Destroy(gameObject));
    }
    void Shoot()
    {
        fireTimer += Time.deltaTime;
        if (fireTimer > fireDelayTime)
        {

            EnemyBulletA b = Instantiate(bullet, firePos);
            bulletss.Add(b);

            b.name = "eBullet";
            b.transform.SetParent(EnemyCont.instance.enemyBullet);
            fireTimer = 0;

        }
    }

}
