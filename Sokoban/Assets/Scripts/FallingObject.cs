using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObject : MonoBehaviour
{
    protected GameManager gameManager = GameManager.Instance;

    protected int _FallSpeed = 5;

    protected float fallClock = 0.0f;
    protected bool falling = false;

    protected float delay = 0.02f;

    public bool CheckFalling()
    {
        return falling;
    }

    protected bool CheckCanFall()
    {
        return fallClock > 1.0f / ((float)_FallSpeed - transform.position.y * _FallSpeed * delay);
    }

    protected void Fall()
    {
        Vector3 fallPos = transform.localPosition;

        fallPos.y--;

        transform.localPosition = fallPos;

        fallClock = 0.0f;
    }
}
