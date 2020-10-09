using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    public int numberOfHitsToDestroy;
    public GameObject effectPrefab;

    public void ApplyDamage()
    {
        numberOfHitsToDestroy--;
        if (numberOfHitsToDestroy <= 0)
        {
            GameObject.FindWithTag("GameController").GetComponent<GameController>().RemoveBlock(transform.position);
            Vector3 pos = transform.position + new Vector3(0, 0, -1);

            Instantiate(effectPrefab, pos, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
