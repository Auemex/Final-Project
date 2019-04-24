using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarMover : MonoBehaviour
{

    private ParticleSystem ps;
    private float hSliderValue = 1.0F;
    private GameController gameControllerObj;


    void Start()
    {
        ps = GetComponent<ParticleSystem>();
        gameControllerObj = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    void Update()
    {
        var main = ps.main;
        main.simulationSpeed = hSliderValue;

        if (gameControllerObj.Win == true)
        {
            if (hSliderValue <= 15)
            {
                hSliderValue += Time.deltaTime;
            }
        }
    }
}