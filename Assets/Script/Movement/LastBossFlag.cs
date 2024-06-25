using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LastBossFlag : MonoBehaviour
{
    public float speed;
    public Transform BlockEdge, Princess;
    public int nextWorld = 1;
    public int nextStage = 1;
    public int DownStairCase;
    private GameObject Boss;
    public GameObject Endtext;
    private GameObject Princess0;

    private void Start()
    {
        Princess0 = GameObject.FindWithTag("Princesss");
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(HandleLevelCompletionSequence(other.transform));
        }
    }

    private IEnumerator HandleLevelCompletionSequence(Transform player)
    {
        player.GetComponent<PlayerMovement>().enabled = false;
        Debug.Log("PlayerMovement disabled");
        Boss = GameObject.FindWithTag("KoopaBoss");

        if (Boss != null)
        {
            Debug.Log("Boss bulundu, KillBoss çağrılıyor.");
            BossKoopa bossKoopa = Boss.GetComponent<BossKoopa>();
            if (bossKoopa != null)
            {
                bossKoopa.KillBoss();
            }
        }
        else
        {
            Debug.Log("Boss bulunamadı.");
        }

        yield return StartCoroutine(LevelCompleteSequence(player));
    }

    private IEnumerator MoveTo(Transform subject, Vector3 position)
    {
        Debug.Log($"MoveTo: Moving {subject.name} to {position}");
        while (Vector3.Distance(subject.position, position) > 0.125f)
        {
            subject.position = Vector3.MoveTowards(subject.position, position, speed * Time.deltaTime);
            Debug.Log($"Current position: {subject.position}, Target position: {position}");
            yield return null;
        }

        subject.position = position;
        Debug.Log($"MoveTo: {subject.name} reached {position}");
    }

    private IEnumerator LevelCompleteSequence(Transform player)
    {
        PlayerSpriteRenderer[] playerSpriteRenderers = player.GetComponentsInChildren<PlayerSpriteRenderer>();
        foreach (PlayerSpriteRenderer playerSpriteRenderer in playerSpriteRenderers)
        {
            playerSpriteRenderer.EnableRunAnimation();
        }

        // Önce 1 birim sağa hareket
        Debug.Log("LevelCompleteSequence: Moving player right");
        Vector3 targetPosition = player.position + Vector3.right;
        yield return MoveTo(player, targetPosition);

        // Ardından 3 birim aşağıya hareket
        Debug.Log("LevelCompleteSequence: Moving player down");
        targetPosition = player.position + Vector3.down * DownStairCase;
        yield return MoveTo(player, targetPosition);

        // En sonunda Prenses'e hareket
        Debug.Log("LevelCompleteSequence: Moving player to Princess");
        yield return MoveTo(player, Princess.position);

        foreach (PlayerSpriteRenderer playerSpriteRenderer in playerSpriteRenderers)
        {
            playerSpriteRenderer.DisableForceRunAnimation();
        }
        Endtext.SetActive(true);

        PrincessPomegranade princessPomegranade = Princess0.GetComponent<PrincessPomegranade>();
        if (princessPomegranade != null)
        {
            Debug.Log("Calling GiveFlowerToEuario");
            princessPomegranade.GiveFlowerToEuario();
        }

        yield return new WaitForSeconds(7f);
        player.gameObject.SetActive(false);

        GameManager.Instance.LoadLevel(nextWorld, nextStage);
    }
}
