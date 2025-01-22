using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private MoveTo  moveto;
    [SerializeField]
    private float   jumppower = 5f;
    Rigidbody2D     rigidbody2D;
    private int     bestScore   = 0;
    private int     score;
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
        rigidbody2D = GetComponent<Rigidbody2D>();
        moveto      = GetComponent<MoveTo>();
        // ��� ���� ȸ���� ����
        rigidbody2D.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody2D.velocity = Vector3.up * jumppower;

            if(Score <= BestScore)
            {
                score =  BestScore;
            }
        }

       // Control();


    }
    private void Control()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        
        moveto.moveTo(new Vector3(x, y, 0));
    }


}
