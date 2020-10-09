using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private AudioController audioController;

    public void Start()
    {
        audioController = GameObject.FindWithTag("MainCamera").GetComponent<AudioController>();
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
    }
}
