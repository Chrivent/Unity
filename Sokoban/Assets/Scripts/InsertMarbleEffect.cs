using UnityEngine;

public class InsertMarbleEffect : MonoBehaviour
{
    int insertSpeed = 10;
    float narrowRate = 0.2f;

    Vector3 downPosition;

    void Start()
    {
        downPosition = transform.localPosition;

        downPosition.y--;
    }

    void Update()
    {
        Vector3 pos = transform.localPosition;
        Vector3 sca = transform.localScale;

        pos.y -= insertSpeed * Time.deltaTime;
        sca.x -= insertSpeed * narrowRate * Time.deltaTime;

        transform.localPosition = pos;
        transform.localScale = sca;

        if (transform.localPosition.y <= downPosition.y)
            Destroy(gameObject);
    }
}