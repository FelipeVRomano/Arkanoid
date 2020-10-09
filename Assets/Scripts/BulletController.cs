using UnityEngine;
public class BulletController : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.gameObject.CompareTag("Block")|| 
            hit.gameObject.CompareTag("SpecialBlock"))
        {
            hit.gameObject.GetComponent<BlockController>().ApplyDamage(); //Importante
            Destroy(gameObject);
        }

        if (hit.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }

    }




    

    
        














    
    
}
