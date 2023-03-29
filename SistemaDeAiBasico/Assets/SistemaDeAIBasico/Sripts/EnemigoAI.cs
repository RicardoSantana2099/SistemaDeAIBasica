using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemigoAI : MonoBehaviour
{
    public Transform objetivo;
    public float velocidad;
    public NavMeshAgent IA;

    void Update()
    {
        IA.speed = velocidad;
        IA.SetDestination(objetivo.position);
    }
}
