using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BossFlag : MonoBehaviour
{
    public GameObject[] panels;
    public float speed;
    public Transform BlockEdge, BlockStarter, Princess;
    public int nextWorld = 1;
    public int nextStage = 1;
    public int DownStairCase;
    private GameObject Boss;
    public GameObject Endtext;

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

    yield return StartCoroutine(FadeOutPanels());
    yield return StartCoroutine(MoveTo(player, BlockStarter.position));
    yield return StartCoroutine(LevelCompleteSequence(player));
}


    private IEnumerator FadeOutPanels()
    {
        foreach (GameObject panel in panels)
        {
            CanvasGroup canvasGroup = panel.GetComponent<CanvasGroup>();
            if (canvasGroup == null)
            {
                canvasGroup = panel.AddComponent<CanvasGroup>();
            }

            float duration = 0.1f; // Opacity'nin düşme süresi
            float elapsedTime = 0f;

            while (elapsedTime < duration)
            {
                canvasGroup.alpha = Mathf.Lerp(1, 0, elapsedTime / duration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            canvasGroup.alpha = 0; // Tamamen görünmez yap
            panel.SetActive(false); // Paneli devre dışı bırak

            // Bir sonraki panele geçmeden önce 0.25 saniye bekle
            yield return new WaitForSeconds(0.1f);

        }


    }

    private IEnumerator MoveTo(Transform subject, Vector3 position)
    {
        while (Vector3.Distance(subject.position, position) > 0.125f)
        {
            subject.position = Vector3.MoveTowards(subject.position, position, speed * Time.deltaTime);
            yield return null;
        }

        subject.position = position;

    }

    private IEnumerator LevelCompleteSequence(Transform player)
    {
        PlayerSpriteRenderer[] playerSpriteRenderers = player.GetComponentsInChildren<PlayerSpriteRenderer>();
        foreach (PlayerSpriteRenderer playerSpriteRenderer in playerSpriteRenderers)
        {
            playerSpriteRenderer.EnableRunAnimation();

        }
  

        yield return MoveTo(player, BlockStarter.position);


        // Önce 1 birim sağa hareket
        Vector3 targetPosition = player.position + Vector3.right;
        yield return MoveTo(player, targetPosition);


        // Ardından 3 birim aşağıya hareket
        targetPosition = player.position + Vector3.down * DownStairCase;
        yield return MoveTo(player, targetPosition);


        // En sonunda Prenses'e hareket
        yield return MoveTo(player, Princess.position);
        foreach (PlayerSpriteRenderer playerSpriteRenderer in playerSpriteRenderers)
        {
            playerSpriteRenderer.DisableForceRunAnimation();

        }
        Endtext.SetActive(true);



        yield return new WaitForSeconds(7f);
        player.gameObject.SetActive(false);

        GameManager.Instance.LoadLevel(nextWorld, nextStage);


    }
}
