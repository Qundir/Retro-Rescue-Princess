using System.Collections;
using UnityEngine;
using UnityEngine.Purchasing;

public class BossKoopa : MonoBehaviour
{
    public GameObject BossFireBall;
    public Transform BossFireBallPosition1, BossFireBallPosition2;
    int hitCounter = 0;

    private void Start()
    {
        StartCoroutine(BossShotFire1());
        StartCoroutine(BossShotFire2());
    }

    public void ShotBossFireBall1()
    {
        GameObject fire = Instantiate(BossFireBall, BossFireBallPosition1.position, BossFireBallPosition1.rotation);
        Rigidbody2D rb = fire.GetComponent<Rigidbody2D>();
        rb.velocity = BossFireBallPosition1.right * -7f;  // Sol yöne hareket
        Destroy(fire, 4f);
    }

    public void ShotBossFireBall2()
    {
        GameObject fire = Instantiate(BossFireBall, BossFireBallPosition2.position, BossFireBallPosition2.rotation);
        Rigidbody2D rb = fire.GetComponent<Rigidbody2D>();
        rb.velocity = BossFireBallPosition2.right * -7f;  // Sol yöne hareket
        Destroy(fire, 4f);
    }

    private IEnumerator BossShotFire1()
    {
        while (true)
        {
            float waitTime = Random.Range(3f, 7f);
            yield return new WaitForSeconds(waitTime);
            ShotBossFireBall1();
        }
    }

    private IEnumerator BossShotFire2()
    {
        while (true)
        {
            float waitTime = Random.Range(3f, 7f);
            yield return new WaitForSeconds(waitTime);
            ShotBossFireBall2();
        }
    }
    public void Hit()
    {
        hitCounter++;
        Debug.Log("HitCounter");
        if(hitCounter > 10)
        {
            KillBoss();
        }        
    }
    public void KillBoss()
    {
        gameObject.tag = "Untagged";
        GetComponent<AnimatedSprite>().enabled = false;
        GetComponent<DeathAnimation>().enabled = true;
        GetComponent<BossKoopa>().enabled = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player player = collision.gameObject.GetComponent<Player>();
            if (player != null)
            {
                player.Hit();
            }
        }
    }
}
