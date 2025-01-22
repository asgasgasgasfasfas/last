using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerScoreViewer : MonoBehaviour
{
    [SerializeField]
    private PlayerControl playerController;
    private TextMeshProUGUI textScore;

    private void Awake()
    {
        textScore = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        // text UI에 현재 점수 정보를 업데이트
        textScore.text = "내 최고 점수 : " + playerController.BestScore;
        // text UI에 최고 점수를 
        textScore.text = "현재 점수 : " + playerController.Score;
    }

}
