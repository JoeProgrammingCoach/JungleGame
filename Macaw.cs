
using UnityEngine;

public class Macaw : MonoBehaviour
{
    [SerializeField] private float flightSpeed;
    [SerializeField] private bool flyRight, flyLeft, swoop;
    [SerializeField] private bool hasFlightRestrictions;
    [SerializeField] private float minXFlightPath, maxXFlightPath;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private Transform player;
    //[SerializeField] private float distanceFromPlayer = 4f;
   
    void Update()
    {
        MoveBird(); Swoop(); ;
    }
    private void LateUpdate()
    {
        FlightPath();
    }
    void FlightPath()
    {
        if (hasFlightRestrictions) // set minx and max for horizontal movement of macaws
        {
            Vector3 macaw = transform.position;
            if (macaw.x > maxXFlightPath)
            {
                if (flyRight)
                {
                    flightSpeed *= -1; // reverse direction
                    transform.localScale = new Vector3(-2, 2, 2);

                }
                if (flyLeft)
                {

                    flightSpeed *= -1;// reverse direction
                }
                transform.position = macaw;
            }
            else if (macaw.x < minXFlightPath)
            {
                if (flyRight)
                {
                    flightSpeed *= -1f;
                    transform.localScale = new Vector3(2, 2, 2);
                }
                if (flyLeft)
                { 
                    flightSpeed *= -1f;
                }
            }
        }
    }
        void MoveBird()
        {
            if (flyRight)
            {
                transform.position += Vector3.right * flightSpeed * Time.deltaTime;
                
            }
            if (flyLeft)
            {
                transform.position += Vector3.left * flightSpeed * Time.deltaTime;
                transform.localScale = new Vector3(-2, 2, 2);
            }
        }
    
    void Swoop()
    {
        if (Physics2D.Raycast(transform.position, Vector2.down, Mathf.Infinity, playerLayer))
        {

            
            //if (Vector2.Distance(transform.position, player.position) > distanceFromPlayer)
            {
                /*Vector3 flightHeight = transform.position;
                flightHeight.y += 1f;
                transform.position = flightHeight;
                player.position = transform.position;*/
            }
        }
    }
}
