using System.Collections.Generic;
using UnityEngine;

public class EnemyPooling1 : MonoBehaviour
{
    public GameObject enemyPrefab; // �� ������
    public int poolSize = 10; // �ʱ� Ǯ ũ��
    public float spawnInterval = 0.01f; // �� ���� ����
    public float spawnXRange = 8.0f; // X�� ���� ������
    public float spawnYPosition = 6.0f; // Y�� ���� ��ġ (ȭ�� ��)

    private List<GameObject> enemyPool; // �� Ǯ ����Ʈ
    private float spawnTimer; // �� ���� Ÿ�̸�

    void Start()
    {
        // �� Ǯ �ʱ�ȭ
        enemyPool = new List<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject enemy = Instantiate(enemyPrefab);
            enemy.SetActive(false);
            enemyPool.Add(enemy);
        }
    }

    void Update()
    {
        spawnTimer += Time.deltaTime;

        // ���� ���ݿ� ���� �� ����
        if (spawnTimer >= spawnInterval)
        {
            SpawnEnemy();
            spawnTimer = 0f;
        }

        // ȭ�� �Ʒ��� �������ų� X�� -5 ���Ϸ� �̵��� ���� ��Ȱ��ȭ
        foreach (GameObject enemy in enemyPool)
        {
            if (enemy.activeInHierarchy)
            {
                if (enemy.transform.position.y < -6.0f || enemy.transform.position.x < -5.0f)
                {
                    enemy.SetActive(false);
                }
            }
        }
    }


    // ��Ȱ��ȭ�� �� ��ȯ
    private GameObject GetPooledEnemy()
    {
        foreach (GameObject enemy in enemyPool)
        {
            if (!enemy.activeInHierarchy)
            {
                return enemy;
            }
        }

        // ��� ���� Ȱ��ȭ�Ǿ� �ִٸ� ���ο� �� ����
        GameObject newEnemy = Instantiate(enemyPrefab);
        newEnemy.SetActive(false);
        enemyPool.Add(newEnemy);
        return newEnemy;
    }

    // �� ����
    private void SpawnEnemy()
    {
        GameObject enemy = GetPooledEnemy();
        float randomX = Random.Range(-spawnXRange, spawnXRange); // ���� X ��ġ
        enemy.transform.position = new Vector3(randomX, spawnYPosition, 0);
        enemy.SetActive(true);
    }
}
