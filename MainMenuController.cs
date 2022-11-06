using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
   public void OnPlayClick()
    {
        SceneManager.LoadScene(3);
    }

    
   public void OnTrophyClick()
    {
        SceneManager.LoadScene(1);
    }
    public void OnInfoClick()
    {
        SceneManager.LoadScene(2);
    }
}
