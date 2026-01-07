using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;

    void LateUpdate()
    {
        if (player == null) return;

        transform.position = new Vector3(
            transform.position.x,
            player.position.y + offset.y,
            transform.position.z
        );
    }
}
