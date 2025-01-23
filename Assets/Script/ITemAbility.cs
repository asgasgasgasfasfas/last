using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ITemAbility : MonoBehaviour
{
    private int item;
    [SerializeField]
    private int multiply = 3;
    [SerializeField]
    private CountdownText countdownText;


    private void Awake()
    {
        countdownText = GameObject.Find("CountdownText");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            PlayerControl playerControl = collision.GetComponent<PlayerControl>();
            Debug.Log("배율"+ item);
            if (playerControl != null)
            {
                Debug.Log($"기존 Item 값: {playerControl.itemAbility}");
                Debug.Log($"Multiply 값: {multiply}");


                Debug.Log($"새로운 Item 값: {playerControl.itemAbility}");

                StartCoroutine(ItemEffectt(playerControl));
            }


           
        }

    }
    private IEnumerator ItemEffectt(PlayerControl playerControl)
    {   //기존값 저장 
        int originalAbility = playerControl.itemAbility;
        // 아이템 효과 적용
        playerControl.itemAbility = multiply;
        MoveTo moveTo = GetComponent<MoveTo>();
        moveTo.speed = 0f;

        transform.position = new Vector3(0.8f, 4.36f, 0);

        countdownText.StartCountdown(10f);

        yield return new WaitForSeconds(10f);
        //기존값 복원 
        moveTo.speed = 4f;

        playerControl.itemAbility = originalAbility;

        gameObject.SetActive(false);
    }
}
