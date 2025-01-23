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
        if (playerController == null)
        {
            Debug.LogError("PlayerControl�� ã�� �� �����ϴ�. Player �±׿� ������Ʈ�� Ȯ���ϼ���.");
        }
        playerController.BestScore = PlayerPrefs.GetInt("BestScore", 5);
        //   Debug.Log("����! ���� ����: " + playerController.Score);
        playerController.Score = 0;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"�浹�� ������Ʈ: {other.gameObject.name}");

        if (playerController != null)
        {
            playerController.Score += 1 * item;
            Debug.Log("������ ���! ���� ����: " + item);
            if (playerController.Score > playerController.BestScore)
            {
                playerController.Score = playerController.BestScore  ;
               // Debug.Log("///" + playerController.Score + playerController.BestScore);
            }
        }
        else
        {
            Debug.LogError("PlayerControl�� null�Դϴ�. Awake()���� ����� �ʱ�ȭ�Ǿ����� Ȯ���ϼ���.");
        }
    }

}
