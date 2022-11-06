using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ConfigureHighScoreList : MonoBehaviour
{  
    [SerializeField] TMP_InputField nameInputField;
    [SerializeField] TextMeshProUGUI nameTypedIn;
    [SerializeField] PlayerData playerData;
    [SerializeField] HighScoreSO highScoreSo;

    private void Update()
    {
        OrganizeHighScores();
    }
    public void OrganizeHighScores()
    {
      nameTypedIn.text = nameInputField.text;
        

        if (playerData.currentScore >= highScoreSo.topPlayerScore)
        {
            highScoreSo.topPlayerScore = playerData.currentScore;
            highScoreSo.topPlayerName = nameInputField.text;
            return;
        }else if (playerData.currentScore >= highScoreSo.secondBestScore)
        {
           highScoreSo.secondBestScore = playerData.currentScore;
            highScoreSo.secondBestName = nameInputField.text;
            return;
        }
        else if (playerData.currentScore >= highScoreSo.thirdBestScore)
        {
            highScoreSo.thirdBestScore = playerData.currentScore;
            highScoreSo.thirdBestName = nameInputField.text;
            return;
        }
        else if (playerData.currentScore >= highScoreSo.fourthBestScore)
        {
            highScoreSo.fourthBestScore = playerData.currentScore;
            highScoreSo.fourthBestName = nameInputField.text;
            return;
        }
        else if (playerData.currentScore >= highScoreSo.fifthBestScore)
        {
            highScoreSo.fifthBestScore = playerData.currentScore;
            highScoreSo.fifthBestName = nameInputField.text;

        }
        

    }

 
}
