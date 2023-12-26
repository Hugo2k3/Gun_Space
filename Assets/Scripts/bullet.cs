using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class bullet : MonoBehaviour
{
   
    Rigidbody2D myRigidbody;
    
    CapsuleCollider2D myCapsule;
    
    
    [SerializeField] float ySpeed=20f;

    // Start is called before the first frame update
    void Start()
    {
        
        myRigidbody = GetComponent<Rigidbody2D>();
        myCapsule = GetComponent<CapsuleCollider2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!GameManager.Instance.isGameStart) return;
        myRigidbody.velocity = new Vector2 (0, ySpeed);
        destroy_bullet();
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy" )
        {
            GameManager.Instance.AddScore(1);
          
            Destroy(collision.gameObject);

        }
        Destroy(gameObject);


    }
    void destroy_bullet()
    {
        if (myCapsule.IsTouchingLayers(LayerMask.GetMask("limit")))
        {
            Destroy(gameObject);
        }
    }
   
    
}
