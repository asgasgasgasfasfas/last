using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ITemAbility : MonoBehaviour
{
    private int item;
    [SerializeField]
    private int multiply = 3;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            PlayerControl item = collision.GetComponent<PlayerControl>();
            Debug.Log("배율"+ item);
            if (item != null)
            {
                Debug.Log($"기존 Item 값: {item.itemAbility}");
                Debug.Log($"Multiply 값: {multiply}");

                // 아이템 효과 적용
                item.itemAbility = multiply;
                Debug.Log($"새로운 Item 값: {item.itemAbility}");
            }


            Destroy(gameObject);
        }

    }
}
