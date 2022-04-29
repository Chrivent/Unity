using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] int _DieTime = 2;
    [SerializeField] int _ClearTime = 2;

    [SerializeField] Wall _Wall;
    [SerializeField] Stone _Stone;
    [SerializeField] Sand _Sand;
    [SerializeField] Door _Door;
    [SerializeField] Portal _Portal;
    [SerializeField] Key _Key;
    [SerializeField] Marble _Marble;
    [SerializeField] Rock _Rock;
    [SerializeField] Bomb _Bomb;
    [SerializeField] Scarab _Scarab;
    [SerializeField] Mummy _Mummy;
    [SerializeField] Player _Player;;
    [SerializeField] Flame _Flame;

    [SerializeField] AudioSource _BoomAudio;
    [SerializeField] AudioSource _EnterPortalAudio;

    List<Transform> wall = new List<Transform>();
    List<Transform> stone = new List<Transform>();
    List<Transform> sand = new List<Transform>();
    Transform door;
    Transform portal;
    Transform key;
    List<Transform> marble = new List<Transform>();
    List<Transform> rock = new List<Transform>();
    List<Transform> bomb = new List<Transform>();
    List<Transform> scarab = new List<Transform>();
    List<Transform> mummy = new List<Transform>();
    Transform player;
    List<Transform> flame = new List<Transform>();

    float dieClock = 0.0f;
    float clearClock = 0.0f;
    bool dead = false;
    bool cleared = false;

    static GameManager instance;

    public static GameManager Instance
    {
        get
        {
            return instance;
        }
    }

    void Awake()
    {
        instance = this;
    }

    Transform CreateGameObject(GameObject gameObject, Vector3 position)
    {
        Transform tra = Instantiate(gameObject).transform;

        tra.transform.localPosition = position;
        tra.gameObject.SetActive(true);

        return tra;
    }

    Transform GetTransformByPosition(Transform transform, Vector3 position)
    {
        if (transform != null)
        {
            if (transform.localPosition == position)
                return transform;
        }

        return null;
    }

    Transform GetTransformByPosition(List<Transform> transform, Vector3 position)
    {
        for (int i = 0; i < transform.Count; i++)
        {
            if (transform[i] != null)
            {
                Transform child = transform[i];

                if (child.localPosition == position)
                    return child;
            }
        }

        return null;
    }

    void DestroyGameObject(Transform transform)
    {
        if (transform != null)
            Destroy(transform.gameObject);
    }

    void DestroyGameObject(List<Transform> transform)
    {
        for (int i = 0; i < transform.Count; i++)
        {
            if (transform[i] != null)
                Destroy(transform[i].gameObject);
        }

        transform.Clear();
    }


    public Transform GetWallByPosition(Vector3 position)
    {
        return GetTransformByPosition(wall, position);
    }

    public Transform GetStoneByPosition(Vector3 position)
    {
        return GetTransformByPosition(stone, position);
    }

    public Transform GetSandByPosition(Vector3 position)
    {
        return GetTransformByPosition(sand, position);
    }

    public Transform GetDoorByPosition(Vector3 position)
    {
        return GetTransformByPosition(door, position);
    }

    public Transform GetPortalByPosition(Vector3 position)
    {
        return GetTransformByPosition(portal, position);
    }

    public Transform GetKeyByPosition(Vector3 position)
    {
        return GetTransformByPosition(key, position);
    }

    public Transform GetMarbleByPosition(Vector3 position)
    {
        return GetTransformByPosition(marble, position);
    }

    public Transform GetRockByPosition(Vector3 position)
    {
        return GetTransformByPosition(rock, position);
    }

    public Transform GetBombByPosition(Vector3 position)
    {
        return GetTransformByPosition(bomb, position);
    }

    public Transform GetScarabByPosition(Vector3 position)
    {
        return GetTransformByPosition(scarab, position);
    }

    public Transform GetMummyByPosition(Vector3 position)
    {
        return GetTransformByPosition(mummy, position);
    }

    public Transform GetPlayerByPosition(Vector3 position)
    {
        return GetTransformByPosition(player, position);
    }

    public Transform GetDoor()
    {
        return door;
    }

    public Transform GetKey()
    {
        return key;
    }

    public Transform GetPlayer()
    {
        return player;
    }

    public bool CheckTransformIsExistByPosition(Vector3 position)
    {
        if (GetWallByPosition(position) != null)
            return true;

        if (GetStoneByPosition(position) != null)
            return true;

        if (GetSandByPosition(position) != null)
            return true;

        if (GetDoorByPosition(position) != null)
            return true;

        if (GetPortalByPosition(position) != null)
            return true;

        if (GetKeyByPosition(position) != null)
            return true;

        if (GetMarbleByPosition(position) != null)
            return true;

        if (GetRockByPosition(position) != null)
            return true;

        if (GetBombByPosition(position) != null)
            return true;

        if (GetScarabByPosition(position) != null)
            return true;

        if (GetMummyByPosition(position) != null)
            return true;

        if (GetPlayerByPosition(position) != null)
            return true;

        return false;
    }

    int GetMarbleCount()
    {
        int count = 0;

        for (int i = 0; i < marble.Count; i++)
        {
            if (marble[i] != null)
                count++;
        }

        return count;
    }

    public void LoadMap()
    {
        DestroyGameObject(wall);
        DestroyGameObject(stone);
        DestroyGameObject(sand);
        DestroyGameObject(door);
        DestroyGameObject(portal);
        DestroyGameObject(key);
        DestroyGameObject(marble);
        DestroyGameObject(rock);
        DestroyGameObject(bomb);
        DestroyGameObject(scarab);
        DestroyGameObject(mummy);
        DestroyGameObject(player);
        DestroyGameObject(flame);

        TextAsset file = Resources.Load<TextAsset>("MapData/lv" + PlayerPrefs.GetInt("SelectLevel").ToString());

        if (file != null)
        {
            int lineCount = 0;
            string[] lines = file.text.Split('\n');

            foreach (string line in lines)
            {
                string[] word = line.Split(' ');

                for (int i = 0; i < word.Length; i++)
                {
                    Vector3 pos = new Vector3(i % 18, -lineCount, 0.0f);

                    if (word[i] == "01")
                        wall.Add(CreateGameObject(_Wall.gameObject, pos));
                    else if (word[i] == "02")
                        stone.Add(CreateGameObject(_Stone.gameObject, pos));
                    else if (word[i] == "03")
                        sand.Add(CreateGameObject(_Sand.gameObject, pos));
                    else if (word[i] == "04")
                        door = CreateGameObject(_Door.gameObject, pos);
                    else if (word[i] == "05")
                        portal = CreateGameObject(_Portal.gameObject, pos);
                    else if (word[i] == "06")
                        key = CreateGameObject(_Key.gameObject, pos);
                    else if (word[i] == "07")
                        marble.Add(CreateGameObject(_Marble.gameObject, pos));
                    else if (word[i] == "08")
                        rock.Add(CreateGameObject(_Rock.gameObject, pos));
                    else if (word[i] == "09")
                        bomb.Add(CreateGameObject(_Bomb.gameObject, pos));
                    else if (word[i] == "10")
                        scarab.Add(CreateGameObject(_Scarab.gameObject, pos));
                    else if (word[i] == "11")
                        mummy.Add(CreateGameObject(_Mummy.gameObject, pos));
                    else if (word[i] == "12")
                        player = CreateGameObject(_Player.gameObject, pos);
                }

                lineCount++;
            }

            if (portal != null)
                portal.GetComponent<Portal>().SetMarbleCount(GetMarbleCount());
        }
        else
            SceneManager.LoadScene("MainMenu");
    }

    public void DIeEvent()
    {
        if (player != null)
        {
            player.GetComponent<Player>().Die();

            dead = true;
        }
    }

    public void Boom(Transform transform, Vector3 position)
    {
        _BoomAudio.Play();

        Destroy(transform.gameObject);

        for (int x = -1; x <= 1; x++)
        {
            for (int y = -1; y <= 1; y++)
            {
                Vector3 flamePos = position;

                flamePos.x += x;
                flamePos.y += y;

                flame.Add(CreateGameObject(_Flame.gameObject, flamePos));
            }
        }
    }

    public void EnterPortalEvent()
    {
        _EnterPortalAudio.Play();

        cleared = true;
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    void Start()
    {
        LoadMap();
    }

    void Update()
    {
        if (dead == true)
        {
            dieClock += Time.deltaTime;

            if (dieClock > _DieTime)
            {
                LoadMap();

                dieClock = 0.0f;

                dead = false;
            }
        }

        if (cleared == true)
        {
            clearClock += Time.deltaTime;

            if (clearClock > _ClearTime)
            {
                int level = PlayerPrefs.GetInt("SelectLevel");

                level++;

                PlayerPrefs.SetInt("SelectLevel", level);

                if (level > PlayerPrefs.GetInt("SaveLevel"))
                    PlayerPrefs.SetInt("SaveLevel", level);

                LoadMap();

                clearClock = 0.0f;

                cleared = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
            DIeEvent();

        if (Input.GetKeyDown(KeyCode.Escape))
            GoToMainMenu();
    }
}