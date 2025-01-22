using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawer : MonoBehaviour
{
    [SerializeField]
    private GameObject PipePrefab;
    [SerializeField]
    private int poolSize = 10;
    private List<GameObject> PipePool; // �� Ǯ ����Ʈ
    private float spawnTimer = 0; // �� ���� Ÿ�̸�

    public float spawnInterval = 0.01f;  //������ ����



    private void Start()
    {
        //��Ǯ �ʱ�ȭ
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

        //���� ���ݿ� ���� �� ����
        if (spawnTimer >= spawnInterval)
        {
            SpawnPipe();
            spawnTimer = 0;
        }
        // ȭ�� ������ ������ �� ��Ȱ��ȭ
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
        // ��� ���� Ȱ��ȭ�Ǿ� �ִٸ� ���ο� �� ����
        GameObject newPipe = Instantiate(PipePrefab);
        newPipe.SetActive(false);
        PipePool.Add(newPipe);
        return newPipe;
    }

    // �� ����//-2.5 4.8
        private void SpawnPipe()
        {
        GameObject Pipe = GetPooledPipe();
        float randomY = Random.Range(-2.5f, 4.8f); // ���� Y��ġ
        Pipe.transform.position = new Vector3(4, randomY, 0);
        Pipe.SetActive(true);

        }
}

