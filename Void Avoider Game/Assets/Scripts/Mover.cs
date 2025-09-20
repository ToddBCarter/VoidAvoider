using System.Collections;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float destroyDistance = 10f;
    [SerializeField] private float shrinkDuration = 1.5f;
    [SerializeField] private float finalScale = 0.05f;
    [SerializeField] private float rotationSpeed = 5f;

    public float Speed
    {
        get => speed;
        set => speed = value;
    }

    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        if (transform.position.x < Camera.main.transform.position.x - destroyDistance)
        {
            StartCoroutine(Shrink());
        }
    }

    private IEnumerator Shrink()
    {
        speed = 1f;

        Vector3 startScale = transform.localScale;
        Vector3 targetScale = new Vector3(finalScale, finalScale, startScale.z);

        float elapsedTime = 0f;

        while (elapsedTime < shrinkDuration)
        {
            float t = elapsedTime / shrinkDuration;
            t = 1f - Mathf.Pow(1f - t, 3);

            transform.localScale = Vector3.Lerp(startScale, targetScale, t);
            transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.localScale = targetScale;
        Destroy(gameObject);
    }
}
