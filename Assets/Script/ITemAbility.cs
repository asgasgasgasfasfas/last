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
            Debug.Log("����"+ item.item);
            if (item != null)
            {
                Debug.Log($"���� Item ��: {item.item}");
                Debug.Log($"Multiply ��: {multiply}");

                // ������ ȿ�� ����
                item.item = multiply;
                Debug.Log($"���ο� Item ��: {item.item}");
            }


            Destroy(gameObject);
        }

    }
}
