using System.Collections;
using UnityEngine;

public class health : MonoBehaviour
{
    [SerializeField] bool isplayer;
    [SerializeField] int Score = 50;
    [SerializeField] int Health = 50;
    [SerializeField] ParticleSystem explosion;
    camerashake camerashake;
    [SerializeField] bool applycamerashake;
    [SerializeField] AudioClip explodesfx;
    score score;
    levelmanager levelmanager;
     
       void Awake()
      {
         camerashake = Camera.main.GetComponent<camerashake>();
         score = FindObjectOfType<score>();
         levelmanager = FindObjectOfType<levelmanager>();
      }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        damage Damage = other.GetComponent<damage>();
        if(Damage != null)
        {
            takedamage(Damage.getdamage());
            playhiteffect();
            shakecamera();
            Damage.hit();

        }
    }
    void takedamage(int damage)
    {
       Health -= damage;
       if(Health <= 0)
       {
         GetComponent<AudioSource>().PlayOneShot(explodesfx);
         die();
       }
    }
    void die()
    {
        if(!isplayer)
        {
            score.modifyscore(Score);
        }
        else
        {
            levelmanager.loadgameover();
        }
        Destroy(gameObject,0.5f);
    }
    void playhiteffect()
    {
        if(explosion != null)
        {
            ParticleSystem instance = Instantiate(explosion,transform.position,Quaternion.identity);
            Destroy(instance.gameObject,instance.main.duration + instance.main.startLifetime.constantMax);
        }
    }
    void shakecamera()
    {
        if(camerashake != null && applycamerashake)
        {
            camerashake.play();
        }
    }
    public int gethealth()
    {
        return Health;
    }

}
