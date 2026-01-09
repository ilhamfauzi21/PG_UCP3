using UnityEngine;

public class SpawnObstacles : MonoBehaviour
{
    public GameObject obstacle;

    public float minY = -2f;
    public float maxY = 2f;
    public float timeBetweenSpawn = 1f;

    private float spawnTimer;

    void Update()
    {
        if (Time.time >= spawnTimer)
        {
            Spawn();
            spawnTimer = Time.time + timeBetweenSpawn;
        }
    }

    void Spawn()
    {
        float randomY = Random.Range(minY, maxY);

        float spawnX = Camera.main.ViewportToWorldPoint(
            new Vector3(1, 0, 0)
        ).x + 1.5f;

        Vector3 spawnPosition = new Vector3(spawnX, randomY, 0f);

        Instantiate(obstacle, spawnPosition, Quaternion.identity);
    }
}
