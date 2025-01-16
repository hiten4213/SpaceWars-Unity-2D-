using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class score : MonoBehaviour
{
   
   int currentscore = 0;
   static score instance;
   private void Awake()
    {
       ManageSingleton();
    }
    void ManageSingleton()
    {
      if(instance != null)
      {
        gameObject.SetActive(false);
        Destroy(gameObject);
      }
      else
      {
        instance = this;
        DontDestroyOnLoad(gameObject);
      }
    }
   public int getcurrentscore()
   {
    return currentscore;
   }

   public void modifyscore(int value)
   {
     currentscore += value;
     Mathf.Clamp(currentscore,0,int.MaxValue);
   }
   public void resetscore()
   {
     currentscore = 0;
   }
}
