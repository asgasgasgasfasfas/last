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
        // text UI�� ���� ���� ������ ������Ʈ
        textScore.text = "�� �ְ� ���� : " + playerController.BestScore;
        // text UI�� �ְ� ������ 
        textScore.text = "���� ���� : " + playerController.Score;
    }

}
