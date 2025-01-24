using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoTextCureent : MonoBehaviour
{

    private TextMeshProUGUI textScore;
    private int bestScore;
    private int Score;

    private void Awake()
    {
        textScore = GetComponent<TextMeshProUGUI>();
     
        Score        = PlayerPrefs.GetInt("Score");
    }

    private void Update()
    {
        // text UI에 현재 점수 정보를 업데이트
        textScore.text = "최고 점수 : " + Score;

    }
}
