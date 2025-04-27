using UnityEngine;

public class GameController : Singleton<GameController>
{
    [SerializeField] float acceleration;
    [SerializeField] float maxGameSpeed;
    static float gameSpeed;
    public float GameSpeed => gameSpeed;

    void Start()
    {
        gameSpeed = 0.0f;
    }

    void Update()
    {
        if (gameSpeed <= maxGameSpeed)
            gameSpeed += acceleration * Time.deltaTime;
    }
}
