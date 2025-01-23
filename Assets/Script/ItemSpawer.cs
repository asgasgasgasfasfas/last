using System.Collections.Generic;
using UnityEngine;

public class ItemSpawer : MonoBehaviour
{
    [SerializeField]
    private GameObject[] itmePrb; // ������ ������ �迭

    private int probability;

    private int poolSize = 2; // Ǯ ũ��
    private List<GameObject> itemPool; // ������ Ǯ
    private float spawnTimer = 0f;

    public float spawnInterval = 5f;

    void Start()
    {
        // ������ Ǯ �ʱ�ȭ
        itemPool = new List<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            foreach (GameObject prefab in itmePrb)
            {
                GameObject item = Instantiate(prefab); // ������ ����
                item.SetActive(false); // �ʱ⿡�� ��Ȱ��ȭ
                itemPool.Add(item); // Ǯ�� �߰�
            }
        }
    }

    void Update()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= spawnInterval)
        {
            spawnTimer = 0f;

            // 60%: 0�� ������, 30%: 1�� ������, 10%: 2�� ������
            probability = Random.Range(0, 101);
            int result = probability < 60 ? 0 : (probability < 90 ? 1 : 2);

            // Ǯ���� ��Ȱ��ȭ�� ������Ʈ ã��
            GameObject item = GetInactiveItem(result);
            if (item != null)
            {
                item.transform.position = transform.position; // ���� ��ġ ����
                item.SetActive(true); // Ȱ��ȭ
                Debug.Log("������" + result);
            }
        }
    }

    private GameObject GetInactiveItem(int prefabIndex)
    {
        // ������ ������ �ε����� ��ġ�ϴ� ��Ȱ��ȭ�� ������Ʈ ��ȯ
        foreach (GameObject item in itemPool)
        {
            if (!item.activeInHierarchy && item.name.StartsWith(itmePrb[prefabIndex].name))
            {
                return item;
                Debug.Log("������" + prefabIndex);
            }
        }
        return null; // ��� ������ ������Ʈ�� ������ null ��ȯ
    }




}
