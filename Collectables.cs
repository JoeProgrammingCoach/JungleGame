
using UnityEngine;


public class Collectables : MonoBehaviour
{
    private BoxCollider2D boxCol;
    [SerializeField] PlayerData playerData;
    [SerializeField] bool redJewel, greenJewel, blueJewel, goldIdol;
    bool hasBeenCollected;
    private void Awake()
    {
        Gems.allGems++;
        //print("Started with " + Gems.allGems + " gems");
        boxCol = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        string[] collect = { "Red Jewel", "Green Jewel", "Blue Jewel", "Gold Idol" };
        string[] blueGreen = {"Blue Jewel", "Green Jewel" };
        
        if (collision.attachedRigidbody.IsTouchingLayers(LayerMask.GetMask("Red Jewel")))
        {
            playerData.currentScore += 20;
        }
        else if (collision.attachedRigidbody.IsTouchingLayers(LayerMask.GetMask(blueGreen)))
        {
            playerData.currentScore += 10;
        }
        else if (collision.attachedRigidbody.IsTouchingLayers(LayerMask.GetMask("Gold Idol")))
        {
            playerData.currentScore += 50;
        }
        
        if (collision.attachedRigidbody.IsTouchingLayers(LayerMask.GetMask(collect)))
        {Destroy(gameObject);
            
        }    
    }
 
 
    public void OnApplicationQuit()
    {
        Gems.allGems = 0;
        Gems.gemsInRocks = 0;
    }
    public void OnDestroy()
    {
        Gems.allGems--;
        //print("There are "+Gems.allGems + " gem(s) left");
       
        
    }
}
    
   

    
    

