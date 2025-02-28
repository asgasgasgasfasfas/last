using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject PipePrefab;
    [SerializeField]
    private Transform panelTransform; // �г��� Transform�� ������
    [SerializeField]
    private int poolSize = 10;

    private List<GameObject> PipePool;
    private float spawnTimer = 0;
    public float spawnInterval = 1.0f;
    private bool isSpawning = false; // ������ ���� ����

    private void Start()
    {
        PipePool = new List<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject Pipe = Instantiate(PipePrefab, panelTransform); // �θ� ����
            Pipe.SetActive(false);
            PipePool.Add(Pipe);
        }
    }

    public void StartSpawning() // �ܺο��� ȣ�� �����ϵ��� public �޼��� �߰�
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
                if (Pipe.transform.localPosition.x < -355.0f) // ����� �κ�
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

        GameObject newPipe = Instantiate(PipePrefab, panelTransform); // �θ� ����
        newPipe.SetActive(false);
        PipePool.Add(newPipe);
        return newPipe;
    }

    private void SpawnPipe()
    {
        GameObject Pipe = GetPooledPipe();
        float randomY = Random.Range(-500f, 725f);

        // �г� ������ ���� ���������� ����
        Pipe.transform.localPosition = new Vector3(1008f, randomY, 0); // ����� �κ�
        Pipe.SetActive(true);
    }
}
