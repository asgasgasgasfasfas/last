using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreUP : MonoBehaviour
{
    public PlayerControl playerControl;

    // ������ ����� ����
    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerControl.Score++;
        Debug.Log(playerControl.Score);
    }
}
