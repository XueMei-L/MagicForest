using UnityEngine;

public class StarCoinPrefab : MonoBehaviour
{
    private ObjectPoolManager poolManager;

    public float speed = 2f;
    public int expValue = 20;

    private float leftEdge;

    public void Init(ObjectPoolManager manager)
    {
        poolManager = manager;
    }
    void Start() {
        // to bringg coin to front of all
        MeshRenderer renderer = GetComponent<MeshRenderer>();
        renderer.sortingLayerName = "Default"; 
        renderer.sortingOrder = 10; 
    }
    void Update()
    {
        if (GameManagerSceneReward.Instance == null) return;

        if (!GameManagerSceneReward.Instance.gameStarted || 
            GameManagerSceneReward.Instance.gameOver)
            return;

        transform.position += Vector3.left * speed * Time.deltaTime;

        UpdateLeftEdge();

        if (transform.position.x < leftEdge)
        {
            poolManager.ReturnToPool(gameObject);
        }
    }
    void UpdateLeftEdge()
    {
        Camera cam = Camera.main;

        float height = cam.orthographicSize;
        float width = height * cam.aspect;

        leftEdge = cam.transform.position.x - width - 2f;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerExperience playerExp = other.GetComponent<PlayerExperience>();

            if (playerExp != null)
            {
                playerExp.AddExp(expValue); // ⭐ 加经验
            }

            poolManager.ReturnToPool(gameObject);
        }
    }
}