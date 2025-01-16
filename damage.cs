using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damage : MonoBehaviour
{
    [SerializeField] int dmgvalue = 10;
    public int getdamage()
    {
        return dmgvalue;
    }
   public void hit()
    {
        Destroy(gameObject);
    }
}
