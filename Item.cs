using UnityEngine;

public class Item : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out var player))
        {
            player.EarnPoints();
            Destroy(gameObject);
        }
    }
}
