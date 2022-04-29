using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marble : FallingObject
{
    [SerializeField] AudioSource _FallMarble;

    void Update()
    {
        if (gameManager != null)
        {
            fallClock += Time.deltaTime;

            if (CheckCanFall() == true)
            {
                Vector3 marbleDownPos = transform.localPosition;

                marbleDownPos.y--;

                Transform portal = gameManager.GetPortalByPosition(marbleDownPos);
                Transform bomb = gameManager.GetBombByPosition(marbleDownPos);
                Transform scarab = gameManager.GetScarabByPosition(marbleDownPos);
                Transform mummy = gameManager.GetMummyByPosition(marbleDownPos);
                Transform player = gameManager.GetPlayerByPosition(marbleDownPos);

                if (gameManager.CheckTransformIsExistByPosition(marbleDownPos) == false)
                    falling = true;
                else if (portal != null)
                {
                    portal.GetComponent<Portal>().InsertMarble();

                    Destroy(gameObject);
                }
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
                        _FallMarble.Play();

                    falling = false;
                }

                if (falling == true)
                    Fall();
            }
        }
    }
}
