using System.Collections;
using UnityEngine;

public class CPUPlayerMovt : MonoBehaviour
{
    private float speed = 80;
    public Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        StartCoroutine(RandomMovement());
    }

    IEnumerator RandomMovement()
    {
        while (true)
        {
            //random movement direction
            Vector3 randomDirection = new Vector3(Random.Range(-120f, 120f), 0, Random.Range(-120f, 120f));//.normalized;

            // force to rigidbody for random movement
            rb.AddForce(randomDirection * speed);

            // random time before changing direction
            float waitTime = Random.Range(1f, 2f);
            yield return new WaitForSeconds(waitTime);

            Debug.Log("Applied force in " + randomDirection + " direction. Waiting for " + waitTime + " seconds.");
        }
    }
}
