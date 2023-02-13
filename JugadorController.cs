using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class JugadorController : MonoBehaviour
{
    // Start is called before the first frame update
    
    public AudioSource audioSource;
    public float velocidad;
    private Rigidbody rb;
    //Inicializamos la variable tiempo
    public float tiempo_start;
    public float tiempo_end; 
  
    //Contador
    private int contador;
    //Textos
    public TextMeshProUGUI TextoContador, TextoGanar;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        contador = 0;
        setTextoContador();
        //Inicio el texto de ganar a vacío
        TextoGanar.text = "";
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float movimientoH = Input.GetAxis("Horizontal");
        float movimientoV = Input.GetAxis("Vertical");


        Vector3 movimiento = new Vector3 (movimientoH,0.0f,movimientoV);

        rb.AddForce(movimiento * velocidad);
    }

    void OnTriggerEnter(Collider other)
    {
        GetComponent<AudioSource>().Play();
        other.gameObject.SetActive(false);
        contador = contador + 1;
        setTextoContador();
       

    }

    /*public IEnumerator EscenaVolverMenu()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("Menu");
    }
    */
    void setTextoContador()
{
        TextoContador.text = "Contador: " + contador.ToString();
        if (contador >= 12)
        {
            TextoGanar.text = "¡Ganaste!";
            StartCoroutine(MostrarGanar());
        }
    }

    IEnumerator MostrarGanar()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("MenuPrincipal");
    }
}