using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public static PlayerData Instance;
    
    public bool hasKey = false;

    public HashSet<string> openedChests = new HashSet<string>();

    [Header("EXP")]
    public int currentExp = 0;
    public int maxExp = 100;
    public int level = 1;

    [Header("HP")]
    public int currentHP = 100;
    public int maxHP = 100;

    [Header("Scene State")]
    public Vector3 returnPosition;
    public bool hasReturnPosition = false;
    public bool doorUsed = false;

    void Awake()
    {
        // Singleton pattern (persistent across scenes)
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}