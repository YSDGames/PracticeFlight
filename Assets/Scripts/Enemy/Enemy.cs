using System.Collections;
using System.Collections.Generic;
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



    [SerializeField] protected EnemyBulletA bullet;
    [SerializeField] protected Transform parent;


    protected Transform bulletParent;

    float fireTimer;
    public float fireDelayTime;

    void Update()
    {

        transform.Translate(Vector3.down * Time.deltaTime * data.speed);


        test();
    }

    public virtual void test()
    {
        Debug.Log("123");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.GetComponent<PlayerBullet>())
        {
            Destroy(collision.gameObject);
            Hit(collision.GetComponent<PlayerBullet>().power);

        }


    }

    //���� �����س����� ����龲�� �����Ҷ�� �����ϰ�
    public void Hit(float dmg)
    {
        sa.SetSprite(normalSP, hitSP, 0.2f, 0.05f);
        data.hp -= data.dmg;
        if (data.hp <= 0)
        {
            Dead();
        }

    }
    // ������ �����ض�
    public virtual void Init()
    {
        sa = GetComponent<SpriteAnimation>();
    }




    public void Dead()
    {
        Destroy(GetComponent<Rigidbody2D>());
        GetComponent<CircleCollider2D>().isTrigger = false;

        sa.SetSprite(explosionSP, 0.1f, () => Destroy(gameObject));
        
        
    }





    //void Shoot()
    //{
    //    fireTimer += Time.deltaTime;
    //    if (fireTimer > fireDelayTime)
    //    {

    //        EnemyBulletA b = Instantiate(bullet, parent);
    //        b.name = "eBullet";
    //        b.transform.SetParent(bulletParent);

    //        fireTimer = 0;

    //    }
    //}
    //
}
