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

        playerController.BestScore = PlayerPrefs.GetInt("BestScore", 5);
        //초기화
        playerController.Score = 0;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // 플레이어에서 아이템 값 받아오기 
        item = other.GetComponent<PlayerControl>().itemAbility;

        playerController.Score += 1 * item;
            Debug.Log("파이프 통과! 현재 점수: " + playerController.Score);
            if (playerController.Score >= playerController.BestScore)
            {
                playerController.BestScore = playerController.Score;
                Debug.Log("///" + playerController.Score + playerController.BestScore);
            }
        

    }

}
