using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Padle : MonoBehaviour
{
    //Variables para el control por mouse
    public bool specialP;
    Vector3 mouse2D;
    Vector3 mouse3D;

    //Variables del Padle
    [SerializeField]
    int padleLimit = 6;
    [SerializeField]
    float padleSpeed = 50f;
    public bool selectorControl;

    //Variables Bola
    public GameObject ball_Ob;   
    public Ball bola_S;  
    Rigidbody rigid_ball;
    public bool have_Ball;
    public int n_Balls = 1;





    void Start()
    {
        //Variables para encontrar a la bola
        ball_Ob = GameObject.FindGameObjectWithTag("ball");
        bola_S = ball_Ob.GetComponent<Ball>();
        rigid_ball = bola_S.GetComponent<Rigidbody>();
        have_Ball = true;
    }

    
    void Update()
    {

        if (selectorControl) ControlMouse();
       else ControlTeclado();

       ControlDisparo();       
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ball")
        {
            Vector3 direccion = collision.contacts[0].point - transform.position;
            direccion = direccion.normalized;
            collision.rigidbody.velocity = collision.gameObject.GetComponent<Ball>().ballSpeed * direccion;
        }
    }

    public void ControlMouse()
    {
        mouse2D   = Input.mousePosition;
        mouse2D.z = -Camera.main.transform.position.z;
        mouse3D   = Camera.main.ScreenToWorldPoint(mouse2D);

        Vector3 pos = this.transform.position;
        pos.x = mouse3D.x;
        if (pos.x < -padleLimit) pos.x = -padleLimit;
        else if (pos.x > padleLimit) pos.x = padleLimit;
        this.transform.position = pos;
    }

    public void ControlTeclado()
    {       
        transform.Translate(Input.GetAxis("Horizontal")* Vector3.down * padleSpeed * Time.deltaTime);

        Vector3 pos = this.transform.position;  
        if (pos.x < -padleLimit) pos.x = -padleLimit;
        else if (pos.x > padleLimit) pos.x = padleLimit;
        this.transform.position = pos;
    }

    public void ControlDisparo()
    {
        if (Input.GetKey(KeyCode.Space) && have_Ball)
        {
            have_Ball = false;
            ball_Ob.transform.SetParent(null);
            rigid_ball.velocity = bola_S.ballSpeed * Vector3.up;
        }
    }


    
}
