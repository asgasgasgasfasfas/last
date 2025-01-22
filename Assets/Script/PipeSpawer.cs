using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawer : MonoBehaviour
{
    [SerializeField]
    private GameObject PipePrefab;
    [SerializeField]
    private int poolSize = 10;
    private List<GameObject> PipePool; // 적 풀 리스트
    private float spawnTimer = 0; // 적 생성 타이머

    public float spawnInterval = 0.01f;  //적생성 간격



    private void Start()
    {
        //적풀 초기화
        PipePool = new List<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject Pipe = Instantiate(PipePrefab);
            Pipe.SetActive(false);
            PipePool.Add(Pipe);
        }

    }
    // Update is called once per frame
    void Update()
    {
        spawnTimer += Time.deltaTime;

        //스폰 간격에 따라 적 생성
        if (spawnTimer >= spawnInterval)
        {
            SpawnPipe();
            spawnTimer = 0;
        }
        // 화명 밖으로 내려간 적 비활성화
        foreach (GameObject Pipe in PipePool)
        {
            if (Pipe.activeInHierarchy)
            {
                if (Pipe.transform.position.x < -5.0f)
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
        // 모든 적이 활성화되어 있다면 새로운 적 생성
        GameObject newPipe = Instantiate(PipePrefab);
        newPipe.SetActive(false);
        PipePool.Add(newPipe);
        return newPipe;
    }

    // 적 스폰//-2.5 4.8
        private void SpawnPipe()
        {
        GameObject Pipe = GetPooledPipe();
        float randomY = Random.Range(-2.5f, 4.8f); // 랜덤 Y위치
        Pipe.transform.position = new Vector3(4, randomY, 0);
        Pipe.SetActive(true);

        }
}

