using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Timer : MonoBehaviour
{
    public float timeLeft;
    public float startingTimeGiven;
    public bool countdownIsOn;
    public TextMeshProUGUI countDownTXT;
    [SerializeField] PlayerData playerData;
    private void Start()
    {
        countdownIsOn = true;
       
    }
    private void Update()
    {
        if (countdownIsOn)
        {
           if ( timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
                ConvertToMinutesandSeconds(timeLeft);
                playerData.timeLeft = timeLeft;

            }
           else { timeLeft = 0;
            countdownIsOn = false;}
        }
    }
    public void ResetTimer()
    {
        timeLeft = startingTimeGiven;
    }
    public void FreezeTimer()
    {
        countdownIsOn = false;
    }


    void ConvertToMinutesandSeconds(float currentTime)
    {
        currentTime += 1;
        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);
        countDownTXT.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }

    private void OnDestroy()
    {
        countDownTXT.text = "";
    }
}
