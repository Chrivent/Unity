using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomPlayerEffect : MonoBehaviour
{
    int _BlastTime = 10;

    float blastClock = 0.0f;

    void Update()
    {
        blastClock += Time.deltaTime;

        if (blastClock > 1.0f / (float)_BlastTime)
            Destroy(gameObject);
    }
}
