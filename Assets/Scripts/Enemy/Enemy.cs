using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public struct EnemyData
{
    public float speed;
    public float hp;
    public float dmg;

}

public abstract class Enemy : MonoBehaviour
{
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

    }

    void Update()
    {
        
            
        
        

        bulletss = new List<EnemyBulletA>();

        transform.Translate(Vector3.down * Time.deltaTime * data.speed);
        Shoot();

        if (p == null)
        {
            p = FindObjectOfType<Player>();
            return;
        }
        else if(firePos != null)
        {
            Vector2 vec = transform.position - p.transform.position;
            float angle = Mathf.Atan2(vec.y, vec.x) * Mathf.Rad2Deg;
            firePos.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        }

        if (transform.position.y < -5.5f)
        {
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

    public void Dead()
    {
        if (bulletss.Count > 0)
        {
            foreach (var item in bulletss)
            {
                Debug.Log("zz");
                Destroy(item.gameObject);
            }
        }

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
