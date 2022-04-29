using UnityEngine;

public class Mummy : CharacterObject
{
    int _MoveSpeed = 3;

    char direction = 'W';

    void Update()
    {
        if (gameManager != null)
        {
            moveClock += Time.deltaTime;

            if (moveClock > 1.0f / (float)_MoveSpeed)
            {
                Transform player = gameManager.GetPlayer();

                if (player != null)
                {
                    Vector3 mummyMovePos = transform.localPosition;
                    Vector3 playerPos = player.localPosition;

                    switch (direction)
                    {
                        case 'W':
                            if (playerPos.x > mummyMovePos.x)
                                mummyMovePos.x++;
                            else if (playerPos.x < mummyMovePos.x)
                                mummyMovePos.x--;

                            direction = 'H';
                            break;

                        case 'H':
                            if (playerPos.y > mummyMovePos.y)
                                mummyMovePos.y++;
                            else if (playerPos.y < mummyMovePos.y)
                                mummyMovePos.y--;

                            direction = 'W';
                            break;
                    }

                    if (gameManager.CheckTransformIsExistByPosition(mummyMovePos) == false)
                        Move(mummyMovePos);
                    else if (player.localPosition == mummyMovePos)
                        gameManager.Boom(transform, playerPos);
                }
            }
        }
    }
}