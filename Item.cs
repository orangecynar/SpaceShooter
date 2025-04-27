using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] GameObject pickupEffectPrefab;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out var player))
        {
            player.EarnPoints();
            Instantiate(pickupEffectPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
