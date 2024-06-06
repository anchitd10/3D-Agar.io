using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow_player : MonoBehaviour
{
    public GameObject player;

    void Start()
    {
        player = GameObject.Find("Player");
    }

    void Update()
    {
        //position
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 30, player.transform.position.z-15);

        //rotation
        transform.rotation = Quaternion.Euler(60f, 0f, 0f);
    }

    public void AdjustCameraOnCollect()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z - 1);
    }
}
