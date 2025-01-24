using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
    private MoveTo  moveto;
    [SerializeField]
    private StageData stageData;
    [SerializeField]
    private float   jumppower = 5f;
    Rigidbody2D     rigidbody2D2;
    public int      itemAbility = 1;
    private int     bestScore   = 0;
    private int     score;
    public float moveSpeed = 10f; // 캐릭터 이동 속도
    private Vector3 startTouchPosition; // 마우스를 누르거나 터치한 초기 위치
    private Vector3 currentTouchPosition; // 현재 마우스나 터치 위치
    private Vector3 moveDirection; // 이동 방향
    private bool isTouching = false; // 현재 입력 상태 (누르고 있는 중인지)
    public int Score
    {                // score 값이 음수가 되지 않도록 
        set => score = Mathf.Max(0, value);
        get => score;
    }
    public int BestScore
    {                // score 값이 음수가 되지 않도록 
        set => bestScore = Mathf.Max(0, value);
        get => bestScore;
    }
    void Start()
    {
        score = 0;
        rigidbody2D2 = GetComponent<Rigidbody2D>();
        moveto      = GetComponent<MoveTo>();
       
        // 모든 축의 회전을 고정
        rigidbody2D2.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    // Update is called once per frame
    void Update()
    {
        Control02();
        Control01();




    }
    private void Control03()
    {
        if (Input.GetMouseButton(0))
        {
            rigidbody2D2.velocity = Vector3.up * jumppower;

        }
    }
    private void Control02()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        moveto.moveTo(new Vector3(x, y, 0));

    }
    private void Control01()
    {
        // 입력 시작 (마우스 왼쪽 버튼 클릭 또는 터치 시작)
        if (Input.GetMouseButtonDown(0))
        {
            isTouching = true;
            startTouchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            startTouchPosition.z = 0; // z축 고정
        }

        // 입력 중 (마우스를 누르고 이동하거나 터치 이동)
        if (Input.GetMouseButton(0) && isTouching)
        {
            currentTouchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            currentTouchPosition.z = 0; // z축 고정

            // 이동 방향 계산 (현재 위치 - 시작 위치)
            moveDirection = (currentTouchPosition - startTouchPosition).normalized;

            // 캐릭터 이동
            transform.position += moveDirection *( moveSpeed * Time.deltaTime);
        }

        // 입력 종료 (마우스 버튼을 떼거나 터치 종료)
        if (Input.GetMouseButtonUp(0))
        {
            isTouching = false;
            moveDirection = Vector3.zero; // 이동 방향 초기화
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
 
        if(score > bestScore)
        {
            bestScore = score;
        }
        
            PlayerPrefs.SetInt("Score", score);
            PlayerPrefs.SetInt("BestScore", bestScore);
            PlayerPrefs.Save();
           //  Debug.Log(score + "ddd" + bestScore);

           //  SceneManager.LoadScene("GameOver");


    }

    private void LateUpdate()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, stageData.LimitMin.x, stageData.LimitMax.x),
                                         Mathf.Clamp(transform.position.y, stageData.LimitMin.y, stageData.LimitMax.y));
    }

}
