using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.WSA;

public class gyro : MonoBehaviour
{
    //public Rigidbody rb;
    public Rigidbody player;
    //public GameObject player;

    public float gyroFactor = 0f;
    public  float speed = 80f;

    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.Find("Player");
        player = GetComponent<Rigidbody>();

        Gyroscope gyro = Input.gyro;
        gyro.enabled = true;

        //Input.gyro.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 tilt = Input.acceleration;
        tilt = Quaternion.Euler(90, 0, 0) * tilt;
        tilt.y = 0;

        if (tilt.magnitude > 0)
        {
            player.AddForce(tilt * speed * gyroFactor * Time.deltaTime);
        }

        //Debug.Log(Input.gyro.attitude);
        transform.rotation = Input.gyro.attitude;
    }
}
