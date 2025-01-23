using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ITemAbility : MonoBehaviour
{
    private ScoreUP item;
    [SerializeField]
    private int multiply;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
             item = GetComponent<ScoreUP>();
            Debug.Log("배율"+ item.item);
            if (item != null)
            {
                Debug.Log($"기존 Item 값: {item.item}");
                Debug.Log($"Multiply 값: {multiply}");

                // 아이템 효과 적용
                item.item = multiply;
                Debug.Log($"새로운 Item 값: {item.item}");
            }


            Destroy(gameObject);
        }

    }
}
