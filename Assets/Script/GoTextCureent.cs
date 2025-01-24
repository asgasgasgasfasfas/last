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
        // text UI�� ���� ���� ������ ������Ʈ
        textScore.text = "�ְ� ���� : " + Score;

    }
}
