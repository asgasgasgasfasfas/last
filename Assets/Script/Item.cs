using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]
    private GameObject[] itmePrb; 
    private float Timer = 0;
    private int probability;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Timer = Time.deltaTime;

        if(Timer > 2)
        {   //60퍼  x2 30퍼 x3 10퍼 x5 )
            probability = Random.Range(0, 101);

            int result = probability < 60 ? 0 : (probability < 90 ? 2 : 3); 

            GameObject itemclone = Instantiate(itmePrb[result], transform.position, Quaternion.identity);

            Debug.Log("아이템"+result);
        }
    }
}
