using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pathfinder : MonoBehaviour
{
    enemyspawner enemyspawner;
     waveconfig waveconfigg;
    List<Transform> waypoints;
    int destroy = 10;
    int waypointindex=0;

    
     void Awake()
     {
        enemyspawner = FindObjectOfType<enemyspawner>();
   
     }
    void Start()
    {
        waveconfigg = enemyspawner.getcurrentwave();
        waypoints = waveconfigg.getwaypoints();
        transform.position = waypoints[waypointindex].position;
    }

    
    void Update()
    {
       StartCoroutine(followpath());
    }
    IEnumerator followpath()
    {
        if(waypointindex < waypoints.Count)
        {
           UnityEngine.Vector3 targetposition = waypoints[waypointindex].position;
            float delta = waveconfigg.getmovespeed()*Time.deltaTime;
            transform.position = UnityEngine.Vector2.MoveTowards(transform.position,targetposition,delta);
            if(transform.position == targetposition)
            {
                waypointindex++;
            }
            yield return new WaitForSecondsRealtime(destroy);
             Destroy(gameObject);
        }
        
    }
}
