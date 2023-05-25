using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Days : MonoBehaviour
{
    // Start is called before the first frame update

    public float morning;
    public float noon;
    public float night;
    public Animator theanim;
    void Start()
    {
        Morning();
        theanim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Morning()
    {
        theanim.SetTrigger("Morning");
        Invoke("Noon", noon);
    }

    void Noon()
    {
        theanim.SetTrigger("Night");
        Invoke("Night", night);
    }
    void Night()
    {
        theanim.SetTrigger("Morning");
        Invoke("Morning", morning);
    }
}
