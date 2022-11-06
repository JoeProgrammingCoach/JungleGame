using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetCurrentScore : MonoBehaviour
{
    [SerializeField] PlayerData playerData;

    private void OnApplicationQuit()
    {
        playerData.currentScore = 0;
       
    }
}
