using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextScoreCurrant : MonoBehaviour
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
        textScore.text = "현재 점수 : " + playerController.Score;

    }
}
