using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreUP : MonoBehaviour
{
    public PlayerControl playerController;
    public int item = 1;

    // ������ ����� ����
    private void Awake()
    {
        //tip ���� �ڵ忡���� �ѹ��� ȣ���ϱ� ������ ondie() �Լ����� �ٷ� ȣ���ص� ������
        //������Ʈ Ǯ���� �̿ꤷ�� ������Ʈ�� ������ ��쿡�� �ּ� 1����  find  �� �̿���
        //   playerController �� ������ �����صΰ� ����ϴ� ���� ���꿡 ȿ�����̴�
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();
        //�δ�ģ ���� ������ ������ �ڵ�
          itmePrb = GetComponent<Item>();

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerController.Score = 1 * item;
        Debug.Log(playerController.Score);
    }
}
