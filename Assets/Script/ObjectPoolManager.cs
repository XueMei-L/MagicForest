using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject starCoinPrefab;
    public int maxCoins = 5;
    public Transform coinsParent;

    private Queue<GameObject> pool = new Queue<GameObject>();
    private List<GameObject> activeCoins = new List<GameObject>();

    private Camera cam;

    void Start()
    {
        cam = Camera.main;

        for (int i = 0; i < maxCoins * 2; i++)
        {
            GameObject coin = Instantiate(starCoinPrefab, coinsParent);
            coin.GetComponent<StarCoinPrefab>().Init(this);
            coin.SetActive(false);
            pool.Enqueue(coin);
        }

        for (int i = 0; i < maxCoins; i++)
        {
            SpawnCoin();
        }
    }

    void Update()
    {
        if (GameManagerSceneReward.Instance == null) return;

        if (!GameManagerSceneReward.Instance.gameStarted || 
            GameManagerSceneReward.Instance.gameOver)
            return;

        while (activeCoins.Count < maxCoins)
        {
            SpawnCoin();
        }
    }

    public void SpawnCoin()
    {
        GameObject coin = pool.Count > 0 ? pool.Dequeue() : Instantiate(starCoinPrefab, coinsParent);

        coin.GetComponent<StarCoinPrefab>().Init(this);

        coin.transform.position = GetRandomCameraPosition();
        coin.SetActive(true);

        activeCoins.Add(coin);
    }

    public void ReturnToPool(GameObject coin)
    {
        if (!activeCoins.Contains(coin)) return;

        activeCoins.Remove(coin);
        coin.SetActive(false);
        pool.Enqueue(coin);
    }

    Vector3 GetRandomCameraPosition()
    {
        Camera cam = Camera.main;

        float height = cam.orthographicSize;
        float width = height * cam.aspect;

        float camX = cam.transform.position.x;
        float camY = cam.transform.position.y;

        float minY = camY - height + 5;
        float maxY = camY;

        float x = camX + Random.Range(-width, width);
        float y = Random.Range(minY, maxY);

        return new Vector3(x, y, 0);
    }
}