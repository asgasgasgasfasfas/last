using System.Collections.Generic;
using UnityEngine;

public class ItemSpawer : MonoBehaviour
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
                Debug.Log("아이템" + result);
            }
        }
    }

    private GameObject GetInactiveItem(int prefabIndex)
    {
        // 지정된 프리팹 인덱스와 일치하는 비활성화된 오브젝트 반환
        foreach (GameObject item in itemPool)
        {
            if (!item.activeInHierarchy && item.name.StartsWith(itmePrb[prefabIndex].name))
            {
                return item;
                Debug.Log("아이템" + prefabIndex);
            }
        }
        return null; // 사용 가능한 오브젝트가 없으면 null 반환
    }




}
