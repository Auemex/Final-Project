using UnityEngine;
using System.Collections;

public class BGScroller : MonoBehaviour
{

    public float scrollSpeed;
    public float tileSizeZ;
    private GameController gameControllerObj;

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
        gameControllerObj = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    void Update()
    {
        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeZ);
        transform.position = startPosition + Vector3.forward * newPosition;

        if (gameControllerObj.Win == true)
        {
            if (scrollSpeed >= -15)
            {
                scrollSpeed -= Time.deltaTime;
            }

        }
    }
}