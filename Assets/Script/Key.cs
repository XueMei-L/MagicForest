using UnityEngine;

public class Key : MonoBehaviour
{
    public GameObject keyUI;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;

        PlayerData.Instance.hasKey = true;

        if (keyUI != null)
            keyUI.SetActive(true);

        gameObject.SetActive(false);

        Debug.Log("Key collected!");
    }
}