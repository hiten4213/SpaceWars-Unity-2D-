using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class playermovement : MonoBehaviour
{
    Vector2 rawinput;
    [SerializeField] float movespeed = 1f;
    Vector2 minbounds;
    Vector2 maxbounds;
    [SerializeField] float paddingtop;
    [SerializeField] float paddingbottom;
    [SerializeField] float paddingright;
    [SerializeField] float paddingleft;
    shooter shooter;
    private void Awake() 
    {
        shooter = GetComponent<shooter>();
    }

    void Start() 
    {
        bounds();
    }
    void Update()
    {
        move();
    }
    void bounds()
    {
        Camera maincamera = Camera.main;
        minbounds = maincamera.ViewportToWorldPoint(new Vector2(0,0));
        maxbounds = maincamera.ViewportToWorldPoint(new Vector2(1,1));
    }
    private void move()
    {
        Vector2 delta = rawinput * movespeed * Time.deltaTime;
        Vector2 newpos = new Vector2();
        newpos.x = Mathf.Clamp(transform.position.x + delta.x,minbounds.x+paddingleft ,maxbounds.x-paddingright);
        newpos.y = Mathf.Clamp(transform.position.y + delta.y,minbounds.y+paddingtop ,maxbounds.y-paddingbottom);
        transform.position = newpos;

    }

    void OnMove(InputValue value)
    {
       rawinput=value.Get<Vector2>();
    }
    void OnFire(InputValue value)
    {
       if(shooter != null)
       {
         shooter.isfiring = value.isPressed;
       }
    }
}
