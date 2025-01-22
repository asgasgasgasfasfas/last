using System.Collections.Generic;
using UnityEngine;

public class EnemyPooling1 : MonoBehaviour
{
    public GameObject enemyPrefab; // 적 프리팹
    public int poolSize = 10; // 초기 풀 크기
    public float spawnInterval = 0.01f; // 적 생성 간격
    public float spawnXRange = 8.0f; // X축 생성 범위ㅊ
    public float spawnYPosition = 6.0f; // Y축 생성 위치 (화면 위)

    private List<GameObject> enemyPool; // 적 풀 리스트
    private float spawnTimer; // 적 생성 타이머

    void Start()
    {
        // 적 풀 초기화
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

        // 스폰 간격에 따라 적 생성
        if (spawnTimer >= spawnInterval)
        {
            SpawnEnemy();
            spawnTimer = 0f;
        }

        // 화면 아래로 내려가거나 X축 -5 이하로 이동한 적을 비활성화
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


    // 비활성화된 적 반환
    private GameObject GetPooledEnemy()
    {
        foreach (GameObject enemy in enemyPool)
        {
            if (!enemy.activeInHierarchy)
            {
                return enemy;
            }
        }

        // 모든 적이 활성화되어 있다면 새로운 적 생성
        GameObject newEnemy = Instantiate(enemyPrefab);
        newEnemy.SetActive(false);
        enemyPool.Add(newEnemy);
        return newEnemy;
    }

    // 적 스폰
    private void SpawnEnemy()
    {
        GameObject enemy = GetPooledEnemy();
        float randomX = Random.Range(-spawnXRange, spawnXRange); // 랜덤 X 위치
        enemy.transform.position = new Vector3(randomX, spawnYPosition, 0);
        enemy.SetActive(true);
    }
}
