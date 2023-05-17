using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{

    public GameObject cloudPrefab; // Assign the cloud sprite object to this variable in the inspector.
    public float spawnRate = 2f; // Adjust this value to control the frequency of cloud spawns.
                                 // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnClouds());
    }

    IEnumerator SpawnClouds()
    {
        while (true)
        {
            // Instantiate a new cloud at the spawner's position
            GameObject newCloud = Instantiate(cloudPrefab, transform.position, Quaternion.identity);

            // Wait for the specified spawn rate before spawning the next cloud
            yield return new WaitForSeconds(spawnRate);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
