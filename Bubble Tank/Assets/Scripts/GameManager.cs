using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
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

    [SerializeField] Player _Player;

    Transform player;

    void Start()
    {
        player = _Player.transform;
    }

    Transform GetPlayer()
    {
        return player;
    }
}
