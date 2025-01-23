using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreUP : MonoBehaviour
{
    private PlayerControl playerController;
    public int item = 1;

    // ������ ����� ����
    private void Awake()
    {
        // PlayerControl ã��
        playerController = GameObject.FindGameObjectWithTag("Player")?.GetComponent<PlayerControl>();

        playerController.BestScore = PlayerPrefs.GetInt("BestScore", 5);
        //�ʱ�ȭ
        playerController.Score = 0;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // �÷��̾�� ������ �� �޾ƿ��� 
        item = other.GetComponent<PlayerControl>().itemAbility;

        playerController.Score += 1 * item;
            Debug.Log("������ ���! ���� ����: " + playerController.Score);
            if (playerController.Score >= playerController.BestScore)
            {
                playerController.BestScore = playerController.Score;
                Debug.Log("///" + playerController.Score + playerController.BestScore);
            }
        

    }

}
