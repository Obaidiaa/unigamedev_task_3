using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject enemyPrefab; // Assign the enemy sprite object to this variable in the inspector.
    public GameObject enemy2Prefab; // Assign the enemy sprite object to this variable in the inspector.
    public GameObject enemy3Prefab; // Assign the enemy sprite object to this variable in the inspector.
    public GameObject enemy4Prefab; // Assign the enemy sprite object to this variable in the inspector.
    public float spawnRate; // Adjust this value to control the frequency of enemy spawns.
    void Start()
    {
        StartCoroutine(SpawnEnemies());

    }

    IEnumerator SpawnEnemies()
    {

        // don't spawn enemies until the game starts and there are no enemies on the screen
        while (true)
        {
            // yield return new WaitUntil(() => GameObject.FindGameObjectsWithTag("Enemy").Length == 0);

            spawnRate = GameManager.instance.RespawnRate;

            Debug.Log("respwanRate " + GameManager.instance.RespawnRate);
            // Instantiate a new enemy at the spawner's position randomly
            int randomEnemy = Random.Range(1, 5);
            if (randomEnemy == 1)
            {
                Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            }
            else if (randomEnemy == 2)
            {
                Instantiate(enemy2Prefab, transform.position, Quaternion.identity);
            }
            else if (randomEnemy == 3)
            {
                Instantiate(enemy3Prefab, transform.position, Quaternion.identity);
            }
            else if (randomEnemy == 4)
            {
                Instantiate(enemy4Prefab, transform.position, Quaternion.identity);
            }else{
                Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            }

            // Wait for the specified spawn rate before spawning the next enemy
            yield return new WaitForSeconds(spawnRate);
        }
    }



    // Update is called once per frame
    void Update()
    {

    }
}
