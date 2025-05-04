using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject explosionPrefab;
    [SerializeField] Projectile projectilePrefab;
    [SerializeField] Transform shootPoint;
    [SerializeField] float shootCooldown;
    [SerializeField] float movementDamping;
    [SerializeField] GameUI gameUI;
    float lastShotTime;
    int points = 0;

    void Update()
    {
#if UNITY_EDITOR
        if (Input.GetMouseButton(0) && !EventSystem.current.IsPointerOverGameObject())
#else
        if (Input.GetMouseButton(0) && !EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
#endif
            transform.position = Vector2.Lerp(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition), movementDamping * Time.deltaTime);

        if (Time.time > lastShotTime + shootCooldown)
        {
            Instantiate(projectilePrefab, shootPoint.position, Quaternion.identity);
            lastShotTime = Time.time;
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<Obstacle>())
        {
            int highscore = 0;
            if (PlayerPrefs.HasKey("Highscore"))
                highscore = PlayerPrefs.GetInt("Highscore");
            if (points > highscore)
            {
                PlayerPrefs.SetInt("Highscore", highscore = points);
                PlayerPrefs.Save();
            }
            gameUI.OnGameOver(points, highscore);
            Instantiate(explosionPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    public void EarnPoints()
    {
        points++;
        gameUI.UpdateScore(points);
    }
}
