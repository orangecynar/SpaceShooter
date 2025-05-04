public class Background : Singleton<Background>
{
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
}
