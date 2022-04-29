using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : CharacterObject
{
    [SerializeField] AudioSource _WalkAudio;
    [SerializeField] AudioSource _PushAudio;
    [SerializeField] AudioSource _DieAudio;

    [SerializeField] BoomPlayerEffect _BoomPlayerEffect;
    [SerializeField] EnterPortalEffect _EnterPortalEffect;

    int _MoveSpeed = 15;

    public void Die()
    {
        _DieAudio.Play();

        Transform boomPlayerEffect = Instantiate<GameObject>(_BoomPlayerEffect.gameObject).transform;

        boomPlayerEffect.localPosition = transform.localPosition;
        boomPlayerEffect.gameObject.SetActive(true);

        Destroy(gameObject);
    }

    char GetDirection()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
            return 'L';

        if (Input.GetKey(KeyCode.RightArrow))
            return 'R';

        if (Input.GetKey(KeyCode.UpArrow))
            return 'U';

        if (Input.GetKey(KeyCode.DownArrow))
            return 'D';

        return 'S';
    }

    void Update()
    {
        if (gameManager != null)
        {
            char direction = GetDirection();

            moveClock += Time.deltaTime;

            if (moveClock > 1.0f / (float)_MoveSpeed)
            {
                Vector3 playerMovePos = transform.localPosition;

                switch (direction)
                {
                    case 'L':
                        playerMovePos.x--;
                        break;

                    case 'R':
                        playerMovePos.x++;
                        break;

                    case 'U':
                        playerMovePos.y++;
                        break;

                    case 'D':
                        playerMovePos.y--;
                        break;
                }

                Transform sand = gameManager.GetSandByPosition(playerMovePos);
                Transform key = gameManager.GetKeyByPosition(playerMovePos);
                Transform scarab = gameManager.GetScarabByPosition(playerMovePos);
                Transform mummy = gameManager.GetMummyByPosition(playerMovePos);

                if (gameManager.CheckTransformIsExistByPosition(playerMovePos) == false)
                {
                    _WalkAudio.Play();

                    Move(playerMovePos);
                }
                else if (sand != null)
                {
                    _WalkAudio.Play();

                    Destroy(sand.gameObject);
                    Move(playerMovePos);
                }
                else if (key != null)
                {
                    Transform door = gameManager.GetDoor();

                    if (door != null)
                    {
                        door.GetComponent<Door>().Open();

                        Destroy(key.gameObject);

                        Move(playerMovePos);
                    }
                }
                else if (scarab != null)
                    gameManager.Boom(scarab, playerMovePos);
                else if (mummy != null)
                    gameManager.Boom(mummy, playerMovePos);
                else
                {
                    Vector3 beyondPos = playerMovePos;

                    switch (direction)
                    {
                        case 'L':
                            beyondPos.x--;
                            break;

                        case 'R':
                            beyondPos.x++;
                            break;
                    }

                    if (gameManager.CheckTransformIsExistByPosition(beyondPos) == false)
                    {
                        Transform pushMarble = gameManager.GetMarbleByPosition(playerMovePos);
                        Transform pushRock = gameManager.GetRockByPosition(playerMovePos);
                        Transform pushBomb = gameManager.GetBombByPosition(playerMovePos);

                        if (pushMarble != null && pushMarble.localPosition.y == transform.localPosition.y)
                        {
                            _PushAudio.Play();

                            pushMarble.localPosition = beyondPos;

                            Move(playerMovePos);
                        }
                        else if (pushRock != null && pushRock.localPosition.y == transform.localPosition.y)
                        {
                            _PushAudio.Play();

                            pushRock.localPosition = beyondPos;

                            Move(playerMovePos);
                        }
                        else if (pushBomb != null && pushBomb.localPosition.y == transform.localPosition.y)
                        {
                            _PushAudio.Play();

                            pushBomb.localPosition = beyondPos;

                            Move(playerMovePos);
                        }
                    }
                }
            }

            Vector3 playerDownPos = transform.localPosition;

            playerDownPos.y--;

            Transform portal = gameManager.GetPortalByPosition(playerDownPos);

            if (portal != null)
            {
                if (portal.GetComponent<Portal>().CheckFill() == true)
                {
                    gameManager.EnterPortalEvent();

                    Transform enterPortalEffect = Instantiate<GameObject>(_EnterPortalEffect.gameObject).transform;

                    enterPortalEffect.localPosition = transform.localPosition;
                    enterPortalEffect.gameObject.SetActive(true);

                    Destroy(gameObject);
                }
            }
        }
    }
}