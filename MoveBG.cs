using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBG : MonoBehaviour
{
    [SerializeField] float speed;
    private Vector3 StartPosition;

    void Start()
    {
        StartPosition = transform.position;
    }


    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
        if (transform.position.x > 13.266f)
        {
            transform.position = StartPosition;
        }
    }

    
}
