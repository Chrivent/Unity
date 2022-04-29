using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillPortalEffect : MonoBehaviour
{
    int rotateSpeed = 100;

    void Update()
    {
        Vector3 ang = transform.localEulerAngles;

        ang.z -= rotateSpeed * Time.deltaTime;

        transform.localEulerAngles = ang;
    }
}
