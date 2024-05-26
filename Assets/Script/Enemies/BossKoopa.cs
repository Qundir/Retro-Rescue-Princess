using UnityEngine;

public class BossKoopa : MonoBehaviour
{
    public GameObject BossFireBall;
    public Transform BossFireBallPosition1, BossFireBallPosition2;
    public void ShotBossFireBall1()
    {
        GameObject fire = Instantiate(BossFireBall, BossFireBallPosition1.position , BossFireBallPosition1.rotation);
        Rigidbody2D rb = fire.GetComponent<Rigidbody2D>();
        rb.velocity = BossFireBallPosition1.right * 10f;
        Destroy(fire, 15f);
    }
    public void ShotBossFireBall2()
    {
        GameObject fire = Instantiate(BossFireBall, BossFireBallPosition2.position ,  BossFireBallPosition2.rotation);
        Rigidbody2D rb = fire.GetComponent<Rigidbody2D>();
        rb.velocity = BossFireBallPosition2.right * 10f;
        Destroy(fire, 15f);
    }
}
