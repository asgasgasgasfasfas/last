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
    public float moveSpeed = 10f; // ĳ���� �̵� �ӵ�
    private Vector3 startTouchPosition; // ���콺�� �����ų� ��ġ�� �ʱ� ��ġ
    private Vector3 currentTouchPosition; // ���� ���콺�� ��ġ ��ġ
    private Vector3 moveDirection; // �̵� ����
    private bool isTouching = false; // ���� �Է� ���� (������ �ִ� ������)
    public int Score
    {                // score ���� ������ ���� �ʵ��� 
        set => score = Mathf.Max(0, value);
        get => score;
    }
    public int BestScore
    {                // score ���� ������ ���� �ʵ��� 
        set => bestScore = Mathf.Max(0, value);
        get => bestScore;
    }
    void Start()
    {
        score = 0;
        rigidbody2D2 = GetComponent<Rigidbody2D>();
        moveto      = GetComponent<MoveTo>();
       
        // ��� ���� ȸ���� ����
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
        // �Է� ���� (���콺 ���� ��ư Ŭ�� �Ǵ� ��ġ ����)
        if (Input.GetMouseButtonDown(0))
        {
            isTouching = true;
            startTouchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            startTouchPosition.z = 0; // z�� ����
        }

        // �Է� �� (���콺�� ������ �̵��ϰų� ��ġ �̵�)
        if (Input.GetMouseButton(0) && isTouching)
        {
            currentTouchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            currentTouchPosition.z = 0; // z�� ����

            // �̵� ���� ��� (���� ��ġ - ���� ��ġ)
            moveDirection = (currentTouchPosition - startTouchPosition).normalized;

            // ĳ���� �̵�
            transform.position += moveDirection *( moveSpeed * Time.deltaTime);
        }

        // �Է� ���� (���콺 ��ư�� ���ų� ��ġ ����)
        if (Input.GetMouseButtonUp(0))
        {
            isTouching = false;
            moveDirection = Vector3.zero; // �̵� ���� �ʱ�ȭ
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
