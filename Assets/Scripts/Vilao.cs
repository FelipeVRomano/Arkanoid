using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vilao : MonoBehaviour
{


    private float velMove = 2f;
   
    [SerializeField]
    private Rigidbody2D rb;
   
   public bool moveE;
  
    public bool moveD;
    public bool moveBaixo;
   
    public Transform limiteE;
    public Transform limiteD;
   // public bool congela;
    void Start()
    {
        //rb = GetComponent<GameObject>();
        //rb = GetComponent<Rigidbody2D>();
        moveE = true;
        moveD = false;
        moveBaixo = true;
        Physics2D.IgnoreLayerCollision(8, 8);
       // congela = false;
      

    }


    
    void Update()
    {

        Move();
    }

    public void Move ()
    {
    
        if (moveE && moveBaixo)
        {

            rb.velocity = new Vector2(-velMove, -1);



        }
        else if (moveE && moveBaixo == false)
        {
            rb.velocity = new Vector2(-velMove, 0);
            

        }

        if (moveD && moveBaixo)
        {
            rb.velocity = new Vector2(velMove, -1);


        }
        else if (moveD && !moveBaixo)
        {
            rb.velocity = new Vector2(velMove, -0);

        }
        if(!Physics2D.Raycast(limiteE.position,Vector2.left,0.1f) && moveE)
        {
            moveE = true;
            moveD = false;
        }
        else if (Physics2D.Raycast(limiteE.position, Vector2.left, 0.1f))
        {
           moveE = false;
           moveD = true;
        }
        if (!Physics2D.Raycast(limiteD.position, Vector2.right, 0.1f) && moveD)
        {
           moveE = false;
            moveD = true;
        }
        else if (Physics2D.Raycast(limiteD.position, Vector2.right, 0.1f))
        {
           moveE = true;
           moveD = false; 
       }
       
    }
    public void OnCollisionEnter2D(Collision2D col)
    {
      
      
       
        if (col.gameObject.CompareTag("Ball"))
        {
            Destroy(gameObject);

        }
        
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("destruidor"))
        {
            Destroy(gameObject);

        }
        if (col.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);

        }
    }
}
