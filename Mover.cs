using UnityEngine;

public class Mover : MonoBehaviour
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
        transform.position += Vector3.down * ((speed + GameController.Instance.GameSpeed) * Time.deltaTime);
        if (transform.position.y < -mainCamera.orthographicSize - spriteRenderer.bounds.extents.y)
            Destroy(gameObject);
    }
}
