using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Padle : MonoBehaviour
{
    public bool specialP;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (specialP) StartCoroutine(SpecialPadle());
        if (specialP)
        {
            specialP = false;
        }
       
    }

    public IEnumerator SpecialPadle()
    {
        gameObject.transform.localScale = new Vector3(1, 6, 2);
        yield return new WaitForSeconds(3);
        gameObject.transform.localScale = new Vector3(1, 4, 2);
        yield return null;        
    }
}
