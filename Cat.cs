using UnityEngine;

public class Cat : MonoBehaviour
{
    [SerializeField] float speed = 2f;
    Camera mainCamera;
    SpriteRenderer spriteRenderer;

    void Start()
    {
       mainCamera = Camera.main;
       spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    void Update()
    {
        transform.position += Vector3.right * (speed * Time.deltaTime);
        if (transform.position.x > mainCamera.orthographicSize * mainCamera.aspect + spriteRenderer.bounds.extents.x)
            transform.position = new Vector2(
                -mainCamera.orthographicSize * mainCamera.aspect - spriteRenderer.bounds.extents.x,
                Random.Range(-mainCamera.orthographicSize, mainCamera.orthographicSize));
    }
}
