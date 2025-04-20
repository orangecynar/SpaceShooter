using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; }
    public float GameSpeed { get; private set; }
    [SerializeField] float acceleration;
    [SerializeField] float maxGameSpeed;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);
    }

    void Update()
    {
        if (GameSpeed <= maxGameSpeed)
            GameSpeed += acceleration * Time.deltaTime;
    }
}
