using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] PlayerData playerData;
    

    void Awake ()
    {
        rb = GetComponent<Rigidbody2D>();
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (rb.IsTouchingLayers(LayerMask.GetMask("Hurt")))
        {
            print("Hurt");
            playerData.currentScore -= 10;

        }
    }
   
    
       
    
}
