using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.Services.Core;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;

public class NavJugador : MonoBehaviour
{
    float velocidad;
    GameObject GameobjectwithCharacterController;
    CharacterController controller ;
    GameObject[] enemigos;
    public GameObject[] lista;
    public Material rojo;
    public Material blanco;
    public CanvasManager canvas;
    bool comer = false;

    void Start()
    {
        controller = this.GetComponent<CharacterController>();
        velocidad = 1.0f;
        //canvas = this.GetComponent<CanvasManager>();

    }
    void Update()
    {
    }
    void FixedUpdate()
    {

        enemigos = GameObject.FindGameObjectsWithTag("Enemy");
        //Capturo el movimiento en los ejes
        float movimientoV = Input.GetAxis("Horizontal") * 1;
        float movimientoH = Input.GetAxis("Vertical") * 1;

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
            for (int a = 0; a < enemigos.Length; a++)
            {
                Destroy(enemigos[a]);
                Destroy(other.gameObject);
                canvas.Contador();
            }
        }

            if (other.CompareTag("Enemy"))
            {
               if (comer == false)
               {
                    canvas.GameOver();
                    Time.timeScale = 0;
               }
               else
               {
                    canvas.Contador();
                    Destroy(other.gameObject);
               }
            }
        
        if (other.name == "PowerPellet(Clone)")
        {
            StartCoroutine(Cambio());
            comer = true;
            
            Destroy(other.gameObject);

            for (int n = 0; n < lista.Length; n++)
            {
                lista[n].GetComponent<Renderer>().material = rojo;
                lista[n].GetComponent<NavMeshAgent>().speed = 1;
                lista[n].GetComponent<Enemys>().Huir();
            }

            for (int n = 0; n < enemigos.Length; n++)
            {
                enemigos[n].GetComponent<Renderer>().material = rojo;
                enemigos[n].GetComponent<NavMeshAgent>().speed = 1;
                enemigos[n].GetComponent<Enemys>().Huir();
            }
        }
    }

    IEnumerator Cambio()
    {
        
        yield return new WaitForSeconds(10f);

        comer = false;

        for (int t = 0; t < lista.Length; t++)
        {
            lista[t].GetComponent<Renderer>().material = blanco;
            lista[t].GetComponent<NavMeshAgent>().speed = 1;
            lista[t].GetComponent<Enemys>().Atacar();
        }

        for (int t = 0; t < enemigos.Length; t++)
        {
            enemigos[t].GetComponent<Renderer>().material = blanco;
            enemigos[t].GetComponent<NavMeshAgent>().speed = 1;
            enemigos[t].GetComponent<Enemys>().Atacar();
        }

    }

}