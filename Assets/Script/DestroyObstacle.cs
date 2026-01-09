using UnityEngine;

public class DestroyObstacle : MonoBehaviour
{
    void Update()
    {
        if (transform.position.x < -12f)
        {
            Destroy(gameObject);
        }
    }
}
