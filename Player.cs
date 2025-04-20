using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Projectile projectilePrefab;
    [SerializeField] Transform shootPoint;
    [SerializeField] float shootCooldown;
    float lastShotTime;
    int points = 0;

    void Update()
    {
        if (Input.GetMouseButton(0))
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Time.time > lastShotTime + shootCooldown)
        {
            Instantiate(projectilePrefab, shootPoint.position, Quaternion.identity);
            lastShotTime = Time.time;
        }
    }

    public void EarnPoints()
    {
        points++;
    }
}
