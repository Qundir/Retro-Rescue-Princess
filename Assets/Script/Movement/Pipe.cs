using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Pipe : MonoBehaviour
{
    public Transform connection;
    public Vector3 enterDirection = Vector3.down;
    public Vector3 exitDirection = Vector3.zero;
    public int exitTunnel = 1;
    private bool EnterTunnel = false;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (connection != null && other.CompareTag("Player"))
        {
            if (EnterTunnel)
            {
                StartCoroutine(Enter(other.transform));
                EnterTunnel = false;
            }
        }
    }

    public void EnterTunnelReturnTrue()
    {
        EnterTunnel = true;
    }

    public void EnterTunnelCanceller()
    {
        EnterTunnel = false;
    }

    private IEnumerator Enter(Transform player)
    {
        player.GetComponent<PlayerMovement>().enabled = false;

        Vector3 enteredPosition = transform.position + enterDirection;
        Vector3 enteredScale = Vector3.one * 0.5f;
        yield return Move(player, enteredPosition, enteredScale);
        yield return new WaitForSeconds(1f);

        if (exitTunnel == 1)
        {
            Camera.main.GetComponent<SideScrolling>().SetUnderGround(true);
        }
        else if (exitTunnel == 2)
        {
            Camera.main.GetComponent<SideScrolling>().SetUpperGround(true);
        }
        else if (exitTunnel == 0)
        {
            Camera.main.GetComponent<SideScrolling>().SetNormalGround(true);
        }

        if (exitDirection != Vector3.zero)
        {
            player.position = connection.position - exitDirection;
            yield return Move(player, connection.position + exitDirection, Vector3.one);
        }
        else
        {
            player.position = connection.position;
            player.localScale = Vector3.one;
        }

        player.GetComponent<PlayerMovement>().enabled = true;
    }

    private IEnumerator Move(Transform player, Vector3 endPosition, Vector3 endScale)
    {
        float elapsed = 0f;
        float duration = 1f;
        Vector3 startPosition = player.position;
        Vector3 startScale = player.localScale;

        while (elapsed < duration)
        {
            float t = elapsed / duration;

            player.position = Vector3.Lerp(startPosition, endPosition, t);
            player.localScale = Vector3.Lerp(startScale, endScale, t);
            elapsed += Time.deltaTime;
            yield return null;
        }

        player.position = endPosition;
        player.localScale = endScale;
    }
}
