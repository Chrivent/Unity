using UnityEngine;

public class Flame : MonoBehaviour
{
    GameManager gameManager = GameManager.Instance;

    int _BlastTime = 15;

    float blastClock = 0.0f;
    bool sweeped = false;

    void Update()
    {
        if (gameManager != null)
        {
            if (sweeped == false)
            {
                Vector3 flamePos = transform.position;

                Transform stone = gameManager.GetStoneByPosition(flamePos);
                Transform sand = gameManager.GetSandByPosition(flamePos);
                Transform key = gameManager.GetKeyByPosition(flamePos);
                Transform marble = gameManager.GetMarbleByPosition(flamePos);
                Transform rock = gameManager.GetRockByPosition(flamePos);
                Transform bomb = gameManager.GetBombByPosition(flamePos);
                Transform scarab = gameManager.GetScarabByPosition(flamePos);
                Transform mummy = gameManager.GetMummyByPosition(flamePos);
                Transform player = gameManager.GetPlayerByPosition(flamePos);

                if (stone != null)
                    Destroy(stone.gameObject);
                else if (sand != null)
                    Destroy(sand.gameObject);
                else if (key != null)
                    Destroy(key.gameObject);
                else if (marble != null)
                    Destroy(marble.gameObject);
                else if (rock != null)
                    Destroy(rock.gameObject);
                else if (bomb != null)
                    gameManager.Boom(bomb, flamePos);
                else if (scarab != null)
                    gameManager.Boom(scarab, flamePos);
                else if (mummy != null)
                    gameManager.Boom(mummy, flamePos);
                else if (player != null)
                    gameManager.DIeEvent();

                sweeped = true;
            }

            blastClock += Time.deltaTime;

            if (blastClock > 1.0f / (float)_BlastTime)
                Destroy(gameObject);
        }
    }
}