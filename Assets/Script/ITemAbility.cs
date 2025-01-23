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
            Debug.Log("����"+ item);
            if (item != null)
            {
                Debug.Log($"���� Item ��: {item.itemAbility}");
                Debug.Log($"Multiply ��: {multiply}");

                // ������ ȿ�� ����
                item.itemAbility = multiply;
                Debug.Log($"���ο� Item ��: {item.itemAbility}");
            }


            Destroy(gameObject);
        }

    }
}
