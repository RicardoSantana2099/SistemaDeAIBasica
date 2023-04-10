using UnityEngine;

public class Puntos : MonoBehaviour
{
    public float velocidadRotacionX = 10f; // Velocidad de rotación en el eje X
    public float velocidadRotacionY = 20f; // Velocidad de rotación en el eje Y

    void Update()
    {
        // Rotar el objeto en su eje Y y eje X a las velocidades especificadas
        transform.Rotate(Vector3.up, velocidadRotacionY * Time.deltaTime);
        transform.Rotate(Vector3.right, velocidadRotacionX * Time.deltaTime);
    }
}


