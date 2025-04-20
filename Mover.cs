using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] float speed = 2f;

    void Start()
    {
       Destroy(gameObject, 5f);
    }

    void Update()
    {
        transform.position += Vector3.down * ((speed + GameController.Instance.GameSpeed) * Time.deltaTime);
    }
}
