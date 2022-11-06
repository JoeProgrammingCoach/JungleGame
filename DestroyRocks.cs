using UnityEngine;

public class DestroyRocks : MonoBehaviour
{
    [SerializeField] GameObject axe;
    [SerializeField] GameObject jem;
   [SerializeField] PlayerData playerData;
    
    
    private void Awake()
    {
        Gems.gemsInRocks++;
        //print("There are " + Gems.gemsInRocks + " rocks");
       
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (axe.activeInHierarchy)
        {
            Vector3 changeXPos = transform.position + new Vector3(0.5f, 0, 0);
            Instantiate(jem, changeXPos, Quaternion.identity);
            Destroy(gameObject);
           

        }
    }
    private void OnDestroy()
    {
        Gems.gemsInRocks--;
        //print("There are "+Gems.gemsInRocks + " rock left");
    }

}