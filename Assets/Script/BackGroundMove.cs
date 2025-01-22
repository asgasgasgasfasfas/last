using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMove : MonoBehaviour
{
    [SerializeField]
    private Transform target;   //7.09 0.5 
    [SerializeField]
    private float scrollRange = 7.09f;
    [SerializeField]
    private float moveSpeed = 3.0f;
    [SerializeField]
    private Vector3 moveDirection = Vector3.left;


    private void Update()
    {
        transform.position += moveDirection * moveSpeed * Time.deltaTime;

        if (transform.position.x <= -scrollRange)
        {
            transform.position = transform.position + Vector3.right * scrollRange * 2;
        }
    }
}
