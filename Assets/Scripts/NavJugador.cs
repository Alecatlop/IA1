using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;

public class NavJugador : MonoBehaviour
{
    float velocidad;
    GameObject GameobjectwithCharacterController;
    CharacterController controller ;
    GameObject enemigos;
    GameObject gameover;


    void Start()
    {
        controller = this.GetComponent<CharacterController>();
        enemigos = GameObject.FindGameObjectWithTag("Enemy");
        gameover = GameObject.Find("GameOver");
        
        velocidad = 1.0f;
        gameover.SetActive(false);
    }
    void Update()
    {
    }
    void FixedUpdate()
    {

        //Capturo el movimiento en los ejes
        float movimientoV = Input.GetAxis("Horizontal") * 1;
        float movimientoH = Input.GetAxis("Vertical");

        Vector3 anguloTeclas = new Vector3(movimientoV, 0f, movimientoH);
        
        transform.Translate(anguloTeclas * velocidad * Time.deltaTime, Space.World);

        //Genero el vector de movimiento
        //Muevo el jugador
        //transform.position += anguloTeclas * velocidad * Time.deltaTime;
        controller.Move(anguloTeclas * velocidad * Time.deltaTime);
        if (anguloTeclas != null && anguloTeclas != Vector3.zero)
        {
            transform.forward = anguloTeclas * 1;
            transform.rotation = Quaternion.LookRotation(anguloTeclas);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("MazeGeo"))
        {
            Destroy(enemigos);
           
        }

        if (other.CompareTag("Enemy"))
        {
            gameover.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void Return()
    {
        SceneManager.LoadScene("Menu");
    }

}