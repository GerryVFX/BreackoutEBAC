using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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


        GeneraBolla();
    }

    public IEnumerator SpecialPadle()
    {
        gameObject.transform.localScale = new Vector3(1, 6, 2);
        yield return new WaitForSeconds(3);
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

    public void ControlTeclado()
    {
        //if (Input.GetKey(KeyCode.RightArrow))
        //{
        //    transform.Translate(Vector3.down * padleSpeed * Time.deltaTime);
        //}
        //if (Input.GetKey(KeyCode.LeftArrow))
        //{
        //    transform.Translate(Vector3.up * padleSpeed * Time.deltaTime);
        //}

        transform.Translate(Input.GetAxis("Horizontal")* Vector3.down * padleSpeed * Time.deltaTime);

        Vector3 pos = this.transform.position;  
        if (pos.x < -padleLimit) pos.x = -padleLimit;
        else if (pos.x > padleLimit) pos.x = padleLimit;
        this.transform.position = pos;
    }

    public void GeneraBolla()
    {
        
        if (GameObject.FindGameObjectWithTag("ball")==null)
        {
            Instantiate(bola);
        }
    }
}
