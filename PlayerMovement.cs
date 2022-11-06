using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerMovement : MonoBehaviour
{
   [SerializeField] PlatformEffector2D platEff2D;
    public PlayerData playerData;
    [HideInInspector] public Animator animator;
    public Rigidbody2D rb; BoxCollider2D playerBody;
    public int moveSpeed = 20;  public float jumpForce = 10;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] LayerMask platformLayer;
    public float climbSpeed = 40f;
    public bool onLadder = false;
    public LayerMask elephantLayer;
    public LayerMask tusksLayer;
    [SerializeField] private bool playerDead = false;
    CircleCollider2D pickAxe;
    private Timer timer;
     void Awake()
    {
        playerData.currentScore = 0;
        timer = FindObjectOfType<Timer>();
        rb = GetComponent<Rigidbody2D>();
        playerBody = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        pickAxe = GetComponentInChildren<CircleCollider2D>();
    }

    void Update()
    {
        MovePlayer(); CheckIfMoving();
       FallDownThroughPlatform();   ClimbLadder();
    }

    void ClimbLadder()
    {
        {
            if (Physics2D.Raycast(transform.position, Vector3.down, 2f, LayerMask.GetMask("Ladder")))
            {
                 Vector2 currentVelocity = rb.velocity;
                // these 3 lines of code stop the player from falling
                rb.isKinematic = true; onLadder = true;
                currentVelocity = new Vector2( 0,0 );
                rb.velocity = currentVelocity;
            }
            else { rb.isKinematic = false; onLadder = false; }  
        }
        if (onLadder)
        {
            
            if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.Translate(new Vector2(0, 1) * climbSpeed * Time.deltaTime);
                platEff2D.rotationalOffset = 0f;
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.Translate(new Vector2 (0, -1) *climbSpeed * Time.deltaTime);
                platEff2D.rotationalOffset = 180f;
            }
        }
        else { onLadder = false; }
    }
    public void LoseGame()
    { // called by animation event in dead state 
      StartCoroutine(WaitAfterDeath());
        /*SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
       UI_Manager.instance.ClearCanvases();
        timer.ResetTimer(); */
    }
    public IEnumerator WaitAfterDeath()
    {
        yield return new WaitForSeconds(1.2f);
        Time.timeScale = 0;
    }
    void MovePlayer()
    { if (playerDead) { return; }
        if (!playerDead)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.position += Vector3.right * moveSpeed * Time.deltaTime;
                animator.Play("Run");
                ChangeFacingDirection();
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.position += Vector3.left * moveSpeed * Time.deltaTime;
                animator.Play("Run");
                ChangeFacingDirection();
            }
            else if (onLadder) { animator.Play("Idle");return; }
            else if (Input.GetKeyDown(KeyCode.UpArrow) && !onLadder)
            {
                string[] LayersForJumping = { "Platform", "Ground", "Elephant" };
            if (Physics2D.Raycast(transform.position, Vector3.down, 2f, LayerMask.GetMask(LayersForJumping)))
                    { 
                      rb.velocity = Vector3.up * jumpForce;
                    animator.Play("Jump");
                        }
          
            }
        }
    }
   void FallDownThroughPlatform()
    {
        if (playerBody.IsTouchingLayers(LayerMask.GetMask("Platform"))) 
        {
            //print("I am on the platform");
            if (Input.GetKey(KeyCode.DownArrow))
            { platEff2D.rotationalOffset = 180f; }// player can go through platform at bottom of ladder
            if (Input.GetKey(KeyCode.UpArrow)){
                platEff2D.rotationalOffset = 0f; } // player can go through platform at top of ladder
          
        } 
    } 


   
    public void ChangeFacingDirection()
    {
        Vector3 tempV3 = transform.localScale;
        
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            tempV3.x = Mathf.Abs(tempV3.x) * -1;
        } 
        if (Input.GetKey(KeyCode.RightArrow)) 
        {
            tempV3.x =  Mathf.Abs(tempV3.x) * 1;
        
        }
       transform.localScale = tempV3;
    }
    void CheckIfMoving()
    {
        if (!Input.anyKey && !playerDead)
        {
            animator.Play("Idle");
        } 
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (playerBody.IsTouchingLayers(tusksLayer))
        {
            animator.Play("Dead");  playerDead = true; 
            print("hit the tusks");
            UI_Manager.instance.DisplayYouLoseCanvas(); 
            timer.FreezeTimer();
           
        }
    }
    
}

