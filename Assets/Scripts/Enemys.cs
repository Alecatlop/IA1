using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;

public class Enemys : MonoBehaviour
{
    GameObject jugador;
    GameObject huir;
    NavMeshAgent agent;
    bool perseguir = true;

    // Start is called before the first frame update
    void Start()
    {
        
        jugador = GameObject.Find("Chomp");
        huir = GameObject.Find("Spawns");
        agent = this.GetComponent<NavMeshAgent>();
       
    }

    // Update is called once per frame
    void Update()
    {
        

        if (perseguir == true)
        {
            agent.destination = jugador.transform.position;
        }
        else agent.destination = huir.transform.position;


    }

    public void Atacar()
    {
        perseguir = true;
    }

    public void Huir()
    {
        perseguir = false;
        //agent.destination = huir.transform.position;
    }

}
