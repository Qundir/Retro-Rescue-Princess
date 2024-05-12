using System.Collections;
using UnityEngine;

public class PlayerBumpBrick : MonoBehaviour
{
    public GameObject item;
    public Sprite emptyBlock;
    private bool isAnimating;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collider is the player and if the player is in Big or Fire state
        if (collision.gameObject.CompareTag("Player"))
        {
            Player player = collision.gameObject.GetComponent<Player>();
            if (player != null && (player.big || player.fire) && collision.transform.DotTest(transform, Vector2.up))
            {
                // Perform the move and destroy sequence
                StartCoroutine(MoveAndDestroyBrick());
            }
        }
    }

    private IEnumerator MoveAndDestroyBrick()
    {
        if (isAnimating)
            yield break;

        isAnimating = true;

        Vector3 start = transform.localPosition;
        Vector3 end = start + Vector3.up * 0.5f; // Half unit upwards

        float duration = 0.25f; // Duration for movement animation
        float elapsed = 0f;

        while (elapsed < duration)
        {
            transform.localPosition = Vector3.Lerp(start, end, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = end;
        
        // Optionally instantiate an item at brick position
        if (item != null)
        {
            Instantiate(item, transform.position, Quaternion.identity);
        }

        // Change the sprite to empty if assigned
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer && emptyBlock)
        {
            spriteRenderer.sprite = emptyBlock;
        }

        // Destroy the game object
        Destroy(gameObject);

        isAnimating = false;
    }
}
