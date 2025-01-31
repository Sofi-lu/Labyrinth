using UnityEngine;

public class ZonaInvisible : MonoBehaviour
{
    public Vector3 puntoRestriccion = new Vector3(0f, 0f, 0f); // El punto hasta donde se puede mover el jugador

    // Este m�todo se llama cuando otro objeto entra en la zona
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Verificamos si el objeto es el jugador
        {
            // Aqu� puedes poner la l�gica para detener al jugador.
            // Esto puede ser simplemente detener su movimiento o devolverlo a una posici�n v�lida.
            other.transform.position = puntoRestriccion; // Mueve al jugador de vuelta al punto de restricci�n
        }
    }
}

