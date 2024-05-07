using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideScrolling : MonoBehaviour
{
    private Transform player;
    private bool underground = false; // Yeraltında mı olduğunu belirleyen değişken

    public float height = 6f;
    public float undergroundHeight = -12f;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    private void LateUpdate()
    {
        Vector3 cameraPosition = transform.position;

        // Yeraltında değilken oyuncuyu takip et
        if (!underground)
        {
            cameraPosition.x = Mathf.Max(cameraPosition.x, player.position.x);
            cameraPosition.y = height; // Kamera yüksekliğini 6f'ye ayarla
        }
        else
        {
            // Yeraltındayken sabit konuma yerleştir
            cameraPosition = new Vector3(100f, -26.5f, cameraPosition.z);
        }

        transform.position = cameraPosition;
    }

    public void SetUnderGround(bool isUnderGround)
    {
        underground = isUnderGround;
    }
}
