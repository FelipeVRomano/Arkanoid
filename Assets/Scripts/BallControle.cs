using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControle : MonoBehaviour
{
    [SerializeField]
    private Transform ballTrans;
    [SerializeField]
    private BallController ball;
    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Wall"))
        {
            ball.ballAltura = ballTrans.position.y;
        }
    }
}
