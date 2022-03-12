using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Ball : MonoBehaviour
{
    bool isGameStarted = false;
    public float ballSpeed = 25f;

    Vector3 ultimaPosición = Vector3.zero;
    Vector3 direccion = Vector3.zero;
    new Rigidbody rigidbody;
    private Limites limites;
    public UnityEvent bolaDestrida;

    public void Awake()
    {
        limites = GetComponent<Limites>();
    }


    // Start is called before the first frame update
    void Start()
    {
        Vector3 inicial = GameObject.FindGameObjectWithTag("Player").transform.position;
        inicial.y +=  1.6f;
        this.transform.position = inicial;
        this.transform.SetParent(GameObject.FindGameObjectWithTag("Player").transform);
        rigidbody = this.gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (limites.salioAbajo)
        {
            bolaDestrida.Invoke();
            Destroy(this.gameObject);
        }
        if (limites.salioArriba)
        {
            direccion = transform.position - ultimaPosición;
            print("Toco la parte superior");
            direccion.y *= -1;
            direccion = direccion.normalized;
            rigidbody.velocity = ballSpeed * direccion;
            limites.salioArriba = false;
            limites.enabled = false;
            Invoke("ActivarLimites", 0.1f);
        }
        if (limites.salioDerecha)
        {
            direccion = transform.position - ultimaPosición;
            print("Toco la parte derecha");
            direccion.x *= -1;
            direccion = direccion.normalized;
            rigidbody.velocity = ballSpeed * direccion;
            limites.salioDerecha = false;
            limites.enabled = false;
            Invoke("ActivarLimites", 0.1f);
        }
        if (limites.salioIzquierda)
        {
            direccion = transform.position - ultimaPosición;
            print("Toco la parte superior");
            direccion.x *= -1;
            direccion = direccion.normalized;
            rigidbody.velocity = ballSpeed * direccion;
            limites.salioIzquierda = false;
            limites.enabled = false;
            Invoke("ActivarLimites", 0.1f);
        }

        //Mecanica para disparo inicial de la bola
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<Padle>().selectorControl) DisparoMouse();
        else DisparoMando();
       
    }

    public void FixedUpdate()
    {
        ultimaPosición = transform.position;
    }

    public void LateUpdate()
    {
        if (direccion != Vector3.zero) direccion = Vector3.zero;
    }

    public void DisparoMando()
    {
        if (Input.GetKey(KeyCode.Space)||Input.GetButton("Submit"))
        {
            if (!isGameStarted)
            {
                isGameStarted = true;
                this.transform.SetParent(null);
                GetComponent<Rigidbody>().velocity = ballSpeed * Vector3.up;
            }
        }
    }

    public void DisparoMouse()
    {
        if (Input.GetMouseButton(button:1))
        {
            if (!isGameStarted)
            {
                isGameStarted = true;
                this.transform.SetParent(null);
                GetComponent<Rigidbody>().velocity = ballSpeed * Vector3.up;
            }
        }
    }

    public void ActivarLimites()
    {
        limites.enabled=true;
    }

    

}
