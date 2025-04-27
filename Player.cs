using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Projectile projectilePrefab;
    [SerializeField] Transform shootPoint;
    [SerializeField] float shootCooldown;
    [SerializeField] float movementDamping;
    [SerializeField] GameUI gameUI;
    float lastShotTime;
    int points = 0;

    void Update()
    {
        if (Input.GetMouseButton(0))
            transform.position = Vector2.Lerp(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition), movementDamping);

        if (Time.time > lastShotTime + shootCooldown)
        {
            Instantiate(projectilePrefab, shootPoint.position, Quaternion.identity);
            lastShotTime = Time.time;
        }
    }

    public void Defeat()
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
        Destroy(gameObject);
    }

    public void EarnPoints()
    {
        gameUI.UpdateScore(++points);
    }
}
