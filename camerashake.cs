using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerashake : MonoBehaviour
{

    [SerializeField] float shakeduration = 1f;
    [SerializeField] float shakemagnitude = 5f;
    Vector3 initialposi;
   
    void Start()
    {
        initialposi = transform.position;
    }
    public void play()
    {
        StartCoroutine(shake());
    }
   IEnumerator shake()
   {
      float elapsedtime = 0f;
      while(elapsedtime<shakeduration) 
      {
         transform.position = initialposi +(Vector3)Random.insideUnitCircle*shakemagnitude;
         elapsedtime += Time.deltaTime;
         yield return new WaitForEndOfFrame();
      }
      transform.position = initialposi;    
   }
}

