using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] GameObject explosionPrefab;
    Camera mainCamera;
    SpriteRenderer spriteRenderer;

    void Start()
    {
       mainCamera = Camera.main;
       spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    void Update()
    {
        transform.position += Vector3.up * (speed * Time.deltaTime);
        if (transform.position.y > mainCamera.orthographicSize + spriteRenderer.bounds.extents.y)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Obstacle>())
        {
            Instantiate(explosionPrefab, transform.position, transform.rotation);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
