using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scarab : CharacterObject
{
    int _MoveSpeed = 3;

    char direction = 'U';
    bool canMove = false;
    bool checkedForward = false;
    bool blocked = true;

    void RotateDirection()
    {
        if (direction == 'U')
            direction = 'R';
        else if (direction == 'R')
            direction = 'D';
        else if (direction == 'D')
            direction = 'L';
        else
            direction = 'U';
    }

    void RotateDirectionRevert()
    {
        if (direction == 'U')
            direction = 'L';
        else if (direction == 'L')
            direction = 'D';
        else if (direction == 'D')
            direction = 'R';
        else
            direction = 'U';
    }

    void MoveAndCheck(Vector3 position)
    {
        Move(position);

        Vector3 diagonalPos = position;

        switch (direction)
        {
            case 'L':
                diagonalPos.y++;
                break;

            case 'R':
                diagonalPos.y--;
                break;

            case 'U':
                diagonalPos.x++;
                break;

            case 'D':
                diagonalPos.x--;
                break;
        }

        if (gameManager.CheckTransformIsExistByPosition(diagonalPos) == false)
            RotateDirection();
        else if (gameManager.GetPlayerByPosition(diagonalPos) != null)
            RotateDirection();
    }

    void Update()
    {
        if (gameManager != null)
        {
            moveClock += Time.deltaTime;

            Vector3 forwardPos = transform.localPosition;

            switch (direction)
            {
                case 'L':
                    forwardPos.x--;
                    break;

                case 'R':
                    forwardPos.x++;
                    break;

                case 'U':
                    forwardPos.y++;
                    break;

                case 'D':
                    forwardPos.y--;
                    break;
            }

            Transform player = gameManager.GetPlayerByPosition(forwardPos);

            if (canMove == true)
            {
                if (moveClock > 1.0f / (float)_MoveSpeed)
                {
                    if (gameManager.CheckTransformIsExistByPosition(forwardPos) == false)
                        MoveAndCheck(forwardPos);
                    else if (player != null)
                        gameManager.Boom(transform, player.localPosition);
                    else
                    {
                        RotateDirectionRevert();

                        moveClock = 0.0f;
                    }
                }
            }
            else
            {
                if (checkedForward == false)
                {
                    if (gameManager.CheckTransformIsExistByPosition(forwardPos) == false)
                        blocked = false;
                    else if (player != null)
                        blocked = false;

                    checkedForward = true;
                }
                else
                {
                    if (blocked == true)
                    {
                        if (gameManager.CheckTransformIsExistByPosition(forwardPos) == false)
                            canMove = true;
                        else if (player != null)
                            canMove = true;
                        else
                            RotateDirectionRevert();
                    }
                    else
                    {
                        if (gameManager.CheckTransformIsExistByPosition(forwardPos) == false)
                            RotateDirection();
                        else if (player != null)
                            RotateDirection();
                        else
                        {
                            RotateDirectionRevert();

                            canMove = true;
                        }
                    }
                }
            }
        }
    }
}
