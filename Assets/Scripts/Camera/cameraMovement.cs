using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class cameraMovement : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;

    private Rigidbody2D camRb;

    private void Start()
    {
        camRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
            transform.position = new Vector2((player1.transform.position.x + player2.transform.position.x) / 2, 
                (player1.transform.position.y + player2.transform.position.y)/2);
    }
}
