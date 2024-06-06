using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movt : MonoBehaviour
{
    public float speed;
    public Rigidbody rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (!IsCPUControlled()) { 
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
            rb.AddForce(movement * speed);
        }
    }

    bool IsCPUControlled()
    {
        return gameObject.CompareTag("CPUPlayer");
    }
}
