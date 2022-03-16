using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public GameObject padle;
    public Padle padle_S;

    // Start is called before the first frame update
    void Start()
    {
        padle   = GameObject.Find("Padle");
        padle_S = padle.GetComponent<Padle>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MandoInput()
    {
        if (Input.GetAxis("Horizontal")>=-1)
        {

        }
    }
}
