using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallsAdmin : MonoBehaviour
{
    GameObject balls;
    GameObject padle;
    Queue<GameObject> ballinGame = new Queue<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        balls = GameObject.FindGameObjectWithTag("ball");
        padle = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
