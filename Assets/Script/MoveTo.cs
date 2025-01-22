using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTo : MonoBehaviour
{
    [SerializeField]
    private float speed = 3f;
    [SerializeField]
    private Vector3 moveDirection = Vector3.left;



    // Update is called once per frame
    void Update()
    {
        transform.position += moveDirection * speed * Time.deltaTime;
    }

    public void moveTo(Vector3 direction)
    {
        moveDirection = direction;
    }

}
