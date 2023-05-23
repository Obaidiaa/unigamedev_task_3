using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed ; // Adjust this value to control the enemy's movement speed.
    public float leftBoundary = -13f; // The leftmost boundary where the enemy should respawn.
    public float rightBoundary = 10f; // The rightmost boundary where the enemy should respawn.

    public int scoreValue = 100; // The score value of the enemy. Adjust this value to control how many points the player gets for destroying the enemy.

    // audio source
    private AudioSource audioSource;

    //hit sound
    public AudioClip hitSound;
    public int health = 3; // The enemy's health. Adjust this value to control how many cannonballs it takes to destroy the enemy.
    public Animation anim; 
    public string DestoryEn ; 

    // Start is called before the first frame update
    void Start()
    {

        //set the audio source
        audioSource = GetComponent<AudioSource>();

        Debug.Log("enemy created with speed " + speed + " and health " + health + " and score value " + scoreValue);
        anim = gameObject.GetComponent<Animation>(); 
        //anim ["DestoryEn"].layer = 123 ; 
        
    }

    // Update is called once per frame
    void Update()
    {

        //move the enemy to the left if health is not 0
        if (health > 0)
        {
            speed = GameManager.instance.GameSpeed;
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }

        //if the enemy is past the left boundary, move it to the right boundary
        if (transform.position.x < leftBoundary)
        {
            // transform.position = new Vector2(rightBoundary, transform.position.y);
            Destroy(gameObject);
        }

    }



    //the enemy is destroyed when it hits the cannonball if it health is 0 
    //shake the enemy when it is hit by a cannonball
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Cannonball")
        {
            Debug.Log("enemy hit by cannonball");
            health--;
            
            
            
            //play the hit sound
            audioSource.PlayOneShot(hitSound, 0.7F);

            if (health == 0)
            {
                // sink the enemy into the sea before destroying it                
                // GetComponent<Animator>().SetTrigger("Sink");

                // while (transform.position.y > -4.5)
                // {
                //     transform.Translate(Vector3.down * speed * Time.fixedDeltaTime);

                // }
                // when ship is destroyed sink the ship into the sea before destroying it
                GameManager.instance.IncreaseScore(scoreValue);
                Destroy(gameObject, 1f);

            }
            else
            {
                StartCoroutine(Shake());
            }
        }
    }

    //shake the enemy when it is hit by a cannonball
    IEnumerator Shake()
    {
        float shakeAmount = 0.1f;
        float shakeDuration = 0.1f;
        Vector3 initialPosition = transform.position;

        while (shakeDuration > 0)
        {
            transform.position = initialPosition + Random.insideUnitSphere * shakeAmount;

            shakeDuration -= Time.deltaTime;
            yield return null;
        }

        transform.position = initialPosition;
    }
}
