using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "wave config", fileName ="new wave config")]
public class waveconfig : ScriptableObject
{
    
    [SerializeField] Transform pathprefab;
    [SerializeField] float movespeed = 5f;
    [SerializeField] List<GameObject> enemyprefabs;
    [SerializeField] float enemyspawndelay = 1f;
    [SerializeField] float spawntimevariance = 0f;
    [SerializeField] float minspawntime = 0.2f;


public int getenemycount()
{
    return enemyprefabs.Count;
}
public GameObject getenemyprefab(int index)
{
    return enemyprefabs[index];
}
public Transform getstartwaypoint()
{
    return pathprefab.GetChild(0);
}
public List<Transform> getwaypoints()
{
    List<Transform> waypoints = new List<Transform>();
    foreach(Transform child in pathprefab)
    {
        waypoints.Add(child);
    }
    return waypoints;

}

   public float getmovespeed()
   {
     return movespeed;
   }
   
 public float getrandomspawntime()
 {
    float spawntime = Random.Range(enemyspawndelay - spawntimevariance,
    enemyspawndelay + spawntimevariance);
    return Mathf.Clamp(spawntime,minspawntime,float.MaxValue);
 }


}
