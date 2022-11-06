using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Doorway : MonoBehaviour
{
    Collectables collectables;
    //DestroyRocks destroyRocks;
    [SerializeField] PlayerData playerData;
    Timer timer;

    private void Awake()
    {
        //destroyRocks = FindObjectOfType<DestroyRocks>();
        timer = FindObjectOfType<Timer>();
    }
   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (FindObjectOfType<Collectables>() == null)
        if (Gems.gemsInRocks <= 0 && Gems.allGems <= 0)
        {

            if (collision.gameObject.CompareTag(Tag.Player))
            {
                if (playerData.timeLeft > 0)
                {
                    print(playerData.currentScore);
                    timer.FreezeTimer();
                    float finalScore = Mathf.FloorToInt(playerData.timeLeft * 5);
                    playerData.currentScore += finalScore;
                    UI_Manager.instance.DisplayYouWinCanvas();
                    UI_Manager.instance.ManageWinCanvas();
                }
            }
        }
    }
    public void PlayAgain()
    {
        Time.timeScale = 1;

       
        {

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            // create index system for loading the game
            // via arrays
        }
    }

    
  
}
