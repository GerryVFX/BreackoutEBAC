using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Jugador : MonoBehaviour
{
    public bool whitControl;

    //Variables para el movimiento
    int pad_Speed = 35;
    float limitX = 24.5f;

    //Variables para el control por mouse
    Vector3 mouse2D;
    Vector3 mouse3D;

    public Opciones opcion;

    void Update()
    {
        SelectControl();

        if (whitControl) PadMove(); 
        else             ControlMouse();     
    }

    void PadMove()
    {
        transform.Translate(Input.GetAxis("Horizontal") * Vector3.down * pad_Speed * Time.deltaTime);

        //Limitar el movimiento en x
        var pos = transform.position;
        if (pos.x < -limitX)
        {
            pos.x = -limitX;
        }
        else if (pos.x > limitX)
        {
            pos.x = limitX;
        }
        this.transform.position = pos;
    }

    public void ControlMouse()
    {
        mouse2D = Input.mousePosition;
        mouse2D.z = -Camera.main.transform.position.z;
        mouse3D = Camera.main.ScreenToWorldPoint(mouse2D);
        Vector3 pos = this.transform.position;
        pos.x = mouse3D.x;
        this.transform.position = pos;

        //Limitar el movimiento en x
        if (pos.x < -limitX)
        {
            pos.x = -limitX;
        }
        else if (pos.x > limitX)
        {
            pos.x = limitX;
        }
        this.transform.position = pos;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bola")
        {
            Vector3 direction = collision.contacts[0].point - transform.position;
            direction = direction.normalized;
            collision.rigidbody.velocity = collision.gameObject.GetComponent<Bola>().bola_Speed * direction;
        }
    }

    IEnumerator PowerUp()
    {
        var miTrans = GetComponent<Transform>();
        miTrans.localScale = new Vector3(1, 6, 2);
        limitX = 22.5f;
        yield return new WaitForSeconds(30f);
        miTrans.localScale = new Vector3(1, 4, 2);
        limitX = 24.5f;
    }

    public void SelectControl()
    {
        if (opcion.tipoControl == Opciones.control.mouse)
        {
            whitControl = false;
        }
        else if (opcion.tipoControl == Opciones.control.joystick)
        {
            whitControl = true;
        }
    }
}
