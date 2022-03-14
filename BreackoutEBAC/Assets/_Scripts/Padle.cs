using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Padle : MonoBehaviour
{
    //Variables para el control por mouse
    public bool specialP;
    Vector3 mouse2D;
    Vector3 mouse3D;
    [SerializeField] int padleLimit = 24;

    public bool selectorControl;
    public GameObject bola;

    //Variables para control por teclado
    [SerializeField] float padleSpeed = 50f;
    new Transform  transform;

    void Start()
    {
        transform = this.gameObject.transform;
    }

    
    void Update()
    {
        if (selectorControl) ControlMouse();
        else ControlTeclado();



        if (specialP)
        {
                StartCoroutine(SpecialPadle());
                specialP = false;
        }


        //GeneraBolla();
    }

    public IEnumerator SpecialPadle()
    {
        gameObject.transform.localScale = new Vector3(1, 6, 2);
        yield return new WaitForSeconds(10);
        gameObject.transform.localScale = new Vector3(1, 4, 2);
        yield return null;        
    }

    public void ControlMouse()
    {
        mouse2D = Input.mousePosition;
        mouse2D.z = -Camera.main.transform.position.z;
        mouse3D = Camera.main.ScreenToWorldPoint(mouse2D);

        Vector3 pos = this.transform.position;
        pos.x = mouse3D.x;
        if (pos.x < -padleLimit) pos.x = -padleLimit;
        else if (pos.x > padleLimit) pos.x = padleLimit;
        this.transform.position = pos;
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

    

    public void ControlTeclado()
    {
        
        transform.Translate(Input.GetAxis("Horizontal")* Vector3.down * padleSpeed * Time.deltaTime);

        Vector3 pos = this.transform.position;  
        if (pos.x < -padleLimit) pos.x = -padleLimit;
        else if (pos.x > padleLimit) pos.x = padleLimit;
        this.transform.position = pos;
    }

    
}
