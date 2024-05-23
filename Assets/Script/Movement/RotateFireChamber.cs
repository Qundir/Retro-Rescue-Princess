using UnityEngine;
public class RotateAroundPivot : MonoBehaviour
{
    public Transform pivot; // Pivot noktasında boş bir GameObject
    public float rotationSpeed = 30f;

    void Update()
    {
        if (pivot != null)
        {
            transform.RotateAround(pivot.position, Vector3.forward, rotationSpeed * Time.deltaTime);
        }
    }
}
