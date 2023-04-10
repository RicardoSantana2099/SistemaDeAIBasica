using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FantasmaYellow : MonoBehaviour
{
    private int tocadoCount = 0; // Variable para contar cuántas veces ha sido tocado el objeto

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            tocadoCount++; // Incrementa el contador cada vez que se toca el objeto

            if (tocadoCount >= 2) // Comprueba si se ha tocado el objeto dos veces o más
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
}
