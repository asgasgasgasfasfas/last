using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TextScoreBest : MonoBehaviour
{
    [SerializeField]
    private PlayerControl playerController;
    private TextMeshProUGUI textScore;

    private void Awake()
    {
        textScore = GetComponent<TextMeshProUGUI>();
        playerController.BestScore = PlayerPrefs.GetInt("BestScore", 5);
    }

    private void Update()
    {
        // text UI�� ���� ���� ������ ������Ʈ
        textScore.text = "�� �ְ� ���� : " + playerController.BestScore;

    }
}
