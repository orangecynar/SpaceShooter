using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] GameObject playerExplosionPrefab;
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Player>(out var player))
        {
            Instantiate(playerExplosionPrefab, transform.position, transform.rotation);
            player.Defeat();
        }
    }
}
