using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FantasmaRed : MonoBehaviour
{
    private int tocadoCount = 0; // Variable para contar cu�ntas veces ha sido tocado el objeto

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            tocadoCount++; // Incrementa el contador cada vez que se toca el objeto

            if (tocadoCount >= 5) // Comprueba si se ha tocado el objeto cinco veces o m�s
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
}

