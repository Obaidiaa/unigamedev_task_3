using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannonBall : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       Debug.Log("cannonball created"); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //destroy the cannonball when it hits Sea 
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Sea" || collision.gameObject.tag == "Enemy")
        {
            Debug.Log("cannonball hit sea");
            Destroy(gameObject);
        }
    }
    
}
