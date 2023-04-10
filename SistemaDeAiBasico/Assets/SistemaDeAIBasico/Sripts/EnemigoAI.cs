using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemigoAI : MonoBehaviour
{
    public Transform jugador;
    private NavMeshAgent agente;
    private float distanciaMinima = 20.0f; // Distancia mínima para detectar al jugador

    private void Start()
    {
        agente = GetComponent<NavMeshAgent>();
        ObtenerNuevoDestino(); // Obtener un nuevo destino inicial para el enemigo al inicio del juego
    }

    private void Update()
    {
        // Calcular la distancia entre el enemigo y el jugador
        float distanciaJugador = Vector3.Distance(transform.position, jugador.position);

        // Si la distancia es menor que la distancia mínima, el enemigo persigue al jugador
        if (distanciaJugador < distanciaMinima)
        {
            // Realizar un Raycast para detectar al jugador
            RaycastHit hit;
            if (Physics.Raycast(transform.position, jugador.position - transform.position, out hit, distanciaMinima))
            {
                if (hit.collider.tag == "Player")
                {
                    // Si se detecta al jugador, se actualiza la posición del objetivo del NavMeshAgent
                    agente.destination = jugador.position;
                }
            }
        }
        else
        {
            // Si no está persiguiendo al jugador, se mueve de forma autónoma
            if (!agente.hasPath || agente.remainingDistance < 0.5f)
            {
                // Si no tiene un camino o ha llegado a su destino, obtener un nuevo destino aleatorio
                ObtenerNuevoDestino();
            }
        }
    }

    private void ObtenerNuevoDestino()
    {
        // Obtener una posición aleatoria en un radio de 20 unidades del enemigo
        Vector3 destino = Random.insideUnitSphere * 20.0f + transform.position;
        NavMeshHit hit;
        NavMesh.SamplePosition(destino, out hit, 20.0f, NavMesh.AllAreas);

        // Establecer la nueva posición como objetivo del NavMeshAgent
        agente.destination = hit.position;
    }
}


