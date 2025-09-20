using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float destroyDistance = 10f;

    public float Speed
    {
        get => speed;
        set => speed = value;
    }

    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        if (transform.position.x < Camera.main.transform.position.x - destroyDistance)
        {
            Destroy(gameObject);
        }
    }
}
