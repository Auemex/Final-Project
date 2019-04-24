using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    public static float currentTime = 0f;
    float startingTime = 30f;

    public Text countdownText;

    void Start()
    {
        currentTime = startingTime;
    }

    void Update()
    {
        if(GameController.Time == true)
        {
            currentTime -= 1 * Time.deltaTime;
            countdownText.text = currentTime.ToString("0");

            if (currentTime <= 0)
            {
                currentTime = 0;
            }

        }
    }
}
