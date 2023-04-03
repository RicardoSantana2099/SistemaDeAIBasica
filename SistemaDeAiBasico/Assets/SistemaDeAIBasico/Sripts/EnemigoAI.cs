using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemigoAI : MonoBehaviour
{
    public Transform objetivo;
    private NavMeshAgent agente;

    private void Start()
    {
        agente = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        agente.destination = objetivo.position;
    }
}
