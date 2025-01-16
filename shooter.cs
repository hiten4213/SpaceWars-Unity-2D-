using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class shooter : MonoBehaviour
{
    [SerializeField] GameObject projectileprefab;
    [SerializeField] float projectilespeed = 6f;
    [SerializeField] float projectilelife = 5f;
    [SerializeField] float firingrate = 0.2f;
    [SerializeField] AudioClip firesfx;
    public bool isfiring;
    Coroutine firing;
    [SerializeField] bool ai = true;
    void Start()
    {
        if(ai)
        {
            isfiring = true;
        }
    }

    void Update()
    {
        fire();
    }
    void fire()
    {
        if(isfiring && firing == null)
        {
           firing = StartCoroutine(firecontinuously());
           GetComponent<AudioSource>().PlayOneShot(firesfx);
        }
        else if(!isfiring && firing != null)
        {
            StopCoroutine(firing);
            firing = null;
        }
        
    }
    IEnumerator firecontinuously()
    {
       while(true)
       {
         GameObject instance = Instantiate(projectileprefab,transform.position,quaternion.identity);
         Rigidbody2D rb2d = instance.GetComponent<Rigidbody2D>();
         if(rb2d!=null)
         {
            rb2d.velocity = transform.up * projectilespeed;
         }
         Destroy(instance,projectilelife);
         yield return new WaitForSeconds(firingrate);
       }
    }
}
