using System.Collections.Generic;
using UnityEngine;

public class ITemSpawer1 : MonoBehaviour
{
    [SerializeField]
    private GameObject[] itmePrb; // 아이템 프리팹 배열

    private int probability;

    private int poolSize = 2; // 풀 크기
    private List<GameObject> itemPool; // 아이템 풀
    private float spawnTimer = 0f;

    public float spawnInterval = 5f;

    void Start()
    {
        // 아이템 풀 초기화
        itemPool = new List<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            foreach (GameObject prefab in itmePrb)
            {
                GameObject item = Instantiate(prefab); // 프리팹 복사
                item.SetActive(false); // 초기에는 비활성화
                itemPool.Add(item); // 풀에 추가
            }
        }

        Debug.Log($"풀 초기화: 총 {poolSize * itmePrb.Length}개의 오브젝트 생성");
    }

    void Update()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= spawnInterval)
        {
            spawnTimer = 0f;

            // 60%: 0번 프리팹, 30%: 1번 프리팹, 10%: 2번 프리팹
            probability = Random.Range(0, 101);
            int result = probability < 60 ? 0 : (probability < 90 ? 1 : 2);

            // 풀에서 비활성화된 오브젝트 찾기
            GameObject item = GetInactiveItem(result);
            if (item != null)
            {
                item.transform.position = transform.position; // 생성 위치 설정
                item.SetActive(true); // 활성화
                Debug.Log($"아이템 활성화: {result}");
            }
        }
    }

    private GameObject GetInactiveItem(int prefabIndex)
    {
        foreach (GameObject item in itemPool)
        {
            if (!item.activeInHierarchy && item.name.StartsWith(itmePrb[prefabIndex].name))
            {
                Debug.Log("재사용: " + prefabIndex);
                return item;
            }
        }

        // 풀에 사용 가능한 오브젝트가 없으면 새로 생성
        Debug.Log("새로운 아이템 생성: " + prefabIndex);
        GameObject newItem = Instantiate(itmePrb[prefabIndex]);
        newItem.SetActive(false);
        itemPool.Add(newItem);
        return newItem;
    }
}
