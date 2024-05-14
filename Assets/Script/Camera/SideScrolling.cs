using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class SideScrolling : MonoBehaviour
{
    private Transform player;
    private bool underground = false;
    private bool upperground = false;
    private bool normalground = true;
    public float height = 6f;
    public float undergroundHeight = -12f;
    public float uppergroundHeight = 26.5f;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    private void LateUpdate()
    {
        Vector3 cameraPosition = transform.position;

        if (underground)
        {
            cameraPosition = new Vector3(100f, undergroundHeight, cameraPosition.z);
        }
        else if (upperground)
        {
            cameraPosition.x = Mathf.Max(cameraPosition.x, player.position.x);
            cameraPosition.y = uppergroundHeight;
        }
        else if (normalground)
        {
            cameraPosition.x = Mathf.Max(cameraPosition.x, player.position.x);
            cameraPosition.y = height;
        }

        transform.position = cameraPosition;
    }

    public void SetUnderGround(bool isUnderGround)
    {
        underground = isUnderGround;
        upperground = !isUnderGround;
        normalground = false; // normalground false olacak
    }

    public void SetUpperGround(bool isUpperGround)
    {
        upperground = isUpperGround;
        underground = !isUpperGround;
        normalground = false; // normalground false olacak
    }

    public void SetNormalGround(bool isNormalGround)
    {
        normalground = isNormalGround;
        upperground = !isNormalGround;
        underground = !isNormalGround; // underground ve upperground false olacak
    }
}
