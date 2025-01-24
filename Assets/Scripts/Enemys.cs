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
    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        
        jugador = GameObject.Find("Chomp");
        agent = this.GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {
       
        agent.destination = jugador.transform.position;
    }

}
