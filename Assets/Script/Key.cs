using UnityEngine;

public class Key : MonoBehaviour
{
    public GameObject keyUI;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;

        // ⭐ 玩家获得钥匙
        PlayerData.Instance.hasKey = true;

        // ⭐ UI显示
        if (keyUI != null)
            keyUI.SetActive(true);

        // ⭐ 隐藏钥匙
        gameObject.SetActive(false);

        Debug.Log("Key collected!");
    }
}