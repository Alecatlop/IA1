using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    GameObject jugador;
    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        jugador = GameObject.Find("Player");
        agent = this.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = jugador.transform.position;
    }
}
