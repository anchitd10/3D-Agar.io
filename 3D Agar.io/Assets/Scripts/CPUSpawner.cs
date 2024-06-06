using System.Collections;
using UnityEngine;

public class CPUSpawner : MonoBehaviour
{
    public GameObject playerPrefab;
    public int numberOfPlayers = 3;
    public float spawnInterval = 2f;

    void Start()
    {
        StartCoroutine(SpawnPlayers());
    }

    IEnumerator SpawnPlayers()
    {
        for (int i = 0; i < numberOfPlayers; i++)
        {
            SpawnPlayer();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnPlayer()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(98, -98), 1, Random.Range(98, -98));
        GameObject newPlayer = Instantiate(playerPrefab, spawnPosition, Quaternion.identity);

        newPlayer.tag = "CPUPlayer";

        // control random movement
        newPlayer.AddComponent<CPUPlayerMovt>();

        //remove player movt script
        Destroy(newPlayer.GetComponent<player_movt>());
    }
}

