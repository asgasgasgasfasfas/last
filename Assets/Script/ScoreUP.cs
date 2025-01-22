using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreUP : MonoBehaviour
{
    public PlayerControl playerControl;

    // 파이프 통과시 점수
    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerControl.Score++;
        Debug.Log(playerControl.Score);
    }
}
