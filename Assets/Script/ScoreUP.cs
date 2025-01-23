using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreUP : MonoBehaviour
{
    private PlayerControl playerController;
    public int item = 1;

    // 파이프 통과시 점수
    private void Awake()
    {
        // PlayerControl 찾기
        playerController = GameObject.FindGameObjectWithTag("Player")?.GetComponent<PlayerControl>();
        if (playerController == null)
        {
            Debug.LogError("PlayerControl을 찾을 수 없습니다. Player 태그와 컴포넌트를 확인하세요.");
        }
        playerController.BestScore = PlayerPrefs.GetInt("BestScore", 5);
        //   Debug.Log("시작! 현재 점수: " + playerController.Score);
        playerController.Score = 0;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"충돌한 오브젝트: {other.gameObject.name}");

        if (playerController != null)
        {
            playerController.Score += 1 * item;
            Debug.Log("파이프 통과! 현재 점수: " + item);
            if (playerController.Score > playerController.BestScore)
            {
                playerController.Score = playerController.BestScore  ;
               // Debug.Log("///" + playerController.Score + playerController.BestScore);
            }
        }
        else
        {
            Debug.LogError("PlayerControl이 null입니다. Awake()에서 제대로 초기화되었는지 확인하세요.");
        }
    }

}
