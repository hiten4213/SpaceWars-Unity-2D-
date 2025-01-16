using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyspawner : MonoBehaviour
{
    [SerializeField] waveconfig currentwave;
    [SerializeField] List<waveconfig> waveconfigs;
    [SerializeField] float timebetweenwaves = 0f;
    bool islooping = true;
    void Start()
    {
       StartCoroutine(spawnenemies());
    }
    public waveconfig getcurrentwave()
    {
        return currentwave;
    }
IEnumerator spawnenemies()
{
    do{ foreach(waveconfig wave in waveconfigs)
    {
        currentwave = wave;
        for(int i =0;i < currentwave.getenemycount();i++)
    {
    Instantiate(currentwave.getenemyprefab(i), currentwave.getstartwaypoint().position,Quaternion.Euler(0,0,180),transform);
     yield return new WaitForSeconds(currentwave.getrandomspawntime());
    }
     yield return new WaitForSeconds(timebetweenwaves);
    }}
   while(islooping == true);
    
}
   
}
