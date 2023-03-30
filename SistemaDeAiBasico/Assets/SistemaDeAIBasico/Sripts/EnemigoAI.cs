using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemigoAI : MonoBehaviour
{
    public Transform objetivo;
    public float velocidad;
    public float alturaSalto = 2f;
    public float fuerzaSalto = 5f;
    public NavMeshAgent IA;
    private bool enSuelo;

    void Update()
    {
        IA.speed = velocidad;
        IA.SetDestination(objetivo.position);

        if (enSuelo && Input.GetKeyDown(KeyCode.Space))
        {
            enSuelo = false;
            IA.velocity += Vector3.up * Mathf.Sqrt(alturaSalto * -2f * Physics.gravity.y * fuerzaSalto);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            enSuelo = true;
        }
    }
}
