using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro : MonoBehaviour
{
    public float velocidadMovimiento = 1.0f; // Velocidad de movimiento del NPC en el eje Z
    public float distanciaRecorrido = 10.0f; // Distancia total que el NPC recorre en el eje Z
    private float tiempoActual = 0.0f; // Tiempo actual transcurrido
    private int direccion = 1; // Dirección de movimiento del NPC (-1 o 1)

    void Update()
    {
        // Mover el NPC en el eje Z en la dirección actual
        transform.Translate(Vector3.forward * velocidadMovimiento * direccion * Time.deltaTime);

        // Actualizar el tiempo actual transcurrido
        tiempoActual += Time.deltaTime;

        // Comprobar si el NPC ha recorrido la distancia total en la dirección actual
        if (Mathf.Abs(transform.position.z) >= distanciaRecorrido / 2)
        {
            // Cambiar la dirección del NPC para que regrese por el mismo eje
            direccion *= -1;
        }

        // Comprobar si ha pasado el tiempo de regreso
        if (tiempoActual >= 10.0f)
        {
            // Reiniciar el tiempo actual
            tiempoActual = 0.0f;

            // Cambiar la dirección del NPC para que se de media vuelta
            direccion *= -1;
        }
    }
}

