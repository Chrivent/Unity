using UnityEngine;

public class OpenDoorEffect : MonoBehaviour
{
    int openSpeed = 5;

    void Update()
    {
        Vector3 pos = transform.localPosition;
        Vector3 sca = transform.localScale;

        pos.x -= openSpeed * 0.5f * Time.deltaTime;
        sca.x -= openSpeed * Time.deltaTime;

        transform.localPosition = pos;
        transform.localScale = sca;

        if (sca.x <= 0.0f)
            Destroy(gameObject);
    }
}