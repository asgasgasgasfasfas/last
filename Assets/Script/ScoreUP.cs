using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreUP : MonoBehaviour
{
    public PlayerControl playerController;
    public int item = 1;

    // 파이프 통과시 점수
    private void Awake()
    {
        //tip 현재 코드에서는 한번만 호출하기 떄문에 ondie() 함수에서 바로 호출해도 되지만
        //오브젝트 풀링을 이욧ㅇ해 오브젝트를 재사용할 경우에는 최소 1번만  find  를 이용해
        //   playerController 의 정보를 저장해두고 사용하는 것이 연산에 효율적이다
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();
        //부닥친 적의 정보를 얻어오는 코드
          itmePrb = GetComponent<Item>();

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerController.Score = 1 * item;
        Debug.Log(playerController.Score);
    }
}
