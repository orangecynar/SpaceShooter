using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject obstaclePrefab;
    [SerializeField] float spawnCooldown;
    float lastSpawnTime;
    Camera mainCamera;
    SpriteRenderer spriteRenderer;

    void Start()
    {
        mainCamera = Camera.main;
        spriteRenderer = obstaclePrefab.GetComponentInChildren<SpriteRenderer>();
    }

    void Update()
    {
        if (Time.time > lastSpawnTime + spawnCooldown)
        {
            Instantiate(
                obstaclePrefab,
                (Vector2)mainCamera.transform.position + new Vector2(
                    mainCamera.aspect * Random.Range(-mainCamera.orthographicSize, mainCamera.orthographicSize),
                    mainCamera.orthographicSize + spriteRenderer.bounds.extents.y),
                Quaternion.identity);
            lastSpawnTime = Time.time;
        }
    }
}
