using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] GameObject explosionPrefab;
    [SerializeField] GameObject itemPrefab;
    [SerializeField] bool spawnsItems;
    
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<Projectile>())
        {
            Instantiate(explosionPrefab, transform.position, transform.rotation);

            if (spawnsItems)
                Instantiate(itemPrefab, transform.position, transform.rotation);

            Destroy(collider.gameObject);
            Destroy(gameObject);
        }
    }
}
