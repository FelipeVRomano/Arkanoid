using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private AudioController audioController;
   // [HideInInspector]
    public float ballAltura;
    //  private float ballAlturaFinal;
    public float ballAlturaFinal;
    Rigidbody2D rigid2D;
    public void Start()
    {
        audioController = GameObject.FindWithTag("MainCamera").GetComponent<AudioController>();
        rigid2D = gameObject.GetComponent<Rigidbody2D>();
    }

    public void OnCollisionEnter2D(Collision2D hit)
    {
        if (hit.gameObject.CompareTag("Botton"))
        {
            GameObject.FindWithTag("GameController").GetComponent<GameController>().RemoveBall();
            Destroy(gameObject);
        }

        if (hit.gameObject.CompareTag("SpecialBlock"))
        {
            audioController.PlaySound(AudioType.SPECIAL_COLLISION);
            hit.gameObject.GetComponent<BlockController>().ApplyDamage();
        }

        if (hit.gameObject.CompareTag("Block"))
        {
            audioController.PlaySound(AudioType.NORMAL_COLLISION);
            hit.gameObject.GetComponent<BlockController>().ApplyDamage();
        }

        if (hit.gameObject.CompareTag("Player"))
        {
            audioController.PlaySound(AudioType.PLAYER_COLLISION);
        }

        if(hit.gameObject.CompareTag("Wall"))
        {
            ballAlturaFinal = transform.position.y;
            BallAdjust();
        }
    }
    void BallAdjust()
    {
        float diferenca = ballAltura - ballAlturaFinal;
        if(diferenca > 0 && diferenca < 0.1)
        {
            transform.GetComponent<Rigidbody2D>().AddForce(new Vector2(1, -5));
        }
        else if( diferenca < 0 && diferenca > -0.1)
        {
            transform.GetComponent<Rigidbody2D>().AddForce(new Vector2(1, 5));
        }
    }
}
