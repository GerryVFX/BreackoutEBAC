using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    bool isGameStarted = false;
    public float ballSpeed = 25f;


    // Start is called before the first frame update
    void Start()
    {
        Vector3 inicial = GameObject.FindGameObjectWithTag("Player").transform.position;
        inicial.y +=  1;
        this.transform.position = inicial;
        this.transform.SetParent(GameObject.FindGameObjectWithTag("Player").transform);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<Padle>().selectorControl) DisparoMouse();
        else DisparoMando();
       
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Block"|| other.tag=="Finish")
        {
            Destroy(this.gameObject);
        }
    }

}
