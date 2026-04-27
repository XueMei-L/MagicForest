using UnityEngine;

public class Chest : MonoBehaviour
{
    private Animator animator;
    public GameObject keyObject;
    private bool isOpened = false;

    [Header("ID (must be unique)")]
    public string chestID;

    void Start()
    {
        animator = GetComponent<Animator>();
        
        // check the box is opened
        if (PlayerData.Instance.openedChests.Contains(chestID))
        {
            isOpened = true;

            // 直接设置为打开状态
            animator.Play("OpenChest", 0, 1f); // 跳到动画结尾
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isOpened) return;

        if (collision.CompareTag("Player"))
        {
            OpenChest();
        }
    }

    void OpenChest()
    {
        isOpened = true;

        // play animation
        animator.SetTrigger("Open");

        PlayerData.Instance.openedChests.Add(chestID);

        Debug.Log("Chest opened: " + chestID);
    }

    public void SpawnKey()
    {
        if (keyObject != null)
        {
            keyObject.SetActive(true);
        }
    }
}