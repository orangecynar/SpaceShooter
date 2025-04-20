using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject obstaclePrefab;
    [SerializeField] float spawnCooldown;
    float lastSpawnTime;
    Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (Time.time > lastSpawnTime + spawnCooldown)
        {
            Vector2 newPosition = transform.position;
            newPosition.x = mainCamera.transform.position.x + mainCamera.aspect * Random.Range(-mainCamera.orthographicSize, mainCamera.orthographicSize);

            Instantiate(obstaclePrefab, newPosition, Quaternion.identity);
            lastSpawnTime = Time.time;
        }
    }
}
