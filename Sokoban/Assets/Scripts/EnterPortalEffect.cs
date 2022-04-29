using UnityEngine;

public class EnterPortalEffect : MonoBehaviour
{
    int enterSpeed = 1;
    int rotateSpeed = 500;

    void Update()
    {
        Vector3 pos = transform.localPosition;
        Vector3 sca = transform.localScale;
        Vector3 ang = transform.localEulerAngles;

        pos.y -= enterSpeed * 0.5f * Time.deltaTime;
        sca.x -= enterSpeed * Time.deltaTime;
        sca.y -= enterSpeed * Time.deltaTime;
        ang.z -= rotateSpeed * Time.deltaTime;

        transform.localPosition = pos;
        transform.localScale = sca;
        transform.localEulerAngles = ang;

        if (sca.x <= 0.0f)
            Destroy(gameObject);
    }
}