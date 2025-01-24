using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ITemAbility : MonoBehaviour
{
    private int item;
    [SerializeField]
    private int multiply = 3;

    private CountdownText countdownText;


  private void Awake()
  {
        GameObject textObject = GameObject.Find("TextItem");
        countdownText = textObject.GetComponent<CountdownText>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            PlayerControl playerControl = collision.GetComponent<PlayerControl>();
            Debug.Log("����"+ item);
            if (playerControl != null)
            {
                Debug.Log($"���� Item ��: {playerControl.itemAbility}");
                Debug.Log($"Multiply ��: {multiply}");
            
            
                Debug.Log($"���ο� Item ��: {playerControl.itemAbility}");
            
                StartCoroutine(ItemEffectt(playerControl));
            }


           
        }

    }
    private IEnumerator ItemEffectt(PlayerControl playerControl)
    {   //������ ���� 
        int originalAbility = playerControl.itemAbility;
        // ������ ȿ�� ����
        playerControl.itemAbility = multiply;
        MoveTo moveTo = GetComponent<MoveTo>();
        moveTo.speed = 0f;

        transform.position = new Vector3(2.44f, 8.63f, 0);

        countdownText.StartCountdown(10f);

        yield return new WaitForSeconds(10f);
        //������ ���� 
        moveTo.speed = 4f;

        playerControl.itemAbility = originalAbility;

        gameObject.SetActive(false);
    }
}
