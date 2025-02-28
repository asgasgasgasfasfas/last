using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject PipePrefab;
    [SerializeField]
    private Transform panelTransform; // 패널의 Transform을 가져옴
    [SerializeField]
    private int poolSize = 10;

    private List<GameObject> PipePool;
    private float spawnTimer = 0;
    public float spawnInterval = 1.0f;
    private bool isSpawning = false; // 파이프 생성 여부

    private void Start()
    {
        PipePool = new List<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject Pipe = Instantiate(PipePrefab, panelTransform); // 부모 설정
            Pipe.SetActive(false);
            PipePool.Add(Pipe);
        }
    }

    public void StartSpawning() // 외부에서 호출 가능하도록 public 메서드 추가
    {
        isSpawning = true;
    }

    void Update()
    {
        if (!isSpawning) return;
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnInterval)
        {
            SpawnPipe();
            spawnTimer = 0;
        }

        foreach (GameObject Pipe in PipePool)
        {
            if (Pipe.activeInHierarchy)
            {
                if (Pipe.transform.localPosition.x < -355.0f) // 변경된 부분
                {
                    Pipe.SetActive(false);
                }
            }
        }
    }

    private GameObject GetPooledPipe()
    {
        foreach (GameObject Pipe in PipePool)
        {
            if (!Pipe.activeInHierarchy)
            {
                return Pipe;
            }
        }

        GameObject newPipe = Instantiate(PipePrefab, panelTransform); // 부모 설정
        newPipe.SetActive(false);
        PipePool.Add(newPipe);
        return newPipe;
    }

    private void SpawnPipe()
    {
        GameObject Pipe = GetPooledPipe();
        float randomY = Random.Range(-500f, 725f);

        // 패널 내부의 로컬 포지션으로 설정
        Pipe.transform.localPosition = new Vector3(1008f, randomY, 0); // 변경된 부분
        Pipe.SetActive(true);
    }
}
