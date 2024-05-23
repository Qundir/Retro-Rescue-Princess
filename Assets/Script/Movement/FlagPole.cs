using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class FlagPole : MonoBehaviour
{
    public Transform flag;
    public Transform bottom;
    public Transform castle;
    public float speed = 6f;
    public int nextWorld = 1;
    public int nextStage = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            StartCoroutine(MoveTo(flag,bottom.position));
            StartCoroutine(LevelCompleteSequence(other.transform));
        }
    }

    private IEnumerator LevelCompleteSequence(Transform player)
    {
        player.GetComponent<PlayerMovement>().enabled = false;
        PlayerSpriteRenderer[] playerSpriteRenderers = player.GetComponentsInChildren<PlayerSpriteRenderer>();
        foreach (PlayerSpriteRenderer playerSpriteRenderer in playerSpriteRenderers)
        {
            playerSpriteRenderer.EnableRunAnimation();
        }
        yield return MoveTo(player, bottom.position);
        yield return MoveTo(player, player.position + Vector3.right);
        yield return MoveTo(player, player.position + Vector3.right + Vector3.down);
        yield return MoveTo(player, castle.position);
        foreach (PlayerSpriteRenderer playerSpriteRenderer in playerSpriteRenderers)
        {
            playerSpriteRenderer.DisableForceRunAnimation();
            
        }
        GameManager.Instance.LoadLevel(nextWorld, nextStage);
        player.gameObject.SetActive(false);

        yield return new WaitForSeconds(3f);

    }

    private IEnumerator MoveTo(Transform subject, Vector3 position)
    {
        while(Vector3.Distance(subject.position, position) > 0.125f)
        {
            subject.position = Vector3.MoveTowards(subject.position, position, speed * Time.deltaTime);
            yield return null;
        }

        subject.position = position;
    }
}
