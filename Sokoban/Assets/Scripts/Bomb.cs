using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : FallingObject
{
    void Update()
    {
        if (gameManager != null)
        {
            fallClock += Time.deltaTime;

            if (CheckCanFall() == true)
            {
                Vector3 bombDownPos = transform.localPosition;

                bombDownPos.y--;

                Transform scarab = gameManager.GetScarabByPosition(bombDownPos);
                Transform mummy = gameManager.GetMummyByPosition(bombDownPos);

                if (gameManager.CheckTransformIsExistByPosition(bombDownPos) == false)
                    falling = true;
                else if (scarab != null)
                    gameManager.Boom(transform, bombDownPos);
                else if (mummy != null)
                    gameManager.Boom(transform, bombDownPos);
                else if (falling == true)
                    gameManager.Boom(transform, transform.localPosition);

                if (falling == true)
                    Fall();
            }
        }
    }
}
