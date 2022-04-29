using UnityEngine;

public class CharacterObject : MonoBehaviour
{
    protected GameManager gameManager = GameManager.Instance;

    protected float moveClock = 0.0f;

    protected void Move(Vector3 position)
    {
        transform.localPosition = position;

        moveClock = 0.0f;
    }
}