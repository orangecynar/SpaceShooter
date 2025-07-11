using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float speed;
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
}
