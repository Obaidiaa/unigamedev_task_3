using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject enemyPrefab; // Assign the enemy sprite object to this variable in the inspector.
    public float spawnRate = 2f; // Adjust this value to control the frequency of enemy spawns.
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {

        // don't spawn enemies until the game starts and there are no enemies on the screen
        while (true)
        {
            yield return new WaitUntil(() => GameObject.FindGameObjectsWithTag("Enemy").Length == 0);

            // Instantiate a new enemy at the spawner's position
            GameObject newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);

            // Wait for the specified spawn rate before spawning the next enemy
            yield return new WaitForSeconds(spawnRate);
        }
    }


    // Update is called once per frame
    void Update()
    {

    }
}
