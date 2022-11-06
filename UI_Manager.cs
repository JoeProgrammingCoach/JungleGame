using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class UI_Manager : MonoBehaviour
{
    public static UI_Manager instance;

    public TextMeshProUGUI scoreTxt;
    public TextMeshProUGUI highScoreTxt; // for lose Canvas
    public TextMeshProUGUI yourFinalScoreTxt; // for lose Canvas
    public Canvas loseCanvas, winCanvas, UICanvas;
    public TextMeshProUGUI winHighScoreTxt;
    public TextMeshProUGUI winFinalScoreTxt;
    public TextMeshProUGUI livesCountText;
    public PlayerData playerData;
    public TMP_InputField inputNameField;
  
    void Awake()
    {
        Time.timeScale = 1;
        
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
            if (UICanvas != null) return;
            if (loseCanvas != null) return;
            DontDestroyOnLoad(gameObject);
           DontDestroyOnLoad(UICanvas);
            DontDestroyOnLoad(loseCanvas);
            DontDestroyOnLoad(winCanvas);
        }

    }
    private void Update()
    {
        ManageCurrentScores();
        ManageLoseScores();
    }

    public void DisplayYouLoseCanvas()
    {
        winCanvas.enabled = false;
        loseCanvas.enabled = true;

        
    }
    public void DisplayYouWinCanvas()
    {
        loseCanvas.enabled = false;
        winCanvas.enabled = true;
        Time.timeScale = 0;
    }
    public void ClearCanvases()
    {
        loseCanvas.enabled = false;
        winCanvas.enabled = false;
        Time.timeScale = 1;
    }
    public void ManageCurrentScores()
    {
        scoreTxt.text = "Score: " + playerData.currentScore;
     if (playerData.currentScore >= playerData.highScore)
        {
            playerData.highScore = playerData.currentScore;

        }
        highScoreTxt.text = "High Score: " + playerData.highScore;
    } 
    public void ManageLoseScores()
    {
        yourFinalScoreTxt.text = "Your final score: " + playerData.currentScore;
        
        
    }
    public void ManageWinCanvas()
    {
        if (playerData.currentScore > playerData.highScore)
        {
            playerData.highScore = playerData.currentScore;
        }
        winFinalScoreTxt.text = "Final Score: " + playerData.currentScore;
        winHighScoreTxt.text = "High Score: " + playerData.highScore;
    }

    


}
