using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerspawnerdestroyer : MonoBehaviour
{
    AudioManager audioManager;
    public follow_player cameraFollow;

    public GameObject collectiblePrefab;
    public GameObject player;
    public float Time_to_create_Mass = 0.5f;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        cameraFollow = Camera.main.GetComponent<follow_player>();
    }


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        StartCoroutine(SpawnMassContinuously());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 randomSpawnerPosition = new Vector3(Random.Range(98, -98), 1, Random.Range(98, -98));
            Instantiate(collectiblePrefab, randomSpawnerPosition, Quaternion.identity);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Mass"))
        {
            //play sfx
            audioManager.PlaySFX(audioManager.Collect);

            Destroy(other.gameObject);

            //scale up player
            ScaleUpPlayer();

            //adjust camera on collect
            cameraFollow.AdjustCameraOnCollect();

            /*Vector3 randomSpawnerPosition = new Vector3(Random.Range(98, -98), 1, Random.Range(98, -98));
            GameObject newCollectible = Instantiate(collectiblePrefab, randomSpawnerPosition, Quaternion.identity);*/

            //add point to score
            ScoreManager.instance.AddPoint();
        }
    }

    private void ScaleUpPlayer()
    {
        float scaleFactor = 1.1f;
        player.transform.localScale *= scaleFactor;
    }

    IEnumerator SpawnMassContinuously()
    {
        while (true)
        {
            yield return new WaitForSeconds(Time_to_create_Mass);

            Vector3 randomSpawnerPosition = new Vector3(Random.Range(98, -98), 1, Random.Range(98, -98));
            Instantiate(collectiblePrefab, randomSpawnerPosition, Quaternion.identity);
        }
    }

}
