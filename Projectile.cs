using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float speed;

    void Start()
    {
        Destroy(gameObject, 1f);
    }

    void Update()
    {
        transform.position += Vector3.up * (speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Obstacle>())
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
