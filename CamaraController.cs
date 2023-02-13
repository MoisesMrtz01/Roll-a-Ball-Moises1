using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraController : MonoBehaviour
{
    //Referencia al nuestro Jugador
    public GameObject Jugador;

    //Para registrar la diferencia entre la posición de la cámara y la del Jugador
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        //diferencia entre la posición de la cámara y la del Jugador
        offset = transform.position - Jugador.transform.position;

    }

    // Update is called once per frame
    void LateUpdate()
    {
        //Actualizo la posición de la cámara
        transform.position = Jugador.transform.position + offset;

    }
}
