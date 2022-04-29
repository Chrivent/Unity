using UnityEngine;

public class Rock : FallingObject
{
    [SerializeField] AudioSource _FallRock;

    void Update()
    {
        if (gameManager != null)
        {
            fallClock += Time.deltaTime;

            if (CheckCanFall() == true)
            {
                Vector3 rockDownPos = transform.localPosition;

                rockDownPos.y--;

                Transform bomb = gameManager.GetBombByPosition(rockDownPos);
                Transform scarab = gameManager.GetScarabByPosition(rockDownPos);
                Transform mummy = gameManager.GetMummyByPosition(rockDownPos);
                Transform player = gameManager.GetPlayerByPosition(rockDownPos);

                if (gameManager.CheckTransformIsExistByPosition(rockDownPos) == false)
                    falling = true;
                else if (bomb != null && falling == true)
                    gameManager.Boom(transform, transform.localPosition);
                else if (scarab != null && falling == true)
                    gameManager.Boom(transform, scarab.localPosition);
                else if (mummy != null && falling == true)
                    gameManager.Boom(transform, mummy.localPosition);
                else if (player != null && falling == true)
                    gameManager.Boom(transform, transform.localPosition);
                else
                {
                    if (falling == true)
                        _FallRock.Play();

                    falling = false;
                }

                if (falling == true)
                    Fall();
            }
        }
    }
}