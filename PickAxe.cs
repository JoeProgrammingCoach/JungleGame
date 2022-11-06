
using UnityEngine;

public class PickAxe : MonoBehaviour
{

    [SerializeField] GameObject pickAxe;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] LayerMask destroyRock;
    [Tooltip("Is the Player within range of a rock?")][SerializeField] bool isNearRock;

    private void Update()
    {
        DisplayPickAxe();
    }
    void DisplayPickAxe()
    {if (Physics2D.Raycast(transform.position, Vector2.right, 1.5f, destroyRock) ||
         Physics2D.Raycast(transform.position, Vector2.left, 1.5f, destroyRock))
            {isNearRock = true;}
    else { isNearRock = false;}

    if (isNearRock && Input.GetKeyDown(KeyCode.Space)) {
            pickAxe.gameObject.SetActive(true);
        }
    else if (!isNearRock) { pickAxe.gameObject.SetActive(false);}
                
            //if (Input.GetKeyDown(KeyCode.Space))
           

        
    }
}
