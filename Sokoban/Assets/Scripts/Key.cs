using UnityEngine;

public class Key : FallingObject
{
    [SerializeField] AudioSource _FallKey;

    void Update()
    {
        if (gameManager != null)
        {
            fallClock += Time.deltaTime;

            if (CheckCanFall() == true)
            {
                Vector3 keyDownPos = transform.position;

                keyDownPos.y--;

                Transform player = gameManager.GetPlayerByPosition(keyDownPos);

                if (gameManager.CheckTransformIsExistByPosition(keyDownPos) == false)
                    falling = true;
                else if (player != null)
                {
                    Transform door = gameManager.GetDoor();

                    if (door != null)
                    {
                        door.GetComponent<Door>().Open();

                        Destroy(gameObject);
                    }
                }
                else
                {
                    if (falling == true)
                        _FallKey.Play();

                    falling = false;
                }

                if (falling == true)
                    Fall();
            }
        }
    }
}