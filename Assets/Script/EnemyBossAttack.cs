using UnityEngine;
using System.Collections;

public class EnemyBossAttack : MonoBehaviour
{
    public GameObject mushroomPrefab;


    public float attackInterval = 2f;


    private bool isAttacking = true;

    void Start()
    {
        StartCoroutine(AttackLoop());
    }

    IEnumerator AttackLoop()
    {
        while (isAttacking)
        {
            yield return new WaitForSeconds(attackInterval);

            SpawnMushroom();
        }
    }

    void SpawnMushroom()
    {
        if (mushroomPrefab == null) return;

        Vector3 basePos = transform.position;

        float leftOffsetX = -3f;

        float[] yOffsets = { -1f, -0.5f};

        float randomY = yOffsets[Random.Range(0, yOffsets.Length)];

        Vector3 spawnPos = new Vector3(
            basePos.x + leftOffsetX,
            basePos.y + randomY,
            basePos.z
        );

        Instantiate(mushroomPrefab, spawnPos, Quaternion.identity);
    }

    public void StopAttack()
    {
        isAttacking = false;
    }
}