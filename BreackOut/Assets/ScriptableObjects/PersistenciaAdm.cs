using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistenciaAdm : MonoBehaviour
{
    public List<PuntajePersistente> Guardados;

    public void OnEnable()
    {
        for(int i = 0; i < Guardados.Count; i++)
        {
            var so = Guardados[i];
            so.Cargar();
        }
    }

    public void OnDisable()
    {
        for(int i = 0; i < Guardados.Count; i++)
        {
            var so = Guardados[i];
            so.Guardar();
        }
    }
}
