using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class player : MonoBehaviour
{
    BoxCollider2D myboxcolider;
    [SerializeField] float speed = 5f;
    Vector2 move;
    Vector2 minBounds;
    Vector2 maxBounds;
    [SerializeField] float paddingLeft;
    [SerializeField] float paddingRight;
    [SerializeField] float paddingTop;
    [SerializeField] float paddingBottom;
    [SerializeField] GameObject bullet;
    [SerializeField] Transform gun;

    //bool isAlive = true;
    
    

    private void Awake()
    {
       myboxcolider = GetComponent<BoxCollider2D>();
    }
    private void Start()
    {

        initBounds();
    }
    private void Update()
    {
        if (!GameManager.Instance.isGameStart) return;
        move_space();
        Die();

    }
    void initBounds()
    {
        Camera cam = Camera.main;
        minBounds = cam.ViewportToWorldPoint(new Vector2(0, 0));
        maxBounds = cam.ViewportToWorldPoint(new Vector2(1, 1));
    }
    void  OnMove(InputValue value)
    {
        if (!GameManager.Instance.isGameStart) return;
        move = value.Get<Vector2>();
    }
    void  move_space()
    {
        if (!GameManager.Instance.isGameStart) return;
        Vector2 delta = move*speed*Time.deltaTime;
        Vector2 litmit = new Vector2();
        litmit.x = math.clamp(transform.position.x + delta.x, minBounds.x+paddingLeft, maxBounds.x-paddingRight);
        litmit.y = math.clamp(transform.position.y + delta.y, minBounds.y+paddingBottom, maxBounds.y-paddingTop);
        transform.position = litmit;
    }
     
    void OnFire(InputValue value)
    {
         if(!GameManager.Instance.isGameStart) return;
        Instantiate(bullet, gun.transform.position, transform.rotation);
    }

    void Die()
    {
        if (myboxcolider.IsTouchingLayers(LayerMask.GetMask("Enemy")))
        {
            //isAlive = false;
            GameManager.Instance.ShowGameOver();
           
           
            
            // chuyen den man game over;
        }
    }

  

}
